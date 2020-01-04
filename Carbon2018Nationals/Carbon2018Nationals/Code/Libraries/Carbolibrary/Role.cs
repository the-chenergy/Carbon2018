using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	/// <summary>
	/// Indicates who will have the rights to complete this action.
	/// </summary>
	public enum Role
	{

		/// <summary>Represents a normal group member, or a right that everyone in a group has.</summary>
		Normal,
		/// <summary>Represents an administrator of a group, or a right that only the administrators (and the owner) of a group have.</summary>
		Administrator,
		/// <summary>Represents the owner of a group, or a right that only the owner of a group has.</summary>
		Owner,

	}

}
