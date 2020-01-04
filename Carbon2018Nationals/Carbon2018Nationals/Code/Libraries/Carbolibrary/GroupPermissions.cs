using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	/// <summary>
	/// Provides a collection of permission settings to a group instance.
	/// </summary>
	public struct GroupPermissions
	{

		/// ########################## PUBLIC PROPERTIES ############################

		/// <summary>The rights to accept the join-group requests from new members. This is meaningless when the value of JoinGroupPermissionType is FullyClosed.</summary>
		public Role AcceptJoinGroupRequests;

		/// <summary>The rights to invite new group members.</summary>
		public Role InviteGroupMembers;

		/// <summary>The rights to remove group members.</summary>
		public Role RemoveGroupMembers;

		/// <summary>The rights to create meetings in this Group.</summary>
		public Role CreateMeetings;

		/// <summary>The rights to delete meetings in this Group.</summary>
		public Role DeleteMeetings;

		/// <summary>The rights to delete posts in this Group.</summary>
		public Role DeletePosts;

		/// <summary>The rights to edit the info of this Group (name and description).</summary>
		public Role EditGroupInfo;

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################



		/// ########################### PRIVATE METHODS #############################



	}

}
