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

	public partial class LoginPanel : UserControl
	{

		/// ############################# CONSTRUCTOR ###############################

		public LoginPanel()
		{
			InitializeComponent();
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public SignUpPanel SignUpPanel;

		/// ######################### PRIVATE PROPERTIES ############################



		/// ########################### PUBLIC METHODS ##############################

		public void LoadSignUpInfo(string username)
		{
			UsernameTextBox.Text = username;

			PasswordTextBox.Text = "";
			PasswordTextBox.Select();

			SignUpSuccessLabel.Visible = true;

			ParentForm.Controls.Remove(SignUpPanel);
			SignUpPanel.Dispose();
			SignUpPanel = null;
		}

		public void Login()
		{
			if (!LoginButton.Enabled)
				return;

			if (!UsernameTextBox.TextLength.IsBetween(5, 20)
				|| !Global.Config.UsernameOnlyLogin && !PasswordTextBox.TextLength.IsBetween(8, 20))
			{
				InvalidLoginLabel.Text = "Your username or password is incorrect!";
				InvalidLoginLabel.Visible = true;

				return;
			}

			Form1 form1 = ParentForm as Form1;

			int result;
			if ((result = form1.LoginToDatabase(
				UsernameTextBox.RawText, Global.Config.UsernameOnlyLogin ?
					null : Sha512Encoder.Encode(PasswordTextBox.RawText)
			)) < 0)
			{
				switch (result)
				{
					case -1:
						InvalidLoginLabel.Text = "Server could not be reached. Please check your internet connection!";
						break;

					case -2:
						InvalidLoginLabel.Text = "Your username or password is incorrect!";
						break;
				}

				InvalidLoginLabel.Visible = true;

				return;
			}

			if (SignUpPanel != null)
			{
				SignUpPanel.Parent.Controls.Remove(SignUpPanel);
				SignUpPanel.Dispose();
			}

			form1.MenuBar.MenuButtonList.SelectIndex(0);

			form1.SwitchTab(Tab.Meetings);
		}

		public void ResizePanel(int height)
		{
			Height = height;

			LoginButton.Top = height - 69;

			if (SignUpPanel != null && SignUpPanel.Visible)
				SignUpPanel.ResizePanel(height);
		}

		/// ########################### PRIVATE METHODS #############################

		protected void UpdateLoginButtonStatus()
		{
			LoginButton.Enabled = (UsernameTextBox.RawText != "" 
				&& (Global.Config.UsernameOnlyLogin || PasswordTextBox.RawText != "")
			);
		}

		/// ############################### EVENTS ##################################

		protected void OnShowPasswordButtonMouseDown(object sender, MouseEventArgs e)
		{
			PasswordTextBox.PasswordChar = default;
		}

		protected void OnShowPasswordButtonMouseUp(object sender, MouseEventArgs e)
		{
			PasswordTextBox.PasswordChar = Global.SpecialString.PasswordChar;
			PasswordTextBox.Focus();
			PasswordTextBox.SelectionStart = PasswordTextBox.TextLength;
		}

		protected void OnTextBoxTextChanged(object sender, EventArgs e)
		{
			UpdateLoginButtonStatus();

			if (InvalidLoginLabel.Visible)
				InvalidLoginLabel.Visible = false;

			if (SignUpSuccessLabel.Visible)
				SignUpSuccessLabel.Visible = false;
		}

		protected void OnUsernameTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				if (!Global.Config.UsernameOnlyLogin && PasswordTextBox.RawText == "")
				{
					PasswordTextBox.Select();
				}
				else
				{
					e.SuppressKeyPress = true;

					Login();
				}

				e.Handled = true;
			}
		}

		protected void OnPasswordTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				e.Handled = e.SuppressKeyPress = true;

				Login();
			}
		}

		protected void OnLoginButtonClick(object sender, EventArgs e)
		{
			Login();
		}

		protected void OnSignUpButtonClick(object sender, EventArgs e)
		{
			if (SignUpPanel == null)
			{
				SignUpPanel = new SignUpPanel()
				{
					Location = Location,
					LoginPanel = this,
				};

				ParentForm.AddControl(SignUpPanel);
			}
			else
			{
				SignUpPanel.Visible = true;
			}

			SignUpPanel.ResizePanel(Height);

			Visible = false;
		}

	}

}
