using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarboUiComponent
{

	/// <summary>
	/// A drag-and-droppable button list by Carbon.
	/// </summary>
	public class Carbolist : UserControl
	{

		/// ***************************** CONSTUCTOR ********************************

		/// <summary>
		/// Creates a new Carbolist instance.
		/// </summary>
		/// <param name="sampleButton">A sample button object where all list-items will copy its properties from.</param>
		/// <param name="color">The background color of this list (default: pure black).</param>
		/// <param name="onSelect">A callback when an list-item is selected. It must contain one argument: CarbolistItem.</param>
		public Carbolist(Button sampleButton = null, object color = null, Action<CarbolistItem> onSelect = null)
		{
			if (color == null)
				color = rg.b(0x000000);

			if (sampleButton == null)
				sampleButton = new Button();

			BackColor = (Color)color;
			Width = sampleButton.Width;
			Height = 0;
			Location = sampleButton.Location;
			CanDeselect = true;
			OnSelect = onSelect;

			itemFont = sampleButton.Font;
			itemColor = sampleButton.BackColor;
			itemSize = sampleButton.Size;

			if (sampleButton.Parent != null)
				sampleButton.Controls.Remove(sampleButton);

			if (!sampleButton.IsDisposed)
				sampleButton.Dispose();

			Items = new List<CarbolistItem>();
		}

		/// ************************** PUBLIC PROPERTIES ****************************

		/// <summary>A callback when an list-item is selected. It must contain one argument: CarbolistItem.</summary>
		public Action<CarbolistItem> OnSelect { get; set; }

		/// <summary>Whether user can deselect an item by clicking on it.</summary>
		public bool CanDeselect { get; set; }

		/// ************************* PRIVATE PROPERTIES ****************************

		/// <summary>[ReadOnly] The list-item selected by user.</summary>
		public CarbolistItem SelectedItem { get; protected set; }

		/// <summary>[ReadOnly] The collections of all list-items.</summary>
		public List<CarbolistItem> Items { get; protected set; }

		/// <summary>[ReadOnly] Whether any list-item has been dragged since the most recent add or remove action.</summary>
		public bool IsDragged { get; protected set; }

		protected CarbolistItem draggingItem;
		protected Point draggingStartPoint;
		protected Color itemColor;
		protected Font itemFont;
		protected Size itemSize;
		protected bool isDraggingItem;

		/// *************************** PUBLIC METHODS ******************************

		/// <summary>
		/// Adds a new list-item into the Carbolist. Also returns that new item.
		/// </summary>
		/// <param name="title">The title that the item will display.</param>
		/// <param name="data">The data provider linked with the item.</param>
		public CarbolistItem AddItem(string title, object data = null)
		{
			if (title == null)
				throw new Exception("Argument title must be non-null.");

			Color backgroundColor = Items.Count % 2 == 0
				? SampleButtonColors.BlueDark
				: SampleButtonColors.BlueLight;

			CarbolistItem item = new CarbolistItem(
				title,
				backgroundColor,
				SampleButtonColors.BlueSelected,
				itemSize,
				new Point(0, Items.Count * itemSize.Height),
				itemFont,
				data,
				this);

			Controls.Add(item);

			item.Background.Click += OnCarbolistItemClick;
			item.Background.MouseDown += OnCarbolistItemMouseDown;

			Items.Add(item);
			Height += item.Height;

			IsDragged = false;

			return item;
		}

		/// <summary>
		/// Adds a group of list-items into the Carbolist.
		/// </summary>
		/// <param name="titles">The titles of the new items.</param>
		/// <param name="data">The linked data of the new items.</param>
		public List<CarbolistItem> AddItems(List<string> titles, IList data = null)
		{
			if (titles == null)
				throw new Exception("Argument titles must be non-null.");

			List<CarbolistItem> output = new List<CarbolistItem>();

			if (data == null)
			{
				for (int i = 0, l = titles.Count; i < l; i++)
				{
					output.Add(AddItem(titles[i]));
				}

				return output;
			}

			if (titles.Count != data.Count)
				throw new Exception("The counts of titles and data must match.");

			for (int i = 0, l = titles.Count; i < l; i++)
			{
				output.Add(AddItem(titles[i], data[i]));
			}

			return output;
		}

		/// <summary>
		/// Adds a group of list-items from a data source.
		/// The titles of all items will automatically be set to a given key of a property of data.
		/// </summary>
		/// <param name="data">The data source.</param>
		/// <param name="key">The key of a string property of data that provides the titles of new items.</param>
		public List<CarbolistItem> AddItemsBy(string key, IList data)
		{
			if (data == null)
				throw new Exception("Argument data must be non-null.");

			if (data.Count == 0)
				return new List<CarbolistItem>();

			try
			{
				return AddItems(data.Cast<object>().Select(x => x.GetType().GetProperty(key).GetValue(x).ToString()).ToList(), data);
			}
			catch (Exception)
			{
				throw new Exception($"Key \"{key}\" not found in data type ({data[0].GetType().ToString()}).");
			}
		}

		/// <summary>
		/// Removes a list-item from the Carbolist.
		/// </summary>
		/// <param name="item"></param>
		public void RemoveItem(CarbolistItem item)
		{
			if (item == null)
				throw new Exception("Argument item must be non-null");

			if (item == SelectedItem)
				SelectedItem = null;

			Controls.Remove(item);
			Items.Remove(item);

			item.Background.Click -= OnCarbolistItemClick;
			item.Background.MouseDown -= OnCarbolistItemMouseDown;
			item.Dispose();

			Height -= itemSize.Height;

			IsDragged = false;

			SortItems();

			if (!CanDeselect)
				SelectItem(Items[Items.Count - 1]);
		}

		/// <summary>
		/// Removes all list-items from the Carbolist.
		/// </summary>
		public void RemoveAllItems()
		{
			DeselectItem();

			Controls.Clear();

			foreach (CarbolistItem p in Items)
			{
				p.Background.Click -= OnCarbolistItemClick;
				p.Background.MouseDown -= OnCarbolistItemMouseDown;
				p.Dispose();
			}

			Items.Clear();

			Height = 0;

			SortItems();
		}

		/// <summary>
		/// Selects a list-item. If it's already selected, deselects it.
		/// </summary>
		/// <param name="item"></param>
		public CarbolistItem SelectItem(CarbolistItem item)
		{
			if (!Items.Contains(item))
				throw new Exception("Item not found in this Carbolist.");

			OnCarbolistItemClick(item.Background, null);

			return item;
		}

		/// <summary>
		/// If any list-item is selected, deselects it.
		/// </summary>
		public void DeselectItem()
		{
			if (SelectedItem == null)
				return;

			SelectedItem.Selected = false;
			SelectedItem = null;
		}

		/// *************************** PRIVATE METHODS *****************************

		protected void SortItems()
		{
			Items = Items.OrderBy(x => x.Top).ToList();

			for (int i = 0, l = Items.Count; i < l; i++)
			{
				if (Items[i] == draggingItem)
					continue;

				Items[i].Top = i * itemSize.Height;

				if (draggingItem == null)
					Items[i].ChangeBackColor(
						i % 2 == 0
						? SampleButtonColors.BlueDark
						: SampleButtonColors.BlueLight);
			}
		}

		/// ******************************* EVENTS **********************************

		protected void OnCarbolistItemMouseDown(object target, MouseEventArgs e)
		{
			// drag-and-drop preparations

			// drag-and-drop only when the list has more than 1 item.
			if (Items.Count <= 1)
				return;

			if (e.Button != MouseButtons.Left)
				return;

			Button button = target as Button;

			draggingItem = button.Parent as CarbolistItem;
			draggingStartPoint = e.Location;

			button.MouseMove += OnDraggingItemMouseMove;
			button.MouseUp += OnDraggingItemMouseUp;
		}

		protected void OnDraggingItemMouseMove(object target, MouseEventArgs e)
		{
			// user needs to move the mouse for 10 pixels to start dragging
			if (!isDraggingItem)
			{
				// distance <= 10
				if (Math.Sqrt(Math.Pow(e.X - draggingStartPoint.X, 2) + Math.Pow(e.Y - draggingStartPoint.Y, 2)) <= 10)
					return;

				isDraggingItem = true;
				draggingItem.BringToFront();

				draggingItem.Background.Click -= OnCarbolistItemClick;
			}

			int topLimit = -1;
			int bottomLimit = Height - itemSize.Height + 1;

			draggingItem.Top = Math.Max(Math.Min(e.Y + draggingItem.Top - draggingStartPoint.Y, bottomLimit), topLimit);

			SortItems();
		}

		protected void OnDraggingItemMouseUp(object target, MouseEventArgs e)
		{
			Button button = target as Button;

			button.MouseMove -= OnDraggingItemMouseMove;
			button.MouseUp -= OnDraggingItemMouseUp;

			// restore click event
			if (isDraggingItem)
				button.Click += OnCarbolistItemClick;

			draggingItem = null;
			isDraggingItem = false;

			SortItems();

			if (!IsDragged)
				IsDragged = true;
		}

		protected void OnCarbolistItemClick(object target, EventArgs e)
		{
			CarbolistItem item = ((Button)target).Parent as CarbolistItem;

			if (item == SelectedItem)
			{
				if (CanDeselect)
				{
					item.Selected = false;
					SelectedItem = null;
				}
			}
			else
			{
				if (SelectedItem != null)
					SelectedItem.Selected = false;

				item.Selected = true;
				SelectedItem = item;
			}

			// callback event listener
			OnSelect?.Invoke(item);
		}

	}

}
