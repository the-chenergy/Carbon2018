using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarboUiComponent
{

	/// <summary>
	/// A scrollable container of controls.
	/// </summary>
	public class Carbopanel : UserControl
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// Creates a new Carbopanel instance.
		/// </summary>
		public Carbopanel()
		{
			Panel = new UserControl()
			{
				Height = 0
			};

			ScrollBar = new Carboscrollbar(OnScrollBarDragged, ForeColor, BackColor, scrollBarWidth = 10)
			{
				Visible = false,
			};

			Controls.Add(Panel);
			Controls.Add(ScrollBar);
		}

		/// ########################## PUBLIC PROPERTIES ############################

		/// <summary>A Label instance where the new added Labels and TextBoxes will copy their formats and styles from.</summary>
		public Label SampleLabel { get; set; }

		/// ######################### PRIVATE PROPERTIES ############################

		/// <summary>[ReadOnly] The Carboscrollbar instance in this Carbopanel.</summary>
		public Carboscrollbar ScrollBar { get; protected set; }

		/// <summary>[ReadOnly] The Container of all added controls.</summary>
		public UserControl Panel { get; protected set; }

		protected int scrollBarWidth;
		protected int currentY;
		protected int margin;
		protected int padding;

		/// ########################### PUBLIC METHODS ##############################

		public void AddSpace(int spaceHeight)
		{
			if (Panel.Controls.Count == 0)
				return;

			(Panel.Controls[Panel.Controls.Count - 1].Tag as LocationInfo).Spacing += spaceHeight;
		}

		/// <summary>
		/// Adds a Control to this Carbopanel.
		/// </summary>
		/// <param name="control">The Control to add.</param>
		/// <param name="fillWidth">Whether this Control should resize itself to fill this Carbopanel horizontally at all time.</param>
		/// <param name="align">The horizontal alignment of this Control.</param>
		/// <returns></returns>
		public Control AddControl(Control control, bool fillWidth = false, HorizontalAlignment align = default)
		{
			control.Tag = new LocationInfo(fillWidth, 0, align);

			control.MaximumSize = new Size(Panel.Width, int.MaxValue);

			if (fillWidth)
				control.Width = Panel.Width - control.Margin.Left;

			switch (align)
			{
				case HorizontalAlignment.Left:
					control.Left = 0;
					break;

				case HorizontalAlignment.Center:
					control.Left = (Panel.Width - control.Width) / 2;
					break;

				case HorizontalAlignment.Right:
					control.Left = Panel.Width - control.Width;
					break;
			}

			return AddChildControl(control);
		}

		/// <summary>
		/// Adds a Label with custom styles to this Carbopanel. The new Label will copy the format and style from SampleLabel.
		/// </summary>
		/// <param name="text">The text in the Label.</param>
		/// <param name="size">The font size of the text in the Label. -1 represents the same font size as SampleLabel.</param>
		/// <param name="color">The text color of the new Label. Passing null will use the ForeColor of SampleLabel.</param>
		/// <param name="backColor">The background color of the new Label. Passing null will use the BackColor of SampleLabel.</param>
		/// <param name="style">The font style of the text in the Label. Passing null will use the FontStyle of SampleLabel.</param>
		/// <param name="align">The horizontal alignment of the new Label.</param>
		/// <returns></returns>
		public Label AddLabel(string text, float size = -1, object color = null, object backColor = null, object style = null, HorizontalAlignment align = default)
		{
			Font font = null;

			if (size == -1 && style == null)
				font = SampleLabel?.Font ?? Font;
			else
				font = new Font((SampleLabel?.Font ?? Font).FontFamily, size, (FontStyle)style);

			return AddControl(new Label()
			{
				AutoSize = true,
				MaximumSize = new Size(Panel.Width, 0),
				BackColor = (Color)(backColor ?? SampleLabel?.BackColor ?? BackColor),
				ForeColor = (Color)(color ?? SampleLabel?.ForeColor ?? ForeColor),
				Font = font,
				Text = text,
			}, false, align) as Label;
		}

		public Carbotextbox AddText(string text, float size = -1, object color = null, object backColor = null, object style = null, HorizontalAlignment align = default)
		{
			Font font = null;

			if (size == -1 && style == null)
			{
				font = SampleLabel?.Font ?? Font;
			}
			else
			{
				font = new Font((SampleLabel?.Font ?? Font).FontFamily, size, (FontStyle)(style ?? (SampleLabel?.Font ?? Font).Style));
			}

			return AddControl(new Carbotextbox()
			{
				AutoSize = true,
				MaximumSize = new Size(Panel.Width, 0),
				BorderStyle = BorderStyle.None,
				Editable = false,
				Multiline = true,
				WordWrap = true,
				BackColor = (Color)(backColor ?? SampleLabel?.BackColor ?? BackColor),
				ForeColor = (Color)(color ?? SampleLabel?.ForeColor ?? ForeColor),
				Font = font,
				Text = text,
			}, false, align) as Carbotextbox;
		}

		public PictureBox AddImage(Image image, object size = null, HorizontalAlignment align = default)
		{
			PictureBox pictureBox = new PictureBox()
			{
				BackColor = BackColor,
				BackgroundImage = image,
			};

			if (size == null)
			{
				pictureBox.Size = image.Size;
			}
			else
			{
				pictureBox.Size = (Size)size;
				pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
			}

			return AddControl(pictureBox, false, align) as PictureBox;
		}

		public void RemoveAllControls()
		{
			Panel.Controls.Clear();

			currentY = margin;

			Panel.Height = ScrollBar.Total = margin * 2;
			ScrollBar.Visible = false;

			UpdatePanelLocation();
		}

		/// ########################### PRIVATE METHODS #############################

		protected Control AddChildControl(Control control)
		{
			control.Parent?.Controls.Remove(control);

			Panel.Controls.Add(control);

			control.Visible = true;
			control.Top = currentY;

			int extraHeight = control.Height + padding;

			currentY += extraHeight;
			Panel.Height += extraHeight;
			ScrollBar.Total += extraHeight;

			if (!ScrollBar.Visible)
				ScrollBar.Visible = (ScrollBar.Total > ScrollBar.Capacity);

			if (ScrollBar.Value != 0)
			{
				ScrollBar.Value = 0;
				UpdatePanelLocation();
			}

			return control;
		}

		protected void RefreshLayout()
		{
			if (Parent == null) // only when this panel is not added to view
				Panel.Location = new Point(margin, margin);

			Panel.Width = Width - margin * 3 - scrollBarWidth;

			// update controls

			if (Panel.Controls.Count > 0)
			{
				currentY = margin;

				foreach (Control p in Panel.Controls)
				{
					LocationInfo locationInfo = p.Tag as LocationInfo;

					p.MaximumSize = new Size(Panel.Width, int.MaxValue);

					if (locationInfo.FillWidth)
						p.Width = Panel.Width - p.Margin.Left;

					switch (locationInfo.Align)
					{
						case HorizontalAlignment.Center:
							p.Left = (Panel.Width - p.Width) / 2;
							break;

						case HorizontalAlignment.Right:
							p.Left = Panel.Width - p.Width;
							break;
					}

					p.Top = currentY;

					currentY += p.Height + padding + locationInfo.Spacing;
				}

				Panel.Height = Panel.Controls[Panel.Controls.Count - 1].Bottom + margin;
			}

			ScrollBar.Location = new Point(Width - margin - ScrollBar.Width, margin);
			ScrollBar.Height = ScrollBar.Capacity = Height - margin * 2;
			ScrollBar.Total = Panel.Height;

			UpdatePanelLocation();
		}

		protected void UpdatePanelLocation()
		{
			Panel.Top = -ScrollBar.Value;
		}

		/// ############################### EVENTS ##################################

		override protected void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);

			RefreshLayout();
		}

		override protected void OnMarginChanged(EventArgs e)
		{
			base.OnMarginChanged(e);

			margin = Margin.Left;

			currentY = (Panel.Controls.Count > 0 ? Panel.Controls[Panel.Controls.Count - 1].Bottom : 0) + margin;

			RefreshLayout();
		}

		override protected void OnPaddingChanged(EventArgs e)
		{
			base.OnPaddingChanged(e);

			padding = Padding.Left;

			RefreshLayout();
		}

		override protected void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged(e);

			ScrollBar.BackColor = ControlPaint.Light(BackColor, .20f);
			ScrollBar.ForeColor = ControlPaint.Light(BackColor, .70f);
		}

		override protected void OnMouseWheel(MouseEventArgs e)
		{
			if (!ScrollBar.Visible)
				return;

			ScrollBar.Value -= Math.Sign(e.Delta) * SystemInformation.MouseWheelScrollLines * 40;

			UpdatePanelLocation();
		}

		protected void OnScrollBarDragged(int value)
		{
			UpdatePanelLocation();
		}

		/// *************** EXTENSIONS ***************

		protected class LocationInfo
		{

			public LocationInfo(bool fillWidth = false, int space = 0, HorizontalAlignment align = default)
			{
				FillWidth = fillWidth;
				Spacing = space;
				Align = align;
			}

			public bool FillWidth;
			public int Spacing;
			public HorizontalAlignment Align;

		}

	}

}
