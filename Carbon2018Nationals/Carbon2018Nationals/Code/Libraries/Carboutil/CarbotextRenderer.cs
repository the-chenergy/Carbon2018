using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carboutil
{

	public class CarbotextRenderer
	{

		/// ########################## PUBLIC PROPERTIES ############################



		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################

		static public int MeasureText(string text, Font font)
		{
			TextFormatFlags flags = (
				TextFormatFlags.Left
				| TextFormatFlags.Top
				| TextFormatFlags.NoPadding
				| TextFormatFlags.NoPrefix
			);

			Size size1 = TextRenderer.MeasureText("GOSH DANG THIS", font, new Size(int.MaxValue, int.MaxValue), flags);
			Size size2 = TextRenderer.MeasureText(text + "GOSH DANG THIS", font, new Size(int.MaxValue, int.MaxValue), flags);

			return size2.Width - size1.Width;
		}

		/// ########################### PRIVATE METHODS #############################



	}

}
