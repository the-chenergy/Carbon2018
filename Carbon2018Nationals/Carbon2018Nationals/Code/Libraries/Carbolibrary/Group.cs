using System;
using System.Collections.Generic;
using System.Linq;

namespace Carbolibrary
{

	///<summary>
	/// Represents a PLC Group, which contains a collection of PLC Meetings along with group specific parameters.
	///</summary>
	public class Group
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// Creates a new Group instance.
		/// </summary>
		/// <param name="name">The name of the group.</param>
		/// <param name="code">The identifier of the group.</param>
		/// <param name="description">The description of the group.</param>
		/// <param name="date">The DateTime when this group was created. (default=DateTime.Now)</param>
		/// <param name="id">The ID (in database) of this group.</param>
		public Group(string name = "", string code = "", string description = "", object date = null, int id = -1, User owner = null)
		{
			Id = id;
			Name = name;
			Code = code;
			Description = description;
			Date = (DateTime)(date ?? DateTime.Now);
			Owner = owner;

			Members = new List<User>();
			Meetings = new List<Meeting>();
			Administrators = new List<User>();
		}

		/// ########################## PUBLIC PROPERTIES ############################

		/// <summary>The creator of this Group.</summary>
		public User Owner { get; set; }

		/// <summary>The DateTime when this Group was created.</summary>
		public DateTime Date { get; set; }

		/// <summary>The Permissions in this Group.</summary>
		public GroupPermissions Permissions { get; set; }

		/// <summary>Determines who can search and join this Group.</summary>
		public GroupType JoinType { get; set; }

		/// <summary>The Role of the current user. This value won't be stored to the database.</summary>
		public Role CurrentUserRole { get; set; }

		/// <summary>The name of this Group.</summary>
		public string Name { get; set; }

		/// <summary>The identifier of this Group.</summary>
		public string Code { get; set; }

		/// <summary>The description of this Group.</summary>
		public string Description { get; set; }

		/// <summary>The ID (in database) of this Group. -1 represents that this Group is not saved in database.</summary>
		public int Id { get; set; }

		/// <summary>Whether this group can be found by its name. If the value is false, this group can only be found by its exact group-code.</summary>
		public bool CanBeFoundByName { get; set; } = true;

		/// ######################### PRIVATE PROPERTIES ############################

		/// <summary>[ReadOnly] The collection of Meeting in this Group.</summary>
		public List<Meeting> Meetings { get; protected set; }

		/// <summary>[ReadOnly] The members in this Group.</summary>
		public List<User> Members { get; protected set; }

		/// <summary>[ReadOnly] The administrators of this Group.</summary>
		public List<User> Administrators { get; protected set; }

		/// ########################### PUBLIC METHODS ##############################

		/// <summary>
		/// If the user is not a member in this Group, adds a member to this Group.
		/// </summary>
		/// <param name="member">The member to add.</param>
		public User AddMember(User member)
		{
			if (Members.Contains(member))
				throw new Exception("This member already exists in this group.");

			Members.Add(member);

			return member;
		}

		/// <summary>
		/// Adds members to this Group.
		/// </summary>
		/// <param name="members">The list of members to add.</param>
		public void AddMembers(IEnumerable<User> members)
		{
			foreach (User p in members)
				AddMember(p);
		}

		/// <summary>
		/// Removes a member from this Group.
		/// </summary>
		/// <param name="member">The member to remove.</param>
		public User RemoveMember(User member)
		{
			if (!Members.Contains(member))
				throw new Exception("This member is not found in this group.");

			Members.Remove(member);

			return member;
		}

		/// <summary>
		/// Removes all members from this group.
		/// </summary>
		public void RemoveAllMembers()
		{
			Members.Clear();
		}

		/// <summary>
		/// If the user is not an administrator in this Group, adds an administrator to this Group.
		/// </summary>
		/// <param name="administrator">The administrator to add.</param>
		public User AddAdministrator(User administrator)
		{
			if (Administrators.Contains(administrator))
				throw new Exception("This administrator already exists in this group.");

			Administrators.Add(administrator);

			return administrator;
		}

		/// <summary>
		/// Adds administrators to this Group.
		/// </summary>
		/// <param name="administrators">The list of administrators to add.</param>
		public void AddAdministrators(IEnumerable<User> administrators)
		{
			foreach (User p in administrators)
				AddAdministrator(p);
		}

		/// <summary>
		/// Removes an administrator from this Group.
		/// </summary>
		/// <param name="administrator">The administrator to remove.</param>
		public User RemoveAdministrator(User administrator)
		{
			if (!Administrators.Contains(administrator))
				throw new Exception("This administrator is not found in this group.");

			Administrators.Remove(administrator);

			return administrator;
		}

		/// <summary>
		/// Removes all administrators from this group.
		/// </summary>
		public void RemoveAllAdministrators()
		{
			Administrators.Clear();
		}

		/// <summary>
		/// Adds a meeting to this Group, and sets the meeting.Group property to this Group instance.
		/// </summary>
		/// <param name="meeting">The meeting to add.</param>
		public Meeting AddMeeting(Meeting meeting)
		{
			if (Meetings.Contains(meeting))
				throw new Exception("This meeting already exists in this group.");

			meeting.Group = this;

			Meetings.Add(meeting);

			return meeting;
		}

		/// <summary>
		/// Removes a meeting from this Group.
		/// </summary>
		/// <param name="meeting"></param>
		public Meeting RemoveMeeting(Meeting meeting)
		{
			if (!Meetings.Contains(meeting))
				throw new Exception("This meeting is not found in this group.");

			Meetings.Remove(meeting);

			return meeting;
		}

		/// <summary>
		/// Search users in this group by a keyword.
		/// </summary>
		/// <param name="keyword">The searching keyword.</param>
		public List<User> SearchMembers(string keyword)
		{
			List<User> result = new List<User>();

			foreach (User p in Members)
			{
				if (p.Username == keyword)
					result.Add(p);

				if (p.Phone == keyword)
					result.Add(p);

				if (p.Name.ToLower().Contains(keyword.ToLower()))
					result.Add(p);

				if (p.Email.ToLower().Contains(keyword.ToLower()))
					result.Add(p);
			}

			return result.Distinct().ToList();
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
