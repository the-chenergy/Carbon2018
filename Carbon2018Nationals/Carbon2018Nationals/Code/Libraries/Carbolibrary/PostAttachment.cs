using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	public class PostAttachment
	{

		/// ############################# CONSTRUCTOR ###############################

		public PostAttachment(string url = "", Image icon = null, long size = 0, int id = -1)
		{
			Url = url;
			Icon = icon;
			Size = size;
			Id = id;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Image Icon { get; set; }

		public string Url
		{
			get => url;

			set
			{
				url = value;

				Name = url.Substring(url.LastIndexOf("`") + 1);

				if (!url.Contains("."))
					Extension = "*";
				else
					Extension = url.Substring(url.LastIndexOf(".") + 1).ToLower();
			}
		}

		public long Size { get; set; }
		public int Id { get; set; }

		/// ######################### PRIVATE PROPERTIES ############################

		public string Name { get; protected set; }
		public string Extension { get; protected set; }

		protected string[] sizeUnits =
		{
			"B", "KB", "MB", "GB"
		};
		protected string url;

		/// ########################### PUBLIC METHODS ##############################

		public string GetSizeAsString()
		{
			if (Size == 0)
				return "0 B";

			int unitIndex = (int)Math.Log(Size, 1024);
			double temp = Size / Math.Pow(1024, unitIndex);

			return $"{temp.ToString($"N{(temp < 100 ? 1 : 0)}")} {sizeUnits[unitIndex]}";
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
