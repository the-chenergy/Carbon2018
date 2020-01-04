using System.Data.SQLite;

using Carboutil;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace Carbolibrary
{

	/// <summary>
	/// Provides the access and save/load functions to a Carbon database.
	/// </summary>
	public class Database
	{

		#region ########################## PUBLIC PROPERTIES ############################



		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		/// <summary>[ReadOnly] The SQLiteConnection instance of this Database.</summary>
		static public SQLiteConnection Connection { get; protected set; }

		/// <summary>
		/// [ReadOnly] The User who is currently logged in. Use Database.Login() method to change its value.
		/// This can be null if nobody has logged in yet.
		/// </summary>
		static public User CurrentUser { get; protected set; }

		/// <summary>[ReadOnly] The URL to the current database. Use Database.Connect() method to change its value.</summary>
		static public string Url { get; protected set; }

		/// <summary>[ReadOnly] Whether the database has been connected successfully.</summary>
		static public bool IsConnected { get; protected set; }

		/// <summary>[ReadOnly] Whether the FileManager has been connected. Use Database.ConnectFileManager() method to change its value.</summary>
		static public bool IsFileManagerConnected { get; protected set; }

		/// <summary>[Private] Users that have already been loaded from database. This prevents it from loading the same users more than once and reduces processing time.</summary>
		static protected Dictionary<string, User> loadedUsers = new Dictionary<string, User>();

		static protected Regex numberFilter = new Regex(@"[0-9]+");
		static protected Regex emailFilter = new Regex(@".+@.+\..+");

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		#region *************** BASIC ACTIONS ***************

		#region DATABASE

		/// <summary>
		/// Creates a brand new Carbon database file.
		/// </summary>
		/// <param name="url">The URL to create the new database.</param>
		static public void Create(string url)
		{
			if (File.Exists(url))
				File.Delete(url);

			SQLiteConnection.CreateFile(url);

			if (Connection == null)
				Connection = new SQLiteConnection($"Data Source = {url}; Version = 3", true);

			Connection.Open();

			GetCommand("CREATE TABLE Users (Id INTEGER NOT NULL, Username TEXT, Password TEXT, IsAdmin INTEGER, Name TEXT, Status TEXT, Email TEXT, Phone TEXT, Groups TEXT, Meetings TEXT, Posts TEXT, Notifications TEXT)").ExecuteNonQuery(true);
			GetCommand("CREATE TABLE Groups (Id INTEGER NOT NULL, Code TEXT, Name TEXT, Owner INTEGER, Admins TEXT, Permissions TEXT, Users TEXT, Description TEXT, Date TEXT, Meetings TEXT)").ExecuteNonQuery(true);
			GetCommand("CREATE TABLE Meetings (Id INTEGER NOT NULL, GroupId INTEGER, Name TEXT, Users TEXT, Description TEXT, Date TEXT, Posts TEXT, Tags TEXT)").ExecuteNonQuery(true);
			GetCommand("CREATE TABLE Posts (Id INTEGER NOT NULL, MeetingId INTEGER, Title TEXT, Content TEXT, Author INTEGER, Date TEXT, LatestDate TEXT, Tags TEXT, Attachments TEXT)").ExecuteNonQuery(true);

			#region ADD A LOT OF GROUPS (optional, just for testing scrollbars)

			//int[] groupIndices = new int[32];
			//int[] meetingIndices = new int[64];
			//// write a lot of meetings
			//for (int i = 0; i < 64; i++)
			//{
			//	GetCommand($"INSERT INTO Meetings (Id, GroupId, Name, Users, Description, Date, Tags) VALUES ({i}, 0, 'Meeting{i}', '0', 'This is meeting {i + 1}.', '{EncodeDate(DateTime.Now)}', '')").ExecuteNonQuery(true);

			//	meetingIndices[i] = i;
			//}
			//// write a lot of groups
			//for (int i = 0; i < 32; i++)
			//{
			//	if (i == 0)
			//		GetCommand($"INSERT INTO Groups (Id, Code, Name, Owner, Admins, Permissions, Users, Description, Date, Meetings) VALUES ({i}, 'group{i}', 'Group{i}', 0, '', '0,0,0,0,0,0,0,0,0', '0', 'This is group {i + 1}.', '{EncodeDate(DateTime.Now)}', '{string.Join(",", meetingIndices)}')").ExecuteNonQuery(true);
			//	else
			//		GetCommand($"INSERT INTO Groups (Id, Code, Name, Owner, Admins, Permissions, Users, Description, Date, Meetings) VALUES ({i}, 'group{i}', 'Group{i}', 0, '', '0,0,0,0,0,0,0,0,0', '0', 'This is group {i + 1}.', '{EncodeDate(DateTime.Now)}', '')").ExecuteNonQuery(true);

			//	groupIndices[i] = i;
			//}
			//// add a default user: asianboii
			//GetCommand($"INSERT INTO Users (Id, Username, Password, IsAdmin, Name, Status, Email, Phone, Groups, Meetings, Posts, Notifications) VALUES (0, 'asianboii', '{Sha512Encoder.Encode("12341234")}', 1, 'Test', 'Test!!', 'a@o.e', '1234123412', '{string.Join(",", groupIndices)}', '{string.Join(",", meetingIndices)}{"".PadRight(127, ';')}', '', '')").ExecuteNonQuery(true);

			#endregion

			Connection.Close();
		}

		/// <summary>
		/// Tries connecting to a database. Returns true if it's successful.
		/// </summary>
		/// <param name="url">The URL to the database.</param>
		static public bool Connect(string url)
		{
			IsConnected = false;

			if (Connection != null)
			{
				Connection.Close();
				Connection.Dispose();
			}

			Connection = new SQLiteConnection($"Data Source = {url}; Version = 3", true);

			Url = url;

			// check file existance

			if (!File.Exists(url))
			{
				if (MessageBox.Show($"DATABASE {url} DOES NOT EXIST!\nWANNA CREATE A NEW ONE?", "Oops!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					Create(url);

					return Connect(url);
				}

				return false;
			}

			// test connections

			try
			{
				Connection.Open();

				GetCommand("SELECT Id FROM Users ORDER BY Id ASC").ExecuteNonQuery(true);
			}
			catch (Exception ee)
			{
				MessageBox.Show($"CANNOT OPEN DATABASE {url}!\nGET OUTTA HERE WITH DAT {ee.GetType().ToString().Split('.').Reverse().ToArray()[0]}!", "Heck no!", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}

			Connection.Close();

			return (IsConnected = true);
		}

		/// <summary>
		/// Checks if the username and password provided match;
		/// if they do, loads the info of the user and the groups he joined.
		/// Returns true if the login was successful.
		/// The loaded User will be stored in Database.CurrentUser property (if successful).
		/// Use Database.Connect() to connect to a database before logging in.
		/// </summary>
		/// <param name="username">The username to login.</param>
		/// <param name="password">The SHA512 ENCODED password to login.</param>
		static public bool Login(string username, string password)
		{
			Connection.Open();

			CurrentUser = null;

			// preparations

			SQLiteDataReader reader = GetCommand($"SELECT * FROM Users WHERE Username = '{username}'").ExecuteReader(true);
			string groupData = "", meetingData = "", postData = "", notifData = "";

			// search for specific user by username and password provided

			if (!reader.Read() || (password != null && reader.GetString("Password") != password))
			{
				//MessageBox.Show("YOUR USERNAME OR PASSWORD WAS INCORRECT!!", "DontLogInWithoutPermissionsStefan");
				reader.Close();
				Connection.Close();

				return false;
			}

			CurrentUser = new User(
				username,
				reader.GetString("Name"),
				reader.GetString("Status"),
				reader.GetString("Email"),
				reader.GetString("Phone"),
				reader.GetInt32("Id"),
				reader.GetBoolean("IsAdmin")
			);

			FileManager.LoadUserImage(CurrentUser);

			groupData = reader.GetString("Groups");
			meetingData = reader.GetString("Meetings");
			postData = reader.GetString("Posts");
			notifData = reader.GetString("Notifications");

			CurrentUser.IsConnectedToDb = true;

			reader.Close();

			loadedUsers[CurrentUser.Id.ToString()] = CurrentUser;

			//tra.ce("Load", groupData, meetingData, postData);

			if (groupData != "")
			{
				// load groups
				foreach (string p in DecodeList(groupData))
				{
					reader = GetCommand($"SELECT * FROM Groups WHERE Id = {p}").ExecuteReader(true);

					reader.Read();

					if (!(reader["Name"] is string))
					// data has been deleted by another user
					{
						reader.Close();

						continue;
					}

					Group group = new Group(
						reader.GetString("Name"),
						reader.GetString("Code"),
						reader.GetString("Description"),
						DecodeDate(reader.GetString("Date")),
						reader.GetInt32("Id"),
						LoadUserInfo(reader.GetInt32("Owner").ToString())
					);

					group.AddAdministrators(
						DecodeList(reader.GetString("Admins")).Select(x => LoadUserInfo(x))
					);
					group.AddMembers(
						DecodeList(reader.GetString("Users")).Select(x => LoadUserInfo(x))
					);

					DecodeGroupPermissionSettings(reader.GetString("Permissions"), group);

					reader.Close();

					CurrentUser.AddGroup(group);

					if (CurrentUser == group.Owner)
						group.CurrentUserRole = Role.Owner;
					else if (group.Administrators.Contains(CurrentUser))
						group.CurrentUserRole = Role.Administrator;
				}

				// load meetings to their correct groups

				List<List<string>> meetingIds = Decode2dList(meetingData);

				for (int i = 0, l = meetingIds.Count; i < l; i++)
				{
					foreach (string p in meetingIds[i])
					{
						// skip groups that have no meetings
						if (p == "")
							continue;

						reader = GetCommand($"SELECT * FROM Meetings WHERE Id = {p}").ExecuteReader(true);

						reader.Read();

						if (!(reader["Name"] is string)) // data has been deleted
						{
							reader.Close();

							continue;
						}

						Meeting meeting = new Meeting(
							reader.GetString("Name"),
							reader.GetString("Description"),
							DecodeDate(reader.GetString("Date")),
							CurrentUser.JoinedGroups[i],
							reader.GetInt32("Id")
						);

						meeting.AddMembers(reader.GetString("Users").Split(',').Select(x => LoadUserInfo(x)));
						meeting.AddTags(DecodeTagList(reader.GetString("Tags")));

						CurrentUser.AddMeeting(CurrentUser.JoinedGroups[i].AddMeeting(meeting));

						reader.Close();
					}
				}

				// load posts to their correct meetings

				List<List<List<string>>> postIds = Decode3dList(postData);

				for (int i = 0, l = postIds.Count; i < l; i++)
				{
					for (int j = 0, m = postIds[i].Count; j < m; j++)
					{
						foreach (string p in postIds[i][j])
						{
							if (p == "")
								continue;

							reader = GetCommand($"SELECT * FROM Posts WHERE Id = {p}").ExecuteReader(true);

							reader.Read();

							if (!(reader["Title"] is string)) // data has been deleted
							{
								reader.Close();

								continue;
							}

							Post post = new Post(
								reader.GetString("Title"),
								reader.GetString("Content"),
								DecodeDate(reader.GetString("Date")),
								DecodeDate(reader.GetString("LatestDate")),
								LoadUserInfo(reader.GetInt32("Author").ToString()),
								CurrentUser.JoinedMeetings[j],
								reader.GetInt32("Id")
							);

							post.AddTags(DecodeTagList(reader.GetString("Tags")));

							FileManager.LoadPostAttchmentList(post, DecodeList(reader.GetString("Attachments")));

							CurrentUser.JoinedGroups[i].Meetings[j].AddPost(post);

							reader.Close();
						}
					}
				}
			}

			// load notifications

			if (notifData != "")
				CurrentUser.AddNotifications(DecodeNotificationList(notifData));

			Connection.Close();

			UpdateUserGmps();

			return true;
		}

		#endregion

		#region FILEMANAGER

		/// <summary>
		/// Connect the FileManager to a data source directory.
		/// Returns true if it's successful.
		/// </summary>
		/// <param name="url">The URL to connect the FileManager to.</param>
		static public bool ConnectFileManager(string url)
		{
			return (IsFileManagerConnected = FileManager.Connect(url));
		}

		#endregion

		#endregion

		#region *************** EXISTANCE CHECKERS ***************

		/// <summary>
		/// Checks if a username already exists (for the "Username is taken" thing when signing up).
		/// </summary>
		/// <param name="username">The username to be checked.</param>
		static public bool HasUsername(string username)
		{
			return CheckExistance("Users", "Username", username);
		}

		/// <summary>
		/// Checks if a group code already exists (for the "Group code is taken" thing when creating groups).
		/// </summary>
		/// <param name="code">The group code to be checked.</param>
		static public bool HasGroupCode(string code)
		{
			return CheckExistance("Groups", "Code", code);
		}

		#endregion

		#region *************** CREATING DATA ***************

		#region CREATING G/M/P

		/// <summary>
		/// Creates a new group in database and renews the ID of the group.
		/// (This method does not check if the group already exists in database.)
		/// </summary>
		/// <param name="group">The group to create.</param>
		static public void CreateGroup(Group group)
		{
			Connection.Open();

			group.Id = InsertRecord("Groups",
				"Code", group.Code,
				"Name", group.Name,
				"Owner", group.Owner.Id,
				"Admins", EncodeIdList(group.Administrators),
				"Permissions", EncodeGroupPermissionSettings(group),
				"Users", "",
				"Description", group.Description,
				"Date", EncodeDate(group.Date),
				"Meetings", EncodeIdList(group.Meetings)
			);

			Connection.Close();

			// add the rest of users

			AddGroupMembers(group, group.Members);
		}

		/// <summary>
		/// Creates a new meeting in the database.
		/// </summary>
		/// <param name="meeting">The meeting to create.</param>
		static public void CreateMeeting(Meeting meeting)
		{
			Connection.Open();

			meeting.Id = InsertRecord("Meetings",
				"GroupId", meeting.Group.Id,
				"Name", meeting.Name,
				"Users", "",
				"Description", meeting.Description,
				"Date", EncodeDate(meeting.Date),
				"Posts", EncodeIdList(meeting.Posts),
				"Tags", EncodeTagList(meeting.Tags)
			);

			// update its corresponding group as well
			GetCommand(
				$"UPDATE Groups SET Meetings = '{EncodeIdList(meeting.Group.Meetings)}' WHERE Id = {meeting.Group.Id}"
			).ExecuteNonQuery(true);

			Connection.Close();

			AddMeetingMembers(meeting, meeting.Members);
		}

		/// <summary>
		/// Creates a new post in database.
		/// </summary>
		/// <param name="post">The post to create.</param>
		static public void CreatePost(Post post)
		{
			Connection.Open();

			post.Id = InsertRecord("Posts",
				"MeetingId", post.Meeting.Id,
				"Title", post.Title,
				"Content", post.RtfContent,
				"Author", post.Author.Id,
				"Date", EncodeDate(post.Date),
				"LatestDate", EncodeDate(post.LatestDate),
				"Tags", EncodeTagList(post.Tags),
				"Attachments", ""
			);

			// save its attachments
			List<PostAttachment> temp = new List<PostAttachment>(post.Attachments); // make an orig copy

			post.RemoveAllAttachments();
			post.AddAttachments(FileManager.CreatePostAttachments(post, temp.Select(x => x.Url)));

			GetCommand(
				$"UPDATE Posts SET Attachments = '{EncodeIdList(post.Attachments)}' WHERE Id = {post.Id}"
			).ExecuteNonQuery(true);

			// update its corresponding meeting as well
			GetCommand(
				$"UPDATE Meetings SET Posts = '{EncodeIdList(post.Meeting.Posts)}' WHERE Id = {post.Meeting.Id}"
			).ExecuteNonQuery(true);

			// add post to users

			foreach (User p in post.Meeting.Members)
			{
				SQLiteDataReader reader;

				// append the string in Posts column in Users table
				// find the current spot to add the post ID

				reader = GetCommand($"SELECT Groups, Meetings, Posts FROM Users WHERE Id = {p.Id}").ExecuteReader(true);
				reader.Read();

				int groupIndex = DecodeList(reader.GetString("Groups")).IndexOf(
					post.Meeting.Group.Id.ToString()
				);
				// the ID IN THE GROUP LIST (not the actual group ID)
				// of the group that the post is in

				int meetingIndex = Decode2dList(reader.GetString("Meetings"))[groupIndex].IndexOf(
					post.Meeting.Id.ToString()
				); // the ID in the meeting list of the meeting that the post is in

				List<List<List<string>>> postIds = Decode3dList(reader.GetString("Posts"));

				reader.Close();

				if (groupIndex == postIds.Count)
					postIds.Add(new List<List<string>>());

				if (meetingIndex == postIds[groupIndex].Count)
					postIds[groupIndex].Add(new List<string>());

				postIds[groupIndex][meetingIndex].Add(post.Id.ToString());

				GetCommand($"UPDATE Users SET Posts = '{Encode3dList(postIds)}' WHERE Id = {p.Id}").ExecuteNonQuery(true);
			}

			Connection.Close();
		}

		#endregion

		#region CREATING USERS

		/// <summary>
		/// Creates a new user in the database (sign-up).
		/// </summary>
		/// <param name="user">The user to create.</param>
		/// <param name="password">The SHA512 ENCODED password that user provided.</param>
		static public void CreateUser(User user, string password)
		{
			Connection.Open();

			user.Id = InsertRecord("Users",
				"Username", user.Username,
				"Password", password,
				"IsAdmin", 0,
				"Name", user.Name,
				"Status", user.Status,
				"Email", user.Email,
				"Phone", user.Phone,
				"Groups", "",
				"Meetings", "",
				"Posts", ""
			);

			Connection.Close();
		}

		#endregion

		#endregion

		#region *************** DELETING DATA ***************

		#region DELETING G/M/P

		/// <summary>
		/// Deletes a group in the database.
		/// (This method does not check if the group ever exists in the database.)
		/// </summary>
		/// <param name="group">The group to delete.</param>
		static public void DeleteGroup(Group group)
		{
			Connection.Open();

			// remove its meetings
			SQLiteDataReader reader = GetCommand($"SELECT * FROM Groups WHERE Id = {group.Id}").ExecuteReader(true);

			reader.Read();
			string meetings = reader.GetString("Meetings");
			reader.Close();

			foreach (string p in DecodeList(meetings))
				ClearMeeting(p);

			// set group data in database to null 
			// do it once won't make it, at least twice will :)
			GetCommand($"UPDATE Groups SET Code = NULL, Name = NULL, Owner = NULL, Admins = NULL, Permissions = NULL, Users = NULL, Description = NULL, Date = NULL, Meetings = NULL WHERE Id = {group.Id}").ExecuteNonQuery(true);
			GetCommand($"UPDATE Groups SET Code = NULL, Name = NULL, Owner = NULL, Admins = NULL, Permissions = NULL, Users = NULL, Description = NULL, Date = NULL, Meetings = NULL WHERE Id = {group.Id}").ExecuteNonQuery(true);

			Connection.Close();
		}

		/// <summary>
		/// [NotImplemented] Deletes a meeting in the database.
		/// </summary>
		/// <param name="meeting">The meeting to delete.</param>
		static public void DeleteMeeting(Meeting meeting)
		{
			Connection.Open();

			// remove meeting from its parent group
			GetCommand(
				$"UPDATE Groups SET Meetings = '{EncodeIdList(meeting.Group.Meetings)}' WHERE Id = {meeting.Group.Id}"
			).ExecuteNonQuery(true);

			ClearMeeting(meeting.Id);

			Connection.Close();
		}

		/// <summary>
		/// Deletes a post in the database.
		/// </summary>
		/// <param name="post">The post to delete.</param>
		static public void DeletePost(Post post)
		{
			Connection.Open();

			GetCommand(
				$"UPDATE Meetings SET Posts = '{EncodeIdList(post.Meeting.Posts)}' WHERE Id = {post.Meeting.Id}"
			).ExecuteNonQuery(true);

			foreach (User p in post.Meeting.Members)
				RemovePostFromMember(p, post);

			ClearPost(post.Id);

			Connection.Close();
		}

		/// <summary>
		/// [Private] Sets a meeting to null in database, and deletes the posts in the meeting,
		/// by the meeting's ID.
		/// </summary>
		/// <param name="id">The ID of the meeting. It can be an int or a string.</param>
		static protected void ClearMeeting(object id)
		{
			if (id.ToString() == "")
				return;

			// remove its posts
			SQLiteDataReader reader = GetCommand($"SELECT * FROM Meetings WHERE Id = {id}").ExecuteReader(true);

			reader.Read();
			string posts = reader.GetString("Posts");
			reader.Close();

			foreach (string p in DecodeList(posts))
				ClearPost(p);

			GetCommand($"UPDATE Meetings SET GroupId = NULL, Name = NULL, Users = NULL, Description = NULL, Date = NULL, Posts = NULL, Tags = NULL WHERE Id = {id}").ExecuteNonQuery(true);
		}

		/// <summary>
		/// Sets a post to null in database by its ID.
		/// </summary>
		/// <param name="id">The ID of the post. It can be an int or a string.</param>
		static protected void ClearPost(object id)
		{
			if (id.ToString() == "")
				return;

			FileManager.DeleteAllPostAttachmentsById(id);

			GetCommand(
				$"UPDATE Posts SET MeetingId = NULL, Title = NULL, Content = NULL, Author = NULL, Date = NULL, LatestDate = NULL, Tags = NULL, Attachments = NULL WHERE Id = {id}"
			).ExecuteNonQuery(true);
		}

		/// <summary>
		/// Removes a post of a Meeting member.
		/// </summary>
		/// <param name="member"></param>
		/// <param name="post"></param>
		static protected void RemovePostFromMember(User member, Post post)
		{
			LoadUserGmpIds(
				member.Id,
				out List<string> groupIds,
				out List<List<string>> meetingIds,
				out List<List<List<string>>> postIds
			);

			int groupIndex = groupIds.IndexOf(post.Meeting.Group.Id.ToString());
			int meetingIndex = meetingIds[groupIndex].IndexOf(post.Meeting.Id.ToString());

			postIds[groupIndex][meetingIndex].Remove(post.Id.ToString());

			GetCommand(
				$"UPDATE Users SET Posts = '{Encode3dList(postIds)}' WHERE Id = {member.Id}"
			).ExecuteNonQuery(true);
		}

		#endregion

		#endregion

		#region *************** UPDATING DATA ***************

		#region ADDING G/M MEMBERS

		/// <summary>
		/// Adds a member user to a group in database.
		/// (This methods does not check if the group exists in the database.)
		/// </summary>
		/// <param name="group">The group where the user is being added.</param>
		/// <param name="member">The user to add to the group.</param>
		static public void AddGroupMember(Group group, User member)
		{
			Connection.Open();

			AppendRecordList("Groups", "Users", group.Id, member.Id);
			AppendRecordList("Users", "Groups", member.Id, group.Id);

			Connection.Close();
		}

		/// <summary>
		/// Adds member users to a group in database.
		/// (This methods does not check if the group exists in the database.)
		/// </summary>
		/// <param name="group">The group where the users are being added.</param>
		/// <param name="members">The collection of members to be added.</param>
		static public void AddGroupMembers(Group group, IEnumerable<User> members)
		{
			Connection.Open();

			// add users to group
			AppendRecordList("Groups", "Users", group.Id, EncodeIdList(members));

			// add group to each user's group list
			foreach (User p in members)
				AppendRecordList("Users", "Groups", p.Id, group.Id);

			Connection.Close();
		}

		/// <summary>
		/// Adds a member user to a meeting in database.
		/// </summary>
		/// <param name="meeting">The meeting where the user is being added.</param>
		/// <param name="member">The user to be added.</param>
		static public void AddMeetingMember(Meeting meeting, User member)
		{
			Connection.Open();

			AppendRecordList("Meetings", "Users", meeting.Id, member.Id);

			AddMeetingToMember(member, meeting);

			Connection.Close();
		}

		/// <summary>
		/// Adds member users to a meeting in database.
		/// </summary>
		/// <param name="meeting">The meeting where the users are being added.</param>
		/// <param name="members">The collectionof users to be added.</param>
		static public void AddMeetingMembers(Meeting meeting, IEnumerable<User> members)
		{
			Connection.Open();

			AppendRecordList("Meetings", "Users", meeting.Id, EncodeIdList(members));

			foreach (User p in members)
				AddMeetingToMember(p, meeting);

			Connection.Close();
		}

		/// <summary>
		/// [Private] Adds a meeting, along with the posts it contains, to a meeting member.
		/// </summary>
		static protected void AddMeetingToMember(User member, Meeting meeting)
		{
			SQLiteDataReader reader = GetCommand(
				   $"SELECT Groups, Meetings, Posts FROM Users WHERE Id = {member.Id}"
			).ExecuteReader(true);

			LoadUserGmpIds(
				member.Id,
				out List<string> groupIds,
				out List<List<string>> meetingIds,
				out List<List<List<string>>> postIds
			);

			int groupIndex = groupIds.IndexOf(meeting.Group.Id.ToString());

			if (groupIndex == meetingIds.Count)
				meetingIds.Add(new List<string>());

			if (groupIndex == postIds.Count)
				postIds.Add(new List<List<string>>());

			meetingIds[groupIndex].Add(meeting.Id.ToString());
			postIds[groupIndex].Add(new List<string> { EncodeIdList(meeting.Posts) });

			GetCommand(
				$"UPDATE Users SET Meetings = '{Encode2dList(meetingIds)}', Posts = '{Encode3dList(postIds)}' Where Id = {member.Id}"
			).ExecuteNonQuery(true);
		}

		#endregion

		#region REMOVING G/M MEMBERS

		/// <summary>
		/// Removes a member from a group in database.
		/// </summary>
		/// <param name="group">The group to remove the member from.</param>
		/// <param name="member">The member to remove.</param>
		static public void RemoveGroupMember(Group group, User member)
		{
			Connection.Open();

			// remove user from group
			RemoveFromRecordList("Groups", "Users", group.Id, member.Id);

			// remove the group, and its containing meetings and posts from the user
			RemoveGroupFromMember(member, group);

			// remove user from meetings in the group
			foreach (Meeting p in group.Meetings)
				RemoveFromRecordList("Meetings", "Users", p.Id, member.Id);

			Connection.Close();
		}

		/// <summary>
		/// Removes members from a group in database.
		/// </summary>
		/// <param name="group">The group to remove the members from.</param>
		/// <param name="members">The list of members to remove.</param>
		static public void RemoveGroupMembers(Group group, IEnumerable<User> members)
		{
			Connection.Open();

			// remove user from group
			RemoveFromRecordList("Groups", "Users", group.Id, EncodeIdList(members));

			// remove the group, and its containing meeting and posts from the users
			foreach (User p in members)
				RemoveGroupFromMember(p, group);

			// remove user from meetings in the group
			foreach (Meeting p in group.Meetings)
				RemoveFromRecordList("Meetings", "Users", p.Id, EncodeIdList(members));

			Connection.Close();
		}

		/// <summary>
		/// [Private] Removes the group, also the meetings and posts in the group, from a group member.
		/// </summary>
		static protected void RemoveGroupFromMember(User member, Group group)
		{
			LoadUserGmpIds(
				member.Id,
				out List<string> groupIds,
				out List<List<string>> meetingIds,
				out List<List<List<string>>> postIds
			);

			int groupIndex = groupIds.IndexOf(group.Id.ToString());

			groupIds.RemoveAt(groupIndex);
			meetingIds.RemoveAt(groupIndex);
			postIds.RemoveAt(groupIndex);

			GetCommand(
				$"UPDATE Users SET Groups = '{EncodeList(groupIds)}', Meetings = '{Encode2dList(meetingIds)}', Posts = '{Encode3dList(postIds)}' WHERE Id = {member.Id}"
			).ExecuteNonQuery(true);
		}

		/// <summary>
		/// Removes a member from a meeting in database.
		/// </summary>
		/// <param name="group">The meeting to remove the member from.</param>
		/// <param name="members">The member to remove.</param>
		static public void RemoveMeetingMember(Meeting meeting, User member)
		{
			Connection.Open();

			RemoveFromRecordList("Meetings", "Users", meeting.Id, member.Id);

			RemoveMeetingFromMember(member, meeting);

			Connection.Close();
		}

		/// <summary>
		/// Removes members from a meeting in database.
		/// </summary>
		/// <param name="group">The meeting to remove the members from.</param>
		/// <param name="members">The list of members to remove.</param>
		static public void RemoveMeetingMembers(Meeting meeting, IEnumerable<User> members)
		{
			Connection.Open();

			RemoveFromRecordList("Meetings", "Users", meeting.Id, EncodeIdList(members));

			foreach (User p in members)
				RemoveMeetingFromMember(p, meeting);

			Connection.Close();
		}

		/// <summary>
		/// [Private] Removes the meeting and the posts in the meeting from a meeting member.
		/// </summary>
		static protected void RemoveMeetingFromMember(User member, Meeting meeting)
		{
			LoadUserGmpIds(
				member.Id,
				out List<string> groupIds,
				out List<List<string>> meetingIds,
				out List<List<List<string>>> postIds
			);

			int groupIndex = groupIds.IndexOf(meeting.Group.Id.ToString());
			int meetingIndex = meetingIds[groupIndex].IndexOf(meeting.Id.ToString());

			meetingIds[groupIndex].RemoveAt(meetingIndex);
			postIds[groupIndex].RemoveAt(meetingIndex);

			GetCommand(
				$"UPDATE Users SET Meetings = '{Encode2dList(meetingIds)}', Posts = '{Encode3dList(postIds)}' WHERE Id = {member.Id}"
			).ExecuteNonQuery(true);
		}

		#endregion

		#region UPDATING G/M/P INFO

		/// <summary>
		/// Updates the information of a group in the database.
		/// (Information only contains the group's Name and Description, not the Members!)
		/// </summary>
		/// <param name="group">The group to update.</param>
		static public void UpdateGroup(Group group)
		{
			Connection.Open();

			GetCommand(
				$"UPDATE Groups SET Name = @0, Description = @1, Admins = '{EncodeIdList(group.Administrators)}', Permissions = '{EncodeGroupPermissionSettings(group)}' WHERE Id = {group.Id}",
				group.Name,
				group.Description
			).ExecuteNonQuery(true);

			Connection.Close();
		}

		/// <summary>
		/// Updates the info of a meeting in the database.
		/// </summary>
		/// <param name="meeting">The meeting to update.</param>
		static public void UpdateMeeting(Meeting meeting)
		{
			Connection.Open();

			GetCommand(
				$"UPDATE Meetings SET Description = @0, Tags = '{EncodeTagList(meeting.Tags)}' WHERE Id = {meeting.Id}",
				meeting.Description
			).ExecuteNonQuery(true);

			Connection.Close();
		}

		/// <summary>
		/// Updates a post in the database.
		/// </summary>
		/// <param name="post">The post to update.</param>
		static public void UpdatePost(Post post)
		{
			Connection.Open();

			GetCommand(
				$"UPDATE Posts SET Title = @0, Content = @1, LatestDate = '{EncodeDate(post.LatestDate)}', Tags = '{EncodeTagList(post.Tags)}', Attachments = '{EncodeIdList(post.Attachments)}' WHERE Id = {post.Id}",
				post.Title,
				post.RtfContent
			).ExecuteNonQuery(true);

			Connection.Close();
		}

		#endregion

		#region UPDATING USER DATA (INFO/NOTIFS)

		/// <summary>
		/// Saves CurrentUser's group, meeting, and post orders to database.
		/// </summary>
		static public void UpdateUserGmps()
		{
			Connection.Open();

			GetCommand(
				$"UPDATE Users SET Groups = '{EncodeIdList(CurrentUser.JoinedGroups)}', Meetings = '{EncodeMeetingList(CurrentUser.JoinedGroups)}', Posts = '{EncodePostList(CurrentUser.JoinedGroups)}' WHERE Id = {CurrentUser.Id}"
			).ExecuteNonQuery(true);

			Connection.Close();
		}

		/// <summary>
		/// Saves CurrentUser's notification data to the database.
		/// </summary>
		static public void UpdateUserNotifications()
		{
			Connection.Open();

			GetCommand(
				$"UPDATE Users SET Notifications = '{EncodeNotificationList(CurrentUser.Notifications)}' WHERE Id = {CurrentUser.Id}"
			).ExecuteNonQuery(true);

			Connection.Close();
		}

		#endregion

		#endregion

		#region *************** SEARCHING DATA ***************

		/// <summary>
		/// Search for users in the database by a keyword.
		/// </summary>
		/// <param name="keyword">The searching keyword.</param>
		/// <returns></returns>
		static public List<User> SearchUsers(string keyword)
		{
			List<User> result = new List<User>();

			Connection.Open();

			SearchUsersBy("Username", keyword.Replace(" ", "_"), false, result);

			if (keyword.Length == 10 && numberFilter.IsMatch(keyword))
				SearchUsersBy("Phone", keyword, true, result);

			SearchUsersBy("Name", keyword, false, result);

			if (emailFilter.IsMatch(keyword))
				SearchUsersBy("Email", keyword, true, result);
			else
				SearchUsersBy("Email", keyword, false, result);

			Connection.Close();
			
			return result.Distinct().ToList();
		}

		#endregion

		#region *************** NOTIFICATIONS ***************

		/// <summary>
		/// Sends a notification.
		/// </summary>
		/// <param name="notification">The notification to send.</param>
		/// <param name="receiver">The receiver of the notification.</param>
		static public void SendNotification(Notification notification, User receiver)
		{
			if (receiver.Id == CurrentUser.Id)
				return;

			Connection.Open();

			SQLiteDataReader reader = GetCommand($"SELECT Notifications FROM Users WHERE Id = {receiver.Id}").ExecuteReader(true);

			reader.Read();
			string newData = reader.GetString("Notifications");
			reader.Close();

			if (newData != "")
				newData += "\n";

			newData += EncodeNotification(notification);

			GetCommand(
				$"UPDATE Users SET Notifications = @0 WHERE Id = {receiver.Id}",
				newData
			).ExecuteNonQuery(true);

			Connection.Close();
		}

		/// <summary>
		/// Send a notification to a list of receivers.
		/// This method won't send notifications to CurrentUser himself.
		/// </summary>
		/// <param name="notification">The notification to send.</param>
		/// <param name="receivers">The receivers of the notification.</param>
		static public void SendNotifications(Notification notification, IEnumerable<User> receivers)
		{
			// the collection is empty or contains only the current user
			if (receivers.Count() == 0
				|| receivers.Count() == 1 && receivers.ToList()[0].Id == CurrentUser.Id)
			{
				return;
			}

			Connection.Open();

			string notifData = EncodeNotification(notification);

			foreach (User p in receivers)
			{
				// don't send notifications to current user himself
				if (p.Id == CurrentUser.Id)
					continue;

				SQLiteDataReader reader = GetCommand($"SELECT Notifications FROM Users WHERE Id = {p.Id}").ExecuteReader(true);

				reader.Read();
				string newData = reader.GetString("Notifications");
				reader.Close();

				if (newData != "")
					newData += "\n";

				newData += notifData;

				GetCommand(
					$"UPDATE Users SET Notifications = @0 WHERE Id = {p.Id}",
					newData
				).ExecuteNonQuery(true);
			}

			Connection.Close();
		}

		#endregion

		#endregion

		#region ########################### PRIVATE METHODS #############################

		#region *************** BASIC TOOLS ***************

		/// <summary>
		/// [Private] Generates an SQLiteCommand to execute. Pass arguments to safely encode escape characters.
		/// </summary>
		/// <param name="command">The command being executed. Use "@0", "@1", etc. to pass arguments.</param>
		/// <param name="args">The arguments to pass. The first value will replace "@0" in the string, and so on.</param>
		static protected SQLiteCommand GetCommand(string command, params object[] args)
		{
			SQLiteCommand temp = new SQLiteCommand(command, Connection);

			if (args.Length > 0)
			{
				for (int i = 0, l = args.Length; i < l; i++)
					temp.Parameters.AddWithValue($"@{i}", args[i]);
			}

			return temp;
		}

		/// <summary>
		/// [Private] Checks if a value exists in a particular column in a table. Returns true if it does.
		/// </summary>
		/// <param name="table">The name of the table to search for.</param>
		/// <param name="column">The column to search for.</param>
		/// <param name="value">The value to check if is match.</param>
		static protected bool CheckExistance(string table, string column, string value)
		{
			Connection.Open();

			SQLiteDataReader reader = GetCommand($"SELECT Id FROM {table} WHERE {column} = '{value}'").ExecuteReader(true);

			try
			{
				return reader.Read();
			}
			finally
			{
				reader.Close();

				Connection.Close();
			}
		}

		#endregion

		#region *************** LOADING TOOLS ***************

		/// <summary>
		/// [Private] Loads the basic info (username, name, and status) of a user by its ID.
		/// The SQLiteConnection should be opened before this method is called!
		/// (This method does not check if the ID exists in the database!)
		/// </summary>
		/// <param name="id">The ID of the user (this should be an int but set to string to avoid using ToString's).</param>
		static protected User LoadUserInfo(string id)
		{
			// search loadedUsers dict to see if the user info is already gotten
			if (loadedUsers.ContainsKey(id))
				return loadedUsers[id];

			SQLiteDataReader reader = GetCommand($"SELECT * FROM Users WHERE Id = {id}").ExecuteReader(true);

			reader.Read();

			try
			{
				return LoadUserInfo(reader, false);
			}
			finally
			{
				reader.Close();
			}
		}

		/// <summary>
		/// [Private] Loads the basic info (username, name, and status) of a user by its ID,
		/// using the given SQLiteDataReader.
		/// (This method does not close the reader after reading!)
		/// </summary>
		/// <param name="reader">The reader to be used to load the new user's information.</param>
		static protected User LoadUserInfo(SQLiteDataReader reader, bool checkIfLoaded = true)
		{
			int id = reader.GetInt32("Id");

			if (checkIfLoaded && loadedUsers.ContainsKey(id.ToString()))
				return loadedUsers[id.ToString()];

			User user = new User(
				reader.GetString("Username"),
				reader.GetString("Name"),
				reader.GetString("Status"),
				reader.GetString("Email"),
				reader.GetString("Phone"),
				id,
				reader.GetBoolean("IsAdmin")
			);

			FileManager.LoadUserImage(user);

			// record the loaded user just in case another group/meeting/post needs it,
			// so we don't have to load it again
			loadedUsers[user.Id.ToString()] = user;

			return user;
		}

		/// <summary>
		/// [Private] Loads the ID lists of groups, meetings, and posts of a user by his ID.
		/// </summary>
		static protected void LoadUserGmpIds(
			object id,
			out List<string> groupIds,
			out List<List<string>> meetingIds,
			out List<List<List<string>>> postIds)
		{
			SQLiteDataReader reader = GetCommand(
				$"SELECT Groups, Meetings, Posts FROM Users WHERE Id = {id}"
			).ExecuteReader(true);

			reader.Read();

			groupIds = DecodeList(reader.GetString("Groups"));
			meetingIds = Decode2dList(reader.GetString("Meetings"));
			postIds = Decode3dList(reader.GetString("Posts"));

			reader.Close();
		}

		/// <summary>
		/// [Private] Searches and loads the basic info (username, name, and status) of a user by a given keyword.
		/// The SQLiteConnection should be opened before this method is called!
		/// </summary>
		/// <param name="column">The column to search keyword from.</param>
		/// <param name="keyword">The keyword to search.</param>
		/// <param name="isPerfectMatch">Whether it should use perfect-match when searching.</param>
		/// <param name="result">The reference to the output list.</param>
		static protected void SearchUsersBy(string column, string keyword, bool isPerfectMatch, List<User> result)
		{
			string command = isPerfectMatch ?
				$"SELECT * FROM Users WHERE {column} = '{keyword}'" :
				$"SELECT * FROM Users WHERE {column} LIKE '%{keyword}%'";

			SQLiteDataReader reader = GetCommand(command).ExecuteReader(true);

			while (reader.Read())
				result.Add(LoadUserInfo(reader));

			reader.Close();
		}

		#endregion

		#region *************** SAVING TOOLS ***************

		/// <summary>
		/// [Private] Returns the first empty (null) row in a table, or -1 if there's no empty rows.
		/// </summary>
		/// <param name="table">The name of the table to search for.</param>
		/// <param name="columnToIdentify">The name of the column which will be checked if is null.</param>
		static protected int GetEmptyRowOf(string table, string columnToIdentify)
		{
			SQLiteDataReader reader = GetCommand($"SELECT * FROM {table} WHERE {columnToIdentify} IS NULL").ExecuteReader(true);

			try
			{
				return reader.Read() ? reader.GetInt32("Id") : -1;
			}
			finally
			{
				reader.Close();
			}
		}

		/// <summary>
		/// [Private] Inserts a new record to a table in the database, and returns the ID of the inserted record.
		/// This method will find an empty row in the table and fill it first.
		/// </summary>
		/// <param name="table">The name of the table to insert data to.</param>
		/// <param name="args">The data to insert, formatted as "key-value-pairs" (Key0, Value0, Key1, Value1, etc.)</param>
		static protected int InsertRecord(string table, params object[] args)
		{
			if (args.Length % 2 == 1)
				throw new Exception("Argument args must have an even # of length.");

			object[] keys = args.Where((x, i) => i % 2 == 0).ToArray();
			object[] values = args.Where((x, i) => i % 2 == 1).ToArray();
			string command;

			int id = GetEmptyRowOf(table, keys[0].ToString());

			// fill empty spots first
			if (id >= 0)
			{
				command = $"UPDATE {table} SET ";
				for (int i = 0, l = keys.Length; i < l; i++)
					command += $"{keys[i]} = @{i}, ";

				command = $"{command.Substring(0, command.Length - 2)} WHERE Id = {id}";
			}
			else
			{
				id = Convert.ToInt32(GetCommand($"SELECT COUNT(Id) FROM {table}").ExecuteScalar(true));

				command = $"INSERT INTO {table} (Id, {string.Join(", ", keys)}) VALUES ({id}, ";
				for (int i = 0, l = keys.Length; i < l; i++)
					command += $"@{i}, ";

				command = $"{command.Substring(0, command.Length - 2)})";
			}

			GetCommand(command, values).ExecuteNonQuery(true);

			return id;
		}

		/// <summary>
		/// [Private] Inserts a value (usually an ID) to the end of a record that is an in-database formatted list.
		/// </summary>
		/// <param name="table">The name of the table to insert the value to.</param>
		/// <param name="column">The name of the column where the formatted list is in.</param>
		/// <param name="id">The target row ID.</param>
		/// <param name="value">The value to insert.</param>
		static protected void AppendRecordList(string table, string column, int id, object value)
		{
			SQLiteDataReader reader = GetCommand($"SELECT {column} FROM {table} WHERE Id = {id}").ExecuteReader(true);

			reader.Read();
			string data = reader.GetString(column);
			reader.Close();

			if (data != "")
				data += ",";

			data += value.ToString();

			GetCommand($"UPDATE {table} SET {column} = '{data}' WHERE Id = {id}").ExecuteNonQuery(true);
		}

		/// <summary>
		/// [Private] Removes a value (usually an ID) from a record that is an in-database formatted list.
		/// </summary>
		/// <param name="table">The name of the table to remove the value from.</param>
		/// <param name="column">The name of the column where the formatted list is in.</param>
		/// <param name="id">The target row ID.</param>
		/// <param name="value">The value to search and remove.</param>
		static protected bool RemoveFromRecordList(string table, string column, int id, object value)
		{
			SQLiteDataReader reader = GetCommand($"SELECT {column} FROM {table} WHERE Id = {id}").ExecuteReader(true);

			reader.Read();
			List<string> data = DecodeList(reader.GetString(column));
			reader.Close();

			if (!data.Remove(value.ToString()))
				return false;

			GetCommand($"UPDATE {table} SET {column} = '{EncodeList(data)}' WHERE Id = {id}").ExecuteNonQuery(true);

			//tra.ce("SHOWDETAILS!!", data);

			return true;
		}

		#endregion

		#region *************** ENCODING TOOLS ***************

		#region DATES

		/// <summary>
		/// [Private] Encodes a DateTime instance to its in-database format ("yyyy/MM/dd HH:mm:ss").
		/// </summary>
		/// <param name="date">The DateTime instance to encode.</param>
		static protected string EncodeDate(DateTime date)
		{
			return date.ToString("yyyy/MM/dd HH:mm:ss");
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a DateTime instance.
		/// </summary>
		/// <param name="dateData">The encoded string of the Datetime instance.</param>
		static protected DateTime DecodeDate(string dateData)
		{
			return DateTime.ParseExact(dateData, "yyyy/MM/dd HH:mm:ss", null);
		}

		#endregion

		#region NOTIFICATIONS

		/// <summary>
		/// [Private] Encodes a Notification instance to its in-database format
		/// ("type\tdate\tisRead\tgroupId\tgroupName\tmeetingId\tmeetingName\tpostId\tpostName").
		/// </summary>
		/// <param name="notification">The Notification instance to encode.</param>
		static protected string EncodeNotification(Notification notification)
		{
			// notifData: type,date,isRead,groupId,groupName,meetingId,meetingName,postId,postName
			// comma = \t

			string notifData = $"{(int)notification.Type}\t{EncodeDate(notification.Date)}\t{notification.IsRead.ToString().ToLower()}\t{notification.User?.Id ?? -1}\t{notification.User1?.Id ?? -1}\t";

			notifData += (notification.Group == null ?
				"\t-1"
				: $"{notification.Group.Name}\t{notification.Group.Id}") + "\t";

			notifData += (notification.Meeting == null ?
				"\t-1" :
				$"{notification.Meeting.Name}\t{notification.Meeting.Id}") + "\t";

			notifData += (notification.Post == null ?
				"\t-1" :
				$"{notification.Post.Title}\t{notification.Post.Id}");

			return notifData;
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a Notification instance.
		/// </summary>
		/// <param name="notifData">The encoded string of a Notification instance.</param>
		static protected Notification DecodeNotification(string notifData)
		{
			string[] notif = notifData.Split('\t');

			Notification notification = new Notification((NotificationType)int.Parse(notif[0]), DecodeDate(notif[1]), bool.Parse(notif[2]));

			if (notif[3][0] != '-') // int(notif[3]) >= 0 (-1 means it's N/A)
			{
				notification.User = LoadUserInfo(notif[3]);

				if (notif[4][0] != '-') // user1 is not N/A
					notification.User1 = LoadUserInfo(notif[4]);

				if (notif[5] != "") // group is not N/A
				{
					if (notif[6][0] == '-') // group is deleted (doesn't have an ID so it's -1)
						notification.Group = new Group(notif[5]);
					else
						notification.Group = CurrentUser.GetGroupById(int.Parse(notif[6])) ?? new Group(notif[5]);

					if (notif[7] != "") // meeting isn't N/A
					{
						if (notif[8][0] == '-')
							notification.Meeting = new Meeting(notif[7]);
						else
							notification.Meeting = CurrentUser.GetMeetingById(int.Parse(notif[8]), notification.Group) ?? new Meeting(notif[7]);

						if (notif[9] != "") // post isn't N\A
						{
							if (notif[10][0] == '-')
								notification.Post = new Post(notif[9]);
							else
								notification.Post = CurrentUser.GetPostById(int.Parse(notif[10]), notification.Meeting) ?? new Post(notif[9]);
						}
					}
				}
			}

			return notification;
		}

		/// <summary>
		/// [Private] Encodes a list of notifications to its in-database formatted string.
		/// </summary>
		/// <param name="notifications">The list of notifications.</param>
		static protected string EncodeNotificationList(List<Notification> notifications)
		{
			return EncodeList(CurrentUser.Notifications.Select(x => EncodeNotification(x)), '\n');
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a list of notifications.
		/// </summary>
		/// <param name="notifData">The in-database formatted list of notif string.</param>
		static protected List<Notification> DecodeNotificationList(string notifData)
		{
			return DecodeList(notifData, '\n').Select(x => DecodeNotification(x)).ToList();
		}

		#endregion

		#region TAGS

		/// <summary>
		/// [Private] Encodes a Tag list to its in-database format
		/// ("tagType0,tagType1,tagType2,...").
		/// </summary>
		/// <param name="tags">The list of Tags to encode.</param>
		static protected string EncodeTagList(List<Tag> tags)
		{
			return EncodeList(tags.Select(x => x.Name));
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a list of Tags. 
		/// </summary>
		/// <param name="tagData">The in-database formatted string to decode.</param>
		static protected List<Tag> DecodeTagList(string tagData)
		{
			return DecodeList(tagData).Select(x => new Tag(x)).ToList();
		}

		#endregion

		#region ATTACHMENTS

		/// <summary>
		/// [Private] Encodes a PostAttachment list to its in-database format
		/// ("attUrl0\nattUrl1\nattUrl2\n...").
		/// </summary>
		/// <param name="attachments">The list of PostAttachments to encode.</param>
		static protected string EncodeAttachmentList(List<PostAttachment> attachments)
		{
			return EncodeList(attachments.Select(x => x.Url), '\n');
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a list of PostAttachments. 
		/// </summary>
		/// <param name="attachmentData">The in-database formatted string to decode.</param>
		static protected List<PostAttachment> DecodeAttachmentList(string attachmentData)
		{
			return DecodeList(attachmentData, '\n').Select(x => new PostAttachment(x)).ToList();
		}

		#endregion

		#region PERMISSIONS

		/// <summary>
		/// Encodes the permission settings of a group to the in-database format
		/// ("acceptJoinGroupRequests,inviteGroupMembers,removeGroupMembers,createMeetings,deleteMeetings,deletePosts,editGroupInfo,joitType,canBeFoundByName").
		/// </summary>
		/// <param name="group">The group whose permission settings are to be encoded.</param>
		static protected string EncodeGroupPermissionSettings(Group group)
		{
			return string.Join(",", new int[] {
				(int)group.Permissions.AcceptJoinGroupRequests,
				(int)group.Permissions.InviteGroupMembers,
				(int)group.Permissions.RemoveGroupMembers,
				(int)group.Permissions.CreateMeetings,
				(int)group.Permissions.DeleteMeetings,
				(int)group.Permissions.DeletePosts,
				(int)group.Permissions.EditGroupInfo,
				(int)group.JoinType,
				group.CanBeFoundByName.ToInt()
			});
		}

		/// <summary>
		/// Decodes an in-database string to the permission settings to a group.
		/// </summary>
		/// <param name="data">The string to decode.</param>
		/// <param name="group">The group where to put those decoded data to.</param>
		static protected void DecodeGroupPermissionSettings(string data, Group group)
		{
			int[] values = DecodeList(data).Select(x => int.Parse(x)).ToArray();

			group.Permissions = new GroupPermissions()
			{
				AcceptJoinGroupRequests = (Role)values[0],
				InviteGroupMembers = (Role)values[1],
				RemoveGroupMembers = (Role)values[2],
				CreateMeetings = (Role)values[3],
				DeleteMeetings = (Role)values[4],
				DeletePosts = (Role)values[5],
				EditGroupInfo = (Role)values[6],
			};

			group.JoinType = (GroupType)values[7];
			group.CanBeFoundByName = values[8].ToBool();
		}

		#endregion

		#region COMMON LISTS

		/// <summary>
		/// [Private] Encodes a 1-dimensional string list to its in-database format
		/// ("element0,element1,element2,...").
		/// </summary>
		/// <param name="list">The list to encode.</param>
		/// <param name="separator">The separator of the elements.</param>
		static protected string EncodeList(IEnumerable<string> list, char separator = ',')
		{
			return string.Join(separator.ToString(), list);
		}

		/// <summary>
		/// [Private] Encodes a 2-dimensional string list to its in-database format
		/// ("arr0ele0,arr0ele1,...;arr1ele0,arr1ele1,...;...").
		/// </summary>
		/// <param name="list">The list to encode.</param>
		static protected string Encode2dList(IEnumerable<IEnumerable<string>> list)
		{
			return string.Join(";", list.Select(x => EncodeList(x)));
		}

		/// <summary>
		/// [Private] Encodes a 3-dimensional string list to its in-database format
		/// ("a0a0e0,a0a0e1;a0a1e0,a0a1e1/a1a0e0,a1a0e1;a1a1e0,a1a1e1/...").
		/// </summary>
		/// <param name="list">The list to encode.</param>
		static protected string Encode3dList(IEnumerable<IEnumerable<IEnumerable<string>>> list)
		{
			return string.Join("/", list.Select(x => Encode2dList(x)));
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a 1-dimensional string list.
		/// </summary>
		/// <param name="listData">The encoded string of a 1D string list.</param>
		/// <param name="separator">The separator of the strings.</param>
		/// <returns></returns>
		static protected List<string> DecodeList(string listData, char separator = ',')
		{
			return listData.Split(separator).Where(x => x != "").ToList();
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a 2-dimensional string list.
		/// </summary>
		/// <param name="listData">The encoded string of a 2D string list.</param>
		static protected List<List<string>> Decode2dList(string listData)
		{
			return listData.Split(';').Select(x => DecodeList(x)).ToList();
		}

		/// <summary>
		/// [Private] Decodes an in-database formatted string to a 3-dimensional string list.
		/// </summary>
		/// <param name="listData">The encoded string of a 3D string list.</param>
		static protected List<List<List<string>>> Decode3dList(string listData)
		{
			return listData.Split('/').Select(x => Decode2dList(x)).ToList();
		}

		#endregion

		#region G/M/P/USER LISTS

		/// <summary>
		/// [Private] Encodes the IDs of a group/meeting/post/user list to an in-database formatted string
		/// ("id0,id1,...").
		/// </summary>
		/// <param name="data">A List instance which contains objects having an "Id" property.</param>
		/// <returns></returns>
		static protected string EncodeIdList(IEnumerable data)
		{
			return string.Join(",", data.Cast<dynamic>().Select(x => x.Id));
		}

		/// <summary>
		/// [Private] Encodes the IDs of a the Meetings in a group to an in-database formatted string
		/// ("grp0mtg0,grpmtg1,...;grp1mtg0,grp1mtg1,...;...").
		/// </summary>
		/// <param name="groups">The parent group of those meetings.</param>
		static protected string EncodeMeetingList(List<Group> groups)
		{
			return string.Join(";", groups.Select(x => EncodeIdList(x.Meetings)));
		}

		/// <summary>
		/// [Private] Encodes the IDs of the Posts in a group to an in-database formatted string
		/// (g0m0p0,g0m0p1;g0m1p0,g0m1p1/g1m0p0,g1m0p1;g1m1p0,g1m1p1/...").
		/// </summary>
		/// <param name="groups">The parent group of those posts.</param>
		static protected string EncodePostList(List<Group> groups)
		{
			return string.Join("/", groups.Select(
				x => string.Join(";", x.Meetings.Select(y => EncodeIdList(y.Posts)))
			));
		}

		#endregion

		#endregion

		#endregion

	}

}

#region ****** EXTENSIONS ******

static internal class Extensions
{

	/// <summary>
	/// Returns a column as an int by its name.
	/// </summary>
	/// <param name="input"></param>
	/// <param name="column">The name of the column.</param>
	/// <returns></returns>
	static internal int GetInt32(this SQLiteDataReader input, string column)
	{
		return Convert.ToInt32(input[column]);
	}

	/// <summary>
	/// Returns a column as a string by its name.
	/// </summary>
	/// <param name="column">The name of the column.</param>
	/// <returns></returns>
	static internal string GetString(this SQLiteDataReader input, string column)
	{
		return Convert.ToString(input[column]);
	}

	static internal bool GetBoolean(this SQLiteDataReader input, string column)
	{
		return input.GetInt32(column) == 1;
	}

	/// <summary>
	/// Executes the command.
	/// </summary>
	/// <param name="input"></param>
	/// <param name="autoDispose"></param>
	static internal void ExecuteNonQuery(this SQLiteCommand input, bool autoDispose)
	{
		// this fixes a stupid SQL bug: Database is sometimes locked
		// even when all Connections/Readers are closed,
		// because they're actually not disposed until next time
		// the Garbage -collection fires
		GC.Collect();
		GC.WaitForPendingFinalizers();

		input.ExecuteNonQuery();

		if (autoDispose)
			input.Dispose();
	}

	static internal SQLiteDataReader ExecuteReader(this SQLiteCommand input, bool autoDispose)
	{
		try
		{
			return input.ExecuteReader();
		}
		finally
		{
			if (autoDispose)
				input.Dispose();
		}
	}

	static internal object ExecuteScalar(this SQLiteCommand input, bool autoDispose)
	{
		try
		{
			return input.ExecuteScalar();
		}
		finally
		{
			if (autoDispose)
				input.Dispose();
		}
	}

}

#endregion