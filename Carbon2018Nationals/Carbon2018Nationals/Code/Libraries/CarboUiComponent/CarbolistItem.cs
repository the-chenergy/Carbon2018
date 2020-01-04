using Carboutil;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarboUiComponent
{

	/// <summary>
	/// A list-item of a Carbolist.
	/// </summary>
	public class CarbolistItem : Carbobutton
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// Creates a new CarbolistItem instance.
		/// </summary>
		public CarbolistItem(int id, Color color, Color selectedColor, object tag, Carbolist parent)
		{
			BackColor = normalBackColor = color;
			Id = id;
			selectedBackColor = selectedColor;
			Tag = tag;
			ParentList = parent;

			FlatAppearance.BorderSize = 0;
			UseMnemonic = false;

			CanSelect = true;
			IsShowingText = true;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		/// <summary>The ID of this CarbolistItem in its parent Carbolist.</summary>
		public int Id { get; set; }

		new public bool CanSelect { get; set; }

		public bool IsShowingMenuButton { get; set; } = true;

		public bool IsDragging { get; internal set; }

		override public string Text
		{
			get => base.Text;

			set
			{
				text = value;

				base.Text = IsShowingText ? value : "";
			}
		}

		/// <summary>Get/set whether this CarbolistItem is selected.</summary>
		public bool IsSelected
		{
			get
			{
				return BackColor == selectedBackColor;
			}
			set
			{
				if (value)
				{
					BackColor = selectedBackColor;
					Font = new Font(Font, FontStyle.Bold);
				}
				else
				{
					BackColor = normalBackColor;
					Font = new Font(Font, FontStyle.Regular);
				}
			}
		}

		/// ######################### PRIVATE PROPERTIES ############################

		/// <summary>[ReadOnly] The related Carbolist instance.</summary>
		public Carbolist ParentList { get; protected set; }

		public Carbobutton MenuButton { get; protected set; }

		public bool IsShowingText { get; protected set; }

		protected Color normalBackColor;
		protected Color selectedBackColor;
		protected string text;

		/// ########################### PUBLIC METHODS ##############################

		/// <summary>
		/// Change the background color of this item.
		/// If this CarbolistItem is selected, the change will be applied when this is unselected.
		/// </summary>
		/// <param name="color">The new background color.</param>
		public void ChangeBackColor(Color color)
		{
			normalBackColor = color;

			if (!IsSelected)
				BackColor = color;
		}

		public void AutoSetWidth()
		{
			Width = TextRenderer.MeasureText(Text, Font).Width + (Font.Size * 1.3).Round();
		}

		public void SetIcon(Image icon)
		{
			if (icon == null)
			{
				TextAlign = ParentList.ItemTextAlign;
				TextImageRelation = TextImageRelation.ImageBeforeText;

				return;
			}

			ImageAlign = ParentList.ItemIconAlign;
			TextAlign = ParentList.ItemTextAlignWithImage;
			TextImageRelation = ParentList.ItemTextIconRelation;

			Image = icon;
		}

		public void ShowText()
		{
			if (IsShowingText)
				return;

			IsShowingText = true;
			base.Text = text;
		}

		public void HideText()
		{
			if (!IsShowingText)
				return;

			IsShowingText = false;
			base.Text = "";
		}

		public void RegisterMenuButton(string text, object backColor = null, object foreColor = null, object tag = null, Size size = default)
		{
			if (text == "")
			{
				MouseEnter -= OnMouseEnter;
				MouseLeave -= OnMouseLeave;
				MenuButton.MouseEnter -= OnMouseEnter;
				MenuButton.MouseLeave -= OnMouseLeave;
				MenuButton.Click -= OnMenuButtonClick;

				Controls.Remove(MenuButton);
				MenuButton.Dispose();

				if (Image == null && ParentList.ItemTextAlign == ContentAlignment.MiddleCenter)
					TextAlign = ContentAlignment.MiddleCenter;

				return;
			}

			backColor = backColor ?? normalBackColor;
			foreColor = foreColor ?? ForeColor;

			Font font = new Font(Font.FontFamily, Math.Max(Font.Size - 2, 10), FontStyle.Italic);

			if (MenuButton == null)
			{
				MenuButton = new Carbobutton()
				{
					Height = size.Height > 0 ? size.Height : Height,
					BackColor = (Color)backColor,
					ForeColor = (Color)foreColor,
					Font = font,
					FlatStyle = FlatStyle.Flat,
					Visible = false,
				};

				MenuButton.FlatAppearance.BorderSize = 0;

				this.AddControl(MenuButton);

				MouseEnter += OnMouseEnter;
				MouseLeave += OnMouseLeave;
				MenuButton.MouseEnter += OnMouseEnter;
				MenuButton.MouseLeave += OnMouseLeave;
				MenuButton.Click += OnMenuButtonClick;

				if (TextAlign != ContentAlignment.MiddleLeft
					&& ParentList.ItemTextAlign == ContentAlignment.MiddleCenter)
				{
					TextAlign = ContentAlignment.MiddleLeft;
				}
			}

			MenuButton.Width = size.Width > 0 ? size.Width : (TextRenderer.MeasureText(text, font).Width * 1.2).Round();
			MenuButton.Left = Width - MenuButton.Width;
			MenuButton.Text = text;
			MenuButton.Tag = tag;
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################

		public event EventHandler MenuButtonClick;

		protected void OnMouseEnter(object sender, EventArgs e)
		{
			if (MenuButton == null || MenuButton.Visible)
				return;

			if (IsShowingMenuButton && ParentList.AreItemsShowingMenuButtons)
				MenuButton.Visible = true;
		}

		protected void OnMouseLeave(object sender, EventArgs e)
		{
			if (MenuButton == null || !MenuButton.Visible)
				return;

			if (this.IsMouseEntered())
				return;

			MenuButton.Visible = false;
		}

		protected void OnMenuButtonClick(object sender, EventArgs e)
		{
			MenuButtonClick(this, e);

			MenuButton.Visible = false;
		}

	}

}
