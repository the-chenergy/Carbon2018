namespace Carbon
{
	partial class GroupAdvancedSettingForm
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
			this.TopBarBackground = new System.Windows.Forms.PictureBox();
			this.GroupNameLabel = new System.Windows.Forms.Label();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.MenuListSampleButton = new System.Windows.Forms.Button();
			this.Panel = new CarboUiComponent.Carbopanel();
			this.PanelSampleLabel = new System.Windows.Forms.Label();
			this.CloseButton = new CarboUiComponent.Carbobutton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.EditButton = new CarboUiComponent.Carbobutton();
			this.PermissionHelpButton = new CarboUiComponent.Carbobutton();
			((System.ComponentModel.ISupportInitialize)(this.TopBarBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// TopBarBackground
			// 
			this.TopBarBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(55)))), ((int)(((byte)(115)))));
			this.TopBarBackground.Location = new System.Drawing.Point(0, 0);
			this.TopBarBackground.Name = "TopBarBackground";
			this.TopBarBackground.Size = new System.Drawing.Size(901, 65);
			this.TopBarBackground.TabIndex = 0;
			this.TopBarBackground.TabStop = false;
			// 
			// GroupNameLabel
			// 
			this.GroupNameLabel.AutoSize = true;
			this.GroupNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(55)))), ((int)(((byte)(115)))));
			this.GroupNameLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupNameLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.GroupNameLabel.Location = new System.Drawing.Point(7, 9);
			this.GroupNameLabel.Name = "GroupNameLabel";
			this.GroupNameLabel.Size = new System.Drawing.Size(100, 28);
			this.GroupNameLabel.TabIndex = 1;
			this.GroupNameLabel.Text = "Carbon";
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(55)))), ((int)(((byte)(115)))));
			this.DescriptionLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.ForeColor = System.Drawing.Color.SteelBlue;
			this.DescriptionLabel.Location = new System.Drawing.Point(11, 40);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(174, 16);
			this.DescriptionLabel.TabIndex = 2;
			this.DescriptionLabel.Text = "Advanced Group Settings";
			// 
			// MenuListSampleButton
			// 
			this.MenuListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(58)))), ((int)(((byte)(125)))));
			this.MenuListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MenuListSampleButton.Font = new System.Drawing.Font("Century Gothic", 12.75F);
			this.MenuListSampleButton.ForeColor = System.Drawing.Color.DodgerBlue;
			this.MenuListSampleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.MenuListSampleButton.Location = new System.Drawing.Point(4, 71);
			this.MenuListSampleButton.MinimumSize = new System.Drawing.Size(0, 50);
			this.MenuListSampleButton.Name = "MenuListSampleButton";
			this.MenuListSampleButton.Size = new System.Drawing.Size(165, 423);
			this.MenuListSampleButton.TabIndex = 7;
			this.MenuListSampleButton.Text = "Menu List";
			this.MenuListSampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.MenuListSampleButton.UseVisualStyleBackColor = false;
			this.MenuListSampleButton.Visible = false;
			// 
			// Panel
			// 
			this.Panel.Location = new System.Drawing.Point(175, 71);
			this.Panel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.Panel.Name = "Panel";
			this.Panel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Panel.SampleLabel = this.PanelSampleLabel;
			this.Panel.Size = new System.Drawing.Size(713, 387);
			this.Panel.TabIndex = 8;
			// 
			// PanelSampleLabel
			// 
			this.PanelSampleLabel.AutoSize = true;
			this.PanelSampleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
			this.PanelSampleLabel.ForeColor = System.Drawing.Color.DarkGray;
			this.PanelSampleLabel.Location = new System.Drawing.Point(186, 85);
			this.PanelSampleLabel.Name = "PanelSampleLabel";
			this.PanelSampleLabel.Size = new System.Drawing.Size(115, 22);
			this.PanelSampleLabel.TabIndex = 10;
			this.PanelSampleLabel.Text = "Setting Title";
			this.PanelSampleLabel.Visible = false;
			// 
			// CloseButton
			// 
			this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
			this.CloseButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.CloseButton.FlatAppearance.BorderSize = 0;
			this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CloseButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CloseButton.ForeColor = System.Drawing.Color.LightGray;
			this.CloseButton.Location = new System.Drawing.Point(811, 461);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(77, 27);
			this.CloseButton.TabIndex = 9;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = false;
			this.CloseButton.Click += new System.EventHandler(this.OnCloseButtonClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(58)))), ((int)(((byte)(125)))));
			this.pictureBox1.Location = new System.Drawing.Point(0, 65);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(169, 434);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// EditButton
			// 
			this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(80)))), ((int)(((byte)(220)))));
			this.EditButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.EditButton.FlatAppearance.BorderSize = 0;
			this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EditButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditButton.ForeColor = System.Drawing.Color.LightGray;
			this.EditButton.Location = new System.Drawing.Point(175, 461);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(77, 27);
			this.EditButton.TabIndex = 9;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = false;
			this.EditButton.Visible = false;
			this.EditButton.Click += new System.EventHandler(this.OnEditWindowButtonClick);
			// 
			// PermissionHelpButton
			// 
			this.PermissionHelpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(110)))), ((int)(((byte)(240)))));
			this.PermissionHelpButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.PermissionHelpButton.FlatAppearance.BorderSize = 0;
			this.PermissionHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PermissionHelpButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PermissionHelpButton.ForeColor = System.Drawing.Color.LightGray;
			this.PermissionHelpButton.Location = new System.Drawing.Point(190, 121);
			this.PermissionHelpButton.Name = "PermissionHelpButton";
			this.PermissionHelpButton.Size = new System.Drawing.Size(242, 29);
			this.PermissionHelpButton.TabIndex = 9;
			this.PermissionHelpButton.Text = "Need Help with Permissions?";
			this.PermissionHelpButton.UseVisualStyleBackColor = false;
			this.PermissionHelpButton.Visible = false;
			this.PermissionHelpButton.Click += new System.EventHandler(this.OnPermissionHelpButtonClick);
			// 
			// GroupAdvancedSettingForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(900, 500);
			this.Controls.Add(this.PanelSampleLabel);
			this.Controls.Add(this.PermissionHelpButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.MenuListSampleButton);
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.GroupNameLabel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.TopBarBackground);
			this.Name = "GroupAdvancedSettingForm";
			this.Text = "GroupPermissionSettingForm";
			((System.ComponentModel.ISupportInitialize)(this.TopBarBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.Button MenuListSampleButton;
		public CarboUiComponent.Carbobutton CloseButton;
		public System.Windows.Forms.Label PanelSampleLabel;
		public System.Windows.Forms.PictureBox TopBarBackground;
		public System.Windows.Forms.Label GroupNameLabel;
		public System.Windows.Forms.Label DescriptionLabel;
		public CarboUiComponent.Carbopanel Panel;
		public System.Windows.Forms.PictureBox pictureBox1;
		public CarboUiComponent.Carbobutton EditButton;
		public CarboUiComponent.Carbobutton PermissionHelpButton;
	}
}