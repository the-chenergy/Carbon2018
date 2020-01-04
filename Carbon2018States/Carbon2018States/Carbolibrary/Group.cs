using System;
using System.Collections.Generic;

namespace Carbolibrary
{

	///<summary> Class containing a collection of meeetings and group specific parameters
	/// 
	/// External Calls
	/// Meetings
	/// User
	/// GroupFormatting
	/// ContentArea
	///</summary>
	public class Group
	{

		public Group(string name, string description = "", List<User> users = null)
		{
			//verify that someone has the rights to change
			//interesting constructor things here

			Name = name;
			Description = description;
			Users = users;
			Meetings = new List<Meeting>();

			if (users == null)
				Users = new List<User>();
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public List<Meeting> Meetings { get; private set; }
		public List<User> Users { get; private set; }
		public Format Format { get; private set; }
		public List<ContentArea> ContentAreas { get; private set; }

		public void AddUser(User user)
		{
			Users.Add(user);
		}

		public void RemoveUser(User user)
		{
			Users.Remove(user);
		}

		//public void AddMeetingPost(Meeting meeting, string title, List<User> members, ContentArea contentArea)
		//{
		//	meeting.AddPost(title, members, contentArea);
		//}

		//public void RemoveMeetingPost(Meeting meeting, Post post)
		//{
		//	meeting.RemovePost(post);
		//}

		public Meeting AddMeeting(string name, string description, List<User> members, List<ContentArea> contentAreas)
		{
			Meeting meeting = new Meeting(name, description, members, contentAreas, Format, this);

			Meetings.Add(meeting);

			return meeting;
		}

		public Meeting AddMeeting(Meeting meeting)
		{
			meeting.Group = this;

			Meetings.Add(meeting);

			return meeting;
		}

		public void RemoveMeeting(Meeting meeting)
		{
			Meetings.Remove(meeting);
		}

	}

}
