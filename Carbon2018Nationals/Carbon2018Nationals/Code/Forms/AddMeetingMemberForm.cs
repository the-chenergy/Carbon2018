using Carbolibrary;
using CarboUiComponent;
using Carboutil;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon
{

	public partial class AddMeetingMemberForm : AddGroupMemberForm
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// This is for the designer. Use the other constructor instead!
		/// </summary> 
		public AddMeetingMemberForm()
			: base()
		{
			InitializeComponent();
		}

		public AddMeetingMemberForm(Meeting meeting, Action<List<User>> onComplete = null)
			: base(meeting.Group)
		{
			InitializeComponent();

			Init(meeting.Group, onComplete);

			Meeting = meeting;
			ExistingUsers = meeting?.Members ?? new List<User>();

			DescriptionLabel.Text = $"to meeting {meeting?.Name} of group {meeting?.Group?.Name}";

			SearchTextBox.Text = "";
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Meeting Meeting;

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################

		override public void Search()
		{
			SearchList.RemoveAllItems();

			if (Group.Members.Count == 1) // only the user himself is in the group
			{
				SearchHintLabel.Visible = true;
				SearchHintLabel.Text = $"Add more users to this group \"{Group.Name}\" first!";
				SearchResultLabel.Text = "Hint:";

				return;
			}

			if (SearchTextBox.RawText.Trim() == "")
			{
				SearchList.AddItemsBy("Name", Group.Members, "UserImage64");
				SearchResultLabel.Text = $"All members of group \"{Group.Name}\":";
			}
			else
			{
				SearchList.AddItemsBy("Name", Group.SearchMembers(SearchTextBox.RawText), "UserImage64");
				SearchResultLabel.Text = "Search Results:";
			}

			foreach (CarbolistItem p in SearchList.Items)
				DrawSpecialSearchListItem(p);

			SearchList.SortItemsBy("Tag.Name");

			foreach (User p in AddedList.Items.Select(x => x.Tag).Cast<User>().Concat(ExistingUsers))
			{
				foreach (CarbolistItem q in SearchList.Items)
				{
					if ((q.Tag as User).Id == p.Id)
					{
						q.Text += " (Added)";
						q.ForeColor = Color.Gray;

						break;
					}
				}
			}

			if (SearchList.Items.Count > 0)
				SearchHintLabel.Visible = false;
			else
				SearchHintLabel.Text = $"No users found in group {Group.Name}.";
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################

		override protected void OnSearchTextBoxTextChanged(object sender, EventArgs e)
		{
			base.OnSearchTextBoxTextChanged(sender, e);

			if (SearchHintLabel.Text == "Searching...")
				SearchResultLabel.Text = "Search Results:";
		}

	}

}
