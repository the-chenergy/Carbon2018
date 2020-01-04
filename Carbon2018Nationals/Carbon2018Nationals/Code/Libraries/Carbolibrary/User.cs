using Carboutil;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	/// <summary>
	/// Represents a user of this software and stores the info of a user.
	/// A user must login to have the accesses to his groups, meetings, and posts.
	/// </summary>
	public class User
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// Creates a new User instance.
		/// </summary>
		/// <param name="username">The username of the new user.</param>
		/// <param name="name">The display name of the new user.</param>
		/// <param name="status">The one-sentence-description of the new user.</param>
		/// <param name="email">The email address of the new user.</param>
		/// <param name="phone">The phone number of the new user.</param>
		/// <param name="id">The in-database ID of the new user.</param>
		/// <param name="isAdmin">Whether the new user is an administrator of the global Carbon platform.</param>
		public User(string username, string name, string status = "", string email = "", string phone = "", int id = -1, bool isAdmin = false)
		{
			Id = id;
			Username = username;
			Name = name;
			Status = status;
			Email = email;
			Phone = phone;
			IsAdministrator = isAdmin;

			JoinedGroups = new List<Group>();
			JoinedMeetings = new List<Meeting>();
			Notifications = new List<Notification>();
		}

		/// ########################## PUBLIC PROPERTIES ############################

		/// <summary>The user image of this User.</summary>
		public Image UserImage { get; set; }

		/// <summary>The user image, 64*64, of this User.</summary>
		public Image UserImage64 { get; set; }

		/// <summary>The login username of this User.</summary>
		public string Username { get; set; }

		/// <summary>The display name of this User.</summary>
		public string Name { get; set; }

		/// <summary>A one-sentence-description of this User.</summary>
		public string Status { get; set; }

		/// <summary>The email address of this User (optional).</summary>
		public string Email { get; set; }

		/// <summary>The phone number of this User (optional).</summary>
		public string Phone { get; set; }

		/// <summary>The in-database ID of this User. -1 means that this user is not saved in the database.</summary>
		public int Id { get; set; }

		/// <summary>Whether this User is an Administrator of the global Caron platform.</summary>
		public bool IsAdministrator { get; set; }

		/// <summary>Whether this User's information has completely been loaded from the database.</summary>
		public bool IsConnectedToDb { get; set; }

		/// ######################### PRIVATE PROPERTIES ############################

		/// <summary>[ReadOnly] The collection of groups this User has joined.</summary>
		public List<Group> JoinedGroups { get; protected set; }

		/// <summary>[ReadOnly] The collection of meetings this User has joined.</summary>
		public List<Meeting> JoinedMeetings { get; protected set; }

		/// <summary>[ReadOnly] The collection of notifications this User has received.</summary>
		public List<Notification> Notifications { get; protected set; }

		/// ########################### PUBLIC METHODS ##############################

		public void AddGroup(Group group)
		{
			JoinedGroups.Add(group);
		}

		public void AddGroups(IEnumerable<Group> groups)
		{
			JoinedGroups.AddRange(groups);
		}

		public void AddMeeting(Meeting meeting)
		{
			JoinedMeetings.Add(meeting);
		}

		public void AddMeetings(IEnumerable<Meeting> meetings)
		{
			JoinedMeetings.AddRange(meetings);
		}

		public void AddNotification(Notification notification)
		{
			Notifications.Add(notification);
		}

		public void AddNotifications(IEnumerable<Notification> notifications)
		{
			Notifications.AddRange(notifications);
		}

		public void RemoveGroup(Group group)
		{
			JoinedGroups.Remove(group);
		}

		public void RemoveMeeting(Meeting meeting)
		{
			JoinedMeetings.Remove(meeting);
		}

		public void RemoveNotification(Notification notification)
		{
			Notifications.Remove(notification);
		}

		public Group GetGroupById(int id)
		{
			return JoinedGroups.Find(x => (x.Id == id));
		}

		public Meeting GetMeetingById(int id)
		{
			return JoinedMeetings.Find(x => (x.Id == id));
		}

		public Meeting GetMeetingById(int id, Group parentGroup)
		{
			return parentGroup.Meetings.Find(x => (x.Id == id));
		}

		public Post GetPostById(int id)
		{
			if (JoinedMeetings == null)
				throw new Exception("JoinedMeeting is not initialized.");

			foreach (List<Post> p in JoinedMeetings.Select(x => x.Posts))
			{
				Post temp = p.Find(x => (x.Id == id));

				if (temp != null)
					return temp;
			}

			return null;
		}

		public Post GetPostById(int id, Meeting parentMeeting)
		{
			return parentMeeting.Posts.Find(x => (x.Id == id));
		}

		public List<Group> SearchGroups(string keyword)
		{
			return JoinedGroups.Where(x => (
				x.Code == keyword
				|| x.Name.ToLower().Contains(keyword)
				|| x.Description.ToWordList().IndexOf(keyword.ToWordList().ToArray()) >= 0
			)).Distinct().OrderBy(x => x.Name).ToList();
		}

		public List<Meeting> SearchMeetings(string keyword, bool isTagOnly = false)
		{
			if (isTagOnly)
				return JoinedMeetings.Where(x => x.Tags.Any(y => y.Name.ToLower() == keyword)).ToList();

			return JoinedMeetings.Where(x => (
				x.Name.ToLower().Contains(keyword)
				|| x.Description.ToWordList().IndexOf(keyword.ToWordList().ToArray()) >= 0
				|| x.Tags.Any(y => y.Name.ToLower() == keyword)
			)).Distinct().OrderBy(x => x.Name).ToList();
		}

		public List<Post> SearchPosts(string keyword, bool isTagOnly = false)
		{
			List<Post> output = new List<Post>();

			foreach (List<Post> p in JoinedMeetings.Select(x => x.Posts))
			{
				if (isTagOnly)
				{
					output.AddRange(p.Where(x => (
						x.Tags.Any(y => y.Name.ToLower() == keyword)
						|| x.Meeting.Tags.Any(y => y.Name.ToLower() == keyword)
					)));

					continue;
				}

				output.AddRange(p.Where(x => (
					x.Title.ToLower().Contains(keyword)
					|| x.RawContent.ToWordList().IndexOf(keyword.ToWordList().ToArray()) >= 0
					|| x.Tags.Any(y => y.Name.ToLower() == keyword)
					|| x.Meeting.Tags.Any(y => y.Name.ToLower() == keyword)
					|| x.Attachments.Any(y => y.Name.ToLower().Contains(keyword))
				)));
			}

			return output.Distinct().OrderBy(x => x.Title).ToList();
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
