using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carbolibrary;
using CarboUiComponent;

namespace DontDeleteThisStefan
{

	public partial class PostPanel : UserControl
	{

		/// ***************************** CONSTUCTOR ********************************

		public PostPanel()
		{
			InitializeComponent();

			// instance init

			TitleTextBox = new Carbotextbox("Post Title", TitleSampleTextBox);
			ContentTextBox = new Carbotextbox("Post content...", ContentSampleTextBox);

			TitleTextBox.BorderStyle = ContentTextBox.BorderStyle = BorderStyle.None;
			TitleTextBox.TabStop = ContentTextBox.TabStop = false;

			Controls.Add(TitleTextBox);
			Controls.Add(ContentTextBox);
			Controls.Add(EditButton);

			// instance event init

			TitleTextBox.TextChanged += OnTitleTextBoxChanged;
			ContentTextBox.TextChanged += OnContentTextBoxChanged;
			ContentTextBox.KeyDown += OnContentTextBoxKeyDown;

			// others

			editingTextBoxColor = rg.b(0x051C2E);

			Editable = false;
		}

		/// ************************** PUBLIC PROPERTIES ****************************

		public Carbotextbox TitleTextBox;
		public Carbotextbox ContentTextBox;
		public CarbolistItem CurrentListItem;
		public Post CurrentPost;

		public bool Editable
		{
			get
			{
				return !TitleTextBox.ReadOnly;
			}

			set
			{
				TitleTextBox.ReadOnly = ContentTextBox.ReadOnly = !value;

				//TitleTextBox.BackColor = ContentTextBox.BackColor =
				//	value ?
				//	editingTextBoxColor : BackColor;

				TitleTextBox.BorderStyle = ContentTextBox.BorderStyle =
					value ?
					BorderStyle.FixedSingle : BorderStyle.None;

				DeleteButton.Visible = value;

				DeleteButton.Text = isNewPost ? "Discard" : "Delete";
				EditButton.Text = value ? "Save" : "Edit";

				UpdateEditButtonStatus();
			}
		}

		/// ************************* PRIVATE PROPERTIES ****************************

		protected Color editingTextBoxColor;
		protected bool isNewPost;

		/// *************************** PUBLIC METHODS ******************************

		public void ShowPanel(CarbolistItem postListItem, bool isNewPost = false)
		{
			Visible = true;

			CurrentListItem = postListItem;
			CurrentPost = postListItem.Data as Post;

			TitleTextBox.Text = CurrentPost.Title;
			ContentTextBox.Text = CurrentPost.Content;

			DateLabel.Text = CurrentPost.Date.ToLongDateString();

			AuthorLabel.Text = $"{CurrentPost.Meeting.Group.Name}: {CurrentPost.Meeting.Name}";

			this.isNewPost = isNewPost;

			// ###### TESTING AREA ######

		}

		public void HidePanel()
		{
			Visible = false;

			if (Editable && CurrentPost != null)
			{
				if (ContainsTexts())
					SavePost();
				else
					DeletePost();
			}

			isNewPost = false;

			Editable = false;

			CurrentPost = null;
			CurrentListItem = null;
		}

		/// *************************** PRIVATE METHODS *****************************

		protected bool ContainsTexts()
		{
			return TitleTextBox.RawText.Replace(" ", "") != "" || ContentTextBox.RawText.Replace(" ", "").Replace(n.l, "") != "";
		}

		protected void UpdateEditButtonStatus()
		{
			EditButton.Enabled = !Editable || ContainsTexts();
		}

		protected void SavePost()
		{
			if (CurrentPost.Title == TitleTextBox.RawText && CurrentPost.Content == ContentTextBox.RawText)
				return;

			CurrentPost.Date = DateTime.Now;

			if (TitleTextBox.RawText == "")
				CurrentPost.Title = "Untitled Post";
			else
				CurrentPost.Title = TitleTextBox.RawText;

			if (ContentTextBox.RawText == "")
				CurrentPost.Content = "...";
			else
				CurrentPost.Content = ContentTextBox.RawText;
		}

		protected void DeletePost()
		{
			if (CurrentListItem != null)
			{
				CurrentListItem.ParentList.RemoveItem(CurrentListItem);

				(ParentForm as MainForm).MeetingPanel.Visible = true;
			}

			CurrentPost.Meeting.RemovePost(CurrentPost);

			Visible = false;
		}

		/// ******************************* EVENTS **********************************

		protected void OnTitleTextBoxChanged(object target, EventArgs e)
		{
			if (!Editable)
				return;

			if (CurrentListItem == null)
				return;

			CurrentListItem.Title = TitleTextBox.RawText;

			UpdateEditButtonStatus();
		}

		protected void OnContentTextBoxChanged(object target, EventArgs e)
		{
			UpdateEditButtonStatus();
		}

		protected void OnContentTextBoxKeyDown(object target, KeyEventArgs e)
		{
			if (!Editable)
				return;

			// replace tabs with 4 spaces
			if (e.KeyCode == Keys.Tab)
			{
				SendKeys.Send("{BS}");
				ContentTextBox.AppendText("    ");
			}
		}

		protected void OnEditButtonClick(object target, EventArgs e)
		{
			if (Editable)
			{
				SavePost();

				ShowPanel(CurrentListItem); // update panel
			}

			Editable = !Editable;
		}

		protected void OnDeleteButtonClick(object target, EventArgs e)
		{
			if (isNewPost)
			{
				TitleTextBox.Text = "";
				ContentTextBox.Text = "";

				HidePanel();

				return;
			}

			DeletePost();
		}

	}
}
