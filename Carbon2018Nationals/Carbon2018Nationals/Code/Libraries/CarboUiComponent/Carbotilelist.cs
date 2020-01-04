using Carboutil;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarboUiComponent
{

	public class Carbotilelist : Carbolist
	{

		#region ############################# CONSTRUCTOR ###############################

		public Carbotilelist(CarbolistTheme theme = default, Button sampleButton = null, Action<CarbolistItem> onItemSelect = null)
			: base(theme, sampleButton, onItemSelect)
		{
			itemSize = sampleButton.MinimumSize;
			ItemPadding = sampleButton.Padding.Left;
			ItemMargin = sampleButton.Padding.Top;

			currentX = currentY = currentDefaultX = currentDefaultY = ItemMargin;
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public int ItemPadding { get; set; }

		public int ItemMargin { get; set; }

		override public int Width
		{
			get => base.Width;

			set
			{
				base.Width = value;
				
				ItemContainer.Width = value;

				ScrollBar.Left = value - ScrollBar.Width;

				UpdateItemLocations();
			}
		}

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		protected int currentX;
		protected int currentY;
		protected int currentDefaultX;
		protected int currentDefaultY;

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		/// <summary>
		/// Adds a new list-item into the Carbotilelist. Also returns that new item.
		/// </summary>
		/// <param name="text">The title that the item will display.</param>
		/// <param name="tag">The data provider linked with the item.</param>
		/// <param name="scrollItemIntoView">Automatically scroll the new item into view.</param>
		override public CarbolistItem AddItem(string text, Image icon = null, object tag = null, bool scrollItemIntoView = true)
		{
			if (text == null)
				throw new Exception("Argument text must be non-null.");

			Color backColor = theme.FirstItemBackColor;

			CarbolistItem item = new CarbolistItem(Items.Count, backColor, theme.SelectedItemBackColor, tag, this)
			{
				FlatStyle = FlatStyle.Flat,
				Font = itemFont,
				Text = text,
				ForeColor = theme.ItemForeColor,
			};

			if (itemSize.Width > 0 && itemSize.Height > 0)
			{
				item.Size = itemSize;
			}
			else
			{
				Size textSize = TextRenderer.MeasureText(text, item.Font);

				if (itemSize.Width == 0)
					item.Width = textSize.Width + (item.Font.Size * 1.3).Round();
				else
					item.Width = itemSize.Width;

				if (itemSize.Height == 0)
					item.Height = itemSize.Height = Items.Count > 0 ? Items[0].Height : textSize.Height + (item.Font.Size / 2).Round();
				else
					item.Height = itemSize.Height;
			}

			item.Location = new Point(currentX, currentY);
			
			if (item.Right > Width - ItemMargin)
			{
				item.Left = ItemMargin;
				item.Top = (currentY += item.Height + ItemPadding);
			}

			currentX = item.Right + ItemPadding;
			ItemContainer.Height = item.Bottom + ItemMargin;
			ScrollBar.Total = item.Bottom + ItemMargin + (LeftMenuButton.Text == "" ? 0 : LeftMenuButton.Height);

			if (ItemTextAlign != ContentAlignment.MiddleCenter)
				item.TextAlign = ItemTextAlign;

			if (icon != null)
				item.SetIcon(icon);

			if (itemMenuButtonText != "")
				item.RegisterMenuButton(itemMenuButtonText, itemMenuButtonBackColor, itemMenuButtonForeColor, null, ItemMenuButtonSize);

			ItemContainer.Controls.Add(item);

			Items.Add(item);

			if (scrollItemIntoView)
				ScrollItemIntoView(item);

			IsDragged = false;

			item.MouseEnter += OnMouseEnter;
			item.MouseLeave += OnMouseLeave;
			item.Click += OnItemClick;
			item.MouseDown += OnCarbolistItemMouseDown;
			item.MenuButtonClick += OnCarbolistItemMenuButtonClick;

			UpdateDefaultItemLocations();

			return item;
		}

		override public CarbolistItem AddDefaultItem(string text, object tag = null)
		{
			if (text == null)
				throw new Exception("Argument title must be non-null.");

			CarbolistItem item = new CarbolistItem(DefaultItems.Count, theme.DefaultItemBackColor, theme.SelectedItemBackColor, tag, this)
			{
				FlatStyle = FlatStyle.Flat,
				Font = new Font(itemFont.FontFamily, itemFont.Size - 1, FontStyle.Italic),
				Text = text,
				ForeColor = theme.DefaultItemForeColor,
			};

			if (itemSize.Width > 0 && itemSize.Height > 0)
			{
				item.Size = itemSize;
			}
			else
			{
				Size textSize = TextRenderer.MeasureText(text, item.Font);

				if (itemSize.Width == 0)
					item.Width = textSize.Width + (item.Font.Size * 1.3).Round();
				else
					item.Width = itemSize.Width;

				if (itemSize.Height == 0)
					item.Height = itemSize.Height = Items.Count > 0 ? Items[0].Height : textSize.Height + (item.Font.Size / 2).Round();
				else
					item.Height = itemSize.Height;
			}

			item.Location = new Point(currentDefaultX, currentDefaultY);

			if (item.Right > Width - ItemMargin)
			{
				item.Left = ItemMargin;
				item.Top = (currentDefaultY += item.Height + ItemPadding);
			}

			currentDefaultX = item.Right + ItemPadding;
			ItemContainer.Height = item.Bottom + ItemMargin;
			ScrollBar.Total = item.Bottom + ItemMargin + (LeftMenuButton.Text == "" ? 0 : LeftMenuButton.Height);

			DefaultItems.Add(item);

			ItemContainer.Controls.Add(item);

			IsDragged = false;

			item.MouseEnter += OnMouseEnter;
			item.MouseLeave += OnMouseLeave;
			item.Click += OnDefaultItemClick;

			return item;
		}

		/// <summary>
		/// Removes a list-item from the Carbolist.
		/// </summary>
		/// <param name="item">The CarbolistItem to remove.</param>
		override public void RemoveItem(CarbolistItem item)
		{
			if (item == null)
				throw new Exception("Argument item must be non-null");

			if (item == SelectedItem)
				DeselectItem();

			ItemContainer.Controls.Remove(item);
			Items.Remove(item);

			item.MouseEnter -= OnMouseEnter;
			item.MouseLeave -= OnMouseLeave;
			item.Click -= OnItemClick;
			item.MouseDown -= OnCarbolistItemMouseDown;
			item.MenuButtonClick -= OnCarbolistItemMenuButtonClick;

			item.Dispose();

			IsDragged = false;

			RearrangeItems();

			UpdateItemLocations();

			if (!CanDeselect)
				SelectItem(Items[Items.Count - 1]);

			if (ItemContainer.Top < 0)
				ItemContainer.Top = Math.Min(ItemContainer.Top + itemSize.Height, 0);
		}

		override public void RemoveAllItems(bool removeDefaultItems = false)
		{
			base.RemoveAllItems(removeDefaultItems);

			currentX = currentY = ItemMargin;
			ItemContainer.Height = itemSize.Height;

			UpdateDefaultItemLocations();
		}

		public void RefreshItems()
		{
			UpdateItemLocations();
		}

		override public void ApplyAutoSize()
		{
			base.ApplyAutoSize();

			//tra.ce(ItemContainer.Height = 555);
		}

		#endregion

		#region ########################### PRIVATE METHODS #############################

		override protected void RearrangeItems()
		{
			Items = Items.OrderBy(x => x.Left).OrderBy(
				x => ((x.Top - ItemMargin).RoundTo(itemSize.Height + ItemPadding) + ItemMargin
			)).ToList();

			UpdateItemLocations();

			Refresh();
		}

		override protected void UpdateItemLocations()
		{
			currentX = currentY = ItemMargin;

			if (Items.Count == 0)
			{
				UpdateDefaultItemLocations();

				return;
			}

			for (int i = 0, l = Items.Count; i < l; i++)
			{
				CarbolistItem p = Items[i];

				p.Id = i;

				if (currentX + p.Width + ItemMargin > Width - ItemMargin)
				{
					currentX = ItemMargin;

					currentY += p.Height + ItemPadding;
				}

				if (p != draggingItem)
				{
					p.Left = currentX;
					p.Top = currentY;
				}

				currentX += p.Width + ItemPadding;
			}

			ItemContainer.Height = Items[Items.Count - 1].Bottom + ItemMargin;
			ScrollBar.Total = ItemContainer.Height + (LeftMenuButton.Text == "" ? 0 : LeftMenuButton.Height);

			UpdateDefaultItemLocations();
		}

		override protected void UpdateDefaultItemLocations()
		{
			currentDefaultX = currentX;
			currentDefaultY = currentY;

			foreach (CarbolistItem p in DefaultItems)
			{
				if (currentDefaultX + p.Width + ItemMargin > Width - ItemMargin)
				{
					currentDefaultX = ItemMargin;

					currentDefaultY += p.Height + ItemPadding;
					ItemContainer.Height += p.Height + ItemPadding;
					ScrollBar.Total += p.Height + ItemPadding;
				}

				p.Left = currentDefaultX;
				p.Top = currentDefaultY;

				currentDefaultX += p.Width + ItemPadding;
			}
		}

		override protected void ScrollItemIntoView(CarbolistItem item)
		{
			if (ScrollBar.Total <= ScrollBar.Capacity)
				return;

			//tra.ce(item.Id, ScrollBar.Value, maxCount);

			if (item.Top > ScrollBar.Value + Height - item.Height - LeftMenuButton.Height)
			{
				ScrollBar.Value = item.Bottom - Height + LeftMenuButton.Height;

				UpdateContainerLocation();
			}
			else if (item.Top < ScrollBar.Value)
			{
				ScrollBar.Value = item.Top;

				UpdateContainerLocation();
			}
		}

		override protected void ForceShowDefaultItems()
		{
		}

		override protected void ForceHideDefaultItems()
		{
		}

		#endregion

		#region ############################### EVENTS ##################################

		override protected void OnMouseEnter(object sender, EventArgs e)
		{
			//tra.ce("SHOWDETAILS!!", Items.Select(x => $"{x.Id}, {x.Text}").ToArray());

			if (!LeftMenuButton.Visible && LeftMenuButton.Text != "")
				LeftMenuButton.Visible = true;

			if (!RightMenuButton.Visible && RightMenuButton.Text != "")
				RightMenuButton.Visible = true;

			if (Items.Count > 0)
				ForceShowDefaultItems();

			if (currentY + itemSize.Height <= Height - (LeftMenuButton.Visible ? LeftMenuButton.Height : 0))
				return;

			ScrollBar.BringToFront();
			
			if (!ScrollBar.Visible)
				ScrollBar.Visible = true;
		}

		override protected void OnDraggingItemMouseMove(object sender, MouseEventArgs e)
		{
			// user needs to move the mouse for 10 pixels to start dragging
			if (!isDraggingItem)
			{
				// distance <= 10
				if (Math.Sqrt(Math.Pow(e.X - draggingStartPoint.X, 2) + Math.Pow(e.Y - draggingStartPoint.Y, 2)) <= 10)
					return;

				draggingItem.IsDragging = true;

				Cursor.Current = Cursors.SizeAll;

				isDraggingItem = true;
				draggingItem.BringToFront();

				draggingItem.Click -= OnItemClick;
			}

			int leftLimit = ItemMargin - 1;
			int rightLimit = Width - draggingItem.Width + 1;
			int topLimit = 0;
			int bottomLimit = currentY - (ScrollBar.Visible && LeftMenuButton.Text != "" ? LeftMenuButton.Height : 0);

			draggingItem.Left = (e.X + draggingItem.Left - draggingStartPoint.X).SnapBetween(leftLimit, rightLimit);
			draggingItem.Top = (e.Y + draggingItem.Top - draggingStartPoint.Y).SnapBetween(topLimit, bottomLimit);

			//tra.ce(draggingScrollTime, DateTimeOffset.Now.ToUnixTimeMilliseconds());

			// set a minimum scrolling interval of 50 millis
			if (Carbostopwatch.MilliElapsed(this) >= 50)
			{
				if (draggingItem.Top == topLimit)
				{
					ScrollBar.Value -= itemSize.Height;

					Carbostopwatch.Reset(this);

					UpdateContainerLocation();
				}
				else if (draggingItem.Top == bottomLimit)
				{
					ScrollBar.Value += itemSize.Height;

					Carbostopwatch.Reset(this);

					UpdateContainerLocation();
				}
			}

			RearrangeItems();
		}

		#endregion

	}

}
