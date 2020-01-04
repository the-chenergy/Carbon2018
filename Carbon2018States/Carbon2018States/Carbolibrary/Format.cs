using System.Collections.Generic;

namespace Carbolibrary
{

	///<summary> Class containing formatting rules for post organization and order
	/// 
	/// External Calls
	/// ContentArea
	/// 
	///</summary>
	public class Format
	{

		public Format(params ContentArea[] contentAreas)
		{
			foreach (ContentArea p in contentAreas)
			{
				orderOfContentAreas.Add(p);
			}
		}

		private List<ContentArea> orderOfContentAreas = new List<ContentArea>();

		public List<string> OutputStringList()
		{
			List<string> outputList = new List<string>();

			foreach (ContentArea p in orderOfContentAreas)
			{
				outputList.Add(p.ContentType);
			}

			return outputList;
		}

		public void AddContentArea(ContentArea contentArea)
		{
			orderOfContentAreas.Add(contentArea);
		}

		public void RemoveContentAreaAt(int index)
		{
			orderOfContentAreas.RemoveAt(index);
		}

	}

}
