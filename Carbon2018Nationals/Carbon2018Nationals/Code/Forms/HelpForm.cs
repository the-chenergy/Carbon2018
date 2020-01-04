using Carbon.Properties;

using CarboUiComponent;

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

	public partial class HelpForm : Form
	{

		#region ############################# CONSTRUCTOR ###############################

		public HelpForm()
		{
			InitializeComponent();

			CarbolistTheme tempTheme = CarbolistTheme.LightBlue;
			tempTheme.FirstItemBackColor = ControlPaint.Light(BackColor, .10f);
			tempTheme.SecondItemBackColor = ControlPaint.Light(BackColor, .15f);
			tempTheme.SelectedItemBackColor = ControlPaint.Light(BackColor, 1.00f);

			MenuList = new Carbolist(tempTheme, MenuListSampleButton, OnMenuListItemSelect)
			{
				CanDeselect = false,
				CanDragAndDrop = false,
			};

			MenuList.AddItem(Page.Login);
			MenuList.AddItem(Page.SignUp);
			MenuList.AddItem(Page.Groups);
			MenuList.AddItem(Page.Meetings);
			MenuList.AddItem(Page.Posts);
			MenuList.AddItem(Page.Attachments);
			MenuList.AddItem(Page.Tags);
			MenuList.AddItem(Page.Permissions);
			MenuList.AddItem(Page.About);

			Controls.Add(MenuList);
		}

		#endregion

		#region ########################## PUBLIC PROPERTIES ############################

		public Carbolist MenuList;
		public string CurrentPage;

		#endregion

		#region ######################### PRIVATE PROPERTIES ############################



		#endregion

		#region ########################### PUBLIC METHODS ##############################

		public void ShowForm(string page)
		{
			MenuList.SelectWhere(x => x.Text == page);

			Show();
		}

		#endregion

		#region ########################### PRIVATE METHODS #############################



		#endregion

		#region ############################### EVENTS ##################################

		protected void OnMenuListItemSelect(CarbolistItem sender)
		{
			if (sender.Text == CurrentPage)
				return;

			CurrentPage = sender.Text;

			ContentTextBox.Visible = false;
			ContentTextBox.Text = "";

			switch (CurrentPage)
			{
				case Page.Login:
					ContentTextBox.AppendText("To login, enter your username in the username field");
					ContentTextBox.AppendImage(Resources.HelpLogin0);
					ContentTextBox.AppendText("Then enter your password in the password field");
					ContentTextBox.AppendImage(Resources.HelpLogin1);
					ContentTextBox.AppendText("And then press login at the bottom right");
					ContentTextBox.AppendImage(Resources.HelpLogin2);
					break;

				case Page.SignUp:
					ContentTextBox.AppendText("If you do not have a user account press - New to Carbon? Click here!");
					ContentTextBox.AppendImage(Resources.HelpSignUp0);
					ContentTextBox.AppendText("Enter your information including your name,");
					ContentTextBox.AppendImage(Resources.HelpSignUp1);
					ContentTextBox.AppendText("A unique username,");
					ContentTextBox.AppendImage(Resources.HelpSignUp2);
					ContentTextBox.AppendText("And a password at least 8 characters in length.");
					ContentTextBox.AppendImage(Resources.HelpSignUp3);
					ContentTextBox.AppendText("And once again...");
					ContentTextBox.AppendImage(Resources.HelpSignUp4);
					ContentTextBox.AppendText("You may optionally add your email,");
					ContentTextBox.AppendImage(Resources.HelpSignUp5);
					ContentTextBox.AppendText("And your phone number.");
					ContentTextBox.AppendImage(Resources.HelpSignUp6);
					ContentTextBox.AppendText("When you're finshed, press Sign Up.");
					ContentTextBox.AppendImage(Resources.HelpSignUp7);
					break;

				case Page.Groups:
					ContentTextBox.AppendText("To create a group, hover your mouse over the column where the groups go (the left one) and press the button labeled Create a Group.");
					ContentTextBox.AppendImage(Resources.HelpGroup0);
					ContentTextBox.AppendText("On the right, enter your Group name in the top box labeled \"Group Name\"");
					ContentTextBox.AppendImage(Resources.HelpGroup1);
					ContentTextBox.AppendText("Next, enter a unique group code in the box labeled \"group_code\"");
					ContentTextBox.AppendImage(Resources.HelpGroup2);
					ContentTextBox.AppendText("Then add a description of your group in the big \"Group description\" box");
					ContentTextBox.AppendImage(Resources.HelpGroup3);
					ContentTextBox.AppendText("Add whatever users you need with the add members button.");
					ContentTextBox.AppendImage(Resources.HelpGroup4);
					ContentTextBox.AppendText("When you're finished, press Create at the bottom right to make your group");
					ContentTextBox.AppendImage(Resources.HelpGroup5);
					break;

				case Page.Meetings:
					ContentTextBox.AppendText("To create a meeting, hover your mouse over the column where the meetings go (the middle one) and press the button labeled Create a Meeting.");
					ContentTextBox.AppendImage(Resources.HelpMeeting0);
					ContentTextBox.AppendText("On the right, enter your Meeting name in the top box labeled \"Meeting Name\"");
					ContentTextBox.AppendImage(Resources.HelpMeeting1);
					ContentTextBox.AppendText("Then add a description of your meeting in the big \"Meeting description\" box");
					ContentTextBox.AppendImage(Resources.HelpMeeting2);
					ContentTextBox.AppendText("Add whatever users you need with the add members button.");
					ContentTextBox.AppendImage(Resources.HelpMeeting3);
					ContentTextBox.AppendText("When you're finished, press Create at the bottom right to make your meeting");
					ContentTextBox.AppendImage(Resources.HelpMeeting4);
					break;

				case Page.Posts:
					ContentTextBox.AppendText("To create a post, hover your mouse over the column where the posts go (the right one) and press the button labeled Write a Post.");
					ContentTextBox.AppendImage(Resources.HelpPost0);
					ContentTextBox.AppendText("On the right, enter your Post name in the top box labeled \"Post Title\"");
					ContentTextBox.AppendImage(Resources.HelpPost1);
					ContentTextBox.AppendText("Then add your post content in the big \"Post content\" box -- Feel free to use the formatting tools at the bottom.");
					ContentTextBox.AppendImage(Resources.HelpPost2);
					ContentTextBox.AppendText("If there are any relevant files to add, such as an excel spreadsheet, press the Attach Files to Post button at the bottom to add the files.");
					ContentTextBox.AppendImage(Resources.HelpPost3);
					ContentTextBox.AppendText("Whenever you're done, press Publish at the bottom left to finish your post (Don't worry, you can edit it later by pressing edit)");
					ContentTextBox.AppendImage(Resources.HelpPost4);
					break;

				case Page.Tags:
					ContentTextBox.AppendText("Tags are an important part of Carbon, because they are general identifiers on your posts and meetings to identify what kind of content is in the meeting/post\n\nTo add a tag on a meeting or a post, first open a meeting or a post so you see the contents on the right.Next, press an empty tag under the name of the post or meeting.");
					ContentTextBox.AppendImage(Resources.HelpTag0);
					ContentTextBox.AppendText("Fill in the tag with whatever it will be called and press enter.\n\nDone!\n\nQuick - tip: If a meeting has a tag, every post under the meeting will also share that tag, and unless you remove it from the meeting, it cannot be removed from a post.");
					break;

				case Page.Attachments:
					ContentTextBox.AppendText("To add attachments to a post, simply go to a post you would like to add the attachments to and press the button at the bottom called Attach Files to Post");
					ContentTextBox.AppendImage(Resources.HelpAttachment0);
					ContentTextBox.AppendText("If you want to modify the already attached posts, press the view attachments button");
					ContentTextBox.AppendImage(Resources.HelpAttachment1);
					ContentTextBox.AppendText("You can double click an attachment to open it.\n\nPress the edit button at the bottom right to remove an attachment.");
					ContentTextBox.AppendImage(Resources.HelpAttachment2);
					break;

				case Page.Permissions:
					ContentTextBox.AppendText("Permissions work like this: Owner > Administator > Regular User. An owner or administrator of a group can create meetings, while a regular user can. Any user however, can make a post. An owner or administrator can promote normal users to an administrator by selecting a group, and going to advanced settings at the bottom right.");
					ContentTextBox.AppendImage(Resources.HelpPermission0);
					ContentTextBox.AppendText("Here, you can also modify lots of permissions, such as letting more than just admins do a specific task, or restricting a task to just the owner");
					ContentTextBox.AppendImage(Resources.HelpPermission1);
					ContentTextBox.AppendText("To make a user a group administrator, click their picture/name in the group user menu and press set as administrator");
					ContentTextBox.AppendImage(Resources.HelpPermission2);
					break;

				case Page.About:
					ContentTextBox.AppendText("This cute little program was brought to life by Stefan Todorov and Qianlang Chen.\n\nStefan Todorov: stefan.b.todorov@gmail.com\nQianlang Chen: qianlangchen@gmail.com\n\n");
					ContentTextBox.AppendImage(Resources.LogoIcon);
					break;
			}

			ContentTextBox.Visible = true;

			ContentTextBox.ScrollBar.Value = 0;
			ContentTextBox.Refresh();
		}

		#endregion

		#region *************** EXTENSIONS ***************

		public class Page
		{

			public const string Login = "Login";
			public const string SignUp = "Sign Up";
			public const string Groups = "Groups";
			public const string Permissions = "Permissions";
			public const string Meetings = "Meetings";
			public const string Tags = "Tags";
			public const string Posts = "Posts";
			public const string Attachments = "Attachments";
			public const string About = "About";

		}

		#endregion

	}

}
