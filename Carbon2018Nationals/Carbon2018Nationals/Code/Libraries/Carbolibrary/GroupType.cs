using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	/// <summary>
	/// Determines the permission level of a Group (open/half-open/closed).
	/// </summary>
	public enum GroupType
	{

		/// <summary>All Carbon users can search and join this group, no requests or permissions will be required.</summary>
		FullyOpen,

		/// <summary>All Carbon users can search this group, but they need to send requests and wait for approvals before joining this group.</summary>
		HalfOpen,

		/// <summary>Carbon users cannot search this group (this group is invisible to search engines), and they can only join this group with invitations.</summary>
		FullyClosed,

	}

}
