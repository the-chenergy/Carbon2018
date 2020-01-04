using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carboutil
{

	public class CarboRtfConverter
	{

		/// ########################## PUBLIC PROPERTIES ############################



		/// ######################### PRIVATE PROPERTIES ############################

		static protected RichTextBox rtb = new RichTextBox();

		/// ########################### PUBLIC METHODS ##############################

		static public string ToNormalText(string rtfText)
		{
			rtb.Rtf = rtfText;

			return rtb.Text;
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
