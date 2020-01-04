using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

using Carbolibrary;
using CarboUiComponent;

namespace DontDeleteThisStefan
{

	public partial class MainForm : Form
	{

		/// ***************************** CONSTUCTOR ********************************

		public MainForm()
		{
			InitializeComponent();

			SayHiToUsers();

			// init data instances

			Groups = new List<Group>();

			// init list instances

			GroupList = new Carbolist(GroupSampleButton, GroupListBackground.BackColor, OnGroupListSelect);
			MeetingList = new Carbolist(MeetingSampleButton, MeetingListBackground.BackColor, OnMeetingListSelect);
			PostList = new Carbolist(PostSampleButton, PostListBackground.BackColor, OnPostListSelect);

			AddControl(GroupList);
			AddControl(MeetingList, false);
			AddControl(PostList, false);

			/// ################# TESTING AREA ###################

			//tra.ce(Color.FromArgb(255, 5, 32, 51).ToArgb());
			//tra.ce(rg.b(0x053043).ToArgb());

			//tra.ce(AddControl(new MeetingPanel())); // why the h-ck is this sh-- so huuuge???

			//MeetingPanel.BringToFront();
			//PostPanel.BringToFront(); // freak this doesnt work at all

			//if (!Carbolibrary.SaveLoad.LoadData(ref Groups, @"..\..\AppData\SampleData.xml"))
			//{
			//    MessageBox.Show("GET OUTTA HERE WITH DAT DATA!!!", "ERROR 404");
			//    Application.Exit();
			//}

			//GroupList.AddItemsBy("Name", Groups);

			//tra.ce(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

			//int tabs = 4;
			//while (tabs-- > 0)
			//	tra.ce(tabs);

			//tra.ce(Icon);

			/// ###################################################
		}

		/// ************************** PUBLIC PROPERTIES ****************************

		public Carbolist GroupList;
		public Carbolist MeetingList;
		public Carbolist PostList;
		public List<Group> Groups;
		public Group SelectedGroup;
		public Meeting SelectedMeeting;
		public Post SelectedPost;

		/// ************************* PRIVATE PROPERTIES ****************************

		protected HelpForm formHelp;
		protected SoundPlayer music;
		protected bool playSomeGoodMusicToUsers;
		protected bool sayHiWhenOpening;
		protected bool sayGoodByeWhenClosing;

		/// *************************** PUBLIC METHODS ******************************

		public Control AddControl(Control control, bool visible = true)
		{
			Controls.Add(control);
			control.BringToFront();

			//tra.ce("NODETAILS!!", control, visible);

			if (!visible)
				control.Visible = false;

			return control;
		}

		public CarbolistItem AddGroup(Group group)
		{
			HideMeetingList();
			HidePostList();

			Groups.Add(group);

			GroupPanel.ShowPanel(GroupList.SelectItem(GroupList.AddItem("", group)), true);

			NewMeetingLabel.Visible = true;

			GroupPanel.Editable = true;

			return GroupPanel.CurrentListItem;
		}

		public CarbolistItem AddMeeting(Meeting meeting)
		{
			SelectedGroup.AddMeeting(meeting);

			NewPostLabel.Visible = true;

			ShowMeetingPanel(MeetingList.SelectItem(MeetingList.AddItem("", meeting)), true);

			MeetingPanel.Editable = true;

			return MeetingPanel.CurrentListItem;
		}

		public CarbolistItem AddPost(Post post)
		{
			SelectedMeeting.AddPost(post);

			ShowPostPanel(PostList.SelectItem(PostList.AddItem("", post)), true);

			PostPanel.Editable = true;

			return PostPanel.CurrentListItem;
		}

		public void ShowMeetingList()
		{
			if (!MeetingList.Visible)
			{
				MeetingList.Visible = true;
				AddMeetingButton.Visible = true;
				NewMeetingLabel.Visible = true;
			}
		}

		public void HideMeetingList()
		{
			if (MeetingList.Visible)
			{
				MeetingList.Visible = false;
				AddMeetingButton.Visible = false;
				NewMeetingLabel.Visible = false;

				MeetingPanel.HidePanel();

				GroupPanel.Visible = true;
			}
		}

		public void ShowMeetingPanel(CarbolistItem listItem, bool isNew = false)
		{
			MeetingPanel.ShowPanel(listItem, isNew);

			GroupPanel.Visible = false;
		}

		public void HideMeetingPanel()
		{
			MeetingPanel.HidePanel();

			GroupPanel.Visible = true;
		}

		public void ShowPostList()
		{
			if (!PostList.Visible)
			{
				PostList.Visible = true;
				AddPostButton.Visible = true;
				NewPostLabel.Visible = true;
			}
		}

		public void HidePostList()
		{
			if (PostList.Visible)
			{
				PostList.Visible = false;
				AddPostButton.Visible = false;
				NewPostLabel.Visible = false;

				HidePostPanel();
			}
		}

