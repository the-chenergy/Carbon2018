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

	public class Carboscrollbar : UserControl
	{

		/// ############################# CONSTRUCTOR ###############################

		public Carboscrollbar(Action<int> onDragged = null, object color = null, object backColor = null, int width = 6, int offset = 0)
		{
			if (color == null)
				color = Color.White;

			if (backColor == null)
				backColor = Color.Black;

			OnDragged = onDragged;
			this.offset = offset;

			Controls.Add(Slider = new Carbobutton()
			{
				BackColor = (Color)color,
				FlatStyle = FlatStyle.Flat,
				Location = new Point(offset + 1, 1),
			});

			Controls.Add(Background = new PictureBox()
			{
				BackColor = (Color)backColor,
				Left = offset,
			});

			Slider.FlatAppearance.BorderSize = 0;

			baseWidth = origWidth = width;
			Size = new Size(width, 20);

			Capacity = 1;

			Slider.MouseEnter += OnSliderMouseEnter;
			Slider.MouseLeave += OnSliderMouseLeave;
			Slider.MouseDown += OnSliderMouseDown;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Action<int> OnDragged { get; set; }

		override public Color BackColor
		{
			get => base.BackColor;

			set
			{
				base.BackColor = Background.BackColor = value;
			}
		}

		override public Color ForeColor
		{
			get => Slider.BackColor;

			set
			{
				Slider.BackColor = value;
			}
		}

		public int Value
		{
			get => current;

			set
			{
				current = value.SnapBetween(0, Math.Max(total - capacity, 0));

				Slider.Top = range * current / (total == 0 ? 1 : total) + 1;

				//tra.ce(Slider.Height + "/" + range, current + "/" + Total + " (" + Capacity + ")");
			}
		}

		public int Capacity
		{
			get => capacity;

			set
			{
				if (value < 0)
					throw new Exception("Invalid capacity!");

				capacity = Math.Max(value, 1);

				current = Math.Min(current, Math.Max(total - capacity, 0));

				Slider.Height = Math.Min(range * capacity / (total == 0 ? 1 : total), range) + 1;
				Slider.Top = range * current / (total == 0 ? 1 : total) + 1;
			}
		}

		public int Total
		{
			get => total;

			set
			{
				total = Math.Max(value, 0);

				current = Math.Min(current, Math.Max(total - capacity, 0));

				Slider.Height = Math.Min(range * capacity / (value == 0 ? 1 : value), range);
				Slider.Top = range * current / (value == 0 ? 1 : value) + 1;
			}
		}

		/// ######################### PRIVATE PROPERTIES ############################

		public PictureBox Background { get; protected set; }
		public Carbobutton Slider { get; protected set; }

		protected int total;
		protected int capacity = 1;
		protected int current;
		protected int range;
		protected int draggingStartY;
		protected int origWidth;
		protected int baseWidth;
		protected int offset;
		protected bool isMouseEntered;

		/// ########################### PUBLIC METHODS ##############################



		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################

		override protected void OnLayout(LayoutEventArgs e)
		{
			if (Parent == null)
				return;

			Background.Width = Width;
			Slider.Width = Background.Width - 2;

			Background.Left = isMouseEntered ? 0 : offset;
			Slider.Left = Background.Left + 1;

			Left += origWidth - Width;
			origWidth = Width;

			Background.Height = Height;
			range = Height - 2;
			Slider.Height = ((double)capacity / total * range).Round();
		}

		override protected void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (offset == 0 || Parent == null)
				return;

			e.Graphics.FillRectangle(
				new SolidBrush(Parent.BackColor),
				0, 0, Background.Left, Height
			);
		}

		protected void OnSliderMouseEnter(object sender, EventArgs e)
		{
			isMouseEntered = true;

			if (baseWidth - offset > 15)
				return;

			Width = baseWidth + Math.Max(8 - offset, 1);
		}

		protected void OnSliderMouseLeave(object sender, EventArgs e)
		{
			isMouseEntered = false;

			if (baseWidth - offset > 15)
				return;

			Width = baseWidth;
		}

		protected void OnSliderMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			draggingStartY = e.Y;

			Slider.MouseMove += OnSliderMouseMove;
			Slider.MouseUp += OnSliderMouseUp;
		}

		protected void OnSliderMouseMove(object sender, MouseEventArgs e)
		{
			int topLimit = 1;
			int bottomLimit = Height - Slider.Height - 1;

			Slider.Top = (e.Y + Slider.Top - draggingStartY).SnapBetween(topLimit, bottomLimit);

			current = ((Slider.Top - 1) * total / range).SnapBetween(0, total - capacity);

			/*
			 * sld.y     current
			 * ---- = ------
			 * range      total
			 */

			OnDragged?.Invoke(current);
		}

		protected void OnSliderMouseUp(object sender, MouseEventArgs e)
		{
			Slider.MouseMove -= OnSliderMouseMove;
			Slider.MouseUp -= OnSliderMouseUp;
		}

	}

}
