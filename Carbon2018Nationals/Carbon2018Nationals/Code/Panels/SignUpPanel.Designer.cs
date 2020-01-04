namespace Carbon
{
	partial class SignUpPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpPanel));
			this.TitleLabel = new System.Windows.Forms.Label();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.NameTextBox = new CarboUiComponent.Carbotextbox();
			this.NameLabel = new System.Windows.Forms.Label();
			this.UsernameLabel = new System.Windows.Forms.Label();
			this.UsernameTextBox = new CarboUiComponent.Carbotextbox();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
			this.PasswordTextBox = new CarboUiComponent.Carbotextbox();
			this.ConfirmPasswordTextBox = new CarboUiComponent.Carbotextbox();
			this.EmailLabel = new System.Windows.Forms.Label();
			this.PhoneLabel = new System.Windows.Forms.Label();
			this.EmailTextBox = new CarboUiComponent.Carbotextbox();
			this.PhoneTextBox = new CarboUiComponent.Carbotextbox();
			this.OptionalLabel = new System.Windows.Forms.Label();
			this.LoginButton = new CarboUiComponent.Carbobutton();
			this.SignUpButton = new CarboUiComponent.Carbobutton();
			this.UsernameHintLabel = new System.Windows.Forms.Label();
			this.PasswordHintLabel = new System.Windows.Forms.Label();
			this.ConfirmPasswordHintLabel = new System.Windows.Forms.Label();
			this.PhoneHintIcon = new System.Windows.Forms.PictureBox();
			this.EmailHintIcon = new System.Windows.Forms.PictureBox();
			this.ConfirmPasswordHintIcon = new System.Windows.Forms.PictureBox();
			this.PasswordHintIcon = new System.Windows.Forms.PictureBox();
			this.UsernameHintIcon = new System.Windows.Forms.PictureBox();
			this.NameHintIcon = new System.Windows.Forms.PictureBox();
			this.EmailHintLabel = new System.Windows.Forms.Label();
			this.PhoneHintLabel = new System.Windows.Forms.Label();
			this.CheckUsernameButton = new CarboUiComponent.Carbobutton();
			((System.ComponentModel.ISupportInitialize)(this.PhoneHintIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmailHintIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ConfirmPasswordHintIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PasswordHintIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UsernameHintIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NameHintIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.TitleLabel.Location = new System.Drawing.Point(23, 31);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(254, 28);
			this.TitleLabel.TabIndex = 66;
			this.TitleLabel.Text = "Welcome to Carbon!";
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.ForeColor = System.Drawing.Color.DimGray;
			this.DescriptionLabel.Location = new System.Drawing.Point(27, 63);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(62, 18);
			this.DescriptionLabel.TabIndex = 66;
			this.DescriptionLabel.Text = "Sign Up";
			// 
			// NameTextBox
			// 
			this.NameTextBox.AcceptsTab = true;
			this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NameTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.NameTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.NameTextBox.Location = new System.Drawing.Point(30, 150);
			this.NameTextBox.MaxLength = 20;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Restrict = "";
			this.NameTextBox.Size = new System.Drawing.Size(218, 28);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.Watermark = null;
			this.NameTextBox.TextChanged += new System.EventHandler(this.OnNameTextBoxTextChanged);
			this.NameTextBox.Leave += new System.EventHandler(this.OnNameTextBoxLeave);
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameLabel.ForeColor = System.Drawing.Color.Gray;
			this.NameLabel.Location = new System.Drawing.Point(26, 122);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(92, 20);
			this.NameLabel.TabIndex = 66;
			this.NameLabel.Text = "Your Name:";
			// 
			// UsernameLabel
			// 
			this.UsernameLabel.AutoSize = true;
			this.UsernameLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UsernameLabel.ForeColor = System.Drawing.Color.Gray;
			this.UsernameLabel.Location = new System.Drawing.Point(292, 122);
			this.UsernameLabel.Name = "UsernameLabel";
			this.UsernameLabel.Size = new System.Drawing.Size(162, 20);
			this.UsernameLabel.TabIndex = 66;
			this.UsernameLabel.Text = "Choose a Username:";
			// 
			// UsernameTextBox
			// 
			this.UsernameTextBox.AcceptsTab = true;
			this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UsernameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.UsernameTextBox.ConvertSpacesToUnderscores = true;
			this.UsernameTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UsernameTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.UsernameTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.UsernameTextBox.Location = new System.Drawing.Point(296, 150);
			this.UsernameTextBox.MaxLength = 20;
			this.UsernameTextBox.Name = "UsernameTextBox";
			this.UsernameTextBox.Restrict = "[^a-z0-9._]";
			this.UsernameTextBox.Size = new System.Drawing.Size(152, 28);
			this.UsernameTextBox.TabIndex = 1;
			this.UsernameTextBox.Watermark = null;
			this.UsernameTextBox.TextChanged += new System.EventHandler(this.OnUsernameTextBoxTextChanged);
			this.UsernameTextBox.Enter += new System.EventHandler(this.OnUsernameTextBoxEnter);
			this.UsernameTextBox.Leave += new System.EventHandler(this.OnUsernameTextBoxLeave);
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordLabel.ForeColor = System.Drawing.Color.Gray;
			this.PasswordLabel.Location = new System.Drawing.Point(26, 245);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(153, 20);
			this.PasswordLabel.TabIndex = 66;
			this.PasswordLabel.Text = "Create a Password:";
			// 
			// ConfirmPasswordLabel
			// 
			this.ConfirmPasswordLabel.AutoSize = true;
			this.ConfirmPasswordLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ConfirmPasswordLabel.ForeColor = System.Drawing.Color.Gray;
			this.ConfirmPasswordLabel.Location = new System.Drawing.Point(292, 245);
			this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
			this.ConfirmPasswordLabel.Size = new System.Drawing.Size(179, 20);
			this.ConfirmPasswordLabel.TabIndex = 66;
			this.ConfirmPasswordLabel.Text = "Confirm Your Password:";
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.AcceptsTab = true;
			this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.PasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.PasswordTextBox.Location = new System.Drawing.Point(30, 273);
			this.PasswordTextBox.MaxLength = 20;
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.PasswordChar = '•';
			this.PasswordTextBox.Restrict = "";
			this.PasswordTextBox.ShortcutsEnabled = false;
			this.PasswordTextBox.Size = new System.Drawing.Size(218, 28);
			this.PasswordTextBox.TabIndex = 3;
			this.PasswordTextBox.Watermark = null;
			this.PasswordTextBox.TextChanged += new System.EventHandler(this.OnPasswordTextBoxTextChanged);
			this.PasswordTextBox.Enter += new System.EventHandler(this.OnPasswordTextBoxEnter);
			this.PasswordTextBox.Leave += new System.EventHandler(this.OnPasswordTextBoxLeave);
			// 
			// ConfirmPasswordTextBox
			// 
			this.ConfirmPasswordTextBox.AcceptsTab = true;
			this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.ConfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ConfirmPasswordTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.ConfirmPasswordTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(296, 273);
			this.ConfirmPasswordTextBox.MaxLength = 20;
			this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
			this.ConfirmPasswordTextBox.PasswordChar = '•';
			this.ConfirmPasswordTextBox.Restrict = "";
			this.ConfirmPasswordTextBox.ShortcutsEnabled = false;
			this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(218, 28);
			this.ConfirmPasswordTextBox.TabIndex = 4;
			this.ConfirmPasswordTextBox.Watermark = null;
			this.ConfirmPasswordTextBox.TextChanged += new System.EventHandler(this.OnConfirmPasswordTextBoxTextChanged);
			this.ConfirmPasswordTextBox.Leave += new System.EventHandler(this.OnConfirmPasswordTextBoxLeave);
			// 
			// EmailLabel
			// 
			this.EmailLabel.AutoSize = true;
			this.EmailLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EmailLabel.ForeColor = System.Drawing.Color.Gray;
			this.EmailLabel.Location = new System.Drawing.Point(26, 389);
			this.EmailLabel.Name = "EmailLabel";
			this.EmailLabel.Size = new System.Drawing.Size(85, 20);
			this.EmailLabel.TabIndex = 66;
			this.EmailLabel.Text = "Your Email:";
			// 
			// PhoneLabel
			// 
			this.PhoneLabel.AutoSize = true;
			this.PhoneLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PhoneLabel.ForeColor = System.Drawing.Color.Gray;
			this.PhoneLabel.Location = new System.Drawing.Point(323, 389);
			this.PhoneLabel.Name = "PhoneLabel";
			this.PhoneLabel.Size = new System.Drawing.Size(157, 20);
			this.PhoneLabel.TabIndex = 66;
			this.PhoneLabel.Text = "Your Phone Number:";
			// 
			// EmailTextBox
			// 
			this.EmailTextBox.AcceptsTab = true;
			this.EmailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EmailTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EmailTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.EmailTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.EmailTextBox.Location = new System.Drawing.Point(30, 417);
			this.EmailTextBox.MaxLength = 30;
			this.EmailTextBox.Name = "EmailTextBox";
			this.EmailTextBox.Restrict = "[ ]";
			this.EmailTextBox.Size = new System.Drawing.Size(261, 28);
			this.EmailTextBox.TabIndex = 5;
			this.EmailTextBox.Watermark = null;
			this.EmailTextBox.TextChanged += new System.EventHandler(this.OnEmailTextBoxTextChanged);
			this.EmailTextBox.Leave += new System.EventHandler(this.OnEmailTextBoxLeave);
			// 
			// PhoneTextBox
			// 
			this.PhoneTextBox.AcceptsTab = true;
			this.PhoneTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
			this.PhoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PhoneTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PhoneTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.PhoneTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.PhoneTextBox.Location = new System.Drawing.Point(327, 417);
			this.PhoneTextBox.MaxLength = 10;
			this.PhoneTextBox.Name = "PhoneTextBox";
			this.PhoneTextBox.Restrict = "[^0-9]";
			this.PhoneTextBox.Size = new System.Drawing.Size(187, 28);
			this.PhoneTextBox.TabIndex = 6;
			this.PhoneTextBox.Watermark = null;
			this.PhoneTextBox.TextChanged += new System.EventHandler(this.OnPhoneTextBoxTextChanged);
			this.PhoneTextBox.Leave += new System.EventHandler(this.OnPhoneTextBoxLeave);
			// 
			// OptionalLabel
			// 
			this.OptionalLabel.AutoSize = true;
			this.OptionalLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OptionalLabel.ForeColor = System.Drawing.Color.LightGray;
			this.OptionalLabel.Location = new System.Drawing.Point(26, 354);
			this.OptionalLabel.Name = "OptionalLabel";
			this.OptionalLabel.Size = new System.Drawing.Size(86, 19);
			this.OptionalLabel.TabIndex = 66;
			this.OptionalLabel.Text = "Optional:";
			// 
			// LoginButton
			// 
			this.LoginButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.LoginButton.FlatAppearance.BorderSize = 0;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginButton.ForeColor = System.Drawing.Color.White;
			this.LoginButton.Location = new System.Drawing.Point(19, 578);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(296, 30);
			this.LoginButton.TabIndex = 8;
			this.LoginButton.Text = "Already have an account? Click here!";
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Click += new System.EventHandler(this.OnLoginButtonClick);
			// 
			// SignUpButton
			// 
			this.SignUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.SignUpButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.SignUpButton.FlatAppearance.BorderSize = 0;
			this.SignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SignUpButton.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SignUpButton.ForeColor = System.Drawing.Color.White;
			this.SignUpButton.Location = new System.Drawing.Point(417, 560);
			this.SignUpButton.Name = "SignUpButton";
			this.SignUpButton.Size = new System.Drawing.Size(108, 48);
			this.SignUpButton.TabIndex = 7;
			this.SignUpButton.Text = "Sign Up!";
			this.SignUpButton.UseVisualStyleBackColor = false;
			this.SignUpButton.Click += new System.EventHandler(this.OnSignUpButtonClick);
			// 
			// UsernameHintLabel
			// 
			this.UsernameHintLabel.AutoSize = true;
			this.UsernameHintLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UsernameHintLabel.ForeColor = System.Drawing.Color.SteelBlue;
			this.UsernameHintLabel.Location = new System.Drawing.Point(293, 181);
			this.UsernameHintLabel.Name = "UsernameHintLabel";
			this.UsernameHintLabel.Size = new System.Drawing.Size(235, 40);
			this.UsernameHintLabel.TabIndex = 67;
			this.UsernameHintLabel.Text = "5-20 characters, alphanumeric,\r\ndot (.), and underscore (_)";
			this.UsernameHintLabel.UseMnemonic = false;
			this.UsernameHintLabel.Visible = false;
			// 
			// PasswordHintLabel
			// 
			this.PasswordHintLabel.AutoSize = true;
			this.PasswordHintLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordHintLabel.ForeColor = System.Drawing.Color.SteelBlue;
			this.PasswordHintLabel.Location = new System.Drawing.Point(26, 304);
			this.PasswordHintLabel.Name = "PasswordHintLabel";
			this.PasswordHintLabel.Size = new System.Drawing.Size(122, 20);
			this.PasswordHintLabel.TabIndex = 67;
			this.PasswordHintLabel.Text = "8-20 characters";
			this.PasswordHintLabel.UseMnemonic = false;
			this.PasswordHintLabel.Visible = false;
			// 
			// ConfirmPasswordHintLabel
			// 
			this.ConfirmPasswordHintLabel.AutoSize = true;
			this.ConfirmPasswordHintLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ConfirmPasswordHintLabel.ForeColor = System.Drawing.Color.SandyBrown;
			this.ConfirmPasswordHintLabel.Location = new System.Drawing.Point(292, 304);
			this.ConfirmPasswordHintLabel.Name = "ConfirmPasswordHintLabel";
			this.ConfirmPasswordHintLabel.Size = new System.Drawing.Size(156, 20);
			this.ConfirmPasswordHintLabel.TabIndex = 67;
			this.ConfirmPasswordHintLabel.Text = "Incorrect Password!";
			this.ConfirmPasswordHintLabel.UseMnemonic = false;
			this.ConfirmPasswordHintLabel.Visible = false;
			// 
			// PhoneHintIcon
			// 
			this.PhoneHintIcon.Location = new System.Drawing.Point(486, 385);
			this.PhoneHintIcon.Name = "PhoneHintIcon";
			this.PhoneHintIcon.Size = new System.Drawing.Size(24, 24);
			this.PhoneHintIcon.TabIndex = 68;
			this.PhoneHintIcon.TabStop = false;
			this.PhoneHintIcon.Visible = false;
			// 
			// EmailHintIcon
			// 
			this.EmailHintIcon.Location = new System.Drawing.Point(117, 387);
			this.EmailHintIcon.Name = "EmailHintIcon";
			this.EmailHintIcon.Size = new System.Drawing.Size(24, 24);
			this.EmailHintIcon.TabIndex = 68;
			this.EmailHintIcon.TabStop = false;
			this.EmailHintIcon.Visible = false;
			// 
			// ConfirmPasswordHintIcon
			// 
			this.ConfirmPasswordHintIcon.Location = new System.Drawing.Point(477, 241);
			this.ConfirmPasswordHintIcon.Name = "ConfirmPasswordHintIcon";
			this.ConfirmPasswordHintIcon.Size = new System.Drawing.Size(24, 24);
			this.ConfirmPasswordHintIcon.TabIndex = 68;
			this.ConfirmPasswordHintIcon.TabStop = false;
			this.ConfirmPasswordHintIcon.Visible = false;
			// 
			// PasswordHintIcon
			// 
			this.PasswordHintIcon.Location = new System.Drawing.Point(185, 241);
			this.PasswordHintIcon.Name = "PasswordHintIcon";
			this.PasswordHintIcon.Size = new System.Drawing.Size(24, 24);
			this.PasswordHintIcon.TabIndex = 68;
			this.PasswordHintIcon.TabStop = false;
			this.PasswordHintIcon.Visible = false;
			// 
			// UsernameHintIcon
			// 
			this.UsernameHintIcon.Image = global::Carbon.Properties.Resources.ExclamationIcon;
			this.UsernameHintIcon.Location = new System.Drawing.Point(460, 118);
			this.UsernameHintIcon.Name = "UsernameHintIcon";
			this.UsernameHintIcon.Size = new System.Drawing.Size(24, 24);
			this.UsernameHintIcon.TabIndex = 68;
			this.UsernameHintIcon.TabStop = false;
			this.UsernameHintIcon.Visible = false;
			// 
			// NameHintIcon
			// 
			this.NameHintIcon.Image = ((System.Drawing.Image)(resources.GetObject("NameHintIcon.Image")));
			this.NameHintIcon.Location = new System.Drawing.Point(124, 118);
			this.NameHintIcon.Name = "NameHintIcon";
			this.NameHintIcon.Size = new System.Drawing.Size(24, 24);
			this.NameHintIcon.TabIndex = 68;
			this.NameHintIcon.TabStop = false;
			this.NameHintIcon.Visible = false;
			// 
			// EmailHintLabel
			// 
			this.EmailHintLabel.AutoSize = true;
			this.EmailHintLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EmailHintLabel.ForeColor = System.Drawing.Color.SandyBrown;
			this.EmailHintLabel.Location = new System.Drawing.Point(24, 448);
			this.EmailHintLabel.Name = "EmailHintLabel";
			this.EmailHintLabel.Size = new System.Drawing.Size(166, 20);
			this.EmailHintLabel.TabIndex = 67;
			this.EmailHintLabel.Text = "Invalid Email Address!";
			this.EmailHintLabel.UseMnemonic = false;
			this.EmailHintLabel.Visible = false;
			// 
			// PhoneHintLabel
			// 
			this.PhoneHintLabel.AutoSize = true;
			this.PhoneHintLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PhoneHintLabel.ForeColor = System.Drawing.Color.SandyBrown;
			this.PhoneHintLabel.Location = new System.Drawing.Point(323, 448);
			this.PhoneHintLabel.Name = "PhoneHintLabel";
			this.PhoneHintLabel.Size = new System.Drawing.Size(176, 20);
			this.PhoneHintLabel.TabIndex = 67;
			this.PhoneHintLabel.Text = "Invalid Phone Number!";
			this.PhoneHintLabel.UseMnemonic = false;
			this.PhoneHintLabel.Visible = false;
			// 
			// CheckUsernameButton
			// 
			this.CheckUsernameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
			this.CheckUsernameButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.CheckUsernameButton.FlatAppearance.BorderSize = 0;
			this.CheckUsernameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CheckUsernameButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CheckUsernameButton.ForeColor = System.Drawing.Color.DarkGray;
			this.CheckUsernameButton.Location = new System.Drawing.Point(460, 150);
			this.CheckUsernameButton.Name = "CheckUsernameButton";
			this.CheckUsernameButton.Size = new System.Drawing.Size(54, 28);
			this.CheckUsernameButton.TabIndex = 2;
			this.CheckUsernameButton.Text = "Check";
			this.CheckUsernameButton.UseVisualStyleBackColor = false;
			this.CheckUsernameButton.Click += new System.EventHandler(this.OnCheckUsernameButtonClick);
			// 
			// SignUpPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.Controls.Add(this.CheckUsernameButton);
			this.Controls.Add(this.PhoneHintIcon);
			this.Controls.Add(this.EmailHintIcon);
			this.Controls.Add(this.ConfirmPasswordHintIcon);
			this.Controls.Add(this.PasswordHintIcon);
			this.Controls.Add(this.UsernameHintIcon);
			this.Controls.Add(this.NameHintIcon);
			this.Controls.Add(this.PhoneHintLabel);
			this.Controls.Add(this.EmailHintLabel);
			this.Controls.Add(this.ConfirmPasswordHintLabel);
			this.Controls.Add(this.PasswordHintLabel);
			this.Controls.Add(this.UsernameHintLabel);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.SignUpButton);
			this.Controls.Add(this.PhoneTextBox);
			this.Controls.Add(this.ConfirmPasswordTextBox);
			this.Controls.Add(this.UsernameTextBox);
			this.Controls.Add(this.EmailTextBox);
			this.Controls.Add(this.PhoneLabel);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.ConfirmPasswordLabel);
			this.Controls.Add(this.EmailLabel);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.OptionalLabel);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.UsernameLabel);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.TitleLabel);
			this.Font = new System.Drawing.Font("Century Gothic", 14.25F);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "SignUpPanel";
			this.Size = new System.Drawing.Size(551, 629);
			((System.ComponentModel.ISupportInitialize)(this.PhoneHintIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmailHintIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ConfirmPasswordHintIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PasswordHintIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UsernameHintIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NameHintIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label TitleLabel;
		public System.Windows.Forms.Label DescriptionLabel;
		public CarboUiComponent.Carbotextbox NameTextBox;
		public System.Windows.Forms.Label NameLabel;
		public System.Windows.Forms.Label UsernameLabel;
		public CarboUiComponent.Carbotextbox UsernameTextBox;
		public System.Windows.Forms.Label PasswordLabel;
		public System.Windows.Forms.Label ConfirmPasswordLabel;
		public CarboUiComponent.Carbotextbox PasswordTextBox;
		public CarboUiComponent.Carbotextbox ConfirmPasswordTextBox;
		public System.Windows.Forms.Label EmailLabel;
		public System.Windows.Forms.Label PhoneLabel;
		public CarboUiComponent.Carbotextbox EmailTextBox;
		public CarboUiComponent.Carbotextbox PhoneTextBox;
		public System.Windows.Forms.Label OptionalLabel;
		public CarboUiComponent.Carbobutton LoginButton;
		public CarboUiComponent.Carbobutton SignUpButton;
		public System.Windows.Forms.Label UsernameHintLabel;
		public System.Windows.Forms.Label PasswordHintLabel;
		public System.Windows.Forms.Label ConfirmPasswordHintLabel;
		private System.Windows.Forms.PictureBox NameHintIcon;
		private System.Windows.Forms.PictureBox UsernameHintIcon;
		private System.Windows.Forms.PictureBox PasswordHintIcon;
		private System.Windows.Forms.PictureBox ConfirmPasswordHintIcon;
		private System.Windows.Forms.PictureBox EmailHintIcon;
		private System.Windows.Forms.PictureBox PhoneHintIcon;
		public System.Windows.Forms.Label EmailHintLabel;
		public System.Windows.Forms.Label PhoneHintLabel;
		public CarboUiComponent.Carbobutton CheckUsernameButton;
	}
}
