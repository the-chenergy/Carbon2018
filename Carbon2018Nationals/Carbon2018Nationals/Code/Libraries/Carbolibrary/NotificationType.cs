using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	public enum NotificationType
	{

		/**
		 *	0~50: Related to Me, 51~99: Not Related to Me
		 *	
		 *	0+: System notifications (NOT USAGE YET)
		 *	100+: Group notifications
		 *	200+: Meeting notifications
		 *	300+: Post notifications
		 */

		GotInvitedToGroup = 100, // big_z has invited you to group "TSA National".
		GotRemovedFromGroup = 101, // big_z has removed you from group "TSA National".
		GroupDeleted = 102, // big_z has deleted group "TSA National".
		GotSetAsAdmin = 103, // big_z has set you as an administrator of group "TSA National".
		GotRemoveAdmin = 104, // big_z has removed you from the administrators of group "TSA National".
		GroupUserJoined = 150, // form1 has joined group "TSA National".
		GroupUserInvited = 151, // big_z has invited form1 to group "TSA National".
		GroupUserRemoved = 152, // big_z has removed form1 from group "TSA National".
		GroupUserQuit = 153, // form1 has quit group "TSA National".
		GroupAdminAdded = 154, // big_z has set form1 as an administrator of group "TSA National".
		GroupAdminRemoved = 155, // big_z has removed form1 from the administrators of group "TSA National".

		GotInvitedToMeeting = 200, // big_z has invited you to meeting "Airline Schedules" in group "TSA National".
		GotRemovedFromMeeting = 201, // big_z has removed you from meeting "Airline Schedules" in group "TSA National".
		MeetingDeleted = 202, // big_z has deleted meeting "Airline Schedules" in group "TSA National".
		MeetingUserInvited = 250, // (similar to groups)
		MeetingUserRemoved = 251,
		MeetingUserQuit = 252,

		PostPublished = 300, // "Meet at SLC Airport" - new postby big_z in meeting "Airline Schedules" in group "TSA National"
		PostCommented = 301, // form1 has commented on big_z's post "Meet at SLC Airport" in meeting "Airline Schedules".
		PostUpdated = 350, // big_z has updated post "Meet at SLC Airport" in meeting "Airline Schedules".
		PostDeleted = 351, // big_z has deleted post "Meet at SLC Airport" in meeting "Airline Schedules".

	}

}