		public void ShowPostPanel(CarbolistItem listItem, bool isNew = false)
		{
			PostPanel.ShowPanel(listItem, isNew);

			MeetingPanel.Visible = false;
		}

		public void HidePostPanel()
		{
			PostPanel.HidePanel();

			MeetingPanel.Visible = MeetingList.Visible;
		}

		public void UpdateGroupOrders()
		{
			if (!GroupList.IsDragged)
				return;

			IList newOrder = GroupList.Items.Select(x => x.Data).ToList();

			for (int i = 0, l = newOrder.Count; i < l; i++)
			{
				Groups[i] = newOrder[i] as Group;
			}
		}

		public void UpdateMeetingOrders()
		{
			if (!MeetingList.IsDragged || SelectedGroup == null)
				return;

			IList newOrder = MeetingList.Items.Select(x => x.Data).ToList();

			for (int i = 0, l = newOrder.Count; i < l; i++)
			{
				SelectedGroup.Meetings[i] = newOrder[i] as Meeting;
			}
		}

		public void UpdatePostOrders()
		{
			if (!PostList.IsDragged || SelectedMeeting == null)
				return;

			//tra.ce("Old order of " + selectedMeeting.Name, selectedMeeting.Posts.Select(x => x.Title).ToList());

			IList newOrder = PostList.Items.Select(x => x.Data).ToList();

			for (int i = 0, l = newOrder.Count; i < l; i++)
			{
				SelectedMeeting.Posts[i] = newOrder[i] as Post;
			}

			//tra.ce("New order of " + selectedMeeting.Name, selectedMeeting.Posts.Select(x => x.Title).ToList());
		}

		/// *************************** PRIVATE METHODS *****************************

		protected void SayHiToUsers()
		{
			string url0 = @"../../AppData/MoosicSettings.txt";
			string url1 = @"../AppData/MoosicSettings.txt";
			string url2 = @"AppData/MoosicSettings.txt";
			string url3 = @"DontDeleteThisStefan/AppData/MoosicSetting.txt";
			string url4 = @"MoosicSettings.txt";

			string url;

			if (!File.Exists(url = url0)
				&& !File.Exists(url = url1)
				&& !File.Exists(url = url2)
				&& !File.Exists(url = url3)
				&& !File.Exists(url = url4))
				return;

			try
			{
				string[] strings = File.ReadAllLines(url);

				sayHiWhenOpening = sayGoodByeWhenClosing = bool.Parse(strings[0]);
				playSomeGoodMusicToUsers = bool.Parse(strings[1]);
			}
			catch (Exception)
			{
				return;
			}

			if (sayHiWhenOpening)
			{
				Console.Beep(2489, 666);
				Console.Beep(1245, 222);
				Console.Beep(1865, 444);
				Console.Beep(1661, 888);
				Console.Beep(2489, 444);
				Console.Beep(1865, 1666);

				//Console.Beep(1245, 1200);
				//Console.Beep(622, 400);
				//Console.Beep(932, 800);
				//Console.Beep(831, 1600);
				//Console.Beep(1245, 800);
				//Console.Beep(932, 3000);

				//Console.Beep(311, 1200 / 2);
				//Console.Beep(156, 400 / 2);
				//Console.Beep(233, 800 / 2);
				//Console.Beep(208, 1600 / 2);
				//Console.Beep(311, 800 / 2);
				//Console.Beep(233, 3000 / 2);
			}

			if (playSomeGoodMusicToUsers)
				LoadBackgroundMusic();
		}

		protected void LoadBackgroundMusic()
		{
			string url0 = @"../../AppData/Moosic.wav";
			string url1 = @"../AppData/Moosic.wav";
			string url2 = @"AppData/Moosic.wav";
			string url3 = @"DontDeleteThisStefan/AppData/Moosic.wav";
			string url4 = @"Moosic.wav";

			string url;

			if (!File.Exists(url = url0)
				&& !File.Exists(url = url1)
				&& !File.Exists(url = url2)
				&& !File.Exists(url = url3)
				&& !File.Exists(url = url4))
			{
				MessageBox.Show("BACKGROUND MOOSIC NOT FOUND!!!", "OH NO!");

				return;
			}

			music = new SoundPlayer(url);
			music.PlayLooping();
		}

		protected void SayGoodByeToUsers()
		{
			Console.Beep(3322, 400);
			Console.Beep(2489, 400);
			Console.Beep(1661, 400);
			Console.Beep(1865, 2000);
		}

		/// ******************************* EVENTS **********************************

