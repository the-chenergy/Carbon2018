namespace Carbolibrary
{
	enum Levels { NA, User, GroupAdmin, OriginAdmin, xudo }

	///<summary> Class for assigning roles for users
	/// 
	/// External Calls:
	/// N/A
	///</summary>
	public class UserAccess
	{

		public bool EditPost;
		public bool CreatePost;
		public bool DeletePost;
		public bool CreateGroupandMeeting;
		public bool EditGroupandMeeting;
		public bool RemoveGroup;

	}

}
