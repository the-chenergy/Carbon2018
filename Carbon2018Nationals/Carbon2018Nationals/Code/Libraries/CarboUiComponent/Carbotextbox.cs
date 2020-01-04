using Carboutil;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarboUiComponent
{

	/// <summary>
	/// An advanced textbox that can show a watermark when no text is input.
	/// </summary>
	public class Carbotextbox : TextBox
	{

		/// ############################# CONSTRUCTOR ###############################

		public Carbotextbox()
		{
			// the code below enables Ctrl+Backspace shortcuts!
			AutoCompleteSource = AutoCompleteSource.CustomSource;
			AutoCompleteMode = AutoCompleteMode.Suggest;

			Enter += OnEnter;
			Leave += OnLeave;
			MouseDown += OnMouseDown;
			TextChanged += OnTextChanged;
			GotFocus += OnGotFocus;
			ReadOnlyChanged += OnReadOnlyChanged;

			BackColorChanged += OnBackColorChanged;
			ForeColorChanged += OnForeColorChanged;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		[DefaultValue(false)]
		public bool ConvertSpacesToUnderscores { get; set; }

		[DefaultValue(BorderStyle.None)]
		public BorderStyle BorderStyleWhenEditing { get; set; } = BorderStyle.None;

		[DefaultValue(typeof(Color), "DimGray")]
		public Color BorderColor { get; set; } = Color.DimGray;

		[DefaultValue(typeof(Color), "Transparent")]
		public Color BackColorWhenEditing { get; set; } = Color.Transparent;

		[DefaultValue(typeof(Color), "DimGray")]
		public Color WatermarkColor { get; set; } = Color.DimGray;

		/// <summary>[Override] The text in this Carbotextbox.</summary>
		new public string Text
		{
			get => RawText;

			set
			{
				base.Text = value;

				if (!Focused)
				{
					if (RawText == "")
						OnLeave(null, null);
					else if (Parent != null)
						OnEnter(null, null);
				}
			}
		}

		/// <summary>[Override] The text without watermark in this Carbotextbox.</summary>
		public string RawText
		{
			get
			{
				if (PasswordChar != default)
					return base.Text;

				if (base.Text.Length >= 4 && base.Text.Substring(base.Text.Length - 4) == "  \t ")
					return "";

				if (Multiline)
					return base.Text.Replace(n.l, "\n");

				return base.Text;
			}
		}

		/// <summary>A gray text that will show up when the Carbotextbox is empty and deselected.</summary>
		public string Watermark
		{
			get => watermark;

			set
			{
				rawWatermark = value;
				watermark = value + "  \t ";

				// update waterprint display

				if (!Focused && base.Text.Length >= 4 && base.Text.Substring(base.Text.Length - 4) == "  \t ")
				{
					base.Text = watermark;

					OnLeave(null, null);
				}
			}
		}

		public string Restrict
		{
			get => restrict;

			set
			{
				restrict = value;
				regex = new Regex(value ?? "");

				OnTextChanged(null, null);
			}
		}

		[DefaultValue(true)]
		public bool Editable
		{
			get => !ReadOnly;

			set
			{
				ReadOnly = !value;
			}
		}

		[DefaultValue(false)]
		override public bool AutoSize
		{
			get => autoSize;

			set
			{
				if (autoSize = value)
					UpdateSize();
			}
		}

		/// ######################### PRIVATE PROPERTIES ############################

		protected Color backColor;
		protected Color foreColor;
		protected Regex regex;
		protected string restrict = "";
		protected string watermark = "  \t ";
		protected string rawWatermark = "";
		protected bool autoSize;

		/// ########################### PUBLIC METHODS ##############################

		/// <summary>
		/// Sets the ForeColor of this Carbotextbox instance.
		/// </summary>
		public void SetForeColor(Color color)
		{
			foreColor = color;

			if (Text != "")
				base.ForeColor = color;
		}

		/// ########################### PRIVATE METHODS #############################

		[DllImport("User32.dll", EntryPoint = "HideCaret")]
		static protected extern long HideCaret(IntPtr handle);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		static protected extern IntPtr GetWindowDC(IntPtr handle);

		protected void UpdateSize()
		{
			Size = CreateGraphics().MeasureString(base.Text, Font, MaximumSize.Width, default).ToSize();
		}

		/// ############################### EVENTS ##################################

		override protected bool ProcessCmdKey(ref Message message, Keys keys)
		{
			if (Editable)
			{
				switch (keys)
				{
					case Keys.Control | Keys.A:
						if (!ShortcutsEnabled)
						{
							SelectAll();

							return true;
						}
						break;

					case Keys.Control | Keys.Back:
						if (PasswordChar != default)
						{
							SendKeys.SendWait("^+{LEFT}{BACKSPACE}");

							return true;
						}
						break;

					case Keys.Space:
						if (ConvertSpacesToUnderscores)
						{
							SendKeys.Send("{_}");

							return true;
						}
						break;
				}
			}

			return base.ProcessCmdKey(ref message, keys);
		}

		protected void OnTextChanged(object sender, EventArgs e)
		{
			if (autoSize)
				UpdateSize();

			if (restrict == "" || RawText == "")
				return;

			int tempLength = TextLength;
			int tempSelection = SelectionStart;

			base.Text = regex.Replace(Text, "");

			SelectionStart = (tempSelection - tempLength + base.Text.Length).SnapBetween(0, base.Text.Length);
		}

		protected void OnBackColorChanged(object sender, EventArgs e)
		{
			BackColorChanged -= OnBackColorChanged;

			backColor = BackColor;
		}

		protected void OnForeColorChanged(object sender, EventArgs e)
		{
			ForeColorChanged -= OnForeColorChanged;

			foreColor = ForeColor;
		}

		protected void OnEnter(object sender, EventArgs e)
		{
			if (RawText == "")
				base.Text = "";

			base.ForeColor = foreColor;
		}

		protected void OnLeave(object sender, EventArgs e)
		{
			if (PasswordChar != default)
				return;

			if (RawText == "")
			{
				base.Text = watermark;
				base.ForeColor = WatermarkColor;
			}
		}

		protected void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (ReadOnly)
				HideCaret(Handle);
		}

		protected void OnGotFocus(object sender, EventArgs e)
		{
			if (ReadOnly)
				HideCaret(Handle);
		}

		protected void OnReadOnlyChanged(object sender, EventArgs e)
		{
			if (Focused && ReadOnly)
				HideCaret(Handle);

			if (BorderStyleWhenEditing != BorderStyle.None)
				BorderStyle = ReadOnly ? BorderStyle.None : BorderStyleWhenEditing;

			if (BackColorWhenEditing != Color.Transparent)
				BackColor = ReadOnly ? backColor : BackColorWhenEditing;
		}

		override protected void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (BorderColor == Color.DimGray || BorderStyle != BorderStyle.FixedSingle)
				return;

			IntPtr wDC = GetWindowDC(Handle);
			Graphics graphics = Graphics.FromHdc(wDC);

			ControlPaint.DrawBorder(
				graphics,
				new Rectangle(default, Size),
				Focused || this.IsMouseEntered() ? ControlPaint.Light(BorderColor, .20f) : BorderColor,
				ButtonBorderStyle.Solid
			);

			graphics.Dispose();
		}

	}

}
