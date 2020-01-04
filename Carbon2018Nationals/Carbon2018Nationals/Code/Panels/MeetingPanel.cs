using Carbolibrary;
using CarboUiComponent;
using Carboutil;

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

	public partial class MeetingPanel : UserControl
	{

		#region ############################# CONSTRUCTOR ###############################

		public MeetingPanel()
		{
			InitializeComponent();

			// instances

			SortMemberButton.ContextMenu = new ContextMenu(new MenuItem[]
			{
				new MenuItem("By Name (A to Z)", OnSortMemberButtonContextMenuItemClick) {Tag = "Tag.Name"},
				new MenuItem("By Name (Z to A)", OnSortMemberButtonContextMenuItemClick) {Tag = "/Tag.Name"},
			});

			CarbolistTheme tagListTheme = CarbolistTheme.LightBlue;
			tagListTheme.ItemForeColor = Color.DarkGray;
			tagListTheme.DefaultItemForeColor = Color.DimGray;

			TagList = new Carbotilelist(tagListTheme, TagListSampleButton, OnTagListItemSelect)
			{
				CanSelect = false,
			};

			TagList.RegisterItemMenuButtons(Global.SpecialString.X, DeleteButton.BackColor, DeleteButton.ForeColor);

			this.AddControl(TagList);

			// customize style of "new" button in taglist
			AddTagItem = TagList.AddDefaultItem("Add Tag");
			AddTagItem.TextAlign = ContentAlignment.MiddleRight;
			AddTagItem.Paint += OnTagListItemPaint;

			CarbolistTheme tempTheme = CarbolistTheme.LightBlue;
			tempTheme.FirstItemBackColor = tempTheme.SecondItemBackColor = BackColor;

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

			TagList.OnItemMenuButtonClick = OnTagListItemMenuButtonClick;
			TagList.OnDefaultItemSelect = OnTagListDefaultItemSelect;

			// others

			Editable = false;

			editableMemberListBackColor = NameTextBox.BackColorWhenEditing;
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public Carbotilelist TagList;
		public Carbotilelist MemberList;
		public CarbolistItem CurrentListItem;
		public CarbolistItem AddTagItem;
		public Meeting CurrentMeeting;
		public Action<Meeting, bool> OnMeetingSaved;
		public Action<Meeting, bool> OnMeetingDeleted;

		public bool Editable
		{
			get => DescriptionTextBox.Editable;

			set
			{
				NameTextBox.Editable = value && isNewMeeting;

				DescriptionTextBox.Editable = value;

				DeleteButton.Visible = value;

				DeleteButton.Text = isNewMeeting ? "Discard" : "Quit";
				EditButton.Text = value ? (isNewMeeting ? "Create" : "Save") : "Edit";

				MemberList.AreItemsShowingMenuButtons = value;
				MemberList.BackColor = value ? editableMemberListBackColor : BackColor;
				MemberList.BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;
				MemberList.CanDragAndDrop = value;

				TagList.AreItemsShowingMenuButtons = value;
				TagList.CanDragAndDrop = value;
				TagList.BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;

				UpdateEditButtonStatus();
			}
		}

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		protected Color editableMemberListBackColor;
		protected bool isNewMeeting;

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		public void ShowPanel(CarbolistItem meetingListItem, bool isNew = false)
		{
			Visible = true;

			CurrentListItem = meetingListItem;
			CurrentMeeting = meetingListItem.Tag as Meeting;

			NameTextBox.Text = CurrentMeeting.Name;
			ParentGroupNameLabel.Text = $"Meeting of {CurrentMeeting.Group.Name}";
			DescriptionTextBox.Text = CurrentMeeting.Description;

			MemberList.RemoveAllItems();
			MemberList.AddItemsBy("Name", CurrentMeeting.Members, "UserImage64");
			MemberList.SortItemsBy("Tag.Name");

			CarbolistItem temp = MemberList.Items.Find(x => ((x.Tag as User).Id == Database.CurrentUser.Id));

			temp.Text += " (You)";
			temp.RegisterMenuButton("");

			TagList.RemoveAllItems();
			TagList.AddItemsBy("Name", CurrentMeeting.Tags);

			TagList.Items.ForEach(x => DrawSpecialTagListItem(x));

			isNewMeeting = isNew;

			BringToFront();
		}

		public void HidePanel()
		{
			Visible = false;

			if (Editable && CurrentMeeting != null)
			{
				if (ContainsTexts())
					SaveMeeting();
				else
					DeleteMeeting();
			}

			isNewMeeting = false;

			Editable = false;

			CurrentMeeting = null;
			CurrentListItem = null;
		}

		public void ResizePanel(int width, int height)
		{
			Width = width;
			Height = height;

			EditButton.Left = width - 94;
			EditButton.Top = height - 44;

			DeleteButton.Top = height - 44;

			NameTextBox.Width = DescriptionTextBox.Width = TagList.Width = MemberList.Width = width - 60;
			MemberList.Height = height - 442;

			SortMemberButton.Left = MemberList.Right - SortMemberButton.Width;
			AddMemberButton.Left = SortMemberButton.Left - 3 - AddMemberButton.Width;
		}

		#endregion

		#region ########################### PRIVATE METHODS #############################

		protected bool ContainsTexts()
		{
			return NameTextBox.RawText.Trim() != "";
		}

		protected void UpdateEditButtonStatus()
		{
			EditButton.Enabled = !Editable || ContainsTexts();
		}

		protected void SaveMeeting()
		{
			CurrentMeeting.Name = NameTextBox.RawText;

			if (DescriptionTextBox.RawText == "")
				CurrentMeeting.Description = $"Created on {DateTime.Now.DayOfWeek.ToString()}, {DateTime.Now.ToString()}.";
			else
				CurrentMeeting.Description = DescriptionTextBox.RawText;

			CurrentMeeting.RemoveAllTags();

			// remove those tags from parent meeting before saving
			CurrentMeeting.AddTags(TagList.Items.Select(x => x.Tag as Tag));

			CurrentMeeting.RemoveAllMembers();
			CurrentMeeting.AddMembers(MemberList.Items.Select(x => x.Tag as User));

			OnMeetingSaved?.Invoke(CurrentMeeting, isNewMeeting);
		}

		protected void DeleteMeeting()
		{
			if (CurrentListItem != null)
			{
				CurrentListItem.ParentList.RemoveItem(CurrentListItem);

				OnMeetingDeleted?.Invoke(CurrentMeeting, isNewMeeting);
			}

			Visible = false;
		}

		protected void DrawSpecialTagListItem(CarbolistItem item)
		{
			item.Paint += OnTagListItemPaint;
		}

		protected void AddTag(string tagText)
		{
			AddTagItem.Enabled = true;

			AddTagTextBox.KeyDown -= OnAddTagTextBoxKeyDown;
			AddTagTextBox.TextChanged -= OnAddTagTextBoxTextChanged;
			AddTagTextBox.Leave -= OnAddTagTextBoxLeave;

			AddTagTextBox.Visible = false;

			AddTagItem.Text = "Add Tag";
			AddTagItem.AutoSetWidth();
			TagList.RefreshItems();

			if (AddTagTextBox.RawText == "")
				return;

			if (CurrentMeeting.Tags.Any(x => x.Name == AddTagTextBox.RawText))
			{
				MessageBox.Show(
					$"Tag \"{AddTagTextBox.Text}\" already exists for this post.",
					"Existing Tag",
					MessageBoxButtons.OK,
					MessageBoxIcon.Asterisk
				);

				return;
			}

			Tag tag = new Tag(AddTagTextBox.RawText);

			DrawSpecialTagListItem(TagList.AddItem(tag.Name, null, tag));

			if (!Editable)
			{
				CurrentMeeting.AddTag(tag);
				Database.UpdateMeeting(CurrentMeeting);
			}
		}

		#endregion

		#region ############################### EVENTS ##################################

		protected void OnNameTextBoxTextChange(object sender, EventArgs e)
		{
			if (!Editable && CurrentListItem == null)
				return;

			CurrentListItem.Text = NameTextBox.RawText;

			UpdateEditButtonStatus();
		}

		protected void OnEditButtonClick(object sender, EventArgs e)
		{
			if (Editable)
			{
				SaveMeeting();

				ShowPanel(CurrentListItem); // update display
			}

			ShowPanel(CurrentListItem);

			Editable = !Editable;
		}

		protected void OnDeleteButtonClick(object sender, EventArgs e)
		{
			if (isNewMeeting)
			{
				NameTextBox.Text = "";
				DescriptionTextBox.Text = "";

				HidePanel();

				return;
			}

			if (MessageBox.Show(
				$"Are you sure that you want to quit meeting \"{CurrentMeeting.Name}\"?",
				"Quit Meeting",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				DeleteMeeting();
			}
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
			new AddMeetingMemberForm(CurrentMeeting, OnAddMemberFormComplete).ShowForm(ParentForm);
		}

		protected void OnAddMemberFormComplete(List<User> users)
		{
			CurrentMeeting.AddMembers(users);
			MemberList.AddItemsBy("Name", users, "UserImage64");

			if (isNewMeeting)
				return;

			Database.AddMeetingMembers(CurrentMeeting, users);

			// send notifications to those new users

			Database.SendNotifications(
				new Notification(NotificationType.GotInvitedToMeeting, Database.CurrentUser, CurrentMeeting.Group, CurrentMeeting),
				users
			);
		}

		protected void OnMemberListItemMenuButtonClick(CarbolistItem sender)
		{
			User member = sender.Tag as User;

			if (MessageBox.Show(
				$"Remove {member.Name} from this meeting?",
				"Remove Meeting Member",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
				) == DialogResult.No)
			{
				return;
			}

			MemberList.RemoveItem(sender);
			CurrentMeeting.RemoveMember(member);

			if (isNewMeeting)
				return;

			Database.RemoveMeetingMember(CurrentMeeting, member);

			Database.SendNotification(
				new Notification(NotificationType.GotRemovedFromMeeting, Database.CurrentUser, CurrentMeeting.Group, CurrentMeeting),
				member
			);
		}

		protected void OnMemberListItemSelect(CarbolistItem item)
		{
			new BasicUserInfoForm(item.Tag as User).ShowForm(ParentForm);
		}

		protected void OnTagListItemPaint(object sender, PaintEventArgs e)
		{
			if ((sender as CarbolistItem).IsDragging)
				return;

			SolidBrush brush = new SolidBrush(TagList.BackColor);

			e.Graphics.FillPolygon(brush, new Point[]
			{
				new Point(0, 0),
				new Point(7, 0),
				new Point(0, 13),
			});

			e.Graphics.FillPolygon(brush, new Point[]
			{
				new Point(0, 13),
				new Point(7, 26),
				new Point(0, 26),
			});
		}

		protected void OnTagListItemSelect(CarbolistItem sender)
		{
			(ParentForm as Form1).Search($"Tag: {(sender.Tag as Tag).Name}", true);
		}

		protected void OnTagListItemMenuButtonClick(CarbolistItem sender)
		{
			if (MessageBox.Show(
				$"Remove Tag \"{(sender.Tag as Tag).Name}\" from this post?",
				"Remove Post Tag",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Exclamation
				) == DialogResult.No)
			{
				return;
			}

			TagList.RemoveItem(sender);
		}

		protected void OnTagListDefaultItemSelect(CarbolistItem sender)
		{
			AddTagItem.Enabled = false;

			AddTagItem.Text = "               ";
			AddTagItem.AutoSetWidth();
			TagList.RefreshItems();

			AddTagTextBox.BringToFront();

			AddTagTextBox.Visible = true;
			AddTagTextBox.Text = "";
			AddTagTextBox.Width = AddTagItem.Width - 12;

			// set the location of the textbox to the same as the "new" button's

			Point location = TagList.DefaultItems[0].Location;
			location.X += TagList.ItemContainer.Left + TagList.Left + 12;
			location.Y += TagList.ItemContainer.Top + TagList.Top + 5;

			AddTagTextBox.Location = location;

			AddTagTextBox.Select();
			AddTagTextBox.Focus();

			AddTagTextBox.KeyDown += OnAddTagTextBoxKeyDown;
			AddTagTextBox.TextChanged += OnAddTagTextBoxTextChanged;
			AddTagTextBox.Leave += OnAddTagTextBoxLeave;
		}

		protected void OnAddTagTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter || e.KeyData == Keys.Return)
			{
				if (AddTagTextBox.RawText == "")
					return;

				e.SuppressKeyPress = e.Handled = true;

				AddTag(AddTagTextBox.Text);
			}
			else if (e.KeyData == Keys.Escape)
			{
				e.SuppressKeyPress = e.Handled = true;

				AddTagTextBox.Text = "";

				AddTag("");
			}
		}

		protected void OnAddTagTextBoxTextChanged(object sender, EventArgs e)
		{
			AddTagItem.Text = "   " + AddTagTextBox.Text.PadLeft(12, ' ');
			AddTagItem.AutoSetWidth();
			TagList.RefreshItems();

			AddTagTextBox.Width = AddTagItem.Width - 12;

			Point location = TagList.DefaultItems[0].Location;
			location.X += TagList.ItemContainer.Left + TagList.Left + 12;
			location.Y += TagList.ItemContainer.Top + TagList.Top + 5;

			AddTagTextBox.Location = location;
		}

		protected void OnAddTagTextBoxLeave(object sender, EventArgs e)
		{
			AddTag(AddTagTextBox.Text);
		}

		#endregion

	}

}
