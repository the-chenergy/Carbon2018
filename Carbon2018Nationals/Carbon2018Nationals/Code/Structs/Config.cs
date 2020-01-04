using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbon
{

	public class Config
	{

		/// ############################# CONSTRUCTOR ###############################

		public Config()
		{
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public string SavedLoginUsername;
		public string SavedLoginPassword;
		public bool IsDebugging;
		public bool PlayWelcomeAndGoodbyeSounds;
		public bool PlayBackgroundMusic;
		public bool AutoLogin;
		public bool UsernameOnlyLogin;
		public bool DarkenUnselectListItems;

		/// ######################### PRIVATE PROPERTIES ############################

		protected string[] properties =
		{
			"bool", "IsDebugging",
			"bool", "PlayWelcomeAndGoodbyeSounds",
			"bool", "PlayBackgroundMusic",
			"string", "SavedLoginUsername",
			"string", "SavedLoginPassword",
			"bool", "AutoLogin",
			"bool", "UsernameOnlyLogin",
			"bool", "DarkenUnselectListItems",
		};

		/// ########################### PUBLIC METHODS ##############################

		public bool LoadConfig(string url)
		{
			if (url == null)
				return false;

			try
			{
				string[] strings = File.ReadAllLines(url);

				// remove comments (//...)
				for (int i = 0, l = strings.Length; i < l; i++)
				{
					int index;

					if ((index = strings[i].IndexOf("//")) >= 0)
						strings[i] = strings[i].Substring(0, index);
				}

				// assign values
				for (int i = 0, l = properties.Length; i < l; i++)
					ParseValue(properties[i], strings[i / 2], properties[++i]);
			}
			catch
			{
			}
			
			return true;
		}

		/// ########################### PRIVATE METHODS #############################

		protected void ParseValue(string type, string value, string assignTo)
		{
			object actualValue = null;

			switch (type)
			{
				case "string":
					actualValue = value;
					break;

				case "int":
					actualValue = int.TryParse(value, out int tempInt) ? tempInt : 0;
					break;

				case "bool":
					actualValue = bool.TryParse(value, out bool tempBool) && tempBool;
					break;
			}

			GetType().GetField(assignTo).SetValue(this, actualValue);
		}

		/// ############################### EVENTS ##################################


	}

}
