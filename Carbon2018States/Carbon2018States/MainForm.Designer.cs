using System;

namespace DontDeleteThisStefan
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MeetingSampleButton = new System.Windows.Forms.Button();
			this.GroupSampleButton = new System.Windows.Forms.Button();
			this.PostSampleButton = new System.Windows.Forms.Button();
			this.AddPostButton = new System.Windows.Forms.Button();
			this.AddMeetingButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.LoadButton = new System.Windows.Forms.Button();
			this.GroupLabel = new System.Windows.Forms.Label();
			this.MeetingLabel = new System.Windows.Forms.Label();
			this.StopUsingLabel3AsTheNameStefan = new System.Windows.Forms.Label();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.AddGroupButton = new System.Windows.Forms.Button();
			this.HelpButton = new System.Windows.Forms.Button();
			this.NewGroupLabel = new System.Windows.Forms.Label();
			this.NewMeetingLabel = new System.Windows.Forms.Label();
			this.NewPostLabel = new System.Windows.Forms.Label();
			this.MenuBackground = new System.Windows.Forms.PictureBox();
			this.PostListBackground = new System.Windows.Forms.PictureBox();
			this.MeetingListBackground = new System.Windows.Forms.PictureBox();
			this.GroupListBackground = new System.Windows.Forms.PictureBox();
			this.TopMenuBackground = new System.Windows.Forms.PictureBox();
			this.MainBackground = new System.Windows.Forms.PictureBox();
			this.PostPanel = new DontDeleteThisStefan.PostPanel();
			this.MeetingPanel = new DontDeleteThisStefan.MeetingPanel();
			this.GroupPanel = new DontDeleteThisStefan.GroupPanel();
			((System.ComponentModel.ISupportInitialize)(this.MenuBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PostListBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MeetingListBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupListBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TopMenuBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MainBackground)).BeginInit();
			this.SuspendLayout();
			// 
			// MeetingSampleButton
			// 
			this.MeetingSampleButton.FlatAppearance.BorderSize = 0;
			this.MeetingSampleButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MeetingSampleButton.Location = new System.Drawing.Point(235, 89);
			this.MeetingSampleButton.Name = "MeetingSampleButton";
			this.MeetingSampleButton.Size = new System.Drawing.Size(180, 60);
			this.MeetingSampleButton.TabIndex = 1;
			this.MeetingSampleButton.Text = "Meetings";
			this.MeetingSampleButton.UseVisualStyleBackColor = false;
			// 
			// GroupSampleButton
			// 
			this.GroupSampleButton.FlatAppearance.BorderSize = 0;
			this.GroupSampleButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupSampleButton.Location = new System.Drawing.Point(52, 89);
			this.GroupSampleButton.Name = "GroupSampleButton";
			this.GroupSampleButton.Size = new System.Drawing.Size(180, 60);
			this.GroupSampleButton.TabIndex = 1;
			this.GroupSampleButton.Text = "Groups";
			this.GroupSampleButton.UseVisualStyleBackColor = false;
			// 
			// PostSampleButton
			// 
			this.PostSampleButton.BackColor = System.Drawing.Color.Transparent;
			this.PostSampleButton.FlatAppearance.BorderSize = 0;
			this.PostSampleButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PostSampleButton.Location = new System.Drawing.Point(419, 89);
			this.PostSampleButton.Name = "PostSampleButton";
			this.PostSampleButton.Size = new System.Drawing.Size(180, 60);
			this.PostSampleButton.TabIndex = 4;
			this.PostSampleButton.Text = "Posts";
			this.PostSampleButton.UseVisualStyleBackColor = false;
			// 
			// AddPostButton
			// 
			this.AddPostButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.AddPostButton.FlatAppearance.BorderSize = 0;
			this.AddPostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddPostButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddPostButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.AddPostButton.Location = new System.Drawing.Point(564, 642);
			this.AddPostButton.Name = "AddPostButton";
			this.AddPostButton.Size = new System.Drawing.Size(36, 36);
			this.AddPostButton.TabIndex = 6;
			this.AddPostButton.Text = "+";
			this.AddPostButton.UseVisualStyleBackColor = false;
			this.AddPostButton.Visible = false;
			this.AddPostButton.Click += new System.EventHandler(this.OnAddPostButtonClick);
			// 
			// AddMeetingButton
			// 
			this.AddMeetingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.AddMeetingButton.FlatAppearance.BorderSize = 0;
			this.AddMeetingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddMeetingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddMeetingButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.AddMeetingButton.Location = new System.Drawing.Point(379, 642);
			this.AddMeetingButton.Name = "AddMeetingButton";
			this.AddMeetingButton.Size = new System.Drawing.Size(36, 36);
			this.AddMeetingButton.TabIndex = 6;
			this.AddMeetingButton.Text = "+";
			this.AddMeetingButton.UseVisualStyleBackColor = false;
			this.AddMeetingButton.Visible = false;
			this.AddMeetingButton.Click += new System.EventHandler(this.OnAddMeetingButtonClick);
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.SaveButton.FlatAppearance.BorderSize = 0;
			this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveButton.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.SaveButton.ForeColor = System.Drawing.SystemColors.Window;
			this.SaveButton.Location = new System.Drawing.Point(490, 12);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(90, 37);
			this.SaveButton.TabIndex = 14;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = false;
			this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
			// 
			// LoadButton
			// 
			this.LoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.LoadButton.FlatAppearance.BorderSize = 0;
			this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoadButton.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.LoadButton.ForeColor = System.Drawing.SystemColors.Window;
			this.LoadButton.Location = new System.Drawing.Point(379, 12);
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new System.Drawing.Size(90, 37);
			this.LoadButton.TabIndex = 15;
			this.LoadButton.Text = "Load";
			this.LoadButton.UseVisualStyleBackColor = false;
			this.LoadButton.Click += new System.EventHandler(this.OnLoadbuttonClick);
			// 
			// GroupLabel
			// 
			this.GroupLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.GroupLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupLabel.ForeColor = System.Drawing.Color.DarkGray;
			this.GroupLabel.Location = new System.Drawing.Point(52, 64);
			this.GroupLabel.Name = "GroupLabel";
			this.GroupLabel.Size = new System.Drawing.Size(180, 24);
			this.GroupLabel.TabIndex = 16;
			this.GroupLabel.Text = "Groups";
			this.GroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.GroupLabel.UseCompatibleTextRendering = true;
			// 
			// MeetingLabel
			// 
			this.MeetingLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.MeetingLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MeetingLabel.ForeColor = System.Drawing.Color.DarkGray;
			this.MeetingLabel.Location = new System.Drawing.Point(235, 64);
			this.MeetingLabel.Name = "MeetingLabel";
			this.MeetingLabel.Size = new System.Drawing.Size(180, 24);
			this.MeetingLabel.TabIndex = 17;
			this.MeetingLabel.Text = "Meetings";
			this.MeetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.MeetingLabel.UseCompatibleTextRendering = true;
			// 
			// StopUsingLabel3AsTheNameStefan
			// 
			this.StopUsingLabel3AsTheNameStefan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.StopUsingLabel3AsTheNameStefan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StopUsingLabel3AsTheNameStefan.ForeColor = System.Drawing.Color.DarkGray;
			this.StopUsingLabel3AsTheNameStefan.Location = new System.Drawing.Point(419, 64);
			this.StopUsingLabel3AsTheNameStefan.Name = "StopUsingLabel3AsTheNameStefan";
			this.StopUsingLabel3AsTheNameStefan.Size = new System.Drawing.Size(180, 24);
			this.StopUsingLabel3AsTheNameStefan.TabIndex = 18;
			this.StopUsingLabel3AsTheNameStefan.Text = "Posts";
			this.StopUsingLabel3AsTheNameStefan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.StopUsingLabel3AsTheNameStefan.UseCompatibleTextRendering = true;
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.Filter = "XML File (*.xml)|*.xml|Text File (*.txt)|*.txt|All Files (*.*)|*.*";
			this.OpenFileDialog.FilterIndex = 3;
			this.OpenFileDialog.InitialDirectory = "C:\\Users\\Cor";
			// 
			// SaveFileDialog
			// 
			this.SaveFileDialog.Filter = "XML File (*.xml)|*.xml|Text File (*.txt)|*.txt|All Files (*.*)|*.*";
			this.SaveFileDialog.InitialDirectory = "C:\\Users\\Cor";
			// 
			// AddGroupButton
			// 
			this.AddGroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.AddGroupButton.FlatAppearance.BorderSize = 0;
			this.AddGroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddGroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddGroupButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.AddGroupButton.Location = new System.Drawing.Point(197, 642);
			this.AddGroupButton.Name = "AddGroupButton";
			this.AddGroupButton.Size = new System.Drawing.Size(36, 36);
			this.AddGroupButton.TabIndex = 6;
			this.AddGroupButton.Tag = "New Group";
			this.AddGroupButton.Text = "+";
			this.AddGroupButton.UseVisualStyleBackColor = false;
			this.AddGroupButton.Click += new System.EventHandler(this.OnAddGroupButtonClick);
			// 
			// HelpButton
			// 
			this.HelpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.HelpButton.FlatAppearance.BorderSize = 0;
			this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.HelpButton.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.HelpButton.ForeColor = System.Drawing.SystemColors.Window;
			this.HelpButton.Location = new System.Drawing.Point(53, 12);
			this.HelpButton.Name = "HelpButton";
			this.HelpButton.Size = new System.Drawing.Size(90, 37);
			this.HelpButton.TabIndex = 19;
			this.HelpButton.Text = " Help";
			this.HelpButton.UseVisualStyleBackColor = false;
			this.HelpButton.Click += new System.EventHandler(this.OnHelpButtonClick);
			// 
			// NewGroupLabel
			// 
			this.NewGroupLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.NewGroupLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NewGroupLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(36)))), ((int)(((byte)(64)))));
			this.NewGroupLabel.Location = new System.Drawing.Point(80, 638);
			this.NewGroupLabel.Name = "NewGroupLabel";
			this.NewGroupLabel.Size = new System.Drawing.Size(112, 40);
			this.NewGroupLabel.TabIndex = 20;
			this.NewGroupLabel.Text = "New Group →";
			this.NewGroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.NewGroupLabel.UseCompatibleTextRendering = true;
			// 
			// NewMeetingLabel
			// 
			this.NewMeetingLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.NewMeetingLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NewMeetingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(36)))), ((int)(((byte)(64)))));
			this.NewMeetingLabel.Location = new System.Drawing.Point(248, 638);
			this.NewMeetingLabel.Name = "NewMeetingLabel";
			this.NewMeetingLabel.Size = new System.Drawing.Size(129, 40);
			this.NewMeetingLabel.TabIndex = 21;
			this.NewMeetingLabel.Text = "New Meeting →";
			this.NewMeetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.NewMeetingLabel.UseCompatibleTextRendering = true;
			this.NewMeetingLabel.Visible = false;
			// 
			// NewPostLabel
			// 
			this.NewPostLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.NewPostLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NewPostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(36)))), ((int)(((byte)(64)))));
			this.NewPostLabel.Location = new System.Drawing.Point(463, 638);
			this.NewPostLabel.Name = "NewPostLabel";
			this.NewPostLabel.Size = new System.Drawing.Size(98, 40);
			this.NewPostLabel.TabIndex = 22;
			this.NewPostLabel.Text = "New Post →";
			this.NewPostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.NewPostLabel.UseCompatibleTextRendering = true;
			this.NewPostLabel.Visible = false;
			// 
			// MenuBackground
			// 
			this.MenuBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.MenuBackground.Location = new System.Drawing.Point(0, 0);
			this.MenuBackground.Margin = new System.Windows.Forms.Padding(0);
			this.MenuBackground.Name = "MenuBackground";
			this.MenuBackground.Size = new System.Drawing.Size(50, 681);
			this.MenuBackground.TabIndex = 2;
			this.MenuBackground.TabStop = false;
			// 
			// PostListBackground
			// 
			this.PostListBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.PostListBackground.Cursor = System.Windows.Forms.Cursors.Default;
			this.PostListBackground.Location = new System.Drawing.Point(417, 64);
			this.PostListBackground.Margin = new System.Windows.Forms.Padding(0);
			this.PostListBackground.Name = "PostListBackground";
			this.PostListBackground.Size = new System.Drawing.Size(184, 617);
			this.PostListBackground.TabIndex = 2;
			this.PostListBackground.TabStop = false;
			// 
			// MeetingListBackground
			// 
			this.MeetingListBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.MeetingListBackground.Cursor = System.Windows.Forms.Cursors.Default;
			this.MeetingListBackground.Location = new System.Drawing.Point(233, 64);
			this.MeetingListBackground.Margin = new System.Windows.Forms.Padding(0);
			this.MeetingListBackground.Name = "MeetingListBackground";
			this.MeetingListBackground.Size = new System.Drawing.Size(184, 617);
			this.MeetingListBackground.TabIndex = 2;
			this.MeetingListBackground.TabStop = false;
			// 
			// GroupListBackground
			// 
			this.GroupListBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.GroupListBackground.Location = new System.Drawing.Point(50, 64);
			this.GroupListBackground.Margin = new System.Windows.Forms.Padding(0);
			this.GroupListBackground.Name = "GroupListBackground";
			this.GroupListBackground.Size = new System.Drawing.Size(184, 617);
			this.GroupListBackground.TabIndex = 2;
			this.GroupListBackground.TabStop = false;
			// 
			// TopMenuBackground
			// 
			this.TopMenuBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.TopMenuBackground.Location = new System.Drawing.Point(50, 0);
			this.TopMenuBackground.Margin = new System.Windows.Forms.Padding(0);
			this.TopMenuBackground.Name = "TopMenuBackground";
			this.TopMenuBackground.Size = new System.Drawing.Size(551, 64);
			this.TopMenuBackground.TabIndex = 3;
			this.TopMenuBackground.TabStop = false;
			// 
			// MainBackground
			// 
			this.MainBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.MainBackground.Cursor = System.Windows.Forms.Cursors.Default;
			this.MainBackground.Image = ((System.Drawing.Image)(resources.GetObject("MainBackground.Image")));
			this.MainBackground.Location = new System.Drawing.Point(601, 0);
			this.MainBackground.Margin = new System.Windows.Forms.Padding(0);
			this.MainBackground.Name = "MainBackground";
			this.MainBackground.Size = new System.Drawing.Size(664, 681);
			this.MainBackground.TabIndex = 2;
			this.MainBackground.TabStop = false;
			// 
			// PostPanel
			// 
			this.PostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.PostPanel.Editable = false;
			this.PostPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PostPanel.Location = new System.Drawing.Point(601, 0);
			this.PostPanel.Margin = new System.Windows.Forms.Padding(5);
			this.PostPanel.Name = "PostPanel";
			this.PostPanel.Size = new System.Drawing.Size(655, 678);
			this.PostPanel.TabIndex = 5;
			this.PostPanel.Visible = false;
			// 
			// MeetingPanel
			// 
			this.MeetingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.MeetingPanel.Editable = false;
			this.MeetingPanel.ForeColor = System.Drawing.Color.White;
			this.MeetingPanel.Location = new System.Drawing.Point(601, 0);
			this.MeetingPanel.Name = "MeetingPanel";
			this.MeetingPanel.Size = new System.Drawing.Size(655, 670);
			this.MeetingPanel.TabIndex = 7;
			this.MeetingPanel.Visible = false;
			// 
			// GroupPanel
			// 
			this.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.GroupPanel.Editable = false;
			this.GroupPanel.ForeColor = System.Drawing.Color.White;
			this.GroupPanel.Location = new System.Drawing.Point(601, 21);
			this.GroupPanel.Name = "GroupPanel";
			this.GroupPanel.Padding = new System.Windows.Forms.Padding(20);
			this.GroupPanel.Size = new System.Drawing.Size(655, 660);
			this.GroupPanel.TabIndex = 8;
			this.GroupPanel.Visible = false;
			// 
			// FormCarbon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1260, 678);
			this.Controls.Add(this.NewPostLabel);
			this.Controls.Add(this.NewMeetingLabel);
			this.Controls.Add(this.NewGroupLabel);
			this.Controls.Add(this.HelpButton);
			this.Controls.Add(this.StopUsingLabel3AsTheNameStefan);
			this.Controls.Add(this.MeetingLabel);
			this.Controls.Add(this.GroupLabel);
			this.Controls.Add(this.LoadButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.PostPanel);
			this.Controls.Add(this.MeetingPanel);
			this.Controls.Add(this.AddGroupButton);
			this.Controls.Add(this.AddMeetingButton);
			this.Controls.Add(this.AddPostButton);
			this.Controls.Add(this.PostSampleButton);
			this.Controls.Add(this.MeetingSampleButton);
			this.Controls.Add(this.GroupSampleButton);
			this.Controls.Add(this.MenuBackground);
			this.Controls.Add(this.PostListBackground);
			this.Controls.Add(this.MeetingListBackground);
			this.Controls.Add(this.GroupListBackground);
			this.Controls.Add(this.TopMenuBackground);
			this.Controls.Add(this.GroupPanel);
			this.Controls.Add(this.MainBackground);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MaximizeBox = false;
			this.Name = "FormCarbon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Carbon";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(4)))), ((int)(((byte)(214)))));
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnThisClosing);
			((System.ComponentModel.ISupportInitialize)(this.MenuBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PostListBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MeetingListBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupListBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TopMenuBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MainBackground)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox MenuBackground;
		private System.Windows.Forms.PictureBox GroupListBackground;
		private System.Windows.Forms.PictureBox MeetingListBackground;
		private System.Windows.Forms.Button MeetingSampleButton;
		private System.Windows.Forms.Button GroupSampleButton;
		private System.Windows.Forms.PictureBox PostListBackground;
		private System.Windows.Forms.PictureBox TopMenuBackground;
        private System.Windows.Forms.Button PostSampleButton;
		private System.Windows.Forms.Button AddPostButton;
		private System.Windows.Forms.PictureBox MainBackground;
		private System.Windows.Forms.Button AddMeetingButton;
		public MeetingPanel MeetingPanel;
		public GroupPanel GroupPanel;
		public PostPanel PostPanel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.Label MeetingLabel;
        private System.Windows.Forms.Label StopUsingLabel3AsTheNameStefan;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.Button AddGroupButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Label NewGroupLabel;
        private System.Windows.Forms.Label NewMeetingLabel;
        private System.Windows.Forms.Label NewPostLabel;
    }
}

