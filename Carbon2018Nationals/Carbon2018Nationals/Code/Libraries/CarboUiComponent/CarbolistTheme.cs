using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarboUiComponent
{

	public struct CarbolistTheme
	{

		/// <summary>
		/// Light blue sample color theme.
		/// </summary>
		static public readonly CarbolistTheme LightBlue = new CarbolistTheme()
		{
			FirstItemBackColor = Color.FromArgb(24, 87, 236),
			SecondItemBackColor = Color.FromArgb(40, 102, 255),
			DefaultItemBackColor = Color.FromArgb(16, 37, 94),
			SelectedItemBackColor = Color.FromArgb(204, 146, 25),
			ItemForeColor = Color.FromArgb(222, 222, 222),
			DefaultItemForeColor = Color.FromArgb(153, 153, 153),
			ScrollBarBackColor = Color.FromArgb(16, 50, 148),
			ScrollBarForeColor = Color.FromArgb(81, 151, 232),
			MenuButtonBackColor = Color.FromArgb(4, 24, 38),
		};

		/// ########################## PUBLIC PROPERTIES ############################

		public Color FirstItemBackColor;
		public Color SecondItemBackColor;
		public Color DefaultItemBackColor;
		public Color SelectedItemBackColor;
		public Color ScrollBarBackColor;
		public Color MenuButtonBackColor;
		public Color ItemForeColor;
		public Color DefaultItemForeColor;
		public Color ScrollBarForeColor;

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################

		

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
