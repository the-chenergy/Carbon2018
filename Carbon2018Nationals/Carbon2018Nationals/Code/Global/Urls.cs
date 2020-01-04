using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{

	public class Urls
	{

		/// ########################## PUBLIC PROPERTIES ############################

		///////static public string Database = @"../Data/32Groups64Meetings.db";

		static public string Database = "Carbon.db";
		static public string FileManager = "Files";
		static public string Config = "Config.ini";
		static public string Prefs = "Prefs.ini";
		static public string BackgroundMusic = "Music.mp3";

		/// ######################### PRIVATE PROPERTIES ############################

		static protected string[] dataUrls =
		{
			"",
			@"../Data/",
			@"../../Data/",
			@"../../../Data/",
			@"Data/",
			@"DontDeleteThisStefan/Data/",
			@"Carbon/DontDeleteThisStefan/Data/"
		};

		/// ########################### PUBLIC METHODS ##############################

		/// <summary>
		/// Tries to find the actual relative url for a given file name.
		/// </summary>
		static public string TrySolveDataUrl(string fileName)
		{
			string temp;tra.ce(fileName);

			foreach (string p in dataUrls)
			{
				if (File.Exists(temp = p + fileName) || Directory.Exists(temp = p + fileName))
					return temp;
			}

			return null;
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
