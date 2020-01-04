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
	public partial class GroupPanel : UserControl
	{

		/// ***************************** CONSTUCTOR ********************************

		public GroupPanel()
		{
			InitializeComponent();

			// instance init

			NameTextBox = new Carbotextbox("Group Name", NameSampleTextBox);
			DescriptionTextBox = new Carbotextbox("Group description...", DescriptionSampleTextBox);

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
		public Group CurrentGroup;

		public bool Editable
		{
			get
			{
				return !DescriptionTextBox.ReadOnly;
			}

			set
			{
				NameTextBox.Visible = value && isNewGroup;

				DescriptionTextBox.ReadOnly = !value;

				//DescriptionTextBox.BackColor =
				//	value ?
				//	editingTextBoxBackColor : BackColor;

				DescriptionTextBox.BorderStyle =
					value ?
					BorderStyle.FixedSingle : BorderStyle.None;

				DeleteButton.Visible = value;

				DeleteButton.Text = isNewGroup ? "Discard" : "Delete";
				EditButton.Text = value ? "Save" : "Edit";

				UpdateEditButtonStatus();
			}
		}

		/// ************************* PRIVATE PROPERTIES ****************************

		protected Color editingTextBoxBackColor;
		protected bool isNewGroup;

		/// *************************** PUBLIC METHODS ******************************

		public void ShowPanel(CarbolistItem groupListItem, bool isNewGroup = false)
		{
			Visible = true;

			CurrentListItem = groupListItem;
			CurrentGroup = groupListItem.Data as Group;

			NameLabel.Text = NameTextBox.Text = CurrentGroup.Name;
			DescriptionTextBox.Text = CurrentGroup.Description;

			string memberList = "";

			foreach (User p in CurrentGroup.Users)
			{
				memberList += p.Name + n.l;
			}

			MemberListLabel.Text = memberList;

			if (isNewGroup)
			{
				MemberTitleLabel.Visible = false;
			}
			else
			{
				MemberTitleLabel.Visible = true;

				if (MemberListLabel.Text == "")
					MemberListLabel.Text = "No Members Yet";
			}

			this.isNewGroup = isNewGroup;
		}

		public void HidePanel()
		{
			Visible = false;

			if (Editable && CurrentGroup != null)
			{
                if (ContainsTexts())
                    SaveGroup();
                else
                    DeleteGroup();
            }

			NameTextBox.Visible = false;

			isNewGroup = false;

			Editable = false;

			CurrentGroup = null;
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

		protected void SaveGroup()
		{
			if (CurrentGroup.Name == NameTextBox.RawText && CurrentGroup.Description == DescriptionTextBox.Text)
				return;

			CurrentGroup.Name = NameTextBox.RawText;

			if (DescriptionTextBox.RawText == "")
				CurrentGroup.Description = $"Created on {DateTime.Now.DayOfWeek.ToString()}, {DateTime.Now.ToString()}.";
			else
				CurrentGroup.Description = DescriptionTextBox.RawText;
		}

		protected void DeleteGroup()
		{
			//tra.ce("Deleting group " + CurrentListItem.Title + "!!!!");

			if (CurrentListItem != null)
			{
				CurrentListItem.ParentList.RemoveItem(CurrentListItem);

				(ParentForm as MainForm).Groups.Remove(CurrentGroup);
				(ParentForm as MainForm).HideMeetingList();
			}

			Visible = false;
		}

		/// ******************************* EVENTS **********************************

		protected void OnNameTextBoxTextChange(object target, EventArgs e)
		{
			if (!Editable || CurrentListItem == null)
				return;

			CurrentListItem.Title = NameTextBox.RawText;

			UpdateEditButtonStatus();
		}

		protected void OnEditButtonClick(object target, EventArgs e)
		{
			SaveGroup();

			ShowPanel(CurrentListItem);

			Editable = !Editable;
		}

		protected void OnDeleteButtonClick(object target, EventArgs e)
		{
			if (isNewGroup)
			{
				NameLabel.Text = "";
				NameTextBox.Text = "";
				DescriptionTextBox.Text = "";

				HidePanel();

				return;
			}

			DeleteGroup();
		}

	}
}