		protected void OnGroupListSelect(CarbolistItem target)
		{
			if (target.Selected) // user selected a group
			{
				if (target.Data == SelectedGroup)
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
					SelectedGroup = target.Data as Group;

					// hide post list
					HidePostList();

					// refresh meeting list items
					MeetingList.RemoveAllItems();
					MeetingList.AddItemsBy("Name", SelectedGroup.Meetings);

					GroupPanel.HidePanel();
				}

				GroupPanel.ShowPanel(target);

				SelectedMeeting = null;
				SelectedPost = null;

				ShowMeetingList();
				HideMeetingPanel();

				//tra.ce(SelectedGroup.Name, SelectedGroup.Description);
			}
			else // user deselcted a group
			{
				UpdateMeetingOrders();
				UpdatePostOrders();

				HideMeetingList();
				HidePostList();

				GroupPanel.HidePanel();
			}
		}

		protected void OnMeetingListSelect(CarbolistItem target)
		{
			//tra.ce(target.Name, target.Selected);

			if (target.Selected) // user selected a meeting
			{
				if (target.Data == SelectedMeeting)
				// user deselected a meeting, then selected the same meeting again
				{
					PostList.DeselectItem();
				}
				else
				{
					// refresh post order in selected meeting
					UpdatePostOrders();

					SelectedMeeting = target.Data as Meeting;

					// refresh post list items
					PostList.RemoveAllItems();
					PostList.AddItemsBy("Title", SelectedMeeting.Posts);

					HideMeetingPanel();
				}

				ShowMeetingPanel(target);

				SelectedPost = null;

				ShowPostList();
				HidePostPanel();

				//tra.ce(SelectedMeeting.Name, SelectedMeeting.Description);
			}
			else
			{
				UpdatePostOrders();

				HidePostList();
				HideMeetingPanel();
			}
		}

		protected void OnPostListSelect(CarbolistItem target)
		{
			PostPanel.HidePanel();

			if (target.Selected)
			{
				SelectedPost = target.Data as Post;

				// show details of current selected post
				ShowPostPanel(target);
			}
			else
			{
				SelectedPost = null;

				HidePostPanel();
			}
		}

		protected void OnAddGroupButtonClick(object target, EventArgs e)
		{
			//tra.ce("Adding a new group!!!!");

			AddGroup(new Group("", "", new List<User>()));
		}

		protected void OnAddMeetingButtonClick(object target, EventArgs e)
		{
			if (SelectedGroup.Name == "")
				return;

			//tra.ce($"adding a new meeting to group {SelectedGroup.Name}!!");

			AddMeeting(new Meeting("", "", null, null, null, null));
		}

		protected void OnAddPostButtonClick(object target, EventArgs e)
		{
			if (SelectedMeeting.Name == "")
				return;

			AddPost(new Post("", "", null, null));
		}

		protected void OnSaveButtonClick(object target, EventArgs e)
		{
			if (Groups.Count == 0 || Groups[0].Name == "")
			{
				MessageBox.Show("Nothing to save.", "Save");

				return;
			}

			if (SaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				UpdatePostOrders();
				UpdateMeetingOrders();
				UpdateGroupOrders();

				try
				{
					SaveLoad.SaveData(Groups, SaveFileDialog.FileName);
				}
				catch (Exception)
				{
					MessageBox.Show($"An error occured when saving the data to file \"{SaveFileDialog.FileName}\". The target file may be in use, or we may not have the right to access the target file.", ":(");

					return;
				}

				MessageBox.Show($"The data has successfully been saved to file \"{SaveFileDialog.FileName}\"!", "Save Complete!");
			}
		}

		protected string FormatFileName(string fileName)
		{
			return fileName.Split('\\').Reverse().ToList()[0];
		}

		protected void OnLoadbuttonClick(object target, EventArgs e)
		{
			if (OpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				//Groups = SaveLoad.LoadData(OpenFileDialog.FileName);

				try
				{
					Groups = SaveLoad.LoadData(OpenFileDialog.FileName);
				}
				catch (Exception)
				{
					MessageBox.Show($"File \"{FormatFileName(OpenFileDialog.FileName)}\" contains invalid data.", "Oh no!");

					return;
				}

				HidePostList();
				HideMeetingList();
				GroupPanel.HidePanel();

				GroupList.RemoveAllItems();
				GroupList.AddItemsBy("Name", Groups);
			}
		}

		protected void OnHelpButtonClick(object target, EventArgs e)
		{
			if (formHelp == null)
			{
				formHelp = new HelpForm();

				formHelp.FormClosed += OnFormHelpClosed;
			}

			formHelp.Show();
		}

		protected void OnFormHelpClosed(object target, FormClosedEventArgs e)
		{
			formHelp.FormClosed -= OnFormHelpClosed;

			formHelp = null;
		}

		protected void OnThisClosing(object target, FormClosingEventArgs e)
		{
			music?.Stop();

			if (sayGoodByeWhenClosing)
				SayGoodByeToUsers();
		}

	}

}