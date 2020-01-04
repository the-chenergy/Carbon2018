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

	public partial class AddGroupMemberForm : CarboFloatingForm
	{

		/// ############################# CONSTRUCTOR ###############################

		/// <summary>
		/// This is for the designer. Use the other constructor instead!
		/// </summary> 
		public AddGroupMemberForm()
		{
			InitializeComponent();
		}

		public AddGroupMemberForm(Group group, Action<List<User>> onComplete = null)
		{
			InitializeComponent();

			if (!(this is AddMeetingMemberForm))
				Init(group, onComplete);
		}

		protected void Init(Group group, Action<List<User>> onComplete)
		{
			SearchList = new Carbolist(CarbolistTheme.LightBlue, SearchListSampleButton, OnSearchListItemSelect)
			{
				CanSelect = false,
				CanDeselect = false,
				CanDragAndDrop = false,
			};

			AddedList = new Carbolist(
				new CarbolistTheme()
				{
					FirstItemBackColor = Color.FromArgb(5, 55, 115),
					SecondItemBackColor = Color.FromArgb(5, 55, 115),
					ItemForeColor = Color.LightGray,
					ScrollBarBackColor = Color.DarkGray,
					ScrollBarForeColor = Color.Gray,
					SelectedItemBackColor = Color.FromArgb(5, 65, 130),
				},
				AddedListSampleButton
			);

			this.AddControl(SearchList);
			this.AddControl(AddedList);

			AddedList.OnItemMenuButtonClick = OnAddedListItemMenuButtonClick;

			SearchHintLabel.BringToFront();

			Group = group;
			OnComplete = onComplete;

			if (!(this is AddMeetingMemberForm))
			{
				ExistingUsers = group?.Members ?? new List<User>();

				DescriptionLabel.Text = $"to group {group?.Name}";

				SearchTextBox.Text = "";
			}
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Carbolist SearchList;
		public Carbolist AddedList;
		public Group Group;
		public List<User> ExistingUsers;
		public Action<List<User>> OnComplete;

		/// ######################### PRIVATE PROPERTIES ############################

		

		/// ########################### PUBLIC METHODS ##############################

		virtual public void Search()
		{
			if (SearchTextBox.RawText.Trim() == "")
			{
				SearchHintLabel.Visible = true;
				SearchHintLabel.Text = "Use the search bar above to search for users.";

				return;
			}

			if (SearchList.Items.Count > 0)
				SearchList.RemoveAllItems();

			foreach (CarbolistItem p in SearchList.AddItemsBy("Name", Database.SearchUsers(SearchTextBox.RawText), "UserImage64"))
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
				SearchHintLabel.Text = "No users found.";
		}

		/// ########################### PRIVATE METHODS #############################

		protected void DrawSpecialSearchListItem(CarbolistItem item)
		{
			item.Paint += OnSearchListItemPaint;
		}

		/// ############################### EVENTS ##################################

		override protected bool ProcessCmdKey(ref Message message, Keys keys)
		{
			// set focus to search bar when an "alphanumeric key" is pressed.
			if (!SearchTextBox.Focused)
			{
				string[] keyData = keys.ToString().Split(
					new string[] { ", " },
					StringSplitOptions.None
				);

				if (keyData.Length <= 2
					&& keyData[0].Length == 1
					&& (keyData.Length != 2 || keyData[1] == "Shift")
					&& char.IsLetterOrDigit(keyData[0][0]))
				{
					SearchTextBox.Text = keyData.Length == 2 ? keyData[0] : keyData[0].ToLower();

					SearchTextBox.Select();
					SearchTextBox.Select(SearchTextBox.TextLength, 0);

					return true;
				}
			}

			return base.ProcessCmdKey(ref message, keys);
		}

		protected void OnSearchTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				Search();

				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		virtual protected void OnSearchTextBoxTextChanged(object sender, EventArgs e)
		{
			if (SearchList.Items.Count > 0)
				SearchList.RemoveAllItems();

			if (SearchTextBox.RawText.Trim() != "")
			{
				SearchHintLabel.Visible = true;
				SearchHintLabel.Text = "Searching...";

				Carbotimeout.Set(500, Search);
			}
			else
			{
				Carbotimeout.Cancel(Search);

				Search();
			}
		}

		protected void OnSearchButtonClick(object sender, EventArgs e)
		{
			Search();
		}

		protected void OnSearchListItemPaint(object sender, PaintEventArgs e)
		{
			CarbolistItem item = sender as CarbolistItem;
			string text = (item.Tag as User).Email;
			Size size = TextRenderer.MeasureText(text, AddedListTitleLabel.Font);

			SolidBrush brush = new SolidBrush(item.ForeColor);

			e.Graphics.DrawString(
				text,
				AddedListTitleLabel.Font,
				brush,
				72,
				item.Height - size.Height - 12
			);
		}

		protected void OnSearchListItemSelect(CarbolistItem sender)
		{
			User user = sender.Tag as User;
			List<CarbolistItem> temp = AddedList.Items.FindAll(x => (x.Tag as User).Username == user.Username);

			if (temp.Count > 0)
				AddedList.SelectItem(temp[0], true);

			if (SearchTextBox.RawText != "")
			{
				SearchTextBox.Select();
				SearchTextBox.SelectAll();
			}

			if (sender.ForeColor == Color.Gray)
				return;

			AddedList.SelectItem(AddedList.AddItem((sender.Tag as User).Name, null, sender.Tag)).RegisterMenuButton(
				"Remove", Color.FromArgb(5, 65, 130), Color.DarkGray
			);

			Search();

			if (!DoneButton.Enabled)
			{
				DoneButton.Enabled = true;
				DoneButton.FlatAppearance.BorderSize = 1;
			}
		}

		protected void OnAddedListItemMenuButtonClick(CarbolistItem sender)
		{
			AddedList.RemoveItem(sender);

			if (AddedList.Items.Count == 0)
			{
				DoneButton.Enabled = false;
				DoneButton.FlatAppearance.BorderSize = 0;
			}

			Search();
		}

		protected void OnCancelButtonClick(object sender, EventArgs e)
		{
			Close();
		}

		protected void OnDoneButtonClick(object sender, EventArgs e)
		{
			OnComplete?.Invoke(AddedList.Items.Select(x => x.Tag).Cast<User>().ToList());

			Close();
		}

	}

}
