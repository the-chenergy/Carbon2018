using Carbolibrary;
using Carbon;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{

	static public class Global
	{

		static public Config Config = new Config();

		static public Size HelpFormSize = default;

		static public Regex MultiSpaceFilter = new Regex(@"[ ]+");

		static public bool IsTabPressed = false;

		static public class SpecialString
		{

			static public string X = "×";
			static public string DownArrow = "▼";

			static public char PasswordChar = '•';

		}

	}

}
