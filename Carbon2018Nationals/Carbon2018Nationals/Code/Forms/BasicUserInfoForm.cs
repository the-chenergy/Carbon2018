using Carbolibrary;
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

	public partial class BasicUserInfoForm : CarboFloatingForm
	{

		/// ############################# CONSTRUCTOR ###############################

		public BasicUserInfoForm()
		{
			InitializeComponent();
		}

		public BasicUserInfoForm(User user, string option1 = "", Action<BasicUserInfoForm, User> onOption1Click = null, string option2 = "", Action<BasicUserInfoForm, User> onOption2Click = null)
		{
			InitializeComponent();

			User = user;

			UserImageBox.BackgroundImage = user.UserImage;

			NameTextBox.Text = user.Name;
			UsernameTextBox.Text = "@" + user.Username;
			StatusTextBox.Text = user.Status;
			EmailTextBox.Text = user.Email;
			PhoneTextBox.Text = user.Phone;
			AdminLabel.Visible = user.IsAdministrator;

			new ToolTip().SetToolTip(AdminLabel, "This user is an administrator of the Carbon platform.");

			if (option1 != "")
			{
				OptionButton1.Visible = true;
				OptionButton1.Text = option1;
				OnOption1Click = onOption1Click;
			}
			else if (option2 != "")
			{
				OptionButton2.Visible = true;
				OptionButton2.Text = option2;
				OnOption2Click = onOption2Click;
			}
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public User User;
		public Action<BasicUserInfoForm, User> OnOption1Click;
		public Action<BasicUserInfoForm, User> OnOption2Click;

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################



		/// ########################### PRIVATE METHODS #############################



		/// ############################### EVENTS ##################################

		protected void OnCloseButtonClick(object sender, EventArgs e)
		{
			Close();
		}

		protected void OnOptionButton1Click(object sender, EventArgs e)
		{
			OnOption1Click?.Invoke(this, User);
		}

		protected void OnOptionButton2Click(object sender, EventArgs e)
		{
			OnOption2Click?.Invoke(this, User);
		}

	}

}
