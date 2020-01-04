using System;
using System.Collections.Generic;

namespace Carbolibrary
{

	///<summary> Class containing the data included with a Post
	/// 
	/// External Calls:
	/// DateTime
	/// PostHistory
	/// User
	/// ContentArea
	///</summary>
	public class Post
	{

		public Post(
			string title,
			string content,
			List<User> members,
			ContentArea contentArea,
			Meeting meeting = null)
		{
			Title = title;
			Content = content;
			Users = members;
			ContentArea = contentArea;
			Meeting = meeting;
			Date = DateTime.Now;
			Editable = true;
		}

		public List<User> Users { get; set; }
		public DateTime Date { get; set; }
		public ContentArea ContentArea { get; set; }
		public string Content { get; set; }
		public string Title { get; set; }
		public char SortableIdentifier { get; set; }
		public bool Editable { get; set; }
		public Meeting Meeting { get; set; }

	}

}
