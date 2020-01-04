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

	public partial class GroupAdvancedSettingForm : CarboFloatingForm
	{

		/// ############################# CONSTRUCTOR ###############################

		public GroupAdvancedSettingForm()
		{
			InitializeComponent();
		}

		public GroupAdvancedSettingForm(Group group, bool editable = false, Action<GroupAdvancedSettingForm> onEditButtonClick = null)
		{
			InitializeComponent();

			Group = group;
			OnEditButtonClick = onEditButtonClick;

			GroupNameLabel.Text = group.Name == "" ? "New Group" : group.Name;

			permissionSettings = new List<SettingItem>
			{
				new SettingItem(
					"Invite Members",
					"Who can add new members to this group.",
					(int)Group.Permissions.InviteGroupMembers,
					"Everyone", "Administrators", "Owner"
				),
				new SettingItem(
					"Remove Members",
					"Who can remove members from this group.",
					(int)Group.Permissions.RemoveGroupMembers,
					"Everyone", "Administrators", "Owner"
				),
				new SettingItem(
					"Create Meetings",
					"Who can create meetings in this group.",
					(int)Group.Permissions.CreateMeetings,
					"Everyone", "Administrators", "Owner"
				),
				new SettingItem(
					"Delete Meetings",
					"Who can delete the meetings they're in.",
					(int)Group.Permissions.DeleteMeetings,
					"Everyone", "Administrators", "Owner"
				),
				new SettingItem(
					"Edit Group Info",
					"Who can edit the name and description of this group.",
					(int)Group.Permissions.EditGroupInfo,
					"Everyone", "Administrators", "Owner"
				),
				new SettingItem(
					"New Users Can Join",
					"How new members can join this group.",
					(int)Group.JoinType,
					"Without Requests", "With Requests", "With Invitations"
				) { OnValueChanged = OnJoinTypePermissionSettingItemValueChanged },
				new SettingItem(
					"Accept Joining Requests",
					"Who can approve new members to join this group.",
					(int)Group.Permissions.AcceptJoinGroupRequests,
					"Everyone", "Administrators", "Owner"
				) { Enabled = (Group.JoinType == GroupType.HalfOpen) },
			};

			CarbolistTheme tempTheme = CarbolistTheme.LightBlue;
			tempTheme.FirstItemBackColor = tempTheme.SecondItemBackColor = BackColor;

			MenuList = new Carbolist(CarbolistTheme.LightBlue, MenuListSampleButton, OnMenuListItemSelect)
			{
				CanDragAndDrop = false,
				CanDeselect = false,
			};

			MenuList.AddItem("Permissions");
			MenuList.AddItem("Roles");

			MenuList.SelectIndex(0);

			this.AddControl(MenuList);

			if (Editable = editable)
				permissionSettings.ForEach(x => x.Editable = true);
			else
				EditButton.Visible = (Group.CurrentUserRole == Role.Owner);
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Action<GroupAdvancedSettingForm> OnEditButtonClick;
		public Carbolist MenuList;
		public CarbolistItem CurrentMenu;
		public Group Group;
		public bool Editable;

		/// ######################### PRIVATE PROPERTIES ############################

		protected List<SettingItem> permissionSettings;

		/// ########################### PUBLIC METHODS ##############################



		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################

		protected void OnEditWindowButtonClick(object sender, EventArgs e)
		{
			EditButton.Visible = false;

			Editable = true;
			permissionSettings.ForEach(x => x.Editable = true);

			OnEditButtonClick?.Invoke(this);
		}

		protected void OnCloseButtonClick(object sender, EventArgs e)
		{
			Close();

			if (!Editable)
				return;

			Group.Permissions = new GroupPermissions()
			{
				InviteGroupMembers = (Role)permissionSettings[0].SelectedIndex,
				RemoveGroupMembers = (Role)permissionSettings[1].SelectedIndex,
				CreateMeetings = (Role)permissionSettings[2].SelectedIndex,
				DeleteMeetings = (Role)permissionSettings[3].SelectedIndex,
				EditGroupInfo = (Role)permissionSettings[4].SelectedIndex,
				AcceptJoinGroupRequests = (Role)permissionSettings[6].SelectedIndex,
			};

			Group.JoinType = (GroupType)permissionSettings[5].SelectedIndex;
		}

		protected void OnMenuListItemSelect(CarbolistItem sender)
		{
			if (sender == CurrentMenu)
				return;

			Panel.RemoveAllControls();

			CurrentMenu = sender;

			switch (sender.Text)
			{
				case "Permissions":
					Panel.AddControl(PermissionHelpButton);

					Panel.AddLabel("General");

					for (int i = 0; i < 5; i++)
						Panel.AddControl(permissionSettings[i], true, HorizontalAlignment.Center);

					Panel.AddLabel("New Members");

					for (int i = 5; i < 7; i++)
						Panel.AddControl(permissionSettings[i], true, HorizontalAlignment.Center);

					if (Group.CurrentUserRole != Role.Owner)
					{
						Panel.AddLabel(
							"(Permission settings are managed by the owner of the group.)",
							12.75f,
							Color.SandyBrown,
							null,
							FontStyle.Italic
						);
					}

					break;
			}
		}

		protected void OnJoinTypePermissionSettingItemValueChanged(int value)
		{
			permissionSettings[6].Enabled = ((GroupType)value == GroupType.HalfOpen);
		}

		protected void OnPermissionHelpButtonClick(object sender, EventArgs e)
		{
			(Owner as Form1).ShowHelpForm(HelpForm.Page.Permissions);
		}

	}

}
