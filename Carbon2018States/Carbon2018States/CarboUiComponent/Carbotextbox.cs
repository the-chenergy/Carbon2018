using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarboUiComponent
{

	/// <summary>
	/// An advanced textbox that can show a watermark when no text is input.
	/// </summary>
	public class Carbotextbox : TextBox
	{

		/// ***************************** CONSTUCTOR ********************************

		/// <summary>
		/// Creates a new Carbotextbox instance.
		/// </summary>
		/// <param name="watermark">The default watermark.</param>
		/// <param name="sampleTextBox">A sample TextBox object where this Carbotextbox will copy its properties from.</param>
		public Carbotextbox(string watermark = "", TextBox sampleTextBox = null)
		{
			if (sampleTextBox != null)
			{
				BackColor = sampleTextBox.BackColor;
				BorderStyle = sampleTextBox.BorderStyle;
				Font = sampleTextBox.Font;
				ForeColor = sampleTextBox.ForeColor;
				Location = sampleTextBox.Location;
				Multiline = sampleTextBox.Multiline;
				Size = sampleTextBox.Size;
				TextAlign = sampleTextBox.TextAlign;

				if (sampleTextBox.Parent != null)
					sampleTextBox.Parent.Controls.Remove(sampleTextBox);

				if (!sampleTextBox.IsDisposed)
					sampleTextBox.Dispose();
			}

			Enter += OnThisEnter;
			Leave += OnThisLeave;

			AcceptsTab = true;

			Watermark = watermark;
		}

		/// ************************** PUBLIC PROPERTIES ****************************

		/// <summary>[Override] The fore color of this Carbotextbox.</summary>
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}

			set
			{
				base.ForeColor = foreColor = value;
			}
		}

		/// <summary>[Override] The text in this Carbotextbox.</summary>
		public override string Text
		{
			get
			{
				return base.Text;
			}

			set
			{
				base.Text = value;

				if (!Focused)
				{
					if (value == "")
						OnThisLeave(null, null);
					else
						OnThisEnter(null, null);
				}
			}
		}

		/// <summary>A gray text that will show up when the Carbotextbox is empty and deselected.</summary>
		public string Watermark
		{
			get
			{
				return watermark.Substring(watermark.Length - 4);
			}

			set
			{
				if (value == null)
					throw new Exception("Property WaterPrint must be non-null.");

				watermark = value + "  \t ";

				if (!Focused)
					OnThisLeave(null, null); // update waterprint display
			}
		}

		/// <summary>[ReadOnly] The raw text in this Carbotextbox.</summary>
		public string RawText
		{
			get
			{
				if (Text == watermark)
					return "";

				return Text;
			}
		}

		/// ************************* PRIVATE PROPERTIES ****************************

		protected Color foreColor;
		protected string watermark;

		/// *************************** PUBLIC METHODS ******************************



		/// *************************** PRIVATE METHODS *****************************



		/// ******************************* EVENTS **********************************

		protected void OnThisEnter(object target, EventArgs e)
		{
			if (Text == watermark)
				base.Text = "";

			base.ForeColor = foreColor;
		}

		protected void OnThisLeave(object target, EventArgs e)
		{
			if (Text == "")
			{
				base.Text = watermark;

				base.ForeColor = Color.Gray;
			}
		}

	}

}
