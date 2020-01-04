using Carbon.Properties;

using Carbolibrary;
using CarboUiComponent;
using Carboutil;

using WMPLib;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon
{

	public partial class Form1 : Form
	{

		#region ############################# CONSTRUCTOR ###############################

		public Form1()
		{
			InitializeComponent();

			#region INSTANCES INIT

			SearchTextBox.Text = "";

			CarboControlDarkener.Darken(MeetingListLabel);
			CarboControlDarkener.Darken(PostListLabel);

			GroupList = new Carbolist(CarbolistTheme.LightBlue, GroupListSampleButton, OnGroupListItemSelect);
			MeetingList = new Carbolist(CarbolistTheme.LightBlue, MeetingListSampleButton, OnMeetingListItemSelect);
			PostList = new Carbolist(CarbolistTheme.LightBlue, PostListSampleButton, OnPostListItemSelect);

			GroupList.AddDefaultItem("Join a group");
			GroupList.AddDefaultItem("Create a group");
			GroupList.RegisterLeftMenuButton("Sort", Resources.SortIcon,
				"By Name (A to Z)", "Tag.Name",
				"By Name (Z to A)", "/Tag.Name",
				"By Date Created (newest first)", "/Tag.Date.Ticks",
				"By Date Created (oldest first)", "Tag.Date.Ticks"
			);
			GroupList.RegisterRightMenuButton("New", Resources.NewIcon,
				"Join an Existing Group", "join",
				"Create a New Group", "create"
			);
			GroupList.OnMenuButtonClick = OnGroupListMenuButtonClick;

			MeetingList.AddDefaultItem("Create a meeting");
			MeetingList.RegisterLeftMenuButton("Sort", Resources.SortIcon,
				"By Name (A to Z)", "Tag.Name",
				"By Name (Z to A)", "/Tag.Name",
				"By Date Created (newest first)", "/Tag.Date.Ticks",
				"By Date Created (oldest first)", "Tag.Date.Ticks"
			);
			MeetingList.RegisterRightMenuButton("New", Resources.NewIcon);
			MeetingList.OnMenuButtonClick = OnMeetingListMenuButtonClick;

			PostList.AddDefaultItem("Write a post");
			PostList.RegisterLeftMenuButton("Sort", Resources.SortIcon,
				"By Title (A to Z)", "Tag.Title",
				"By Title (Z to A)", "/Tag.Title",
				"By Date Pulished (newest first)", "/Tag.Date.Ticks",
				"By Date Pulished (oldest first)", "Tag.Date.Ticks",
				"By Date Updated (newest first)", "/Tag.LatestDate.Ticks",
				"By Date Updated (oldest first)", "Tag.LatestDate.Ticks",
				"By Author (A to Z)", "Tag.Author.Name",
				"By Author (Z to A)", "/Tag.Author.Name"
			);
			PostList.RegisterRightMenuButton("New", Resources.NewIcon);
			PostList.OnMenuButtonClick = OnPostListMenuButtonClick;

			GroupList.OnDefaultItemSelect = OnGroupListDefaultItemSelect;
			MeetingList.OnDefaultItemSelect = OnMeetingListDefaultItemSelect;
			PostList.OnDefaultItemSelect = OnPostListDefaultItemSelect;

			this.AddControl(GroupList, true, true);
			this.AddControl(MeetingList, true, true);
			this.AddControl(PostList, true, true);

			GroupPanel.OnGroupSaved = OnGroupPanelGroupSaved;
			GroupPanel.OnGroupDeleted = OnGroupPanelGroupDeleted;
			MeetingPanel.OnMeetingSaved = OnMeetingPanelMeetingSaved;
			MeetingPanel.OnMeetingDeleted = OnMeetingPanelMeetingDeleted;
			PostPanel.OnPostSaved = OnPostPanelPostSaved;
			PostPanel.OnPostDeleted = OnPostPanelPostDeleted;

			MenuBar.OnSelect = OnMenuBarSelect;

			#endregion

			#region PREFS AND DATA

			Global.Config.LoadConfig(Urls.TrySolveDataUrl(Urls.Config));

			if (Global.Config.IsDebugging)
			{
				MenuBar.ApplyDebuggingSettings();

				MaximumSize = new Size(int.MaxValue, int.MaxValue);
			}

			if (Global.Config.PlayWelcomeAndGoodbyeSounds)
				PlayWelcomeSound();

			if (Global.Config.PlayBackgroundMusic)
				PlayBackgroundMusic();

			if (Global.Config.DarkenUnselectListItems)
				GroupList.AutoDarkenUnselectControl = MeetingList.AutoDarkenUnselectControl = true;

			ConnectToDatabase();

			Database.ConnectFileManager(Urls.TrySolveDataUrl(Urls.FileManager));

			#endregion

			SwitchTab(Tab.Login);

			#region ***************** TESTING AREA *****************

			//tra.ce(Role.Owner > Role.Administrator);
			//tra.ce(Role.Owner >= Role.Administrator);
			//tra.ce(Role.Owner == Role.Administrator);
			//tra.ce(Role.Owner < Role.Administrator);

			#endregion
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public LoginPanel LoginPanel;
		public Carbolist GroupList;
		public Carbolist MeetingList;
		public Carbolist PostList;
		public User CurrentUser;
		public Group SelectedGroup;
		public Meeting SelectedMeeting;
		public Post SelectedPost;
		public Tab CurrentTab;

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		protected HelpForm helpForm;
		protected WindowsMediaPlayer music;
		protected bool isFirstLogin = true; // determines whether it should auto-login; auto-login should work only on the first login.

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		#region *************** BARS & TABS ***************

		public void SwitchTab(Tab tab)
		{
			CurrentTab = tab;

			switch (tab)
			{
				case Tab.Login:
					GroupListLabel.Visible = MeetingListLabel.Visible = PostListLabel.Visible = false;
					HidePostList();
					HideMeetingList();
					GroupList.Visible = GroupPanel.Visible = false;

					MenuBar.Enabled = false;

					this.AddControl(LoginPanel = new LoginPanel()
					{
						Location = new Point(50, 46),
					});
					LoginPanel.UsernameTextBox.Text = Global.Config.SavedLoginUsername;
					LoginPanel.PasswordTextBox.Text = Global.Config.SavedLoginPassword;
					LoginPanel.UsernameTextBox.Select();

					if (Global.Config.AutoLogin && isFirstLogin)
					{
						isFirstLogin = false;

						LoginPanel.Login();
					}

					break;

				case Tab.Meetings:
					Global.Config.SavedLoginUsername = LoginPanel.UsernameTextBox.RawText;
					Global.Config.SavedLoginPassword = Sha512Encoder.Encode(LoginPanel.PasswordTextBox.RawText);

					Controls.Remove(LoginPanel);
					LoginPanel.Dispose();

					MenuBar.Enabled = true;

					GroupListLabel.Visible = MeetingListLabel.Visible = PostListLabel.Visible = true;
					GroupList.Visible = true;

					SearchTextBox.Visible = true;

					break;
			}

			ResizeControls();
		}

		#endregion

		#region *************** UI COMPONENTS ***************

		public void ShowHelpForm(string page = "")
		{
			if (helpForm == null)
			{
				helpForm = new HelpForm();

				helpForm.FormClosed += OnFormHelpClosed;
			}

			if (page != "")
			{
				helpForm.ShowForm(page);
			}
			else if (CurrentTab == Tab.Login)
			{
				if (LoginPanel.SignUpPanel?.Visible == true)
					helpForm.ShowForm(HelpForm.Page.SignUp);
				else
					helpForm.ShowForm(HelpForm.Page.Login);
			}
			else if (PostPanel.Visible)
			{
				if (PostPanel.AttachmentList.Visible)
					helpForm.ShowForm(HelpForm.Page.Attachments);
				else
					helpForm.ShowForm(HelpForm.Page.Posts);
			}
			else if (MeetingPanel.Visible)
			{
				helpForm.ShowForm(HelpForm.Page.Meetings);
			}
			else
			{
				helpForm.ShowForm(HelpForm.Page.Groups);
			}
		}

		public void ClearMeetingPage()
		{
			HideMeetingList();
			HidePostList();
			GroupList.RemoveAllItems();
			GroupPanel.HidePanel();

			CurrentUser = null;
		}

		public void ShowMeetingList()
		{
			if (MeetingList.Visible)
				return;

			MeetingList.Visible = true;

			CarboControlDarkener.Undarken(MeetingListLabel);
		}

		public void HideMeetingList()
		{
			if (!MeetingList.Visible)
				return;

			MeetingList.Visible = false;
			MeetingPanel.HidePanel();

			GroupPanel.Visible = true;

			UpdateMeetingOrders();

			CarboControlDarkener.Darken(MeetingListLabel);
		}

		public void ShowPostList()
		{
			if (PostList.Visible)
				return;

			PostList.Visible = true;

			CarboControlDarkener.Undarken(PostListLabel);
		}

		public void HidePostList()
		{
			if (!PostList.Visible)
				return;

			PostList.Visible = false;
			PostPanel.HidePanel();

			UpdatePostOrders();

			CarboControlDarkener.Darken(PostListLabel);
		}

		public void ShowSearchBar()
		{
			if (SearchButton.Visible)
				return;

			ClearSearchButton.Visible = SearchButton.Visible = true;
			HelpWindowButton.Visible = false;
		}

		public void HideSearchBar()
		{
			if (HelpWindowButton.Visible)
				return;

			HelpWindowButton.Visible = true;
			ClearSearchButton.Visible = SearchButton.Visible = false;
		}

		public void ShowSearchPanel()
		{
			if (SearchPanel.Visible)
				return;

			MeetingListLabel.Visible = PostListLabel.Visible = false;
			GroupListLabel.Text = "Search Results";

			SearchPanel.Visible = true;

			SearchPanel.BringToFront();

			ResizeControls();
		}

		public void HideSearchPanel()
		{
			if (!SearchPanel.Visible)
				return;

			MeetingListLabel.Visible = PostListLabel.Visible = true;
			GroupListLabel.Text = "Groups";

			SearchPanel.Visible = false;
		}

		public void ResizeControls()
		{
			if (WindowState == FormWindowState.Minimized)
				return;

			int width = Size.Width, height = Size.Height;

			// orig: 1276, 717
			//tra.ce(CurrentPage, width, height);

			// logo
			LogoPictureBox.Left = width - 628;
			LogoPictureBox.Top = height - 569;

			// list background
			ListBackground.Height = height - 107;

			// bar backgrounds
			MenuBar.ResizeBar(height - 36);

			// search result panel
			if (SearchPanel.Visible)
				SearchPanel.ResizePanel(height - 116);

			switch (CurrentTab)
			{
				case Tab.Login:
					LoginPanel.ResizePanel(height - 87);
					break;

				case Tab.Meetings:
					// lists!!
					GroupList.Height = MeetingList.Height = PostList.Height = height - 116;

					// panels!
					GroupPanel.ResizePanel(width - 621, height - 41);
					MeetingPanel.ResizePanel(width - 621, height - 46);
					PostPanel.ResizePanel(width - 621, height - 56);

					break;
			}
		}

		#endregion

		#region *************** DATA ***************

		#region LOGIN

		/// <summary>
		/// -1=cannot connect, -2=incorrect username/password
		/// </summary>
		public int LoginToDatabase(string username, string password)
		{
			// save current data
			if (CurrentUser != null)
			{
				UpdatePostOrders(false);
				UpdateMeetingOrders(false);
				UpdateGroupOrders(false);

				Database.UpdateUserGmps();
			}

			if (!Database.IsConnected && ConnectToDatabase() < 0)
				return -1;

			if (!Database.Login(username, password))
				return -2;

			CurrentUser = Database.CurrentUser;

			/// //////////////////////////////////////////////////////////////////////////////////////
			///		SHOW NOTIFICATIONS
			/// //////////////////////////////////////////////////////////////////////////////////////

			//tra.ce(CurrentUser.Notifications);

			IEnumerable<string> notifTexts = CurrentUser.Notifications.Where(x => !x.IsRead).Select(x => x.GetText());
			
			if (notifTexts.Count() > 0)
			{
				if (MessageBox.Show(
					$"YOU HAVE {notifTexts.Count()} NEW NOTIFICATION(S): \n\n{string.Join("\n\n", notifTexts)}\n\nSHOW THESE AGAIN NEXT TIME?",
					"Notifications",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Asterisk) == DialogResult.No)
				{
					foreach (Notification p in CurrentUser.Notifications)
						p.IsRead = true;

					Database.UpdateUserNotifications();
				}
			}

			// show lists
			GroupList.AddItemsBy("Name", CurrentUser.JoinedGroups);

			// show user image
			MenuBar.UserImageBox.BackgroundImage = CurrentUser.UserImage;

			// user functions
			if (CurrentUser.IsAdministrator)
			{
				if (GroupList.DefaultItems.All(x => x.Text != "Create a group"))
					GroupList.AddDefaultItem("Create a group");
			}
			else
			{
				GroupList.RemoveDefaultItem(GroupList.DefaultItems.Find(x => x.Text == "Create a group"));
			}

			GroupList.RightMenuButton.ContextMenu.MenuItems[1].Enabled = CurrentUser.IsAdministrator;

			return 0;
		}

		#endregion

		#region G/M/P

		public CarbolistItem CreateGroup()
		{
			Group group = new Group("", "", "", null, -1, CurrentUser)
			{
				CurrentUserRole = Role.Owner,
			};

			group.AddMember(CurrentUser);

			HideMeetingList();
			HidePostList();

			GroupList.HideDefaultItems();

			GroupPanel.ShowPanel(GroupList.SelectItem(GroupList.AddItem("", null, group)), true);
			GroupPanel.Editable = true;

			GroupPanel.NameTextBox.Select();

			return GroupPanel.CurrentListItem;
		}

		public CarbolistItem CreateMeeting()
		{
			if (SelectedGroup.Name == "")
				return null;

			Meeting meeting = new Meeting("", "", null, SelectedGroup);

			meeting.AddMember(CurrentUser);

			HidePostList();

			MeetingList.HideDefaultItems();

			MeetingPanel.ShowPanel(MeetingList.SelectItem(MeetingList.AddItem("", null, meeting)), true);
			MeetingPanel.Editable = true;

			MeetingPanel.NameTextBox.Select();

			return MeetingPanel.CurrentListItem;
		}

		public CarbolistItem CreatePost()
		{
			if (SelectedMeeting.Name == "")
				return null;

			Post post = new Post("", "", null, null, CurrentUser, SelectedMeeting);

			PostList.HideDefaultItems();

			PostPanel.ShowPanel(PostList.SelectItem(PostList.AddItem("", null, post)), true);
			PostPanel.Editable = true;

			PostPanel.TitleTextBox.Select();

			return PostPanel.CurrentListItem;
		}

		public void JoinGroup()
		{
			MessageBox.Show("TODO: Join group!", "To Do");
		}

		public bool UpdateGroupOrders(bool updateDatabase = true)
		{
			if (!GroupList.IsDragged)
				return false;

			IList newOrder = GroupList.Items.Select(x => x.Tag).ToList();

			for (int i = 0, l = newOrder.Count; i < l; i++)
			{
				CurrentUser.JoinedGroups[i] = newOrder[i] as Group;
			}

			if (updateDatabase)
				Database.UpdateUserGmps();

			return true;
		}

		public bool UpdateMeetingOrders(bool updateDatabase = true)
		{
			if (SelectedGroup == null || !MeetingList.IsDragged)
				return false;

			IList newOrder = MeetingList.Items.Select(x => x.Tag).ToList();

			for (int i = 0, l = newOrder.Count; i < l; i++)
			{
				SelectedGroup.Meetings[i] = newOrder[i] as Meeting;
			}

			if (updateDatabase)
				Database.UpdateUserGmps();

			return true;
		}

		public bool UpdatePostOrders(bool updateDatabase = true)
		{
			if (SelectedMeeting == null || !PostList.IsDragged)
				return false;

			IList newOrder = PostList.Items.Select(x => x.Tag).ToList();

			for (int i = 0, l = newOrder.Count; i < l; i++)
			{
				SelectedMeeting.Posts[i] = newOrder[i] as Post;
			}

			if (updateDatabase)
				Database.UpdateUserGmps();

			return true;
		}

		#endregion

		#region SEARCH

		public void Search()
		{
			Search(Global.MultiSpaceFilter.Replace(SearchTextBox.RawText, " ").Trim());
		}

		public void Search(string keyword, bool forceUpdateSearchTextBox = false)
		{
			if (forceUpdateSearchTextBox)
			{
				SearchTextBox.Text = keyword;

				ShowSearchBar();
			}

			bool isTagOnly = false;

			if (keyword.Length > 4 && keyword.Substring(0, 4).ToLower() == "tag:")
			{
				isTagOnly = true;
				keyword = keyword.Substring(4).Trim();
			}

			if (keyword == "") // don't search empty string
				return;

			ShowSearchPanel();

			keyword = keyword.ToLower(); // disable case sensitive

			SearchPanel.ShowResults(
				isTagOnly ? null : CurrentUser.SearchGroups(keyword),
				CurrentUser.SearchMeetings(keyword, isTagOnly),
				CurrentUser.SearchPosts(keyword, isTagOnly),
				keyword
			);
		}

		public void SelectSearchedGroup(Group group)
		{
			if (PostList.Visible)
			{
				PostList.DeselectItem();
				HidePostList();
			}

			MeetingList.DeselectItem();

			GroupList.SelectWhere(x => (x.Tag == group), true);

			SearchTextBox.Select();
			SearchTextBox.SelectAll();

			HideSearchPanel();
		}

		public void SelectSearchedMeeting(Meeting meeting)
		{
			PostList.DeselectItem();

			if (SelectedGroup != meeting.Group)
				GroupList.SelectWhere(x => (x.Tag == meeting.Group));

			MeetingList.SelectWhere(x => (x.Tag == meeting), true);

			SearchTextBox.Select();
			SearchTextBox.SelectAll();

			HideSearchPanel();
		}

		public void SelectSeacrhedPost(Post post)
		{
			if (SelectedMeeting != post.Meeting)
			{
				GroupList.SelectWhere(x => (x.Tag == post.Meeting.Group), true);
				MeetingList.SelectWhere(x => (x.Tag == post.Meeting), true);
			}

			PostList.SelectWhere(x => (x.Tag == post), true);

			SearchTextBox.Select();
			SearchTextBox.SelectAll();

			HideSearchPanel();
		}

		#endregion

		#endregion

		#endregion

		#region ########################### PRIVATE METHODS #############################

		protected void PlayWelcomeSound()
		{
			Console.Beep(2489, 666);
			Console.Beep(1245, 222);
			Console.Beep(1865, 444);
			Console.Beep(1661, 888);
			Console.Beep(2489, 444);
			Console.Beep(1865, 1666);
		}

		protected void PlayBackgroundMusic()
		{
			string url = Urls.TrySolveDataUrl(Urls.BackgroundMusic);

			if (url == null)
			{
				MessageBox.Show("BACKGROUND MOOSIC NOT FOUND!!!", "OH NO!", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			music = new WindowsMediaPlayer()
			{
				URL = Path.GetFullPath(url),
			};

			music.controls.play();
			music.settings.setMode("loop", true); // looping
		}

		protected void PlayGoodByeSound()
		{
			Console.Beep(3322, 400);
			Console.Beep(2489, 400);
			Console.Beep(1661, 400);
			Console.Beep(1865, 2000);
		}

		/// <summary>
		/// -1=user cancels, -2=cannot connect
		/// </summary>
		protected int ConnectToDatabase(bool showOpenDialog = false, string dbUrl = null)
		{
			string url;

			if (showOpenDialog)
			{
				if (OpenDBDialog.ShowDialog(this) != DialogResult.OK)
					return -1;

				url = OpenDBDialog.FileName;
			}
			else
			{
				url = dbUrl ?? Database.Url ?? Urls.TrySolveDataUrl(Urls.Database);
			}

			string fileName = url.Split('\\').Reverse().ToArray()[0];

			DialogResult result = showOpenDialog
				? MessageBox.Show(
				$"WANNA SAVE/OVERRIDE DAT DATA TO THE NEW DATABASE {fileName}?\n\n\"Yes\": Save/Override\n\"No\": Open only",
				"Save or Open",
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Asterisk,
				MessageBoxDefaultButton.Button2
			) : DialogResult.No;

			if (result == DialogResult.Cancel)
				return -1;

			if (result == DialogResult.Yes)
			{
				try
				{
					if (File.Exists(url))
						File.Delete(url);

					File.Copy(Database.Url, url);
				}
				catch
				{
					MessageBox.Show($"CANNOT ACCESS {fileName}!!", "Ugh", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			ClearMeetingPage(); // clear lists

			return Database.Connect(url) ? 0 : -2;
		}

		#endregion

		#region ############################### EVENTS ##################################

		#region *************** HOTKEYS ***************

		override protected bool ProcessCmdKey(ref Message message, Keys keys)
		{
			switch (keys)
			{
				case Keys.Tab:
					// show button focus cues just for seeing current focused button.
					Global.IsTabPressed = true;
					break;

				case Keys.F1:
					OnHelpButtonClick(HelpWindowButton, null);
					break;

				case Keys.Control | Keys.Tab:

					/// //////////////////// ///
					///		TESTING AREA	 ///
					/// //////////////////// ///

					//if (floating == null)
					//{
					//	floating = new AddGroupMemberForm();
					//	floating.ShowForm(this);
					//}
					//else
					//{
					//	floating.Close();
					//	floating = null;
					//}

					//long i = ran.dom((long)Math.Pow(1024, ran.dom(4, 0)), 0);
					//tra.ce(i, new PostAttachment("", null, i).GetSizeAsString());

					return true;
			}

			return base.ProcessCmdKey(ref message, keys);
		}

		#endregion

		#region *************** BARS & TABS ***************

		#region MENU BAR

		protected void OnMenuBarSelect(Tab tab)
		{
			switch (tab)
			{
				case Tab.OpenDb: // debugging mode
					if (ConnectToDatabase(true) >= 0)
					{
						if (LoginToDatabase(Global.Config.SavedLoginUsername, Global.Config.SavedLoginPassword) < 0)
						{
							MessageBox.Show(
								$"YOUR USERNAME OR PASSWORD IS NOT VALID TO LOGIN TO THIS DATABASE: \"{Database.Url}\"\n\nTHE TARGET DATABASE MIGHT NOT CONTAIN THIS USERNAME-PASSWORD PAIR: \n\nUsername: {Global.Config.SavedLoginUsername}\nPassword (Encrypted):\n{Global.Config.SavedLoginPassword}",
								"Ouch!!",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error
							);
						}
					}
					break;
			}
		}

		#endregion

		#region SEARCH BAR

		protected void OnSearchTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				e.SuppressKeyPress = e.Handled = true;

				Search();
			}
		}

		protected void OnSearchButtonCilck(object sender, EventArgs e)
		{
			Search();
		}

		protected void OnClearSearchButtonClick(object sender, EventArgs e)
		{
			SearchTextBox.Text = "";
			SearchTextBox.Select();
		}

		protected void OnSearchTextBoxTextChanged(object sender, EventArgs e)
		{
			if (!(SearchTextBox.Focused || ClearSearchButton.Focused)) // text is changed by something else
				return;

			if (SearchTextBox.RawText.Trim() == "")
			{
				Carbotimeout.Cancel(Search);

				HideSearchPanel();
				HideSearchBar();

				return;
			}

			ShowSearchPanel();
			ShowSearchBar();
			SearchPanel.ClearResults();

			Carbotimeout.Set(500, Search);
		}

		#endregion

		#endregion

		#region *************** LISTS ***************

		protected void OnGroupListItemSelect(CarbolistItem sender)
		{
			if (sender.IsSelected) // user selected a group
			{
				if (sender.Tag == SelectedGroup)
				// user deselected a group, then selected the same group again
				{
					MeetingList.DeselectItem();
				}
				else // user selected another group
				{
					// refresh the meeting and post orders in the group that was selected before
					UpdateMeetingOrders();
					UpdatePostOrders();

					// update selected group reference
					SelectedGroup = sender.Tag as Group;

					// hide post list
					HidePostList();
					MeetingPanel.HidePanel();

					// refresh meeting list items
					MeetingList.RemoveAllItems();
					MeetingList.AddItemsBy("Name", SelectedGroup.Meetings);

					GroupPanel.HidePanel();
				}

				GroupPanel.ShowPanel(sender);

				SelectedMeeting = null;
				SelectedPost = null;

				if (CurrentUser.JoinedGroups.Contains(SelectedGroup))
					ShowMeetingList();

				if (MeetingList.RightMenuButton.Enabled = (SelectedGroup.CurrentUserRole >= SelectedGroup.Permissions.CreateMeetings))
					MeetingList.ShowDefaultItems();
				else
					MeetingList.HideDefaultItems();
			}
			else // user deselcted a group
			{
				CarbolistItem temp;

				if ((temp = MeetingList.DeselectItem()) != null)
				{
					GroupList.SelectItem(sender);

					PostList.DeselectItem();

					OnGroupListItemSelect(sender);
					OnMeetingListItemSelect(temp);
				}
				else
				{
					UpdateMeetingOrders();
					UpdatePostOrders();

					HideMeetingList();
					HidePostList();

					GroupPanel.HidePanel();
				}
			}
		}

		protected void OnMeetingListItemSelect(CarbolistItem sender)
		{
			if (sender.IsSelected) // user selected a meeting
			{
				PostPanel.HidePanel();

				if (sender.Tag == SelectedMeeting)
				// user deselected a meeting, then selected the same meeting again
				{
					PostList.DeselectItem();
				}
				else
				{
					// refresh post order in selected meeting
					UpdatePostOrders();

					SelectedMeeting = sender.Tag as Meeting;

					MeetingPanel.HidePanel();

					// refresh post list items
					PostList.RemoveAllItems();
					PostList.AddItemsBy("Title", SelectedMeeting.Posts);
				}

				MeetingPanel.ShowPanel(sender);

				SelectedPost = null;

				if (SelectedGroup.Meetings.Contains(sender.Tag))
					ShowPostList();
			}
			else // user deselected a meeting
			{
				CarbolistItem temp;

				if ((temp = PostList.DeselectItem()) != null)
				{
					MeetingList.SelectItem(sender);

					OnMeetingListItemSelect(sender);
					OnPostListItemSelect(temp);
				}
				else
				{
					UpdatePostOrders();

					HidePostList();
					MeetingPanel.HidePanel();
				}
			}
		}

		protected void OnPostListItemSelect(CarbolistItem sender)
		{
			if (sender.IsSelected)
			{
				SelectedPost = sender.Tag as Post;

				PostPanel.HidePanel();

				// show details of current selected post
				PostPanel.ShowPanel(sender);
			}
			else
			{
				if (PostPanel.AttachmentList.Visible) // postpanel is showing attachments
				{
					PostList.SelectItem(sender);

					PostPanel.ShowPanel(sender);
				}
				else
				{
					SelectedPost = null;

					PostPanel.HidePanel();
				}
			}
		}

		protected void OnGroupListDefaultItemSelect(CarbolistItem sender)
		{
			if (CurrentUser == null)
			{
				MessageBox.Show("YOU'RE NOT EVEN LOGGED IN!!", "No way", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			if (sender.Text == "Join a group")
				JoinGroup();
			else
				CreateGroup();
		}

		protected void OnMeetingListDefaultItemSelect(CarbolistItem sender)
		{
			CreateMeeting();
		}

		protected void OnPostListDefaultItemSelect(CarbolistItem sender)
		{
			CreatePost();
		}

		protected void OnGroupListMenuButtonClick(Carbobutton sender, object tag)
		{
			if (CurrentUser == null)
			{
				MessageBox.Show("YOU'RE NOT EVEN LOGGED IN!!", "No way", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			if (sender == GroupList.LeftMenuButton)
			{
				GroupList.SortItemsBy(tag.ToString());
			}
			else // new button
			{
				if (tag.ToString() == "join")
					JoinGroup();
				else
					CreateGroup();
			}
		}

		protected void OnMeetingListMenuButtonClick(Carbobutton sender, object tag)
		{
			if (sender == MeetingList.LeftMenuButton)
				MeetingList.SortItemsBy(tag.ToString());
			else
				CreateMeeting();
		}

		protected void OnPostListMenuButtonClick(Carbobutton sender, object tag)
		{
			if (sender == PostList.LeftMenuButton)
				PostList.SortItemsBy(tag.ToString());
			else
				CreatePost();
		}

		#endregion

		#region *************** PANELS ***************

		protected void OnGroupPanelGroupSaved(Group group, bool isNew)
		{
			if (isNew) // just created
			{
				CurrentUser.AddGroup(group);

				GroupList.ShowDefaultItems();

				ShowMeetingList();

				Database.CreateGroup(group);
				Database.UpdateUserGmps();

				// send notifications to those added users

				Database.SendNotifications(
					new Notification(NotificationType.GotInvitedToGroup, CurrentUser, group),
					group.Members
				);

				if (group.Administrators.Count > 0)
				{
					Database.SendNotifications(
						new Notification(NotificationType.GotSetAsAdmin, CurrentUser, group),
						group.Administrators
					);
				}
			}
			else
			{
				Database.UpdateGroup(group);
			}
		}

		protected void OnMeetingPanelMeetingSaved(Meeting meeting, bool isNew)
		{
			if (isNew) // just created
			{
				SelectedGroup.AddMeeting(meeting);

				MeetingList.ShowDefaultItems();

				ShowPostList();

				Database.CreateMeeting(meeting);
				Database.UpdateUserGmps();

				// send notif

				Database.SendNotifications(
					new Notification(NotificationType.GotInvitedToMeeting, CurrentUser, SelectedGroup, meeting),
					meeting.Members
				);
			}
			else
			{
				Database.UpdateMeeting(meeting);
			}
		}

		protected void OnPostPanelPostSaved(Post post, bool isNew)
		{
			if (isNew) // just created
			{
				SelectedMeeting.AddPost(post);

				PostList.ShowDefaultItems();

				Database.CreatePost(post);
				Database.UpdateUserGmps();

				// send notifications

				Database.SendNotifications(
					new Notification(
						NotificationType.PostPublished,
						post.Author,
						post.Meeting.Group,
						post.Meeting,
						post
					),
					post.Meeting.Members
				);
			}
			else
			{
				Database.UpdatePost(post);

				Database.SendNotifications(
					new Notification(NotificationType.PostUpdated, CurrentUser, SelectedGroup, SelectedMeeting, post),
					SelectedMeeting.Members
				);
			}
		}

		protected void OnGroupPanelGroupDeleted(Group group, bool isNew)
		{
			GroupList.ShowDefaultItems();

			HideMeetingList();

			if (!isNew && group.Members.Contains(CurrentUser)) // the group is not deleted
			{
				CurrentUser.RemoveGroup(group);

				group.Members.Remove(CurrentUser);

				//Database.RemoveGroup(group, CurrentUser); instead of removing the whole group,
				// only remove the user himself from the group
				Database.RemoveGroupMember(group, CurrentUser);
				Database.UpdateUserGmps();

				// send notifications to the rest of group members
				// TODO: ONLY SEND NOTIFICATIONS TO ADMINS IN THE GROUP

				Database.SendNotifications(
					new Notification(NotificationType.GroupUserQuit, CurrentUser, group),
					group.Members
				);
			}
		}

		protected void OnMeetingPanelMeetingDeleted(Meeting meeting, bool isNew)
		{
			MeetingList.ShowDefaultItems();

			HidePostList();

			if (!isNew)
			{
				SelectedGroup.RemoveMeeting(meeting);

				GroupPanel.Visible = true;

				//Database.DeleteMeeting(meeting);

				Database.RemoveMeetingMember(meeting, CurrentUser);
				Database.UpdateUserGmps();

				Database.SendNotifications(
					new Notification(NotificationType.MeetingUserQuit, CurrentUser, SelectedGroup, meeting),
					meeting.Members
				);
			}
		}

		protected void OnPostPanelPostDeleted(Post post, bool isNew)
		{
			PostList.ShowDefaultItems();

			if (!isNew)
			{
				SelectedMeeting.RemovePost(post);

				MeetingPanel.Visible = true;

				Database.DeletePost(post);
				Database.UpdateUserGmps();

				Database.SendNotifications(
					new Notification(NotificationType.PostDeleted, CurrentUser, SelectedGroup, SelectedMeeting, post),
					SelectedMeeting.Members
				);
			}
		}

		#endregion

		#region *************** FORMS ***************

		protected void OnHelpButtonClick(object sender, EventArgs e)
		{
			ShowHelpForm();
		}

		protected void OnFormHelpClosed(object sender, FormClosedEventArgs e)
		{
			helpForm.FormClosed -= OnFormHelpClosed;

			helpForm = null;
		}

		protected void OnResize(object sender, EventArgs e)
		{
			ResizeControls();
		}

		protected void OnClosing(object sender, FormClosingEventArgs e)
		{
			// update data orders
			if (CurrentTab != Tab.Login)
			{
				// only update database when user actually dragged the data.
				// reduce the number of unnecessary updates
				if (UpdatePostOrders(false)
				 || UpdateMeetingOrders(false)
				 || UpdateGroupOrders(false))
					Database.UpdateUserGmps();
			}

			music?.controls.stop();

			if (Global.Config.PlayWelcomeAndGoodbyeSounds)
				PlayGoodByeSound();
		}

		#endregion

		#endregion

	}

}