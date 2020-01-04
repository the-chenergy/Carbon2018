using Carbon.Properties;

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

	public partial class MenuBar : UserControl
	{

		/// ############################# CONSTRUCTOR ###############################

		public MenuBar()
		{
			InitializeComponent();

			MenuButtonList = new Carbolist(new CarbolistTheme()
			{
				FirstItemBackColor = Color.FromArgb(3, 5, 16),
				SecondItemBackColor = Color.FromArgb(3, 5, 16),
				SelectedItemBackColor = Color.FromArgb(9, 46, 89),
				ItemForeColor = Color.FromArgb(170, 170, 170),
			}, MenuButtonListSampleButton, OnMenuButtonListItemSelect)
			{
				CanDeselect = false,
			};

			MenuButtonList.AddItem("  Meetings", Resources.MeetingsIcon, Tab.Meetings);
			MenuButtonList.AddItem("  Notifications", Resources.NotificationsIcon, Tab.Notifications);
			MenuButtonList.AddItem("  Settings", Resources.SettingsIcon, Tab.Settings);

			MenuButtonList.HideItemTexts();

			Controls.Add(MenuButtonList);

			IsExpanded = false;

			MenuButtonList.MouseLeaveList += OnMouseLeave;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public Carbolist MenuButtonList;
		public Action<Tab> OnSelect;

		public bool IsExpanded
		{
			get
			{
				return Width > 100;
			}
			set
			{
				if (value)
				{
					BringToFront();
					MenuButtonList.ShowItemTexts();

					UserImageBox.SetBounds(16, Height - 144, 128, 128);
				}
				else
				{
					MenuButtonList.HideItemTexts();

					UserImageBox.SetBounds(5, Height - 45, 40, 40);
				}

				Width = value ? 160 : 50;
			}
		}

		/// ######################### PRIVATE PROPERTIES ############################

		

		/// ########################### PUBLIC METHODS ##############################

		public void ApplyDebuggingSettings()
		{
			MenuButtonList.AddItem("   Open DB", Resources.DatabaseIcon, Tab.OpenDb).CanSelect = false;
		}

		public void ResizeBar(int height)
		{
			Height = height;

			UserImageBox.Top = height - (UserImageBox.Height * 1.125).Round();
		}

		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################

		protected void OnMenuButtonListItemSelect(CarbolistItem sender)
		{
			if (IsExpanded)
				IsExpanded = false;

			OnSelect?.Invoke((Tab)sender.Tag);
		}

		protected void OnMouseLeave(object sender, EventArgs e)
		{
			if (IsExpanded && !ClientRectangle.Contains(PointToClient(Control.MousePosition)))
				IsExpanded = false;
		}

		protected void OnExpandButtonMouseHover(object sender, EventArgs e)
		{
			if (IsExpanded)
				return;

			if (Carbostopwatch.MilliElapsed(this) < 500)
				return;

			IsExpanded = true;

			Carbostopwatch.Reset(this);
		}

		protected void OnExpandButtonClick(object sender, EventArgs e)
		{
			if (IsExpanded)
			{
				if (Carbostopwatch.MilliElapsed(this) >= 500)
					IsExpanded = false;
			}
			else
			{
				IsExpanded = true;

				Carbostopwatch.Reset(this);
			}
		}

	}

}
