using System.Collections.Generic;
using System.Linq;

namespace Carbolibrary
{

	///<summary> 
	///Class containing a collection 
	///</summary>
	public class Meeting
	{

		public Meeting(
			string name,
			string description,
			List<User> users,
			List<ContentArea> contentArea,
			Format format,
			Group group = null)
		{
			Name = name;
			Description = description;
			MeetingUsers = users;
			ContentAreas = contentArea;
			GroupFormat = format;
			Group = group;

			Posts = new List<Post>();
			SortedPosts = new List<Post>();
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public Group Group;
		public Format GroupFormat { get; private set; }
		public List<ContentArea> ContentAreas { get; private set; }
		public List<Post> Posts { get; private set; }
		public List<Post> SortedPosts { get; private set; }
		public List<User> MeetingUsers { get; private set; }

		public Post AddPost(string title, string content, List<User> members, ContentArea contentArea)
		{
			Post post = new Post(title, content, members, contentArea, this);
			Posts.Add(post);

			return post;
		}

		public Post AddPost(Post post)
		{
			post.Meeting = this;

			Posts.Add(post);

			return post;
		}

		public void SetIdentifiers()
		{
			List<string> orders = GroupFormat.OutputStringList().OrderBy(x => x).ToList();
			Dictionary<string, char> orderDict = new Dictionary<string, char>();

			for (int i = 0, l = orders.Count; i < l; i++)
			{
				orderDict[orders[i]] = (char)(i + 65);
			}

			foreach (Post p in Posts)
			{
				p.SortableIdentifier = orderDict[p.ContentArea.ContentType];
			}
		}

		public void RemovePost(Post post)
		{
			Posts.Remove(post);
		}

		public void ConstructPrint()
		{
			SetIdentifiers();

			SortedPosts = Posts.OrderBy(x => x.SortableIdentifier).ToList();
		}

		public List<Post> GetPrint()
		{
			ConstructPrint();

			return SortedPosts;
		}

	}

}
