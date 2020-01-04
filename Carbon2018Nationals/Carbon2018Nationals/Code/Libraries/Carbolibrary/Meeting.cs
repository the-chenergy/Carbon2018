using System;
using System.Collections.Generic;

namespace Carbolibrary
{

	///<summary> 
	/// Represents a PLC Meeting, which contains the collections of members and Posts.
	///</summary>
	public class Meeting
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// Creates a new Meeting instance.
		/// </summary>
		/// <param name="name">The name of the meeting.</param>
		/// <param name="description">The description of the meeting.</param>
		/// <param name="date">The date when this meeting was created.</param>
		/// <param name="group">The parent group of this meeting.</param>
		/// <param name="id">The in-database ID of this meeting.</param>
		public Meeting(string name = "", string description = "", object date = null, Group group = null, int id = -1)
		{
			Id = id;
			Name = name;
			Description = description;
			Date = (DateTime)(date ?? DateTime.Now);
			Group = group;

			Members = new List<User>();
			Posts = new List<Post>();
			Tags = new List<Tag>();
		}

		/// ########################## PUBLIC PROPERTIES ############################

		/// <summary>The parent Group instance of this Meeting.</summary>
		public Group Group { get; set; }

		/// <summary>The DateTime when this Meeting was created.</summary>
		public DateTime Date { get; set; }

		/// <summary>The name of this Meeting.</summary>
		public string Name { get; set; }

		/// <summary>The description of this Meeting.</summary>
		public string Description { get; set; }

		/// <summary>The ID of this Meeting in database. -1 represents that this Meeting is not saved in database.</summary>
		public int Id { get; set; }

		/// ######################### PRIVATE PROPERTIES ############################

		/// <summary>[ReadOnly] The posts in this Meeting.</summary>
		public List<Post> Posts { get; protected set; }

		/// <summary>[ReadOnly] The members in this Meeting.</summary>
		public List<User> Members { get; protected set; }

		/// <summary>[ReadOnly] The tags of this Meeting.</summary>
		public List<Tag> Tags { get; protected set; }

		/// ########################### PUBLIC METHODS ##############################

		/// <summary>
		/// Adds a member to this Meeting.
		/// </summary>
		/// <param name="member">The User to add.</param>
		public User AddMember(User member)
		{
			if (Members.Contains(member))
				throw new Exception("This member already exists in this meeting.");

			Members.Add(member);

			return member;
		}

		/// <summary>
		/// Adds members to this Meeting.
		/// </summary>
		/// <param name="members">The collection of Users to add.</param>
		public void AddMembers(IEnumerable<User> members)
		{
			foreach (User p in members)
				AddMember(p);
		}

		/// <summary>
		/// Removes a member from this meeting.
		/// </summary>
		/// <param name="member">The member to remove.</param>
		public User RemoveMember(User member)
		{
			if (!Members.Contains(member))
				throw new Exception("This member is not found in this meeting.");

			Members.Remove(member);

			return member;
		}

		public void RemoveAllMembers()
		{
			Members.Clear();
		}

		/// <summary>
		/// Adds a post to this meeting.
		/// </summary>
		/// <param name="post">The post to add.</param>
		public Post AddPost(Post post)
		{
			if (Posts.Contains(post))
				throw new Exception("This post already exists in this meeting.");

			post.Meeting = this;

			Posts.Add(post);

			return post;
		}

		/// <summary>
		/// Removes a post from this meeting.
		/// </summary>
		/// <param name="post">The post to remove.</param>
		public Post RemovePost(Post post)
		{
			if (!Posts.Contains(post))
				throw new Exception("This post is not found in this meeting.");

			Posts.Remove(post);

			return post;
		}

		/// <summary>
		/// Adds a tag to this meeting.
		/// </summary>
		/// <param name="tag">The tag to add to this meeting.</param>
		public Tag AddTag(Tag tag)
		{
			if (Tags.Contains(tag))
				throw new Exception("This tag has been added to this meeting.");

			Tags.Add(tag);

			return tag;
		}

		/// <summary>
		/// Adds tags to this meeting.
		/// </summary>
		/// <param name="tags">The collection of tags to add to this meeting.</param>
		public void AddTags(IEnumerable<Tag> tags)
		{
			foreach (Tag p in tags)
				AddTag(p);
		}

		/// <summary>
		/// Removes a tag from this meeting.
		/// </summary>
		/// <param name="tag">The tag to remove from this meeting.</param>
		public Tag RemoveTag(Tag tag)
		{
			if (!Tags.Contains(tag))
				throw new Exception("This tag has never been added to this meeting.");

			Tags.Remove(tag);

			return tag;
		}

		/// <summary>
		/// Removes all tags from this meeting.
		/// </summary>
		public void RemoveAllTags()
		{
			Tags.Clear();
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
