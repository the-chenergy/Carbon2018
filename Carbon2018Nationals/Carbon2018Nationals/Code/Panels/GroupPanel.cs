using Carbon.Properties;

using Carbolibrary;
using CarboUiComponent;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon
{

	public partial class GroupPanel : UserControl
	{

		#region ############################# CONSTRUCTOR ###############################

		public GroupPanel()
		{
			InitializeComponent();

			// instance init

			// sort button context menu
			SortMemberButton.ContextMenu = new ContextMenu(new MenuItem[]
			{
				new MenuItem("By Name (A to Z)", OnSortMemberButtonContextMenuItemClick) {Tag = "Tag.Name"},
				new MenuItem("By Name (Z to A)", OnSortMemberButtonContextMenuItemClick) {Tag = "/Tag.Name"},
				new MenuItem("By Role (Administrators first)", OnSortMemberButtonContextMenuItemClick) {Tag = "/MinimumSize.Width"},
				new MenuItem("By Role (Normal users first)", OnSortMemberButtonContextMenuItemClick) {Tag = "MinimumSize.Width"},
			});
			
			CarbolistTheme tempTheme = CarbolistTheme.LightBlue;
			tempTheme.FirstItemBackColor = tempTheme.SecondItemBackColor = BackColor;
			tempTheme.MenuButtonBackColor = EditButton.BackColor;

			MemberList = new Carbotilelist(tempTheme, MemberListSampleButton)
			{
				AreItemsShowingMenuButtons = false,
				CanSelect = false,
				CanDragAndDrop = false,
			};

			MemberList.RegisterItemMenuButtons(Global.SpecialString.X, DeleteButton.BackColor, DeleteButton.ForeColor);

			Controls.Add(MemberList);

			MemberList.OnItemSelect = OnMemberListItemSelect;
			MemberList.OnItemMenuButtonClick = OnMemberListItemMenuButtonClick;

			// others

			Editable = false;

			editableMemberListBackColor = NameTextBox.BackColorWhenEditing;

			tooltip = new ToolTip();

			tooltip.SetToolTip(AdminLabel, "You're an administrator of this group.");
			tooltip.SetToolTip(OwnerLabel, "You're the owner of this group.");
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public Carbotilelist MemberList;
		public CarbolistItem CurrentListItem;
		public Group CurrentGroup;
		public Action<Group, bool> OnGroupSaved;
		public Action<Group, bool> OnGroupDeleted;

		public bool Editable
		{
			get => MemberList.CanDragAndDrop;

			set
			{
				if (value)
					AdminLabel.Visible = OwnerLabel.Visible = false;

				NameTextBox.Editable = DescriptionTextBox.Editable = (value && (isNewGroup
					|| CurrentGroup.CurrentUserRole >= CurrentGroup.Permissions.EditGroupInfo));
				CodeTextBox.Editable = value && isNewGroup;

				DeleteButton.Visible = value;

				DeleteButton.Text = isNewGroup ? "Discard" : "Quit";
				EditButton.Text = value ? (isNewGroup ? "Create" : "Save") : "Edit";

				MemberList.BackColor = value ? editableMemberListBackColor : BackColor;
				MemberList.BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;
				MemberList.CanDragAndDrop = value;

				MemberList.AreItemsShowingMenuButtons = value && CurrentGroup.CurrentUserRole >= CurrentGroup.Permissions.RemoveGroupMembers;

				UpdateEditButtonStatus();
			}
		}

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		protected ToolTip tooltip;
		protected Color editableMemberListBackColor;
		protected bool isNewGroup;

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		public void ShowPanel(CarbolistItem groupListItem, bool isNew = false)
		{
			Visible = true;

			CurrentListItem = groupListItem;
			CurrentGroup = groupListItem.Tag as Group;

			NameTextBox.Text = CurrentGroup.Name;
			CodeTextBox.Text = isNew ? "" : CurrentGroup.Code;
			DescriptionTextBox.Text = CurrentGroup.Description;

			InvalidCodeLabel.Visible = false;

			MemberList.RemoveAllItems();
			MemberList.AddItemsBy("Name", CurrentGroup.Members, "UserImage64");
			MemberList.SortItemsBy("Tag.Name");

			// remove the "remove" button for the user himself in the member list
			CarbolistItem temp = MemberList.Items.Find(x => ((x.Tag as User).Id == Database.CurrentUser.Id));

			temp.Text += " (You)";
			temp.RegisterMenuButton("");

			isNewGroup = isNew;

			BringToFront();

			#region *************** PERMISSIONS ***************

			if (AdminLabel.Visible = (CurrentGroup.CurrentUserRole == Role.Administrator))
			{
				AdminLabel.BringToFront();
				AdminLabel.Left = TextRenderer.MeasureText(CurrentGroup.Name, NameTextBox.Font).Width + 20;
			}

			if (OwnerLabel.Visible = (CurrentGroup.CurrentUserRole == Role.Owner) && !isNew)
			{
				OwnerLabel.BringToFront();
				OwnerLabel.Left = TextRenderer.MeasureText(CurrentGroup.Name, NameTextBox.Font).Width + 20;
			}

			List<CarbolistItem> adminItems = MemberList.Items.FindAll(x => CurrentGroup.Administrators.Contains(x.Tag));
			CarbolistItem ownerItem = MemberList.Items.Find(x => x.Tag == CurrentGroup.Owner);

			foreach (CarbolistItem p in adminItems)
			{
				DrawSpecialMemberListAdminItem(p);
				tooltip.SetToolTip(p, "Group Administrator");

				// mark the role of the member in MinimumSize.Width :)
				p.MinimumSize = new Size((int)Role.Administrator, 0);
			}

			DrawSpecialMemberListOwnerItem(ownerItem);
			tooltip.SetToolTip(ownerItem, "Group Owner");
			ownerItem.MinimumSize = new Size((int)Role.Owner, 0);

			AddMemberButton.Visible = (CurrentGroup.CurrentUserRole >= CurrentGroup.Permissions.InviteGroupMembers);

			// remove buttons' visibilities
			if (CurrentGroup.CurrentUserRole >= CurrentGroup.Permissions.RemoveGroupMembers)
			{
				// no one will remove the owner
				ownerItem.IsShowingMenuButton = false;

				// if you're an normal user, you can't remove admins
				if (CurrentGroup.CurrentUserRole == Role.Normal)
					adminItems.ForEach(x => x.IsShowingMenuButton = false);
			}

			#endregion
		}

		public void HidePanel()
		{
			InvalidCodeLabel.Visible = false;

			Visible = false;

			if (Editable && CurrentGroup != null)
			{
				if (ContainsTexts() && !GroupCodeExists())
					SaveGroup();
				else
					DeleteGroup();
			}

			isNewGroup = false;

			Editable = false;

			CurrentGroup = null;
			CurrentListItem = null;
		}

		public void ResizePanel(int width, int height)
		{
			Width = width;
			Height = height;

			EditButton.Left = width - 94;
			AdvancedSettingButton.Left = EditButton.Left - 3 - AdvancedSettingButton.Width;

			DeleteButton.Top = EditButton.Top = AdvancedSettingButton.Top = height - 49;

			NameTextBox.Width = width - 51;

			DescriptionTextBox.Width = width - 56;

			NameTextBox.Width = DescriptionTextBox.Width = MemberList.Width = width - 60;
			MemberList.Height = height - 442;

			SortMemberButton.Left = MemberList.Right - SortMemberButton.Width;
			AddMemberButton.Left = SortMemberButton.Left - 3 - AddMemberButton.Width;
		}

		#endregion

		#region ########################### PRIVATE METHODS #############################

		protected bool ContainsTexts()
		{
			return NameTextBox.RawText.Trim() != ""
				&& CodeTextBox.RawText != "";
		}

		protected void UpdateEditButtonStatus()
		{
			EditButton.Enabled = !Editable || ContainsTexts();
		}

		protected bool GroupCodeExists()
		{
			return isNewGroup && Database.HasGroupCode(CodeTextBox.RawText);
		}

		protected bool SaveGroup()
		{
			if (isNewGroup) // restrictions of creating new groups
			{
				if (CodeTextBox.TextLength < 3)
				{
					InvalidCodeLabel.Text = "At least 3 characters!";
					InvalidCodeLabel.Visible = true;

					return false;
				}

				if (GroupCodeExists())
				{
					InvalidCodeLabel.Text = "Sorry, this group code is taken!";
					InvalidCodeLabel.Visible = true;

					return false;
				}
			}

			CurrentGroup.RemoveAllMembers();
			CurrentGroup.AddMembers(MemberList.Items.Select(x => x.Tag as User));

			if (!NameTextBox.Editable)
				return true;

			CurrentGroup.Name = NameTextBox.RawText;

			if (isNewGroup)
				CurrentGroup.Code = CodeTextBox.RawText;

			if (DescriptionTextBox.RawText == "")
				CurrentGroup.Description = $"Created on {DateTime.Now.DayOfWeek.ToString()}, {DateTime.Now.ToString()}.";
			else
				CurrentGroup.Description = DescriptionTextBox.RawText;

			OnGroupSaved?.Invoke(CurrentGroup, isNewGroup);

			return true;
		}

		protected void DeleteGroup()
		{
			if (CurrentListItem != null)
			{
				CurrentListItem.ParentList.RemoveItem(CurrentListItem);

				OnGroupDeleted?.Invoke(CurrentGroup, isNewGroup);
			}

			Visible = false;
		}

		protected void DrawSpecialMemberListAdminItem(CarbolistItem item)
		{
			item.Paint += OnMemberListAdminItemPaint;
			item.Invalidate();
		}

		protected void UndrawSpecialMemberListAdminItem(CarbolistItem item)
		{
			item.Paint -= OnMemberListAdminItemPaint;
			item.Invalidate();
		}

		protected void DrawSpecialMemberListOwnerItem(CarbolistItem item)
		{
			item.Paint += OnMemberListOwnerItemPaint;
			item.Invalidate();
		}

		#endregion

		#region ############################### EVENTS ##################################

		protected void OnNameTextBoxTextChange(object sender, EventArgs e)
		{
			if (!Editable || CurrentListItem == null)
				return;

			CurrentListItem.Text = NameTextBox.RawText;

			UpdateEditButtonStatus();
		}

		protected void OnCodeTextBoxTextChange(object sender, EventArgs e)
		{
			if (!Editable || CurrentListItem == null)
				return;

			if (InvalidCodeLabel.Visible)
				InvalidCodeLabel.Visible = false;

			UpdateEditButtonStatus();
		}

		protected void OnEditButtonClick(object sender, EventArgs e)
		{
			if (SaveGroup())
			{
				ShowPanel(CurrentListItem);

				Editable = !Editable;
			}
		}

		protected void OnDeleteButtonClick(object sender, EventArgs e)
		{
			if (isNewGroup)
			{
				NameTextBox.Text = "";
				DescriptionTextBox.Text = "";

				HidePanel();

				return;
			}

			if (CurrentGroup.CurrentUserRole == Role.Owner)
			{
				switch (MessageBox.Show(
					$"You are the owner of group \"{CurrentGroup.Name}\". You can choose to delete this group with all of members and meetings, or transfer this group to another member. Do you want to transfer this group?\n\n\"Yes\": Transfer group (recommended)\n\"No\": Delete group",
					"Transfer Group",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Exclamation
				))
				{
					case DialogResult.Cancel:
						return;

					case DialogResult.No: // delete group
						Database.SendNotifications(
							new Notification(NotificationType.GroupDeleted, Database.CurrentUser, CurrentGroup),
							CurrentGroup.Members
						);
						Database.DeleteGroup(CurrentGroup);

						DeleteGroup();
						return;

					case DialogResult.Yes:
						MessageBox.Show("TODO: Transfer group function.", "To do!");
						return;
				}
			}

			if (MessageBox.Show(
				(CurrentGroup.CurrentUserRole == Role.Administrator ? "You are an administrator of this group.\n" : "")
				+ $"Are you sure that you want to quit group \"{CurrentGroup.Name}\"?",
				"Quit Group",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation) != DialogResult.Yes)
			{
				return;
			}

			if (CurrentGroup.CurrentUserRole == Role.Administrator)
			{
				CurrentGroup.RemoveAdministrator(Database.CurrentUser);

				Database.UpdateGroup(CurrentGroup);
			}

			DeleteGroup();
		}

		protected void OnSortMemberButtonClick(object sender, EventArgs e)
		{
			SortMemberButton.ContextMenu.Show(SortMemberButton, new Point(0, SortMemberButton.Height));
		}

		protected void OnSortMemberButtonContextMenuItemClick(object sender, EventArgs e)
		{
			MemberList.SortItemsBy((sender as MenuItem).Tag.ToString());
		}

		protected void OnAddMemberButtonClick(object sender, EventArgs e)
		{
			new AddGroupMemberForm(CurrentGroup, OnAddMemberFormComplete).ShowForm(ParentForm);
		}

		protected void OnAddMemberFormComplete(List<User> users)
		{
			CurrentGroup.AddMembers(users);
			MemberList.AddItemsBy("Name", users, "UserImage64");

			if (isNewGroup) // since a brand new group doesn't have an ID, we're not able to update its users in Db.
				return;

			Database.AddGroupMembers(CurrentGroup, users);

			// send notifications to those new users

			Database.SendNotifications(
				new Notification(NotificationType.GotInvitedToGroup, Database.CurrentUser, CurrentGroup),
				users
			);
		}

		protected void OnMemberListItemMenuButtonClick(CarbolistItem sender)
		{
			User member = sender.Tag as User;

			if (MessageBox.Show(
				$"Remove {member.Name} from this group?",
				"Remove Group Member",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
				) == DialogResult.No)
			{
				return;
			}

			MemberList.RemoveItem(sender);
			CurrentGroup.RemoveMember(member);

			if (isNewGroup)
				return;

			Database.RemoveGroupMember(CurrentGroup, member);

			Database.SendNotification(
				new Notification(NotificationType.GotRemovedFromGroup, Database.CurrentUser, CurrentGroup),
				member
			);
		}

		protected void OnMemberListItemSelect(CarbolistItem sender)
		{
			if (CurrentGroup.CurrentUserRole == Role.Owner && sender.Tag != CurrentGroup.Owner)
			{
				if (CurrentGroup.Administrators.Contains(sender.Tag))
					new BasicUserInfoForm(sender.Tag as User, "", null, "Remove Administrator", OnBasicUserInfoRemoveAdminOptionClick).ShowForm(ParentForm);
				else
					new BasicUserInfoForm(sender.Tag as User, "Set as Administrator", OnBasicUserInfoSetAsAdminOptionClick).ShowForm(ParentForm);
			}
			else
			{
				new BasicUserInfoForm(sender.Tag as User).ShowForm(ParentForm);
			}
		}

		protected void OnBasicUserInfoRemoveAdminOptionClick(BasicUserInfoForm form, User user)
		{
			if (MessageBox.Show(
				$"Remove {user.Name} from the administrators of this group?",
				"Remove Group Administrator",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
			) != DialogResult.Yes)
			{
				return;
			}

			CurrentGroup.RemoveAdministrator(user);

			form.Close();

			if (isNewGroup)
			{
				UndrawSpecialMemberListAdminItem(MemberList.Items.Find(x => (x.Tag == user)));

				return;
			}

			ShowPanel(CurrentListItem);

			Database.UpdateGroup(CurrentGroup);

			Database.SendNotification(new Notification(NotificationType.GotRemoveAdmin, Database.CurrentUser, CurrentGroup), user);
			Database.SendNotifications(new Notification(NotificationType.GroupAdminRemoved, Database.CurrentUser, user, CurrentGroup), CurrentGroup.Administrators.Except(new User[] { user }));
		}

		protected void OnBasicUserInfoSetAsAdminOptionClick(BasicUserInfoForm form, User user)
		{
			CurrentGroup.AddAdministrator(user);

			form.Close();

			if (isNewGroup)
			{
				DrawSpecialMemberListAdminItem(MemberList.Items.Find(x => (x.Tag == user)));

				return;
			}

			ShowPanel(CurrentListItem);

			Database.UpdateGroup(CurrentGroup);

			Database.SendNotification(new Notification(NotificationType.GotSetAsAdmin, Database.CurrentUser, CurrentGroup), user);
			Database.SendNotifications(new Notification(NotificationType.GroupAdminAdded, Database.CurrentUser, user, CurrentGroup), CurrentGroup.Administrators.Except(new User[] { user }));
		}

		protected void OnMemberListAdminItemPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(Resources.AdminIcon, 35, 31);
		}

		protected void OnMemberListOwnerItemPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(Resources.OwnerIcon, 35, 31);
		}

		protected void OnAdvancedSettingButtonClick(object sender, EventArgs e)
		{
			new GroupAdvancedSettingForm(CurrentGroup, Editable && CurrentGroup.CurrentUserRole == Role.Owner, OnAdvancedSettingFormEditButtonClick).ShowForm(ParentForm);
		}

		protected void OnAdvancedSettingFormEditButtonClick(GroupAdvancedSettingForm form)
		{
			Editable = true;
		}

		#endregion

	}

}
