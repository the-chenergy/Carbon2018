using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	///<summary> Class containing a type for a post
	/// 
	/// External Calls:
	/// 
	///</summary>
	public class ContentArea
	{

		public ContentArea(String type)
		{
			ContentType = type;
		}

		public string ContentType { get; set; }
		
	}

}
