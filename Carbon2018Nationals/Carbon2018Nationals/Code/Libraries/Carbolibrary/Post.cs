using Carboutil;

using System;
using System.Collections.Generic;

namespace Carbolibrary
{

	/// <summary>
	/// Contains the data of a post, including title, content, author, etc.
	/// </summary>
	public class Post
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// Creates a new Post instance.
		/// </summary>
		/// <param name="title">The title of the post.</param>
		/// <param name="rtfContent">The content of the post, in RTF format.</param>
		/// <param name="date">The DateTime of the latest update of the post.</param>
		/// <param name="author">The User who wrote this post.</param>
		/// <param name="meeting">The meeting which this post is in.</param>
		/// <param name="id">The in-database ID of this post.</param>
		public Post(string title = "", string rtfContent = "", object date = null, object latestDate = null, User author = null, Meeting meeting = null, int id = -1)
		{
			Id = id;
			Title = title;
			RtfContent = rtfContent;
			Author = author;
			Meeting = meeting;
			Date = (DateTime)(date ?? DateTime.Now);
			LatestDate = (DateTime)(latestDate ?? Date);

			Tags = new List<Tag>();
			Attachments = new List<PostAttachment>();
		}

		/// ########################## PUBLIC PROPERTIES ############################

		/// <summary>The author of this Post.</summary>
		public User Author { get; set; }

		/// <summary>The Parent Meeting of this Post.</summary>
		public Meeting Meeting { get; set; }

		/// <summary>The DateTime when this Post was written.</summary>
		public DateTime Date { get; set; }

		/// <summary>The DateTime of the latest update of this Post.</summary>
		public DateTime LatestDate { get; set; }

		/// <summary>The title of this Post.</summary>
		public string Title { get; set; }

		/// <summary>The content of this Post, in RTF format.</summary>
		public string RtfContent { get; set; }

		/// <summary>The in-database ID of this post. -1 represents that this Post is not saved in database.</summary>
		public int Id { get; set; }

		/// <summary>[ReadOnly] The content of this Post, in normal text format.</summary>
		public string RawContent => CarboRtfConverter.ToNormalText(RtfContent);

		/// ######################### PRIVATE PROPERTIES ############################

		/// <summary>The collection of Tags of this post.</summary>
		public List<Tag> Tags { get; protected set; }

		/// <summary>The collection of PostAttachments of this post.</summary>
		public List<PostAttachment> Attachments { get; protected set; }

		/// ########################### PUBLIC METHODS ##############################

		/// <summary>
		/// Adds a tag to this post.
		/// </summary>
		/// <param name="tag">The tag to add to this post.</param>
		public Tag AddTag(Tag tag)
		{
			if (Tags.Contains(tag))
				throw new Exception("This tag has already been added to this post.");

			Tags.Add(tag);

			return tag;
		}

		/// <summary>
		/// Adds tags to this post.
		/// </summary>
		/// <param name="tags">The collection of tags to add to this post.</param>
		public void AddTags(IEnumerable<Tag> tags)
		{
			foreach (Tag p in tags)
				AddTag(p);
		}

		/// <summary>
		/// Removes a tag from this post.
		/// </summary>
		/// <param name="tag">The tag to remove from this post.</param>
		public Tag RemoveTag(Tag tag)
		{
			if (!Tags.Contains(tag))
				throw new Exception("This tag has never been added to this post.");

			Tags.Remove(tag);

			return tag;
		}

		/// <summary>
		/// Removes all tags from this post.
		/// </summary>
		public void RemoveAllTags()
		{
			Tags.Clear();
		}

		/// <summary>
		/// Adds an attachment to this post.
		/// </summary>
		/// <param name="attachment">The attachment to add to this post.</param>
		public PostAttachment AddAttachment(PostAttachment attachment)
		{
			if (Attachments.Contains(attachment))
				throw new Exception("This attachment has already been attached to this post.");

			Attachments.Add(attachment);

			return attachment;
		}

		/// <summary>
		/// Adds attachments to this post.
		/// </summary>
		/// <param name="attachments">The collection of PostAttachments to add to this post.</param>
		public void AddAttachments(IEnumerable<PostAttachment> attachments)
		{
			foreach (PostAttachment p in attachments)
				AddAttachment(p);
		}

		/// <summary>
		/// Removes an attachment from this post.
		/// </summary>
		/// <param name="attachment">The attachment to remove from this post.</param>
		public PostAttachment RemoveAttachment(PostAttachment attachment)
		{
			if (!Attachments.Contains(attachment))
				throw new Exception("This attachment has never been attached to this post.");

			Attachments.Remove(attachment);

			return attachment;
		}

		/// <summary>
		/// Removes all attachments from this post.
		/// </summary>
		public void RemoveAllAttachments()
		{
			Attachments.Clear();
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
