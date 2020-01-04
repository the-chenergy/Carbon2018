using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	public class Notification
	{

		/// ############################# CONSTRUCTOR ###############################
		
		public Notification(NotificationType type, DateTime date, bool isRead = false)
		{
			Type = type;
			Date = date;
			IsRead = isRead;
		}

		public Notification(NotificationType type, User user, Group group, Meeting meeting = null, Post post = null)
		{
			Type = type;
			User = user;
			Group = group;
			Meeting = meeting;
			Post = post;

			Date = DateTime.Now;
		}

		public Notification(NotificationType type, User user, User user1, Group group, Meeting meeting = null, Post post = null)
		{
			Type = type;
			User = user;
			User1 = user1;
			Group = group;
			Meeting = meeting;
			Post = post;

			Date = DateTime.Now;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public User User { get; set; }
		public User User1 { get; set; }
		public Group Group { get; set; }
		public Meeting Meeting { get; set; }
		public Post Post { get; set; }
		public DateTime Date { get; set; }
		public NotificationType Type { get; set; }
		public bool IsRead { get; set; }

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################

		public string GetText()
		{
			switch (Type)
			{
				case NotificationType.GotInvitedToGroup:
					return $"{User.Name} has invited you to group \"{Group.Name}\".";

				case NotificationType.GroupUserJoined:
					return $"{User.Name} has joined group \"{Group.Name}\".";

				case NotificationType.GroupUserInvited:
					return $"{User.Name} has invited {User1.Name} to group \"{Group.Name}\".";

				case NotificationType.GotSetAsAdmin:
					return $"{User.Name} has set you as an administrator of group \"{Group.Name}\".";

				case NotificationType.GroupAdminAdded:
					return $"{User.Name} has set {User1.Name} as an administrator of group \"{Group.Name}\".";

				case NotificationType.GotRemoveAdmin:
					return $"{User.Name} has removed you from the administrators of group \"{Group.Name}\".";

				case NotificationType.GroupAdminRemoved:
					return $"{User.Name} has removed {User1.Name} from the administrators of group \"{Group.Name}\".";

				case NotificationType.GroupUserQuit:
					return $"{User.Name} has quit group \"{Group.Name}\".";

				case NotificationType.GroupUserRemoved:
					return $"{User.Name} has removed {User1.Name} from group \"{Group.Name}\".";

				case NotificationType.GotRemovedFromGroup:
					return $"{User.Name} has removed you from group \"{Group.Name}\".";

				case NotificationType.GroupDeleted:
					return $"{User.Name} has deleted group \"{Group.Name}\".";

				case NotificationType.GotInvitedToMeeting:
					return $"{User.Name} has invited you to meeting \"{Meeting.Name}\" in group \"{Group.Name}\".";

				case NotificationType.MeetingUserInvited:
					return $"{User.Name} has invited \"{User1.Name}\" to meeting \"{Meeting.Name}\" in group \"{Group.Name}\".";

				case NotificationType.MeetingUserQuit:
					return $"{User.Name} has quit meeting \"{Meeting.Name}\" in group \"{Group.Name}\".";

				case NotificationType.MeetingUserRemoved:
					return $"{User.Name} has removed {User1.Name} from meeting \"{Meeting.Name}\" in group \"{Group.Name}\".";

				case NotificationType.GotRemovedFromMeeting:
					return $"{User.Name} has removed you from meeting \"{Meeting.Name}\" in group \"{Group.Name}\".";

				case NotificationType.MeetingDeleted:
					return $"{User.Name} has deleted meeting \"{Meeting.Name}\" in group \"{Group.Name}\".";

				case NotificationType.PostPublished:
					return $"\"{Post.Title}\" - new post published by {User.Name} in meeting \"{Meeting.Name}\".";

				case NotificationType.PostUpdated:
					return $"{User.Name} has updated their post \"{Post.Title}\" in meeting \"{Meeting.Name}\".";

				case NotificationType.PostCommented:
					return $"{User.Name} has commented on your post \"{Post.Title}\" in meeting \"{Meeting.Name}\".";

				case NotificationType.PostDeleted:
					return $"{User.Name} has deleted their post \"{Post.Title}\" in meeting \"{Meeting.Name}\".";

				default:
					return tra.ce(this);
			}
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################



	}

}
