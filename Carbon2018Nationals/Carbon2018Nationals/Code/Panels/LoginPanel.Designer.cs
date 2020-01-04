namespace Carbon
{
	partial class LoginPanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		override protected void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TitleLabel = new System.Windows.Forms.Label();
			this.UsernameLabel = new System.Windows.Forms.Label();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.InvalidLoginLabel = new System.Windows.Forms.Label();
			this.SignUpButton = new CarboUiComponent.Carbobutton();
			this.ShowPasswordButton = new CarboUiComponent.Carbobutton();
			this.LoginButton = new CarboUiComponent.Carbobutton();
			this.PasswordTextBox = new CarboUiComponent.Carbotextbox();
			this.UsernameTextBox = new CarboUiComponent.Carbotextbox();
			this.SignUpSuccessLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.TitleLabel.Location = new System.Drawing.Point(169, 66);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(198, 28);
			this.TitleLabel.TabIndex = 5;
			this.TitleLabel.Text = "Login to Carbon";
			// 
			// UsernameLabel
			// 
			this.UsernameLabel.AutoSize = true;
			this.UsernameLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UsernameLabel.ForeColor = System.Drawing.Color.Gray;
			this.UsernameLabel.Location = new System.Drawing.Point(58, 171);
			this.UsernameLabel.Name = "UsernameLabel";
			this.UsernameLabel.Size = new System.Drawing.Size(92, 21);
			this.UsernameLabel.TabIndex = 1;
			this.UsernameLabel.Text = "Username:";
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordLabel.ForeColor = System.Drawing.Color.Gray;
			this.PasswordLabel.Location = new System.Drawing.Point(58, 279);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(86, 21);
			this.PasswordLabel.TabIndex = 1;
			this.PasswordLabel.Text = "Password:";
			// 
			// InvalidLoginLabel
			// 
			this.InvalidLoginLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InvalidLoginLabel.ForeColor = System.Drawing.Color.SandyBrown;
			this.InvalidLoginLabel.Location = new System.Drawing.Point(58, 353);
			this.InvalidLoginLabel.Name = "InvalidLoginLabel";
			this.InvalidLoginLabel.Size = new System.Drawing.Size(422, 48);
			this.InvalidLoginLabel.TabIndex = 6;
			this.InvalidLoginLabel.Text = "Get outta here with dat login info!!!";
			this.InvalidLoginLabel.UseMnemonic = false;
			this.InvalidLoginLabel.Visible = false;
			// 
			// SignUpButton
			// 
			this.SignUpButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.SignUpButton.FlatAppearance.BorderSize = 0;
			this.SignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SignUpButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SignUpButton.ForeColor = System.Drawing.Color.White;
			this.SignUpButton.Location = new System.Drawing.Point(160, 481);
			this.SignUpButton.Name = "SignUpButton";
			this.SignUpButton.Size = new System.Drawing.Size(235, 30);
			this.SignUpButton.TabIndex = 4;
			this.SignUpButton.Text = "New to Carbon? Click here!";
			this.SignUpButton.UseVisualStyleBackColor = false;
			this.SignUpButton.Click += new System.EventHandler(this.OnSignUpButtonClick);
			// 
			// ShowPasswordButton
			// 
			this.ShowPasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
			this.ShowPasswordButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.ShowPasswordButton.FlatAppearance.BorderSize = 0;
			this.ShowPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ShowPasswordButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowPasswordButton.ForeColor = System.Drawing.Color.DarkGray;
			this.ShowPasswordButton.Location = new System.Drawing.Point(361, 273);
			this.ShowPasswordButton.Name = "ShowPasswordButton";
			this.ShowPasswordButton.Size = new System.Drawing.Size(119, 27);
			this.ShowPasswordButton.TabIndex = 2;
			this.ShowPasswordButton.Text = "Show Password";
			this.ShowPasswordButton.UseVisualStyleBackColor = false;
			this.ShowPasswordButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnShowPasswordButtonMouseDown);
			this.ShowPasswordButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnShowPasswordButtonMouseUp);
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.LoginButton.Enabled = false;
			this.LoginButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.LoginButton.FlatAppearance.BorderSize = 0;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginButton.ForeColor = System.Drawing.Color.White;
			this.LoginButton.Location = new System.Drawing.Point(417, 560);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(108, 48);
			this.LoginButton.TabIndex = 3;
			this.LoginButton.Text = "Login!";
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Click += new System.EventHandler(this.OnLoginButtonClick);
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.AcceptsTab = true;
			this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.PasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.PasswordTextBox.Location = new System.Drawing.Point(62, 309);
			this.PasswordTextBox.MaxLength = 40;
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.PasswordChar = '•';
			this.PasswordTextBox.Restrict = null;
			this.PasswordTextBox.ShortcutsEnabled = false;
			this.PasswordTextBox.Size = new System.Drawing.Size(418, 31);
			this.PasswordTextBox.TabIndex = 1;
			this.PasswordTextBox.Watermark = null;
			this.PasswordTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
			this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnPasswordTextBoxKeyDown);
			// 
			// UsernameTextBox
			// 
			this.UsernameTextBox.AcceptsTab = true;
			this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UsernameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.UsernameTextBox.ConvertSpacesToUnderscores = true;
			this.UsernameTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.UsernameTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.UsernameTextBox.Location = new System.Drawing.Point(62, 201);
			this.UsernameTextBox.MaxLength = 40;
			this.UsernameTextBox.Name = "UsernameTextBox";
			this.UsernameTextBox.Restrict = "[^a-z0-9._]";
			this.UsernameTextBox.Size = new System.Drawing.Size(418, 31);
			this.UsernameTextBox.TabIndex = 0;
			this.UsernameTextBox.Watermark = null;
			this.UsernameTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
			this.UsernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnUsernameTextBoxKeyDown);
			// 
			// SignUpSuccessLabel
			// 
			this.SignUpSuccessLabel.AutoSize = true;
			this.SignUpSuccessLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SignUpSuccessLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.SignUpSuccessLabel.Location = new System.Drawing.Point(25, 589);
			this.SignUpSuccessLabel.Name = "SignUpSuccessLabel";
			this.SignUpSuccessLabel.Size = new System.Drawing.Size(303, 19);
			this.SignUpSuccessLabel.TabIndex = 6;
			this.SignUpSuccessLabel.Text = "You\'ve successfully sign-up to Carbon!";
			this.SignUpSuccessLabel.UseMnemonic = false;
			this.SignUpSuccessLabel.Visible = false;
			// 
			// LoginPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.Controls.Add(this.SignUpSuccessLabel);
			this.Controls.Add(this.InvalidLoginLabel);
			this.Controls.Add(this.SignUpButton);
			this.Controls.Add(this.ShowPasswordButton);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.UsernameTextBox);
			this.Controls.Add(this.UsernameLabel);
			this.Controls.Add(this.TitleLabel);
			this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "LoginPanel";
			this.Size = new System.Drawing.Size(551, 629);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label TitleLabel;
		public System.Windows.Forms.Label UsernameLabel;
		public CarboUiComponent.Carbotextbox UsernameTextBox;
		public System.Windows.Forms.Label PasswordLabel;
		public CarboUiComponent.Carbotextbox PasswordTextBox;
		public CarboUiComponent.Carbobutton LoginButton;
		public CarboUiComponent.Carbobutton SignUpButton;
		public CarboUiComponent.Carbobutton ShowPasswordButton;
		public System.Windows.Forms.Label InvalidLoginLabel;
		public System.Windows.Forms.Label SignUpSuccessLabel;
	}
}
