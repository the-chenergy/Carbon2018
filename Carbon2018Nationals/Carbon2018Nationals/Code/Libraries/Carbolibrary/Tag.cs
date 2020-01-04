using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	///<summary> 
	/// Contains a type for a meeting or a post.
	///</summary>
	public class Tag
	{

		/// <summary>
		/// Creates a new Tag instance.
		/// </summary>
		/// <param name="name">The text of the tag.</param>
		public Tag(string name = "")
		{
			Name = name;
		}

		/// <summary>The text of this tag.</summary>
		public string Name { get; set; }

	}

}
