using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	///<summary> Class containing every iteration of strings that a user has inputed
	/// 
	/// External Calls:
	/// User
	///</summary>
	public class PostHistory
	{

		public PostHistory()
		{
		}

		public List<int> ChangeOrder;
		public List<User> ChangeUser;
		public List<string> ChangeText;
		public List<string> TextHistory;

	}

}
