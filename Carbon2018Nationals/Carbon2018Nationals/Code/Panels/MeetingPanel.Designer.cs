namespace Carbon
{
	partial class MeetingPanel
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		public System.ComponentModel.IContainer components = null;

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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		public void InitializeComponent()
		{
			this.ParentGroupNameLabel = new System.Windows.Forms.Label();
			this.MemberTitleLabel = new System.Windows.Forms.Label();
			this.TagListSampleButton = new System.Windows.Forms.Button();
			this.MemberListSampleButton = new System.Windows.Forms.Button();
			this.AddTagTextBox = new CarboUiComponent.Carbotextbox();
			this.AddMemberButton = new CarboUiComponent.Carbobutton();
			this.SortMemberButton = new CarboUiComponent.Carbobutton();
			this.DeleteButton = new CarboUiComponent.Carbobutton();
			this.EditButton = new CarboUiComponent.Carbobutton();
			this.DescriptionTextBox = new CarboUiComponent.Carbotextbox();
			this.NameTextBox = new CarboUiComponent.Carbotextbox();
			this.SuspendLayout();
			// 
			// ParentGroupNameLabel
			// 
			this.ParentGroupNameLabel.AutoSize = true;
			this.ParentGroupNameLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ParentGroupNameLabel.ForeColor = System.Drawing.Color.DimGray;
			this.ParentGroupNameLabel.Location = new System.Drawing.Point(26, 71);
			this.ParentGroupNameLabel.Name = "ParentGroupNameLabel";
			this.ParentGroupNameLabel.Size = new System.Drawing.Size(174, 17);
			this.ParentGroupNameLabel.TabIndex = 1;
			this.ParentGroupNameLabel.Text = "Meeting in Group Carbon";
			this.ParentGroupNameLabel.UseMnemonic = false;
			// 
			// MemberTitleLabel
			// 
			this.MemberTitleLabel.AutoSize = true;
			this.MemberTitleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MemberTitleLabel.ForeColor = System.Drawing.Color.LightGray;
			this.MemberTitleLabel.Location = new System.Drawing.Point(29, 329);
			this.MemberTitleLabel.Name = "MemberTitleLabel";
			this.MemberTitleLabel.Size = new System.Drawing.Size(180, 22);
			this.MemberTitleLabel.TabIndex = 5;
			this.MemberTitleLabel.Text = "Meeting Members:";
			this.MemberTitleLabel.UseMnemonic = false;
			// 
			// TagListSampleButton
			// 
			this.TagListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TagListSampleButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TagListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.TagListSampleButton.Location = new System.Drawing.Point(29, 102);
			this.TagListSampleButton.MinimumSize = new System.Drawing.Size(0, 26);
			this.TagListSampleButton.Name = "TagListSampleButton";
			this.TagListSampleButton.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
			this.TagListSampleButton.Size = new System.Drawing.Size(596, 30);
			this.TagListSampleButton.TabIndex = 8;
			this.TagListSampleButton.Text = "Tag TileList";
			this.TagListSampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.TagListSampleButton.UseVisualStyleBackColor = false;
			this.TagListSampleButton.Visible = false;
			// 
			// MemberListSampleButton
			// 
			this.MemberListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(25)))), ((int)(((byte)(42)))));
			this.MemberListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MemberListSampleButton.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.MemberListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.MemberListSampleButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.MemberListSampleButton.Location = new System.Drawing.Point(30, 373);
			this.MemberListSampleButton.MinimumSize = new System.Drawing.Size(85, 125);
			this.MemberListSampleButton.Name = "MemberListSampleButton";
			this.MemberListSampleButton.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
			this.MemberListSampleButton.Size = new System.Drawing.Size(595, 233);
			this.MemberListSampleButton.TabIndex = 10;
			this.MemberListSampleButton.Text = "Member TileList";
			this.MemberListSampleButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.MemberListSampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.MemberListSampleButton.UseVisualStyleBackColor = false;
			this.MemberListSampleButton.Visible = false;
			// 
			// AddTagTextBox
			// 
			this.AddTagTextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Data",
            "Party",
            "Science",
            "Landmark",
            "School",
            "Household",
            "Pair",
            "Tiny",
            "Flavor",
            "Circus",
            "Soft",
            "Invention",
            "Literature",
            "Time",
            "Instrument",
            "Nature",
            "Pattern",
            "New",
            "Big",
            "Constellation",
            "Craft",
            "Clothes",
            "Bird",
            "Imaginination",
            "Lunch",
            "Greatful",
            "Sky",
            "Hair",
            "Cycle",
            "Black",
            "White",
            "Element"});
			this.AddTagTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.AddTagTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.AddTagTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(37)))), ((int)(((byte)(94)))));
			this.AddTagTextBox.BackColorWhenEditing = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
			this.AddTagTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AddTagTextBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddTagTextBox.ForeColor = System.Drawing.Color.DarkGray;
			this.AddTagTextBox.Location = new System.Drawing.Point(33, 105);
			this.AddTagTextBox.MaxLength = 15;
			this.AddTagTextBox.Name = "AddTagTextBox";
			this.AddTagTextBox.Restrict = "[^A-Za-z0-9\\&]";
			this.AddTagTextBox.Size = new System.Drawing.Size(46, 15);
			this.AddTagTextBox.TabIndex = 9;
			this.AddTagTextBox.Text = "Add";
			this.AddTagTextBox.Visible = false;
			this.AddTagTextBox.Watermark = "  \t   \t ";
			// 
			// AddMemberButton
			// 
			this.AddMemberButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AddMemberButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AddMemberButton.FlatAppearance.BorderSize = 0;
			this.AddMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddMemberButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
			this.AddMemberButton.ForeColor = System.Drawing.Color.White;
			this.AddMemberButton.Location = new System.Drawing.Point(367, 337);
			this.AddMemberButton.Name = "AddMemberButton";
			this.AddMemberButton.Size = new System.Drawing.Size(126, 30);
			this.AddMemberButton.TabIndex = 7;
			this.AddMemberButton.Text = "Add Members";
			this.AddMemberButton.UseVisualStyleBackColor = false;
			this.AddMemberButton.Click += new System.EventHandler(this.OnAddMemberButtonClick);
			// 
			// SortMemberButton
			// 
			this.SortMemberButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.SortMemberButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.SortMemberButton.FlatAppearance.BorderSize = 0;
			this.SortMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SortMemberButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
			this.SortMemberButton.ForeColor = System.Drawing.Color.White;
			this.SortMemberButton.Location = new System.Drawing.Point(499, 337);
			this.SortMemberButton.Name = "SortMemberButton";
			this.SortMemberButton.Size = new System.Drawing.Size(126, 30);
			this.SortMemberButton.TabIndex = 7;
			this.SortMemberButton.Text = "Sort Members";
			this.SortMemberButton.UseVisualStyleBackColor = false;
			this.SortMemberButton.Click += new System.EventHandler(this.OnSortMemberButtonClick);
			// 
			// DeleteButton
			// 
			this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(22)))), ((int)(((byte)(41)))));
			this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DeleteButton.FlatAppearance.BorderSize = 0;
			this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DeleteButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DeleteButton.ForeColor = System.Drawing.Color.White;
			this.DeleteButton.Location = new System.Drawing.Point(16, 626);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(80, 30);
			this.DeleteButton.TabIndex = 4;
			this.DeleteButton.Text = "Quit";
			this.DeleteButton.UseVisualStyleBackColor = false;
			this.DeleteButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
			// 
			// EditButton
			// 
			this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.EditButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.EditButton.FlatAppearance.BorderSize = 0;
			this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EditButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditButton.ForeColor = System.Drawing.Color.White;
			this.EditButton.Location = new System.Drawing.Point(561, 626);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(80, 30);
			this.EditButton.TabIndex = 2;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = false;
			this.EditButton.Click += new System.EventHandler(this.OnEditButtonClick);
			// 
			// DescriptionTextBox
			// 
			this.DescriptionTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.DescriptionTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.DescriptionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.DescriptionTextBox.BackColorWhenEditing = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
			this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DescriptionTextBox.BorderStyleWhenEditing = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DescriptionTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionTextBox.ForeColor = System.Drawing.Color.LightGray;
			this.DescriptionTextBox.Location = new System.Drawing.Point(28, 150);
			this.DescriptionTextBox.Multiline = true;
			this.DescriptionTextBox.Name = "DescriptionTextBox";
			this.DescriptionTextBox.Restrict = "";
			this.DescriptionTextBox.Size = new System.Drawing.Size(597, 97);
			this.DescriptionTextBox.TabIndex = 1;
			this.DescriptionTextBox.Text = "bluh bluh bluh";
			this.DescriptionTextBox.Watermark = "Meeting description...  \t   \t ";
			// 
			// NameTextBox
			// 
			this.NameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.NameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.NameTextBox.BackColorWhenEditing = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
			this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NameTextBox.BorderStyleWhenEditing = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NameTextBox.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.ForeColor = System.Drawing.Color.White;
			this.NameTextBox.Location = new System.Drawing.Point(29, 34);
			this.NameTextBox.MaxLength = 40;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Restrict = "";
			this.NameTextBox.Size = new System.Drawing.Size(596, 37);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.Text = "News";
			this.NameTextBox.Watermark = "Meeting Name  \t   \t ";
			this.NameTextBox.TextChanged += new System.EventHandler(this.OnNameTextBoxTextChange);
			// 
			// MeetingPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.Controls.Add(this.MemberListSampleButton);
			this.Controls.Add(this.AddTagTextBox);
			this.Controls.Add(this.TagListSampleButton);
			this.Controls.Add(this.AddMemberButton);
			this.Controls.Add(this.SortMemberButton);
			this.Controls.Add(this.MemberTitleLabel);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.DescriptionTextBox);
			this.Controls.Add(this.ParentGroupNameLabel);
			this.Controls.Add(this.NameTextBox);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "MeetingPanel";
			this.Size = new System.Drawing.Size(655, 670);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.Label ParentGroupNameLabel;
		public CarboUiComponent.Carbotextbox DescriptionTextBox;
		public CarboUiComponent.Carbotextbox NameTextBox;
		public CarboUiComponent.Carbobutton EditButton;
		public CarboUiComponent.Carbobutton DeleteButton;
		public CarboUiComponent.Carbobutton SortMemberButton;
		public System.Windows.Forms.Label MemberTitleLabel;
		public System.Windows.Forms.Button TagListSampleButton;
		public CarboUiComponent.Carbotextbox AddTagTextBox;
		public System.Windows.Forms.Button MemberListSampleButton;
		public CarboUiComponent.Carbobutton AddMemberButton;
	}
}
