/*
this.SearchTextBox.Text = "";
*/
namespace Carbon
{
	partial class AddGroupMemberForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TitleLabel = new System.Windows.Forms.Label();
			this.SearchTextBox = new CarboUiComponent.Carbotextbox();
			this.SearchButton = new CarboUiComponent.Carbobutton();
			this.RightBarBackground = new System.Windows.Forms.PictureBox();
			this.TopBarBackground = new System.Windows.Forms.PictureBox();
			this.AddedListTitleLabel = new System.Windows.Forms.Label();
			this.DoneButton = new CarboUiComponent.Carbobutton();
			this.CancelWindowButton = new CarboUiComponent.Carbobutton();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.SearchListSampleButton = new System.Windows.Forms.Button();
			this.AddedListSampleButton = new System.Windows.Forms.Button();
			this.SearchHintLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.RightBarBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TopBarBackground)).BeginInit();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(58)))), ((int)(((byte)(125)))));
			this.TitleLabel.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.TitleLabel.Location = new System.Drawing.Point(12, 13);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(215, 23);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "Add Group Members";
			// 
			// SearchTextBox
			// 
			this.SearchTextBox.AcceptsTab = true;
			this.SearchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(50)))), ((int)(((byte)(110)))));
			this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SearchTextBox.ForeColor = System.Drawing.Color.LightGray;
			this.SearchTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.SearchTextBox.Location = new System.Drawing.Point(16, 79);
			this.SearchTextBox.MaxLength = 30;
			this.SearchTextBox.Name = "SearchTextBox";
			this.SearchTextBox.Restrict = "";
			this.SearchTextBox.Size = new System.Drawing.Size(271, 27);
			this.SearchTextBox.TabIndex = 1;
			this.SearchTextBox.Text = "Search User  \t ";
			this.SearchTextBox.Watermark = "Search User";
			this.SearchTextBox.TextChanged += new System.EventHandler(this.OnSearchTextBoxTextChanged);
			this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSearchTextBoxKeyDown);
			// 
			// SearchButton
			// 
			this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
			this.SearchButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.SearchButton.FlatAppearance.BorderSize = 0;
			this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SearchButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SearchButton.ForeColor = System.Drawing.Color.LightGray;
			this.SearchButton.Location = new System.Drawing.Point(303, 79);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(77, 27);
			this.SearchButton.TabIndex = 3;
			this.SearchButton.Text = "Search";
			this.SearchButton.UseVisualStyleBackColor = false;
			this.SearchButton.Click += new System.EventHandler(this.OnSearchButtonClick);
			// 
			// RightBarBackground
			// 
			this.RightBarBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(55)))), ((int)(((byte)(115)))));
			this.RightBarBackground.Location = new System.Drawing.Point(400, -1);
			this.RightBarBackground.Name = "RightBarBackground";
			this.RightBarBackground.Size = new System.Drawing.Size(300, 602);
			this.RightBarBackground.TabIndex = 4;
			this.RightBarBackground.TabStop = false;
			// 
			// TopBarBackground
			// 
			this.TopBarBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(58)))), ((int)(((byte)(125)))));
			this.TopBarBackground.Location = new System.Drawing.Point(-1, -1);
			this.TopBarBackground.Name = "TopBarBackground";
			this.TopBarBackground.Size = new System.Drawing.Size(401, 125);
			this.TopBarBackground.TabIndex = 4;
			this.TopBarBackground.TabStop = false;
			// 
			// AddedListTitleLabel
			// 
			this.AddedListTitleLabel.AutoSize = true;
			this.AddedListTitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(55)))), ((int)(((byte)(120)))));
			this.AddedListTitleLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddedListTitleLabel.ForeColor = System.Drawing.Color.DarkGray;
			this.AddedListTitleLabel.Location = new System.Drawing.Point(408, 17);
			this.AddedListTitleLabel.Name = "AddedListTitleLabel";
			this.AddedListTitleLabel.Size = new System.Drawing.Size(193, 18);
			this.AddedListTitleLabel.TabIndex = 5;
			this.AddedListTitleLabel.Text = "Users going to be added:";
			// 
			// DoneButton
			// 
			this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
			this.DoneButton.Enabled = false;
			this.DoneButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
			this.DoneButton.FlatAppearance.BorderSize = 0;
			this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DoneButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DoneButton.ForeColor = System.Drawing.Color.PowderBlue;
			this.DoneButton.Location = new System.Drawing.Point(603, 548);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new System.Drawing.Size(85, 40);
			this.DoneButton.TabIndex = 3;
			this.DoneButton.Text = "Done";
			this.DoneButton.UseVisualStyleBackColor = false;
			this.DoneButton.Click += new System.EventHandler(this.OnDoneButtonClick);
			// 
			// CancelWindowButton
			// 
			this.CancelWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
			this.CancelWindowButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelWindowButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.CancelWindowButton.FlatAppearance.BorderSize = 0;
			this.CancelWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CancelWindowButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CancelWindowButton.ForeColor = System.Drawing.Color.LightGray;
			this.CancelWindowButton.Location = new System.Drawing.Point(12, 561);
			this.CancelWindowButton.Name = "CancelWindowButton";
			this.CancelWindowButton.Size = new System.Drawing.Size(77, 27);
			this.CancelWindowButton.TabIndex = 3;
			this.CancelWindowButton.Text = "Cancel";
			this.CancelWindowButton.UseVisualStyleBackColor = false;
			this.CancelWindowButton.Click += new System.EventHandler(this.OnCancelButtonClick);
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(55)))), ((int)(((byte)(120)))));
			this.DescriptionLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.ForeColor = System.Drawing.Color.SteelBlue;
			this.DescriptionLabel.Location = new System.Drawing.Point(13, 38);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(119, 16);
			this.DescriptionLabel.TabIndex = 5;
			this.DescriptionLabel.Text = "to group Carbon";
			// 
			// SearchListSampleButton
			// 
			this.SearchListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SearchListSampleButton.Font = new System.Drawing.Font("Century Gothic", 13.5F, System.Drawing.FontStyle.Bold);
			this.SearchListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.SearchListSampleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.SearchListSampleButton.Location = new System.Drawing.Point(16, 139);
			this.SearchListSampleButton.MinimumSize = new System.Drawing.Size(0, 70);
			this.SearchListSampleButton.Name = "SearchListSampleButton";
			this.SearchListSampleButton.Size = new System.Drawing.Size(374, 403);
			this.SearchListSampleButton.TabIndex = 6;
			this.SearchListSampleButton.Text = "List of Search Results";
			this.SearchListSampleButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.SearchListSampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.SearchListSampleButton.UseVisualStyleBackColor = false;
			this.SearchListSampleButton.Visible = false;
			// 
			// AddedListSampleButton
			// 
			this.AddedListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(55)))), ((int)(((byte)(115)))));
			this.AddedListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddedListSampleButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddedListSampleButton.ForeColor = System.Drawing.Color.DimGray;
			this.AddedListSampleButton.Location = new System.Drawing.Point(411, 50);
			this.AddedListSampleButton.MinimumSize = new System.Drawing.Size(0, 30);
			this.AddedListSampleButton.Name = "AddedListSampleButton";
			this.AddedListSampleButton.Size = new System.Drawing.Size(277, 492);
			this.AddedListSampleButton.TabIndex = 6;
			this.AddedListSampleButton.Text = "List of Added Users";
			this.AddedListSampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.AddedListSampleButton.UseVisualStyleBackColor = false;
			this.AddedListSampleButton.Visible = false;
			// 
			// SearchHintLabel
			// 
			this.SearchHintLabel.AutoSize = true;
			this.SearchHintLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SearchHintLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.SearchHintLabel.Location = new System.Drawing.Point(17, 140);
			this.SearchHintLabel.Name = "SearchHintLabel";
			this.SearchHintLabel.Size = new System.Drawing.Size(357, 19);
			this.SearchHintLabel.TabIndex = 5;
			this.SearchHintLabel.Text = "Use the search bar above to search for users.";
			// 
			// AddGroupMemberForm
			// 
			this.AcceptButton = this.DoneButton;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(65)))), ((int)(((byte)(130)))));
			this.CancelButton = this.CancelWindowButton;
			this.ClientSize = new System.Drawing.Size(700, 600);
			this.Controls.Add(this.SearchHintLabel);
			this.Controls.Add(this.AddedListSampleButton);
			this.Controls.Add(this.SearchListSampleButton);
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.AddedListTitleLabel);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.CancelWindowButton);
			this.Controls.Add(this.SearchButton);
			this.Controls.Add(this.SearchTextBox);
			this.Controls.Add(this.TitleLabel);
			this.Controls.Add(this.TopBarBackground);
			this.Controls.Add(this.RightBarBackground);
			this.Name = "AddGroupMemberForm";
			this.Text = "AddMemberForm";
			((System.ComponentModel.ISupportInitialize)(this.RightBarBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TopBarBackground)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public CarboUiComponent.Carbotextbox SearchTextBox;
		public CarboUiComponent.Carbobutton SearchButton;
		public CarboUiComponent.Carbobutton DoneButton;
		public CarboUiComponent.Carbobutton CancelWindowButton;
		public System.Windows.Forms.Button SearchListSampleButton;
		public System.Windows.Forms.Button AddedListSampleButton;
		public System.Windows.Forms.Label TitleLabel;
		public System.Windows.Forms.PictureBox RightBarBackground;
		public System.Windows.Forms.PictureBox TopBarBackground;
		public System.Windows.Forms.Label AddedListTitleLabel;
		public System.Windows.Forms.Label DescriptionLabel;
		public System.Windows.Forms.Label SearchHintLabel;
	}
}