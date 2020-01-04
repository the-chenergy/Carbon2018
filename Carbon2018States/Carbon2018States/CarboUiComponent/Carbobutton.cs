using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarboUiComponent
{

	/// <summary>
	/// A good-looking button class by Carbon.
	/// </summary>
	public class Carbobutton : UserControl
	{

		/// ***************************** CONSTUCTOR ********************************

		/// <summary>
		/// Creates a new Carbobutton instance.
		/// </summary>
		/// <param name="titleOrSampleButton">The title of the Carbobutton, or a sample button where this Carbobutton will copy its other properties from.</param>
		/// <param name="color">The default background color of the Carbobutton (default: pure black).</param>
		/// <param name="size">The default size of the Carbobutton.</param>
		/// <param name="location">The default location of the Carbobutton.</param>
		/// <param name="font">The default font of the Carbobutton.</param>
		/// <param name="data">The linked data of this Carbobutton.</param>
		public Carbobutton(
			object titleOrSampleButton = null,
			object color = null,
			object size = null,
			object location = null,
			Font font = null,
			object data = null)
		{
			object foreColor = null;

			if (titleOrSampleButton is Button)
			{
				Button sample = titleOrSampleButton as Button;

				font = sample.Font;
				location = sample.Location;
				size = sample.Size;
				color = sample.BackColor;
				foreColor = sample.ForeColor;
				titleOrSampleButton = sample.Text;

				if (sample.Parent != null)
					sample.Parent.Controls.Remove(sample);

				if (!sample.IsDisposed)
					sample.Dispose();
			}
			else if (!(titleOrSampleButton is String))
			{
				throw new Exception("Argument sizeOrSampleButton must be the type of either Size or Button.");
			}

			Background = new Button()
			{
				BackColor = rg.b(0x000000),
				FlatStyle = FlatStyle.Flat,
				ForeColor = rg.b(0xDEDEDE),
				Size = new Size(150, 50),
				Text = (string)titleOrSampleButton,
			};

			Background.FlatAppearance.BorderSize = 0;
			Background.Click += OnBackgroundClick;

			Controls.Add(Background);

			if (color != null)
				Background.BackColor = (Color)color;

			if (foreColor != null)
				Background.ForeColor = (Color)foreColor;
			
			if (size != null)
				Background.Size = (Size)size;
			
			if (font != null)
				Background.Font = font;

			Location = (Point)location;
			Size = Background.Size;
			Data = data;
		}

		/// ************************** PUBLIC PROPERTIES ****************************

		/// <summary>The callback of click event.</summary>
		public Action<Carbobutton> OnClick;

		/// <summary>The data provider linked with this Carbobutton.</summary>
		public object Data { get; set; }

		/// <summary>The text on this Carbobutton.</summary>
		public string Title
		{
			get
			{
				return Background.Text;
			}
			set
			{
				Background.Text = value;
			}
		}

		/// ************************* PRIVATE PROPERTIES ****************************

		/// <summary>[ReadOnly] A reference to the background button instance.</summary>
		public Button Background { get; protected set; }

		/// *************************** PUBLIC METHODS ******************************



		/// *************************** PRIVATE METHODS *****************************



		/// ******************************* EVENTS **********************************

		protected void OnBackgroundClick(object target, EventArgs e)
		{
			OnClick?.Invoke(this);
		}

	}

}
