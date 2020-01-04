using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	///<summary> Class for identifying users of the software
	/// 
	/// External Calls:
	/// UserAccess
	/// 
	/// Possible Changes:
	/// Integrating with Microsoft AD services
	///</summary>
	public class User
	{

		public User(string name, string origin, string extraInfo = "")
		{
			Name = name;
			Origin = origin;
			ExtraInfo = extraInfo;

			//code to generate or integrate user ID
		}

		public UserAccess Access;
		public Format Format;
		public string Name;
		public string Origin;
		public string ExtraInfo;

		public string UID { get; set; }

	}

}
