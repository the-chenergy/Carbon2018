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
	public partial class MeetingPanel : UserControl
	{

		/// ***************************** CONSTUCTOR ********************************

		public MeetingPanel()
		{
			InitializeComponent();

			// instance init

			NameTextBox = new Carbotextbox("Meeting Name", NameSampleTextBox);
			DescriptionTextBox = new Carbotextbox("Meeting description...", DescriptionSampleTextBox);

			Controls.Add(NameTextBox);
			Controls.Add(DescriptionTextBox);

			NameTextBox.BringToFront();
			NameTextBox.Visible = false;

			DescriptionTextBox.AcceptsTab = false;

			NameTextBox.TextChanged += OnNameTextBoxTextChange;

			// others

			editingTextBoxBackColor = rg.b(0x051C2E);

			Editable = false;
		}

		/// ************************** PUBLIC PROPERTIES ****************************

		public Carbotextbox NameTextBox;
		public Carbotextbox DescriptionTextBox;
		public CarbolistItem CurrentListItem;
		public Meeting CurrentMeeting;

		public bool Editable
		{
			get
			{
				return !DescriptionTextBox.ReadOnly;
			}

			set
			{
				NameTextBox.Visible = value && isNewMeeting;

				DescriptionTextBox.ReadOnly = !value;

				//DescriptionTextBox.BackColor =
				//	value ?
				//	editingTextBoxBackColor : BackColor;

				DescriptionTextBox.BorderStyle =
					value ?
					BorderStyle.FixedSingle : BorderStyle.None;

				DeleteButton.Visible = value;

				DeleteButton.Text = isNewMeeting ? "Discard" : "Delete";
				EditButton.Text = value ? "Save" : "Edit";

				UpdateEditButtonStatus();
			}
		}

		/// ************************* PRIVATE PROPERTIES ****************************

		protected Color editingTextBoxBackColor;
		protected bool isNewMeeting;

		/// *************************** PUBLIC METHODS ******************************

		public void ShowPanel(CarbolistItem meetingListItem, bool isNewMeeting = false)
		{
			Visible = true;

			CurrentListItem = meetingListItem;
			CurrentMeeting = meetingListItem.Data as Meeting;

			NameLabel.Text = NameTextBox.Text = CurrentMeeting.Name;
			ParentGroupNameLabel.Text = $"Meeting of {CurrentMeeting.Group.Name}";
			DescriptionTextBox.Text = CurrentMeeting.Description;

			this.isNewMeeting = isNewMeeting;
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

			NameTextBox.Visible = false;

			isNewMeeting = false;

			Editable = false;

			CurrentMeeting = null;
			CurrentListItem = null;
		}

		/// *************************** PRIVATE METHODS *****************************

		protected bool ContainsTexts()
		{
			return NameTextBox.RawText.Replace(" ", "") != "";
		}

		protected void UpdateEditButtonStatus()
		{
			EditButton.Enabled = !Editable || ContainsTexts();
		}

		protected void SaveMeeting()
		{
			if (CurrentMeeting.Name == NameTextBox.RawText && CurrentMeeting.Description == DescriptionTextBox.RawText)
				return;

			CurrentMeeting.Name = NameTextBox.RawText;

			if (DescriptionTextBox.RawText == "")
				CurrentMeeting.Description = $"Created on {DateTime.Now.DayOfWeek.ToString()}, {DateTime.Now.ToString()}.";
			else
				CurrentMeeting.Description = DescriptionTextBox.RawText;
		}

		protected void DeleteMeeting()
		{
			if (CurrentListItem != null)
			{
				CurrentListItem.ParentList.RemoveItem(CurrentListItem);

				(ParentForm as MainForm).HidePostList();
				(ParentForm as MainForm).GroupPanel.Visible = true;
			}

			CurrentMeeting.Group.RemoveMeeting(CurrentMeeting);

			Visible = false;
		}

		/// ******************************* EVENTS **********************************

		protected void OnNameTextBoxTextChange(object target, EventArgs e)
		{
			if (!Editable && CurrentListItem == null)
				return;

			CurrentListItem.Title = NameTextBox.RawText;

			UpdateEditButtonStatus();
		}

		protected void OnEditButtonClick(object target, EventArgs e)
		{
			SaveMeeting();

			ShowPanel(CurrentListItem);

			Editable = !Editable;
		}

		protected void OnDeleteButtonClick(object target, EventArgs e)
		{
			if (isNewMeeting)
			{
				NameLabel.Text = "";
				NameTextBox.Text = "";
				DescriptionTextBox.Text = "";

				HidePanel();

				return;
			}

			DeleteMeeting();
		}

	}
}
