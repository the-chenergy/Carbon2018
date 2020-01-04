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

		/// ***************************** CONSTUCTOR ********************************

		/// <summary>
		/// Creates a new CarbolistItem instance.
		/// </summary>
		/// <param name="title">The default title of the CarbolistItem.</param>
		/// <param name="color">The default background color of the CarbolistItem (default: pure black).</param>
		/// <param name="selectedColor">The default background color when this CarbolistItem is selected (default: pure yellow).</param>
		/// <param name="size">The default size of the CarbolistItem.</param>
		/// <param name="font">The default font of the CarbolistItem.</param>
		/// <param name="location">The default location for the CarbolistItem.</param>
		/// <param name="data">The linked data of this CarbolistItem.</param>
		/// <param name="parent">The reference to the related Carbolist.</param>
		public CarbolistItem(
			string title,
			Color color,
			Color selectedColor,
			Size size,
			Point location,
			Font font,
			object data,
			Carbolist parent)
			: base(title, color, size, location, font, data)
		{
			normalBackColor = Background.BackColor;

			if (selectedColor == null)
				selectedBackColor = rg.b(0x00FF00);
			else
				selectedBackColor = selectedColor;

			ParentList = parent;
		}

		/// ************************** PUBLIC PROPERTIES ****************************

		/// <summary>Get/set whether this list-item is selected.</summary>
		public bool Selected
		{
			get
			{
				return Background.BackColor == selectedBackColor;
			}
			set
			{
				if (value)
					Background.BackColor = selectedBackColor;
				else
					Background.BackColor = normalBackColor;
			}
		}

		/// ************************* PRIVATE PROPERTIES ****************************

		/// <summary>[ReadOnly] The related Carbolist instance.</summary>
		public Carbolist ParentList { get; protected set; }

		protected Color normalBackColor;
		protected Color selectedBackColor;

		/// *************************** PUBLIC METHODS ******************************

		/// <summary>
		/// Change the background color of this item.
		/// If this item is selected, the change will be applied when this is unselected.
		/// </summary>
		/// <param name="color">The new background color.</param>
		public void ChangeBackColor(Color color)
		{
			normalBackColor = color;

			if (!Selected)
				Background.BackColor = color;
		}

		/// *************************** PRIVATE METHODS *****************************



		/// ******************************* EVENTS **********************************



	}

}
