using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	///<summary> Class for specifying user access by group or by community
	/// 
	/// External Calls:
	/// N/A
	/// 
	/// Implements:
	/// UserAccess
	///</summary>
	public class SpecificUserAccess : UserAccess
	{

		public string GroupById;
		public string CommunityById;

	}

}
