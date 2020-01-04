using Carbon.Properties;

using Carbolibrary;
using CarboUiComponent;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbon
{

	public partial class SignUpPanel : UserControl
	{

		/// ############################# CONSTRUCTOR ###############################

		public SignUpPanel()
		{
			InitializeComponent();

			NameTextBox.Select();

			defaultUsernameHintText = UsernameHintLabel.Text;
		}

		/// ########################## PUBLIC PROPERTIES ############################

		public LoginPanel LoginPanel;

		/// ######################### PRIVATE PROPERTIES ############################

		protected Regex emailFilter = new Regex(@".+@.+\..+");

		protected string defaultUsernameHintText;
		protected string invalidUsernameHintText = "Sorry, this username is taken!";
		protected string validUsernameHintText = "Yes! You can use this username!";

		/// ########################### PUBLIC METHODS ##############################

		public void ResizePanel(int height)
		{
			Height = height;

			LoginButton.Top = Height - 51;

			SignUpButton.Top = height - 69;
		}

		/// ########################### PRIVATE METHODS #############################

		protected bool IsValidSignUp()
		{
			return (
				// textboxes
				NameTextBox.RawText.Trim() != ""
				&& UsernameTextBox.RawText != ""
				&& PasswordTextBox.RawText != ""
				&& ConfirmPasswordTextBox.RawText != ""
				// hint labels
				&& !UsernameHintLabel.Visible
				&& !PasswordHintLabel.Visible
				&& !ConfirmPasswordHintLabel.Visible
				&& !EmailHintLabel.Visible
				&& !PhoneHintLabel.Visible
			);
		}

		protected bool UpdateSignUpInfo()
		{
			if (NameTextBox.RawText.Trim() == "")
				return SelectTextBox(NameTextBox);

			if (UsernameHintLabel.Visible || UsernameTextBox.RawText == "" || !UpdateUsernameStatus())
				return SelectTextBox(UsernameTextBox);

			if (PasswordHintLabel.Visible || PasswordTextBox.RawText == "")
				return SelectTextBox(PasswordTextBox);

			if (ConfirmPasswordTextBox.RawText == "" || ConfirmPasswordHintLabel.Visible)
				return SelectTextBox(ConfirmPasswordTextBox);

			if (EmailHintLabel.Visible)
				return SelectTextBox(EmailTextBox);

			if (PhoneHintLabel.Visible)
				return SelectTextBox(PhoneTextBox);

			return true;
		}

		protected bool SelectTextBox(Carbotextbox textBox)
		{
			textBox.Select();
			textBox.SelectAll();

			// force the invalid-hint-label to show (leave it, then enter it)
			SendKeys.Send("+{TAB}");
			SendKeys.Send("{TAB}");

			return false;
		}

		protected bool UpdateUsernameStatus()
		{
			if (Database.HasUsername(UsernameTextBox.RawText))
			{
				UsernameHintIcon.Image = Resources.ExclamationIcon;

				UsernameHintLabel.Text = invalidUsernameHintText;
				UsernameHintLabel.ForeColor = Color.SandyBrown;

				return false;
			}

			UsernameHintIcon.Image = Resources.CheckmarkIcon;

			UsernameHintLabel.Text = validUsernameHintText;
			UsernameHintLabel.ForeColor = Color.SteelBlue;

			return true;
		}

		/// ############################### EVENTS ##################################

		protected void OnNameTextBoxTextChanged(object sender, EventArgs e)
		{
			if (NameHintIcon.Visible)
				NameHintIcon.Visible = false;
		}

		protected void OnNameTextBoxLeave(object sender, EventArgs e)
		{
			if (NameTextBox.RawText.Trim() == "")
			{
				if (!(UsernameHintIcon.Visible
					|| PasswordHintIcon.Visible
					|| ConfirmPasswordHintIcon.Visible))
				{
					return;
				}

				NameHintIcon.Image = Resources.ExclamationIcon;
			}
			else
			{
				NameHintIcon.Image = Resources.CheckmarkIcon;
			}

			NameHintIcon.Visible = true;
		}

		protected void OnUsernameTextBoxEnter(object sender, EventArgs e)
		{
			if (UsernameTextBox.RawText == "")
			{
				string usernameHint = NameTextBox.RawText == ""
					? "" : Global.MultiSpaceFilter.Replace(NameTextBox.RawText, "_").PadRight(5, '0');

				UsernameTextBox.Text = usernameHint;
				UsernameTextBox.Select();
			}

			UsernameHintLabel.Visible = true;
		}

		protected void OnCheckUsernameButtonClick(object sender, EventArgs e)
		{
			if (UsernameHintLabel.ForeColor == Color.SandyBrown
				&& UsernameHintLabel.Text == defaultUsernameHintText)
			{
				UsernameTextBox.Select();

				return;
			}

			UsernameHintIcon.Visible = UsernameHintLabel.Visible = true;

			UpdateUsernameStatus();

			UsernameTextBox.Select();
		}

		protected void OnUsernameTextBoxTextChanged(object sender, EventArgs e)
		{
			if (UsernameHintIcon.Visible)
				UsernameHintIcon.Visible = false;

			if (UsernameHintLabel.ForeColor == Color.SandyBrown)
				UsernameHintLabel.ForeColor = Color.SteelBlue;

			if (UsernameHintLabel.Text != defaultUsernameHintText)
				UsernameHintLabel.Text = defaultUsernameHintText;
		}

		protected void OnUsernameTextBoxLeave(object sender, EventArgs e)
		{
			UsernameHintIcon.Visible = true;

			if (UsernameTextBox.TextLength < 5 || UsernameHintLabel.Text == invalidUsernameHintText)
			{
				UsernameHintIcon.Image = Resources.ExclamationIcon;

				UsernameHintLabel.ForeColor = Color.SandyBrown;

				if (UsernameTextBox.TextLength < 5)
					UsernameHintLabel.Text = defaultUsernameHintText;

				return;
			}

			UsernameHintIcon.Image = Resources.CheckmarkIcon;

			UsernameHintLabel.Visible = false;
		}

		protected void OnPasswordTextBoxEnter(object sender, EventArgs e)
		{
			PasswordHintLabel.Visible = true;
		}

		protected void OnPasswordTextBoxTextChanged(object sender, EventArgs e)
		{
			if (PasswordHintIcon.Visible)
				PasswordHintIcon.Visible = false;

			if (PasswordHintLabel.ForeColor == Color.SandyBrown)
				PasswordHintLabel.ForeColor = Color.SteelBlue;

			if (ConfirmPasswordTextBox.RawText != "")
			{
				//ConfirmPasswordHintIcon.Visible = ConfirmPasswordHintLabel.Visible = false;

				ConfirmPasswordTextBox.Text = "";
			}
		}

		protected void OnPasswordTextBoxLeave(object sender, EventArgs e)
		{
			PasswordHintIcon.Visible = true;

			if (PasswordTextBox.TextLength < 8)
			{
				PasswordHintIcon.Image = Resources.ExclamationIcon;

				PasswordHintLabel.ForeColor = Color.SandyBrown;

				return;
			}

			PasswordHintIcon.Image = Resources.CheckmarkIcon;

			PasswordHintLabel.Visible = false;
		}

		protected void OnConfirmPasswordTextBoxTextChanged(object sender, EventArgs e)
		{
			if (ConfirmPasswordHintIcon.Visible)
				ConfirmPasswordHintIcon.Visible = ConfirmPasswordHintLabel.Visible = false;
		}

		protected void OnConfirmPasswordTextBoxLeave(object sender, EventArgs e)
		{
			ConfirmPasswordHintIcon.Visible = true;

			bool isInvalid = (ConfirmPasswordTextBox.RawText == "" || ConfirmPasswordTextBox.RawText != PasswordTextBox.RawText);

			if (isInvalid)
				ConfirmPasswordHintIcon.Image = Resources.ExclamationIcon;
			else
				ConfirmPasswordHintIcon.Image = Resources.CheckmarkIcon;

			ConfirmPasswordHintLabel.Visible = isInvalid;
		}

		protected void OnEmailTextBoxTextChanged(object sender, EventArgs e)
		{
			if (EmailHintIcon.Visible)
				EmailHintIcon.Visible = EmailHintLabel.Visible = false;
		}

		protected void OnEmailTextBoxLeave(object sender, EventArgs e)
		{
			if (EmailTextBox.RawText == "")
			{
				EmailHintIcon.Visible = EmailHintLabel.Visible = false;

				return;
			}

			EmailHintIcon.Visible = true;

			bool isInvalid = !emailFilter.IsMatch(EmailTextBox.RawText);

			if (isInvalid)
				EmailHintIcon.Image = Resources.ExclamationIcon;
			else
				EmailHintIcon.Image = Resources.CheckmarkIcon;

			EmailHintLabel.Visible = isInvalid;
		}

		protected void OnPhoneTextBoxTextChanged(object sender, EventArgs e)
		{
			if (PhoneHintIcon.Visible)
				PhoneHintIcon.Visible = PhoneHintLabel.Visible = false;
		}

		protected void OnPhoneTextBoxLeave(object sender, EventArgs e)
		{
			if (PhoneTextBox.RawText == "")
			{
				PhoneHintIcon.Visible = PhoneHintLabel.Visible = false;

				return;
			}

			PhoneHintIcon.Visible = true;

			if (PhoneTextBox.TextLength < 10)
				PhoneHintIcon.Image = Resources.ExclamationIcon;
			else
				PhoneHintIcon.Image = Resources.CheckmarkIcon;

			PhoneHintLabel.Visible = (PhoneTextBox.TextLength < 10);
		}

		protected void OnLoginButtonClick(object sender, EventArgs e)
		{
			LoginPanel.Visible = true;

			Visible = false;
		}

		protected void OnSignUpButtonClick(object sender, EventArgs e)
		{
			if (!UpdateSignUpInfo())
				return;

			//MessageBox.Show("Sorry, but your stupid programmer just forgot to create a sign-up option for you.\n\nPlease call him and tell him that you love him very very much, then he'll probably program it for you. Thanks!\n\n:D", "Oops!", MessageBoxButtons.YesNo);

			Database.CreateUser(new User(
				UsernameTextBox.RawText,
				NameTextBox.RawText,
				"",
				EmailTextBox.RawText,
				PhoneTextBox.RawText
			), Sha512Encoder.Encode(PasswordTextBox.RawText));

			LoginPanel.Visible = true;
			LoginPanel.LoadSignUpInfo(UsernameTextBox.RawText);
		}

	}

}
