using Carboutil;

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
	public class Carbolist : UserControl, IMessageFilter
	{

		#region ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// Creates a new Carbolist instance.
		/// </summary>
		/// <param name="theme">The color scheme of this Carbolist. Use values in CarbolistTheme class.</param>
		/// <param name="sampleButton">A sample Button object where this Carbolist will copy its properties from.</param>
		/// <param name="onItemSelect">A callback function when a CarbolistItem is selected.</param>
		/// <param name="onOrderChanged">A callback function when the order of this Carbolist is changed.</param>
		public Carbolist(CarbolistTheme theme = default, Button sampleButton = null, Action<CarbolistItem> onItemSelect = null)
		{
			if (sampleButton == null)
				sampleButton = new Button();

			ItemContainer = new UserControl();

			ScrollBar = new Carboscrollbar(OnScrollBarDragged)
			{
				Visible = false,
			};

			itemFont = sampleButton.Font;
			itemSize = new Size(sampleButton.Width, sampleButton.MinimumSize.Height == 0
				 ? sampleButton.Width / 3 : sampleButton.MinimumSize.Height);

			ItemMenuButtonSize = new Size(sampleButton.Padding.Right, sampleButton.Padding.Bottom);
			ItemTextAlign = ItemTextAlignWithImage = sampleButton.TextAlign;
			ItemTextIconRelation = sampleButton.TextImageRelation;
			ItemIconAlign = sampleButton.ImageAlign;

			LeftMenuButton = new Carbobutton()
			{
				Size = new Size(90, 30),
				Top = Height - 30,
				Font = new Font(itemFont.Name, 12),
				FlatStyle = FlatStyle.Flat,
				Visible = false,
				BackgroundImageLayout = ImageLayout.Zoom,
				ImageAlign = ContentAlignment.MiddleLeft,
				TextAlign = ContentAlignment.MiddleLeft,
				TextImageRelation = TextImageRelation.ImageBeforeText,
			};
			RightMenuButton = new Carbobutton()
			{
				Size = LeftMenuButton.Size,
				Location = new Point(LeftMenuButton.Width, LeftMenuButton.Top),
				Font = new Font(itemFont.Name, 12),
				FlatStyle = FlatStyle.Flat,
				Visible = false,
				BackgroundImageLayout = ImageLayout.Zoom,
				ImageAlign = ContentAlignment.MiddleLeft,
				TextAlign = ContentAlignment.MiddleLeft,
				TextImageRelation = TextImageRelation.ImageBeforeText,
			};

			LeftMenuButton.FlatAppearance.BorderSize = RightMenuButton.FlatAppearance.BorderSize = 0;

			Items = new List<CarbolistItem>();
			DefaultItems = new List<CarbolistItem>();

			BackColor = ItemContainer.BackColor = sampleButton.BackColor;
			Width = sampleButton.Width;
			Location = sampleButton.Location;
			OnItemSelect = onItemSelect;

			Height = sampleButton.Height;

			if (sampleButton.Parent != null)
				sampleButton.Controls.Remove(sampleButton);

			ScrollBar.Height = Height;
			ScrollBar.Left = Width - ScrollBar.Width;

			Application.AddMessageFilter(this);

			ScrollBar.Total = LeftMenuButton.Height;

			Controls.Add(LeftMenuButton);
			Controls.Add(RightMenuButton);
			Controls.Add(ScrollBar);
			Controls.Add(ItemContainer);

			Theme = theme;
			ItemContainer.Height = ScrollBar.Total = 0;

			// events

			VisibleChanged += OnVisibleChanged;
			MouseEnter += OnMouseEnter;
			MouseLeave += OnMouseLeave;
			ItemContainer.MouseEnter += OnMouseEnter;
			ItemContainer.MouseLeave += OnMouseLeave;
			ScrollBar.Background.MouseLeave += OnMouseLeave;
			ScrollBar.Slider.MouseLeave += OnMouseLeave;
			LeftMenuButton.MouseClick += OnLeftMenuButtonMouseClick;
			RightMenuButton.MouseClick += OnRightMenuButtonMouseClick;
			LeftMenuButton.MouseLeave += OnMouseLeave;
			RightMenuButton.MouseLeave += OnMouseLeave;
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		/// <summary>A callback when an list-item is selected. It must contain one argument: CarbolistItem.</summary>
		public Action<CarbolistItem> OnItemSelect { get; set; }

		public Action<CarbolistItem> OnItemDoubleSelect
		{
			get => onItemDoubleSelect;

			set
			{
				onItemDoubleSelect = value;

				foreach (CarbolistItem p in Items)
					p.SetStyle(ControlStyles.StandardDoubleClick, value != null);
			}
		}

		/// <summary>A callback when an list-item is being selected. It must contain one argument (CarbolistItem) and return a boolean value (isSuspended).</summary>
		public Func<CarbolistItem, bool> OnItemSelecting { get; set; }

		public Action<CarbolistItem> OnDefaultItemSelect { get; set; }

		/// <summary>A callback when the order of the list-items is changed.</summary>
		public Action OnOrderChanged { get; set; }

		/// <summary>A callback when one of the list-menu-button is clicked.</summary>
		public Action<Carbobutton, object> OnMenuButtonClick { get; set; }

		/// <summary>A callback when a menu button of a list-item is clicked.</summary>
		public Action<CarbolistItem> OnItemMenuButtonClick { get; set; }

		/// <summary>The TextAlign of the list-items. (This only affects new added items.)</summary>
		public ContentAlignment ItemTextAlign { get; set; } = ContentAlignment.MiddleCenter;

		public ContentAlignment ItemTextAlignWithImage { get; set; } = ContentAlignment.MiddleCenter;

		public TextImageRelation ItemTextIconRelation { get; set; } = TextImageRelation.Overlay;

		public ContentAlignment ItemIconAlign { get; set; } = ContentAlignment.MiddleCenter;

		public Size ItemMenuButtonSize { get; set; }

		/// <summary>Whether user can select any item in this Carbolist.</summary>
		new public bool CanSelect { get; set; } = true;

		/// <summary>Whether user can drag-and-drop items.</summary>
		public bool CanDragAndDrop { get; set; } = true;

		/// <summary>Whether user can deselect an item by clicking on it.</summary>
		public bool CanDeselect { get; set; } = true;

		/// <summary>Should the list-items in this Carbolist show their menu buttons.</summary>
		public bool AreItemsShowingMenuButtons { get; set; } = true;

		public bool AutoHideDefaultItems { get; set; } = true;

		public bool AutoDarkenUnselectControl { get; set; }

		/// <summary>The color scheme of this Carbolist.</summary>
		public CarbolistTheme Theme
		{
			get => theme;

			set
			{
				theme = value;

				ScrollBar.ForeColor = value.ScrollBarForeColor;
				ScrollBar.BackColor = value.ScrollBarBackColor;

				LeftMenuButton.BackColor = RightMenuButton.BackColor = value.MenuButtonBackColor;
				LeftMenuButton.ForeColor = RightMenuButton.ForeColor = ScrollBar.ForeColor;
			}
		}

		new public int Height
		{
			get => base.Height;

			set
			{
				base.Height = value;

				ScrollBar.Height = value - (RightMenuButton.Text == "" ? 0 : RightMenuButton.Height);
				ScrollBar.Capacity = value;

				LeftMenuButton.Top = RightMenuButton.Top = value - LeftMenuButton.Height;

				UpdateContainerLocation();
			}
		}

		new virtual public int Width
		{
			get => base.Width;

			set
			{
				base.Width = value;

				// this setter is not capable for Carbotilelists
				if (this is Carbotilelist)
					return;

				itemSize.Width = value;
				ItemContainer.Width = value;

				ScrollBar.Left = value - ScrollBar.Width;

				foreach (CarbolistItem p in Items)
					p.Width = value;

				foreach (CarbolistItem p in DefaultItems)
					p.Width = value;
			}
		}

		override public Color BackColor
		{
			get => base.BackColor;

			set
			{
				base.BackColor = ItemContainer.BackColor = value;
			}
		}

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		/// <summary>[ReadOnly] The list-item selected by user.</summary>
		public CarbolistItem SelectedItem { get; protected set; }

		/// <summary>[ReadOnly] The ScrollBar instance in this Carbolist.</summary>
		public Carboscrollbar ScrollBar { get; protected set; }

		public Carbobutton LeftMenuButton { get; protected set; }
		public Carbobutton RightMenuButton { get; protected set; }

		public UserControl ItemContainer { get; protected set; }

		/// <summary>[ReadOnly] The collections of all list-items.</summary>
		public List<CarbolistItem> Items { get; protected set; }

		public List<CarbolistItem> DefaultItems { get; protected set; }

		/// <summary>[ReadOnly] Whether any list-item has been dragged since the most recent add/remove/visible change.</summary>
		public bool IsDragged { get; protected set; }

		public bool IsShowingDefaultItems { get; protected set; } = true;

		protected CarbolistItem draggingItem;
		protected CarbolistTheme theme;
		protected Action<CarbolistItem> onItemDoubleSelect;
		protected Point draggingStartPoint;
		protected Point draggingItemStartLocation;
		protected Font itemFont;
		protected Size itemSize;
		protected object itemMenuButtonBackColor;
		protected object itemMenuButtonForeColor;
		protected string itemMenuButtonText = "";
		protected bool areItemsShowingMenuButtons;
		protected bool isDraggingItem;
		protected bool canContainDefaultItems;

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		#region *************** ADDING ***************

		/// <summary>
		/// Adds a new list-item into the Carbolist. Also returns that new item.
		/// </summary>
		/// <param name="text">The title that the item will display.</param>
		/// <param name="tag">The data provider linked with the item.</param>
		/// <param name="scrollItemIntoView">Automatically scroll the new item into view.</param>
		virtual public CarbolistItem AddItem(string text, Image icon = null, object tag = null, bool scrollItemIntoView = true)
		{
			if (text == null)
				throw new Exception("Argument text must be non-null.");

			Color backColor = Items.Count % 2 == 0
				? theme.FirstItemBackColor : theme.SecondItemBackColor;

			CarbolistItem item = new CarbolistItem(Items.Count, backColor, theme.SelectedItemBackColor, tag, this)
			{
				FlatStyle = FlatStyle.Flat,
				Top = Items.Count * itemSize.Height,
				Size = itemSize,
				Font = itemFont,
				Text = text,
				ForeColor = theme.ItemForeColor,
			};

			if (icon != null)
				item.SetIcon(icon);

			if (itemMenuButtonText != "")
				item.RegisterMenuButton(itemMenuButtonText, itemMenuButtonBackColor, itemMenuButtonForeColor, null, ItemMenuButtonSize);

			if (ItemTextAlign != ContentAlignment.MiddleCenter)
				item.TextAlign = ItemTextAlign;

			ItemContainer.Controls.Add(item);

			Items.Add(item);
			ItemContainer.Height += item.Height;
			ScrollBar.Total += item.Height;

			if (scrollItemIntoView)
				ScrollItemIntoView(item);

			IsDragged = false;

			item.MouseEnter += OnMouseEnter;
			item.MouseLeave += OnMouseLeave;
			item.Click += OnItemClick;
			item.DoubleClick += OnItemDoubleClick;
			item.MouseDown += OnCarbolistItemMouseDown;
			item.MenuButtonClick += OnCarbolistItemMenuButtonClick;

			if (onItemDoubleSelect != null)
				item.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);

			if (AutoHideDefaultItems)
			{
				if (item.Id == Height / itemSize.Height - 2)
				{
					HideDefaultItems();
					canContainDefaultItems = false;
				}
				else if (item.Id == 0 && !this.IsMouseEntered())
				{
					ForceHideDefaultItems();
				}
			}

			UpdateDefaultItemLocations();

			return item;
		}

		/// <summary>
		/// Adds a group of list-items into the Carbolist.
		/// </summary>
		/// <param name="texts">The texts of the new items.</param>
		/// <param name="icons">The icons of the new items.</param>
		/// <param name="tags">The linked data of the new items.</param>
		public List<CarbolistItem> AddItems(List<string> texts, List<Image> icons = null, IList tags = null)
		{
			List<CarbolistItem> output = new List<CarbolistItem>();

			Image[] iconArray = icons?.ToArray();
			object[] tagArray = tags?.Cast<object>().ToArray();

			for (int i = 0, l = texts?.Count ?? tags.Count; i < l; i++)
				output.Add(AddItem(texts?[i] ?? "", iconArray?.GetValue(i) as Image, tagArray?.GetValue(i), false));

			return output;
		}

		/// <summary>
		/// Adds a group of list-items from a data source.
		/// The texts of all items will automatically be set to a given key of a property of data.
		/// </summary>
		/// <param name="key">The key of a string property of data that provides the titles of new items.</param>
		/// <param name="tags">The data source.</param>
		public List<CarbolistItem> AddItemsBy(string key, IList tags, string imageKey = null)
		{
			if (tags == null)
				throw new Exception("Argument data must be non-null.");

			if (tags.Count == 0)
				return new List<CarbolistItem>();

			List<Image> temp = null;
			if (imageKey != null)
				temp = tags.Cast<object>().Select(GetKeySelector<Image>(imageKey)).ToList();

			if (key == "")
				return AddItems(null, temp, tags);

			return AddItems(tags.Cast<object>().Select(GetKeySelector<string>(key)).ToList(), temp, tags);
		}

		/// <summary>
		/// Adds a new default list-item to this Carbolist. A default list-item stays at the bottom of the Carbolist and won't be dragged.
		/// </summary>
		/// <param name="text">The title that the item will display.</param>
		/// <param name="tag">The data provider linked with the item.</param>
		virtual public CarbolistItem AddDefaultItem(string text, object tag = null)
		{
			if (text == null)
				throw new Exception("Argument text must be non-null.");

			CarbolistItem item = new CarbolistItem(DefaultItems.Count, theme.DefaultItemBackColor, theme.SelectedItemBackColor, tag, this)
			{
				FlatStyle = FlatStyle.Flat,
				Top = Items.Count * itemSize.Height + DefaultItems.Count * itemSize.Height / 2,
				Size = new Size(itemSize.Width, itemSize.Height / 2),
				Font = new Font(itemFont.FontFamily, itemFont.Size - 1, FontStyle.Italic),
				Text = text,
				ForeColor = theme.DefaultItemForeColor,
				Visible = false,
			};

			DefaultItems.Add(item);
			
			if (AutoHideDefaultItems && canContainDefaultItems)
			{
				ItemContainer.Controls.Add(item);

				ItemContainer.Height += item.Height;
				ScrollBar.Total += item.Height;
			}

			IsDragged = false;

			item.MouseEnter += OnMouseEnter;
			item.MouseLeave += OnMouseLeave;
			item.Click += OnDefaultItemClick;

			return item;
		}

		#endregion

		#region *************** REMOVING ***************

		/// <summary>
		/// Removes a list-item from the Carbolist.
		/// </summary>
		/// <param name="item">The CarbolistItem to remove.</param>
		virtual public void RemoveItem(CarbolistItem item)
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
			item.DoubleClick -= OnItemDoubleClick;
			item.MouseDown -= OnCarbolistItemMouseDown;
			item.MenuButtonClick -= OnCarbolistItemMenuButtonClick;

			ItemContainer.Height -= item.Height;
			ScrollBar.Total -= item.Height;

			item.Dispose();

			IsDragged = false;

			RearrangeItems();

			if (AutoHideDefaultItems)
			{
				if (Items.Count == Height / itemSize.Height - 2)
				{
					canContainDefaultItems = true;
					ShowDefaultItems();
				}
				else if (Items.Count == 0)
				{
					ForceShowDefaultItems();
				}
			}

			UpdateDefaultItemLocations();

			if (!CanDeselect && Items.Count > 0)
				SelectItem(Items[Items.Count - 1]);

			if (ItemContainer.Top < 0)
				ItemContainer.Top = Math.Min(ItemContainer.Top + itemSize.Height, 0);
		}

		public List<CarbolistItem> RemoveWhere(Func<CarbolistItem, bool> selector)
		{
			List<CarbolistItem> output = Items.Where(selector).ToList();

			if (output.Count > 0)
				output.ForEach(x => RemoveItem(x));

			return output;
		}

		/// <summary>
		/// Removes a default list-item from the Carbolist.
		/// </summary>
		/// <param name="item">The CarbolistItem to remove.</param>
		public void RemoveDefaultItem(CarbolistItem item)
		{
			if (item == null)
				throw new Exception("Argument item must be non-null");

			ItemContainer.Controls.Remove(item);
			DefaultItems.Remove(item);

			item.MouseEnter -= OnMouseEnter;
			item.MouseLeave -= OnMouseLeave;
			item.Click -= OnDefaultItemClick;
			item.MenuButtonClick -= OnCarbolistItemMenuButtonClick;

			ItemContainer.Height -= item.Height;
			ScrollBar.Total -= item.Height;

			UpdateDefaultItemLocations();

			if (ItemContainer.Top < 0)
				ItemContainer.Top = Math.Min(ItemContainer.Top + itemSize.Height / 2, 0);
		}

		/// <summary>
		/// Removes all list-items from the Carbolist.
		/// </summary>
		/// <param name="removeDefaultItems">Whether it should remove the default list-items as well.</param>
		virtual public void RemoveAllItems(bool removeDefaultItems = false)
		{
			DeselectItem();

			foreach (CarbolistItem p in Items)
			{
				p.MouseEnter -= OnMouseEnter;
				p.MouseLeave -= OnMouseLeave;
				p.Click -= OnItemClick;
				p.DoubleClick -= OnItemDoubleClick;
				p.MouseDown -= OnCarbolistItemMouseDown;
				p.MenuButtonClick -= OnCarbolistItemMenuButtonClick;

				ItemContainer.Controls.Remove(p);
			}

			Items.Clear();

			if (removeDefaultItems)
			{
				foreach (CarbolistItem p in DefaultItems)
				{
					p.Click -= OnDefaultItemClick;
					p.MouseDown -= OnCarbolistItemMouseDown;
					p.MenuButtonClick -= OnCarbolistItemMenuButtonClick;

					ItemContainer.Controls.Remove(p);
				}

				DefaultItems.Clear();
			}

			if (AutoHideDefaultItems && !canContainDefaultItems)
			{
				canContainDefaultItems = true;

				ShowDefaultItems();
			}

			ItemContainer.Height = DefaultItems.Count * itemSize.Height / 2;
			ScrollBar.Total = ItemContainer.Height + (LeftMenuButton.Text == "" ? 0 : LeftMenuButton.Height);
			ForceShowDefaultItems();

			IsDragged = false;

			UpdateContainerLocation();
			UpdateDefaultItemLocations();
		}

		#endregion

		#region *************** SELECT/DESELECT AND SHOW/HIDE ***************

		/// <summary>
		/// Selects a list-item. If it's already selected, deselects it.
		/// </summary>
		/// <param name="item">The item to select/deselect.</param>
		/// <param name="forceSelected">Keep it selected it if it's already selected.</param>
		public CarbolistItem SelectItem(CarbolistItem item, bool forceSelected = false)
		{
			if (item == null)
			{
				DeselectItem();

				return null;
			}

			if (!Items.Contains(item))
				throw new Exception("Item not found in this Carbolist.");

			if (!forceSelected || !item.IsSelected)
				OnItemClick(item, null);

			return item;
		}

		/// <summary>
		/// Selects a list-item. If it's already selected, deselects it.
		/// </summary>
		/// <param name="index">The index to select/deselect.</param>
		public CarbolistItem SelectIndex(int index, bool forceSelected = false)
		{
			if (index < 0 || index >= Items.Count)
				throw new Exception("Item index not found.");

			return SelectItem(Items[index], forceSelected);
		}

		public CarbolistItem SelectWhere(Func<CarbolistItem, bool> selector, bool forceSelected = false)
		{
			return SelectItem(Items.FirstOrDefault(selector), forceSelected);
		}

		/// <summary>
		/// If any list-item is selected, deselects it.
		/// </summary>
		public CarbolistItem DeselectItem()
		{
			if (SelectedItem == null)
				return null;

			CarbolistItem temp = SelectedItem;

			SelectedItem.IsSelected = false;
			SelectedItem = null;

			if (AutoDarkenUnselectControl)
				Items.ForEach(x => CarboControlDarkener.Undarken(x));

			return temp;
		}

		public void ShowItemTexts()
		{
			foreach (CarbolistItem p in Items)
				p.ShowText();
		}

		public void HideItemTexts()
		{
			foreach (CarbolistItem p in Items)
				p.HideText();
		}

		/// <summary>
		/// Shows default list-items.
		/// </summary>
		public void ShowDefaultItems()
		{
			//tra.ce("show!!", isContainingDefaultItems, IsShowingDefaultItems, DefaultItems.Count, DefaultItems.Count > 0 && container.Controls.Contains(DefaultItems[0]));

			if (AutoHideDefaultItems && !canContainDefaultItems)
				return;

			IsShowingDefaultItems = true;

			if (DefaultItems.Count > 0 && ItemContainer.Controls.Contains(DefaultItems[0]))
				return;

			foreach (CarbolistItem p in DefaultItems)
			{
				ItemContainer.Controls.Add(p);
				ItemContainer.Height += p.Height;
				ScrollBar.Total += p.Height;
			}
		}

		/// <summary>
		/// Hides default list-items.
		/// </summary>
		public void HideDefaultItems()
		{
			if (AutoHideDefaultItems && !canContainDefaultItems)
				return;

			IsShowingDefaultItems = false;

			if (DefaultItems.Count > 0 && !ItemContainer.Controls.Contains(DefaultItems[0]))
				return;

			foreach (CarbolistItem p in DefaultItems)
			{
				ItemContainer.Controls.Remove(p);
				ItemContainer.Height -= p.Height;
				ScrollBar.Total -= p.Height;
			}
		}

		#endregion

		#region *************** REGISTERING MENUS ***************

		/// <summary>
		/// Sets the text, icon, and context menu items of the left side menu button, then shows the left side menu button.
		/// Enter "" (empty string) as the text to unregister the button.
		/// </summary>
		/// <param name="text">The text on the button.</param>
		/// <param name="icon">The icon on the button.</param>
		/// <param name="args">The texts and tags(linked data) of the context menu items. Pass the values as "Text0, Tag0, Text1, Tag1, etc.".</param>
		public void RegisterLeftMenuButton(string text, Image icon = null, params object[] args)
		{
			LeftMenuButton.Text = text;
			LeftMenuButton.Image = icon;

			if (args.Length % 2 == 1)
				throw new Exception("Argument args must have an even number of length.");

			if (args.Length > 0)
			{
				LeftMenuButton.ContextMenu = new ContextMenu();

				for (int i = 0, l = args.Length; i < l; i++)
				{
					LeftMenuButton.ContextMenu.MenuItems.Add(new MenuItem(args[i].ToString(), OnLeftMenuButtonContextMenuItemClick)
					{
						Tag = args[++i],
					});
				}
			}
		}

		/// <summary>
		/// Sets the text, icon, and context menu items of the right side menu button, then shows the right side menu button.
		/// Enter "" (empty string) as the text to unregister the button.
		/// </summary>
		/// <param name="text">The text on the button.</param>
		/// <param name="icon">The icon on the button.</param>
		/// <param name="args">The texts and tags(linked data) of the context menu items. Pass the values as "Text0, Tag0, Text1, Tag1, etc.".</param>
		public void RegisterRightMenuButton(string text, Image icon = null, params string[] args)
		{
			RightMenuButton.Text = text;
			RightMenuButton.Image = icon;

			ScrollBar.Height = Height - (text == "" ? 0 : RightMenuButton.Height);

			if (args.Length % 2 == 1)
				throw new Exception("Argument args must have an even number of length.");

			if (args.Length > 0)
			{
				RightMenuButton.ContextMenu = new ContextMenu();

				for (int i = 0, l = args.Length; i < l; i++)
				{
					RightMenuButton.ContextMenu.MenuItems.Add(new MenuItem(args[i], OnRightMenuButtonContextMenuItemClick)
					{
						Tag = args[++i],
					});
				}
			}
		}

		/// <summary>
		/// Sets the texts, backColors, and foreColors of the menu buttons of the list-items.
		/// Enter "" (empty string) as the text to unregister the buttons.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="backColor"></param>
		/// <param name="foreColor"></param>
		public void RegisterItemMenuButtons(string text, object backColor = null, object foreColor = null)
		{
			itemMenuButtonBackColor = backColor;
			itemMenuButtonForeColor = foreColor;
			itemMenuButtonText = text;

			foreach (CarbolistItem p in Items)
				p.RegisterMenuButton(text, backColor, foreColor, null, ItemMenuButtonSize);
		}

		#endregion

		#region *************** TOOLS ***************

		virtual public void ApplyAutoSize()
		{
			Height = ScrollBar.Total;
		}

		/// <summary>
		/// Sorts the list-items by a key. You can use "Key0.Key1.Key2, etc." to access deeper properties.
		/// Put a "/" in front of a key to indicate decending order.
		/// </summary>
		/// <param name="key">The sorting identifier.</param>
		public void SortItemsBy(string key)
		{
			try
			{
				Func<CarbolistItem, dynamic> keySelector = GetKeySelector<dynamic>(key.Replace("/", ""));

				Items = key[0] == '/'
					? Items.OrderByDescending(keySelector).ToList()
					: Items.OrderBy(keySelector).ToList();
			}
			catch
			{
				throw new Exception($"Key \"{key}\" is not found or cannot be accessed.");
			}

			UpdateItemLocations();

			IsDragged = true;
		}

		#endregion

		#endregion

		#region ########################### PRIVATE METHODS #############################

		protected Func<dynamic, TResult> GetKeySelector<TResult>(string key)
		{
			string[] keys = key.Split('.');

			return (x =>
			{
				dynamic target = null;

				foreach (string p in keys)
					target = GetValueBy(p, target ?? x);

				return (TResult)target;
			});
		}

		protected dynamic GetValueBy(string key, dynamic target)
		{
			return target.GetType().GetProperty(key).GetValue(target);
		}

		virtual protected void RearrangeItems()
		{
			Items = Items.OrderBy(x => x.Top).ToList();

			UpdateItemLocations();
		}

		virtual protected void UpdateItemLocations()
		{
			for (int i = 0, l = Items.Count; i < l; i++)
			{
				if (Items[i] == draggingItem)
					continue;

				Items[i].Id = i;
				Items[i].Top = i * itemSize.Height;

				if (draggingItem == null)
					Items[i].ChangeBackColor(i % 2 == 0 ? theme.FirstItemBackColor : theme.SecondItemBackColor);
			}
		}

		virtual protected void UpdateDefaultItemLocations()
		{
			if (AutoHideDefaultItems && !canContainDefaultItems)
				return;

			foreach (CarbolistItem p in DefaultItems)
				p.Top = Items.Count * itemSize.Height + p.Id * itemSize.Height / 2;
		}

		virtual protected void ForceShowDefaultItems()
		{
			if (DefaultItems.Count == 0 || DefaultItems[0].Visible)
				return;

			foreach (CarbolistItem p in DefaultItems)
				p.Visible = true;
		}

		virtual protected void ForceHideDefaultItems()
		{
			if (DefaultItems.Count == 0)
				return;

			foreach (CarbolistItem p in DefaultItems)
				p.Visible = false;
		}

		virtual protected void ScrollItemIntoView(CarbolistItem item)
		{
			if (Items.Count * item.Height <= Height)
				return;

			//tra.ce(item.Id, ScrollBar.Value, maxCount);

			if (item.Top > ScrollBar.Value + Height - item.Height - LeftMenuButton.Height)
			{
				ScrollBar.Value = (item.Id + 1) * item.Height - Height + LeftMenuButton.Height;

				UpdateContainerLocation();
			}
			else if (item.Top < ScrollBar.Value)
			{
				ScrollBar.Value = item.Id * item.Height;

				UpdateContainerLocation();
			}
		}

		protected void UpdateContainerLocation()
		{
			ItemContainer.Top = -ScrollBar.Value;
		}

		#endregion

		#region ############################### EVENTS ##################################

		virtual protected void OnMouseEnter(object sender, EventArgs e)
		{
			if (!LeftMenuButton.Visible && LeftMenuButton.Text != "")
				LeftMenuButton.Visible = true;

			if (!RightMenuButton.Visible && RightMenuButton.Text != "")
				RightMenuButton.Visible = true;

			if (Items.Count > 0)
			{
				ForceShowDefaultItems();

				if (AutoDarkenUnselectControl && SelectedItem != null)
					Items.ForEach(x => CarboControlDarkener.Undarken(x));
			}

			if (Items.Count * itemSize.Height <= Height - (LeftMenuButton.Visible ? LeftMenuButton.Height : 0))
				return;

			ScrollBar.BringToFront();

			if (!ScrollBar.Visible)
				ScrollBar.Visible = true;
		}

		public event EventHandler MouseLeaveList;

		protected void OnMouseLeave(object sender, EventArgs e)
		{
			if (this.IsMouseEntered())
				return;

			if (sender == ScrollBar)
				return;

			if (ScrollBar.Visible)
				ScrollBar.Visible = false;

			if (LeftMenuButton.Visible)
				LeftMenuButton.Visible = false;

			if (RightMenuButton.Visible)
				RightMenuButton.Visible = false;

			if (Items.Count > 0)
			{
				ForceHideDefaultItems();

				if (AutoDarkenUnselectControl && SelectedItem != null)
				{
					foreach (CarbolistItem p in Items)
					{
						if (p != SelectedItem)
							CarboControlDarkener.Darken(p, .01f);
					}
				}
			}

			MouseLeaveList?.Invoke(this, e);
		}

		// optimized mouse wheel method
		public bool PreFilterMessage(ref Message message)
		{
			if (!ScrollBar.Visible)
				return false;

			const int mouseWheelMessageCode0 = 0x020A, mouseWheelMessageCode1 = 0x020E;

			if (message.Msg == mouseWheelMessageCode0 || message.Msg == mouseWheelMessageCode1)
			{
				ScrollBar.Value -= Math.Sign(message.WParam.ToInt32()) * Math.Min(SystemInformation.MouseWheelScrollLines * itemSize.Height, ScrollBar.Capacity);

				UpdateContainerLocation();
			}

			return false;
		}

		protected void OnScrollBarDragged(int value)
		{
			UpdateContainerLocation();
		}

		protected void OnCarbolistItemMouseDown(object sender, MouseEventArgs e)
		{
			if (!CanDragAndDrop)
				return;

			// drag-and-drop preparations

			// drag-and-drop only when the list has more than 1 item.
			if (Items.Count <= 1)
				return;

			if (e.Button != MouseButtons.Left)
				return;

			draggingItem = sender as CarbolistItem;
			draggingStartPoint = e.Location;
			draggingItemStartLocation = draggingItem.Location;

			draggingItem.MouseMove += OnDraggingItemMouseMove;
			draggingItem.MouseUp += OnDraggingItemMouseUp;
		}

		virtual protected void OnDraggingItemMouseMove(object sender, MouseEventArgs e)
		{
			// user needs to move the mouse for 10 pixels to start dragging
			if (!isDraggingItem)
			{
				// distance <= 10
				if (e.Location.DistanceTo(draggingStartPoint) <= 10)
					return;

				Cursor.Current = Cursors.SizeAll;

				draggingItem.IsDragging = true;

				isDraggingItem = true;
				draggingItem.BringToFront();

				draggingItem.Click -= OnItemClick;
				draggingItem.DoubleClick -= OnItemDoubleClick;
			}

			int topLimit = -ItemContainer.Top - 1;
			int bottomLimit = -ItemContainer.Top + Math.Min(Items.Count * itemSize.Height, Height) - itemSize.Height - (ScrollBar.Visible && LeftMenuButton.Text != "" ? LeftMenuButton.Height : 0) + 1;

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

		protected void OnDraggingItemMouseUp(object sender, MouseEventArgs e)
		{
			Cursor.Current = Cursors.Default;

			draggingItem.IsDragging = false;

			draggingItem.MouseMove -= OnDraggingItemMouseMove;
			draggingItem.MouseUp -= OnDraggingItemMouseUp;

			// restore click event
			if (isDraggingItem)
			{
				draggingItem.Click += OnItemClick;
				draggingItem.DoubleClick += OnItemDoubleClick;
			}

			CarbolistItem temp = draggingItem;

			draggingItem = null;
			isDraggingItem = false;

			if (temp.Location.Equals(draggingItemStartLocation))
				return;

			RearrangeItems();

			if (!IsDragged)
				IsDragged = true;

			OnOrderChanged?.Invoke();
		}

		protected void OnItemClick(object sender, EventArgs e)
		{
			if (onItemDoubleSelect != null)
				return;

			CarbolistItem item = sender as CarbolistItem;

			if (OnItemSelecting != null && OnItemSelecting.Invoke(item))
				return;

			ScrollItemIntoView(item);

			if (AutoDarkenUnselectControl)
				CarboControlDarkener.Undarken(item);

			if (CanSelect && item.CanSelect)
			{
				if (item == SelectedItem)
				{
					if (CanDeselect)
						DeselectItem();
				}
				else
				{
					if (SelectedItem != null)
						SelectedItem.IsSelected = false;

					item.IsSelected = true;
					SelectedItem = item;
				}
			}

			if (AutoDarkenUnselectControl && !this.IsMouseEntered())
			{
				foreach (CarbolistItem p in Items)
				{
					if (p != item)
						CarboControlDarkener.Darken(p, .01f);
				}
			}

			// callback event listener
			OnItemSelect?.Invoke(item);
		}

		protected void OnItemDoubleClick(object sender, EventArgs e)
		{
			onItemDoubleSelect?.Invoke(sender as CarbolistItem);
		}

		protected void OnDefaultItemClick(object sender, EventArgs e)
		{
			OnDefaultItemSelect?.Invoke(sender as CarbolistItem);
		}

		protected void OnCarbolistItemMenuButtonClick(object sender, EventArgs e)
		{
			OnItemMenuButtonClick?.Invoke(sender as CarbolistItem);
		}

		protected void OnVisibleChanged(object sender, EventArgs e)
		{
			IsDragged = false;
		}

		protected void OnLeftMenuButtonMouseClick(object sender, MouseEventArgs e)
		{
			if (LeftMenuButton.ContextMenu == null)
			{
				OnMenuButtonClick?.Invoke(LeftMenuButton, -1);

				return;
			}

			LeftMenuButton.ContextMenu.Show(LeftMenuButton, e.Location);
		}

		protected void OnRightMenuButtonMouseClick(object sender, MouseEventArgs e)
		{
			if (RightMenuButton.ContextMenu == null)
			{
				OnMenuButtonClick?.Invoke(RightMenuButton, -1);

				return;
			}

			RightMenuButton.ContextMenu.Show(RightMenuButton, e.Location);
		}

		protected void OnLeftMenuButtonContextMenuItemClick(object sender, EventArgs e)
		{
			OnMenuButtonClick?.Invoke(LeftMenuButton, (sender as MenuItem).Tag);
		}

		protected void OnRightMenuButtonContextMenuItemClick(object sender, EventArgs e)
		{
			OnMenuButtonClick?.Invoke(RightMenuButton, (sender as MenuItem).Tag);
		}

		#endregion

	}

}
