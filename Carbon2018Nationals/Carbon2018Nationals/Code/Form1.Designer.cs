using System;

namespace Carbon
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		override protected void Dispose(bool disposing)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.MeetingListSampleButton = new System.Windows.Forms.Button();
			this.GroupListSampleButton = new System.Windows.Forms.Button();
			this.PostListSampleButton = new System.Windows.Forms.Button();
			this.GroupListLabel = new System.Windows.Forms.Label();
			this.MeetingListLabel = new System.Windows.Forms.Label();
			this.PostListLabel = new System.Windows.Forms.Label();
			this.OpenDBDialog = new System.Windows.Forms.OpenFileDialog();
			this.ListBackground = new System.Windows.Forms.PictureBox();
			this.SearchBarBackground = new System.Windows.Forms.PictureBox();
			this.LogoPictureBox = new System.Windows.Forms.PictureBox();
			this.SearchTextBox = new CarboUiComponent.Carbotextbox();
			this.MenuBar = new Carbon.MenuBar();
			this.PostPanel = new Carbon.PostPanel();
			this.MeetingPanel = new Carbon.MeetingPanel();
			this.GroupPanel = new Carbon.GroupPanel();
			this.ClearSearchButton = new CarboUiComponent.Carbobutton();
			this.SearchButton = new CarboUiComponent.Carbobutton();
			this.HelpWindowButton = new CarboUiComponent.Carbobutton();
			this.SearchPanel = new Carbon.SearchPanel();
			((System.ComponentModel.ISupportInitialize)(this.ListBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchBarBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// MeetingListSampleButton
			// 
			this.MeetingListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.MeetingListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MeetingListSampleButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MeetingListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.MeetingListSampleButton.Location = new System.Drawing.Point(235, 72);
			this.MeetingListSampleButton.MinimumSize = new System.Drawing.Size(0, 60);
			this.MeetingListSampleButton.Name = "MeetingListSampleButton";
			this.MeetingListSampleButton.Size = new System.Drawing.Size(180, 605);
			this.MeetingListSampleButton.TabIndex = 1;
			this.MeetingListSampleButton.Text = "Meeting List";
			this.MeetingListSampleButton.UseVisualStyleBackColor = false;
			this.MeetingListSampleButton.Visible = false;
			// 
			// GroupListSampleButton
			// 
			this.GroupListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.GroupListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GroupListSampleButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.GroupListSampleButton.Location = new System.Drawing.Point(52, 72);
			this.GroupListSampleButton.MinimumSize = new System.Drawing.Size(0, 60);
			this.GroupListSampleButton.Name = "GroupListSampleButton";
			this.GroupListSampleButton.Size = new System.Drawing.Size(180, 605);
			this.GroupListSampleButton.TabIndex = 1;
			this.GroupListSampleButton.Text = "Group List";
			this.GroupListSampleButton.UseVisualStyleBackColor = false;
			this.GroupListSampleButton.Visible = false;
			// 
			// PostListSampleButton
			// 
			this.PostListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.PostListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PostListSampleButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PostListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.PostListSampleButton.Location = new System.Drawing.Point(418, 72);
			this.PostListSampleButton.MinimumSize = new System.Drawing.Size(0, 60);
			this.PostListSampleButton.Name = "PostListSampleButton";
			this.PostListSampleButton.Size = new System.Drawing.Size(180, 605);
			this.PostListSampleButton.TabIndex = 4;
			this.PostListSampleButton.Text = "Post List";
			this.PostListSampleButton.UseVisualStyleBackColor = false;
			this.PostListSampleButton.Visible = false;
			// 
			// GroupListLabel
			// 
			this.GroupListLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
			this.GroupListLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupListLabel.ForeColor = System.Drawing.Color.DimGray;
			this.GroupListLabel.Location = new System.Drawing.Point(52, 48);
			this.GroupListLabel.Name = "GroupListLabel";
			this.GroupListLabel.Size = new System.Drawing.Size(180, 24);
			this.GroupListLabel.TabIndex = 16;
			this.GroupListLabel.Text = "Groups";
			this.GroupListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.GroupListLabel.UseCompatibleTextRendering = true;
			this.GroupListLabel.Visible = false;
			// 
			// MeetingListLabel
			// 
			this.MeetingListLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
			this.MeetingListLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MeetingListLabel.ForeColor = System.Drawing.Color.DimGray;
			this.MeetingListLabel.Location = new System.Drawing.Point(235, 48);
			this.MeetingListLabel.Name = "MeetingListLabel";
			this.MeetingListLabel.Size = new System.Drawing.Size(180, 24);
			this.MeetingListLabel.TabIndex = 17;
			this.MeetingListLabel.Text = "Meetings";
			this.MeetingListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.MeetingListLabel.UseCompatibleTextRendering = true;
			this.MeetingListLabel.Visible = false;
			// 
			// PostListLabel
			// 
			this.PostListLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
			this.PostListLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PostListLabel.ForeColor = System.Drawing.Color.DimGray;
			this.PostListLabel.Location = new System.Drawing.Point(418, 48);
			this.PostListLabel.Name = "PostListLabel";
			this.PostListLabel.Size = new System.Drawing.Size(180, 24);
			this.PostListLabel.TabIndex = 18;
			this.PostListLabel.Text = "Posts";
			this.PostListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.PostListLabel.UseCompatibleTextRendering = true;
			this.PostListLabel.Visible = false;
			// 
			// OpenDBDialog
			// 
			this.OpenDBDialog.CheckFileExists = false;
			this.OpenDBDialog.CheckPathExists = false;
			this.OpenDBDialog.Filter = "Database Files|*.db;*.sqlite|All Files|*.*";
			this.OpenDBDialog.Title = "Connect to SQLite Database";
			// 
			// ListBackground
			// 
			this.ListBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.ListBackground.Cursor = System.Windows.Forms.Cursors.Default;
			this.ListBackground.Location = new System.Drawing.Point(50, 72);
			this.ListBackground.Margin = new System.Windows.Forms.Padding(0);
			this.ListBackground.Name = "ListBackground";
			this.ListBackground.Size = new System.Drawing.Size(551, 609);
			this.ListBackground.TabIndex = 2;
			this.ListBackground.TabStop = false;
			// 
			// SearchBarBackground
			// 
			this.SearchBarBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.SearchBarBackground.Location = new System.Drawing.Point(50, 0);
			this.SearchBarBackground.Margin = new System.Windows.Forms.Padding(0);
			this.SearchBarBackground.Name = "SearchBarBackground";
			this.SearchBarBackground.Size = new System.Drawing.Size(551, 72);
			this.SearchBarBackground.TabIndex = 3;
			this.SearchBarBackground.TabStop = false;
			// 
			// LogoPictureBox
			// 
			this.LogoPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.LogoPictureBox.BackgroundImage = global::Carbon.Properties.Resources.LogoIcon;
			this.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.LogoPictureBox.Location = new System.Drawing.Point(648, 153);
			this.LogoPictureBox.Name = "LogoPictureBox";
			this.LogoPictureBox.Size = new System.Drawing.Size(609, 529);
			this.LogoPictureBox.TabIndex = 23;
			this.LogoPictureBox.TabStop = false;
			// 
			// SearchTextBox
			// 
			this.SearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.SearchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.SearchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SearchTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SearchTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.SearchTextBox.Location = new System.Drawing.Point(60, 13);
			this.SearchTextBox.Name = "SearchTextBox";
			this.SearchTextBox.Restrict = "";
			this.SearchTextBox.Size = new System.Drawing.Size(425, 21);
			this.SearchTextBox.TabIndex = 25;
			this.SearchTextBox.Text = "Search Keywords...";
			this.SearchTextBox.Visible = false;
			this.SearchTextBox.Watermark = "Search groups, meetings, or posts  \t   \t ";
			this.SearchTextBox.WatermarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
			this.SearchTextBox.TextChanged += new System.EventHandler(this.OnSearchTextBoxTextChanged);
			this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSearchTextBoxKeyDown);
			// 
			// MenuBar
			// 
			this.MenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.MenuBar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MenuBar.ForeColor = System.Drawing.Color.White;
			this.MenuBar.IsExpanded = false;
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.Size = new System.Drawing.Size(50, 681);
			this.MenuBar.TabIndex = 24;
			// 
			// PostPanel
			// 
			this.PostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.PostPanel.Editable = false;
			this.PostPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PostPanel.ForeColor = System.Drawing.Color.White;
			this.PostPanel.Location = new System.Drawing.Point(601, 0);
			this.PostPanel.Margin = new System.Windows.Forms.Padding(5);
			this.PostPanel.Name = "PostPanel";
			this.PostPanel.Size = new System.Drawing.Size(655, 660);
			this.PostPanel.TabIndex = 22;
			this.PostPanel.Tag = "PostPanel";
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
			this.MeetingPanel.TabIndex = 21;
			this.MeetingPanel.Tag = "MeetingPanel";
			this.MeetingPanel.Visible = false;
			// 
			// GroupPanel
			// 
			this.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.GroupPanel.Editable = false;
			this.GroupPanel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupPanel.ForeColor = System.Drawing.Color.White;
			this.GroupPanel.Location = new System.Drawing.Point(601, 0);
			this.GroupPanel.Name = "GroupPanel";
			this.GroupPanel.Padding = new System.Windows.Forms.Padding(20);
			this.GroupPanel.Size = new System.Drawing.Size(660, 675);
			this.GroupPanel.TabIndex = 20;
			this.GroupPanel.Tag = "GroupPanel";
			this.GroupPanel.Visible = false;
			// 
			// ClearSearchButton
			// 
			this.ClearSearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
			this.ClearSearchButton.FlatAppearance.BorderSize = 0;
			this.ClearSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ClearSearchButton.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClearSearchButton.ForeColor = System.Drawing.Color.SaddleBrown;
			this.ClearSearchButton.Location = new System.Drawing.Point(493, 0);
			this.ClearSearchButton.Name = "ClearSearchButton";
			this.ClearSearchButton.Size = new System.Drawing.Size(29, 45);
			this.ClearSearchButton.TabIndex = 19;
			this.ClearSearchButton.Text = "×";
			this.ClearSearchButton.UseVisualStyleBackColor = false;
			this.ClearSearchButton.Visible = false;
			this.ClearSearchButton.Click += new System.EventHandler(this.OnClearSearchButtonClick);
			// 
			// SearchButton
			// 
			this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
			this.SearchButton.FlatAppearance.BorderSize = 0;
			this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SearchButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SearchButton.ForeColor = System.Drawing.Color.DimGray;
			this.SearchButton.Location = new System.Drawing.Point(522, 0);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(78, 45);
			this.SearchButton.TabIndex = 19;
			this.SearchButton.Text = "Search";
			this.SearchButton.UseVisualStyleBackColor = false;
			this.SearchButton.Visible = false;
			this.SearchButton.Click += new System.EventHandler(this.OnSearchButtonCilck);
			// 
			// HelpWindowButton
			// 
			this.HelpWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
			this.HelpWindowButton.FlatAppearance.BorderSize = 0;
			this.HelpWindowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
			this.HelpWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.HelpWindowButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HelpWindowButton.ForeColor = System.Drawing.Color.SlateGray;
			this.HelpWindowButton.Location = new System.Drawing.Point(485, 0);
			this.HelpWindowButton.Name = "HelpWindowButton";
			this.HelpWindowButton.Size = new System.Drawing.Size(115, 45);
			this.HelpWindowButton.TabIndex = 19;
			this.HelpWindowButton.Text = "Need Help?";
			this.HelpWindowButton.UseVisualStyleBackColor = false;
			this.HelpWindowButton.Click += new System.EventHandler(this.OnHelpButtonClick);
			// 
			// SearchPanel
			// 
			this.SearchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.SearchPanel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SearchPanel.ForeColor = System.Drawing.Color.White;
			this.SearchPanel.Location = new System.Drawing.Point(50, 72);
			this.SearchPanel.Name = "SearchPanel";
			this.SearchPanel.Size = new System.Drawing.Size(551, 605);
			this.SearchPanel.TabIndex = 26;
			this.SearchPanel.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.ClientSize = new System.Drawing.Size(1260, 678);
			this.Controls.Add(this.SearchTextBox);
			this.Controls.Add(this.MenuBar);
			this.Controls.Add(this.PostPanel);
			this.Controls.Add(this.MeetingPanel);
			this.Controls.Add(this.GroupPanel);
			this.Controls.Add(this.ClearSearchButton);
			this.Controls.Add(this.SearchButton);
			this.Controls.Add(this.HelpWindowButton);
			this.Controls.Add(this.PostListLabel);
			this.Controls.Add(this.MeetingListLabel);
			this.Controls.Add(this.GroupListLabel);
			this.Controls.Add(this.PostListSampleButton);
			this.Controls.Add(this.MeetingListSampleButton);
			this.Controls.Add(this.GroupListSampleButton);
			this.Controls.Add(this.ListBackground);
			this.Controls.Add(this.SearchBarBackground);
			this.Controls.Add(this.LogoPictureBox);
			this.Controls.Add(this.SearchPanel);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MinimumSize = new System.Drawing.Size(1276, 616);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(2)))), ((int)(((byte)(3)))));
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
			this.Resize += new System.EventHandler(this.OnResize);
			((System.ComponentModel.ISupportInitialize)(this.ListBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchBarBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.Button MeetingListSampleButton;
		public System.Windows.Forms.Button GroupListSampleButton;
		public System.Windows.Forms.PictureBox ListBackground;
		public System.Windows.Forms.PictureBox SearchBarBackground;
		public System.Windows.Forms.Button PostListSampleButton;
		public System.Windows.Forms.Label GroupListLabel;
		public System.Windows.Forms.Label MeetingListLabel;
		public System.Windows.Forms.Label PostListLabel;
		public CarboUiComponent.Carbobutton HelpWindowButton;
		public GroupPanel GroupPanel;
		public MeetingPanel MeetingPanel;
		public PostPanel PostPanel;
		public System.Windows.Forms.PictureBox LogoPictureBox;
		public MenuBar MenuBar;
		public System.Windows.Forms.OpenFileDialog OpenDBDialog;
		public CarboUiComponent.Carbobutton SearchButton;
		public CarboUiComponent.Carbobutton ClearSearchButton;
		public CarboUiComponent.Carbotextbox SearchTextBox;
		private SearchPanel SearchPanel;
	}
}

