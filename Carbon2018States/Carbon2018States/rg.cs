using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{

	/// <summary>
	/// This is a method, not a class!!!
	/// </summary>
	public class rg
	{

		/// <summary>
		/// Returns the RGB Color represented by an uint number.
		/// </summary>
		/// <param name="color">The uint form of the color such as 0x123456.</param>
		static public Color b(uint color)
		{
			return Color.FromArgb(255, (byte)((color & 0xFF0000) >> 0x10),
							  (byte)((color & 0x00FF00) >> 8),
							  (byte)(color & 0x0000FF));
		}

	}

}
