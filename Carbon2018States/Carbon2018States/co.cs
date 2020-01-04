using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontDeleteThisStefan
{

	public class co
	{

		static public Color lor(uint color)
		{
			return Color.FromArgb((byte)((color & 0xFF000000) >> 0x18),
							  (byte)((color & 0x00FF0000) >> 0x10),
							  (byte)((color & 0x0000FF00) >> 8),
							  (byte)(color & 0x000000FF));
		}

	}

}
