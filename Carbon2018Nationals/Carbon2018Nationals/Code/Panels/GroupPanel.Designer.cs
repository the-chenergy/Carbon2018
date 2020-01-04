namespace Carbon
{
	partial class GroupPanel
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
			this.InvalidCodeLabel = new System.Windows.Forms.Label();
			this.CodeLabel = new System.Windows.Forms.Label();
			this.MemberListSampleButton = new System.Windows.Forms.Button();
			this.AdminLabel = new System.Windows.Forms.Label();
			this.OwnerLabel = new System.Windows.Forms.Label();
			this.MemberTitleLabel = new System.Windows.Forms.Label();
			this.CodeTextBox = new CarboUiComponent.Carbotextbox();
			this.DescriptionTextBox = new CarboUiComponent.Carbotextbox();
			this.AddMemberButton = new CarboUiComponent.Carbobutton();
			this.DeleteButton = new CarboUiComponent.Carbobutton();
			this.AdvancedSettingButton = new CarboUiComponent.Carbobutton();
			this.SortMemberButton = new CarboUiComponent.Carbobutton();
			this.EditButton = new CarboUiComponent.Carbobutton();
			this.NameTextBox = new CarboUiComponent.Carbotextbox();
			this.SuspendLayout();
			// 
			// InvalidCodeLabel
			// 
			this.InvalidCodeLabel.AutoSize = true;
			this.InvalidCodeLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InvalidCodeLabel.ForeColor = System.Drawing.Color.SandyBrown;
			this.InvalidCodeLabel.Location = new System.Drawing.Point(336, 95);
			this.InvalidCodeLabel.Name = "InvalidCodeLabel";
			this.InvalidCodeLabel.Size = new System.Drawing.Size(84, 21);
			this.InvalidCodeLabel.TabIndex = 2;
			this.InvalidCodeLabel.Text = "Get out!!!";
			this.InvalidCodeLabel.UseMnemonic = false;
			this.InvalidCodeLabel.Visible = false;
			// 
			// CodeLabel
			// 
			this.CodeLabel.Font = new System.Drawing.Font("Century Gothic", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CodeLabel.ForeColor = System.Drawing.Color.Gray;
			this.CodeLabel.Location = new System.Drawing.Point(29, 94);
			this.CodeLabel.Name = "CodeLabel";
			this.CodeLabel.Size = new System.Drawing.Size(19, 22);
			this.CodeLabel.TabIndex = 2;
			this.CodeLabel.Text = "@";
			this.CodeLabel.UseMnemonic = false;
			// 
			// MemberListSampleButton
			// 
			this.MemberListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(25)))), ((int)(((byte)(42)))));
			this.MemberListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MemberListSampleButton.Font = new System.Drawing.Font("Century Gothic", 9F);
			this.MemberListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.MemberListSampleButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.MemberListSampleButton.Location = new System.Drawing.Point(29, 364);
			this.MemberListSampleButton.MinimumSize = new System.Drawing.Size(85, 125);
			this.MemberListSampleButton.Name = "MemberListSampleButton";
			this.MemberListSampleButton.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
			this.MemberListSampleButton.Size = new System.Drawing.Size(595, 233);
			this.MemberListSampleButton.TabIndex = 3;
			this.MemberListSampleButton.Text = "Member TileList";
			this.MemberListSampleButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.MemberListSampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.MemberListSampleButton.UseVisualStyleBackColor = false;
			this.MemberListSampleButton.Visible = false;
			// 
			// AdminLabel
			// 
			this.AdminLabel.AutoSize = true;
			this.AdminLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
			this.AdminLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AdminLabel.ForeColor = System.Drawing.Color.SteelBlue;
			this.AdminLabel.Location = new System.Drawing.Point(312, 52);
			this.AdminLabel.Name = "AdminLabel";
			this.AdminLabel.Size = new System.Drawing.Size(51, 16);
			this.AdminLabel.TabIndex = 6;
			this.AdminLabel.Text = "Admin";
			this.AdminLabel.Visible = false;
			// 
			// OwnerLabel
			// 
			this.OwnerLabel.AutoSize = true;
			this.OwnerLabel.BackColor = System.Drawing.Color.SaddleBrown;
			this.OwnerLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OwnerLabel.ForeColor = System.Drawing.Color.Orange;
			this.OwnerLabel.Location = new System.Drawing.Point(368, 52);
			this.OwnerLabel.Name = "OwnerLabel";
			this.OwnerLabel.Size = new System.Drawing.Size(50, 16);
			this.OwnerLabel.TabIndex = 7;
			this.OwnerLabel.Text = "Owner";
			this.OwnerLabel.Visible = false;
			// 
			// MemberTitleLabel
			// 
			this.MemberTitleLabel.AutoSize = true;
			this.MemberTitleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MemberTitleLabel.ForeColor = System.Drawing.Color.LightGray;
			this.MemberTitleLabel.Location = new System.Drawing.Point(25, 322);
			this.MemberTitleLabel.Name = "MemberTitleLabel";
			this.MemberTitleLabel.Size = new System.Drawing.Size(164, 22);
			this.MemberTitleLabel.TabIndex = 2;
			this.MemberTitleLabel.Text = "Group Members:";
			this.MemberTitleLabel.UseMnemonic = false;
			// 
			// CodeTextBox
			// 
			this.CodeTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.CodeTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.CodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.CodeTextBox.BackColorWhenEditing = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
			this.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CodeTextBox.BorderStyleWhenEditing = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.CodeTextBox.ConvertSpacesToUnderscores = true;
			this.CodeTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CodeTextBox.ForeColor = System.Drawing.Color.DimGray;
			this.CodeTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.CodeTextBox.Location = new System.Drawing.Point(48, 90);
			this.CodeTextBox.MaxLength = 15;
			this.CodeTextBox.Name = "CodeTextBox";
			this.CodeTextBox.Restrict = "[^a-z0-9._]";
			this.CodeTextBox.Size = new System.Drawing.Size(283, 31);
			this.CodeTextBox.TabIndex = 1;
			this.CodeTextBox.Text = "carbon";
			this.CodeTextBox.Watermark = "group_code  \t   \t   \t   \t ";
			this.CodeTextBox.TextChanged += new System.EventHandler(this.OnCodeTextBoxTextChange);
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
			this.DescriptionTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			this.DescriptionTextBox.Location = new System.Drawing.Point(29, 152);
			this.DescriptionTextBox.MaxLength = 200;
			this.DescriptionTextBox.Multiline = true;
			this.DescriptionTextBox.Name = "DescriptionTextBox";
			this.DescriptionTextBox.Restrict = "";
			this.DescriptionTextBox.Size = new System.Drawing.Size(599, 130);
			this.DescriptionTextBox.TabIndex = 2;
			this.DescriptionTextBox.Text = "I love Carbon";
			this.DescriptionTextBox.Watermark = "Group description...  \t   \t   \t   \t ";
			this.DescriptionTextBox.TextChanged += new System.EventHandler(this.OnCodeTextBoxTextChange);
			// 
			// AddMemberButton
			// 
			this.AddMemberButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AddMemberButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AddMemberButton.FlatAppearance.BorderSize = 0;
			this.AddMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddMemberButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddMemberButton.ForeColor = System.Drawing.Color.White;
			this.AddMemberButton.Location = new System.Drawing.Point(367, 328);
			this.AddMemberButton.Name = "AddMemberButton";
			this.AddMemberButton.Size = new System.Drawing.Size(126, 30);
			this.AddMemberButton.TabIndex = 4;
			this.AddMemberButton.Text = "Add Members";
			this.AddMemberButton.UseVisualStyleBackColor = false;
			this.AddMemberButton.Click += new System.EventHandler(this.OnAddMemberButtonClick);
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
			this.DeleteButton.TabIndex = 5;
			this.DeleteButton.Text = "Quit";
			this.DeleteButton.UseVisualStyleBackColor = false;
			this.DeleteButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
			// 
			// AdvancedSettingButton
			// 
			this.AdvancedSettingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AdvancedSettingButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AdvancedSettingButton.FlatAppearance.BorderSize = 0;
			this.AdvancedSettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdvancedSettingButton.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AdvancedSettingButton.ForeColor = System.Drawing.Color.White;
			this.AdvancedSettingButton.Location = new System.Drawing.Point(396, 626);
			this.AdvancedSettingButton.Name = "AdvancedSettingButton";
			this.AdvancedSettingButton.Size = new System.Drawing.Size(159, 30);
			this.AdvancedSettingButton.TabIndex = 4;
			this.AdvancedSettingButton.Text = "Advanced Settings";
			this.AdvancedSettingButton.UseVisualStyleBackColor = false;
			this.AdvancedSettingButton.Click += new System.EventHandler(this.OnAdvancedSettingButtonClick);
			// 
			// SortMemberButton
			// 
			this.SortMemberButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.SortMemberButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.SortMemberButton.FlatAppearance.BorderSize = 0;
			this.SortMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SortMemberButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SortMemberButton.ForeColor = System.Drawing.Color.White;
			this.SortMemberButton.Location = new System.Drawing.Point(498, 328);
			this.SortMemberButton.Name = "SortMemberButton";
			this.SortMemberButton.Size = new System.Drawing.Size(126, 30);
			this.SortMemberButton.TabIndex = 4;
			this.SortMemberButton.Text = "Sort Members";
			this.SortMemberButton.UseVisualStyleBackColor = false;
			this.SortMemberButton.Click += new System.EventHandler(this.OnSortMemberButtonClick);
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
			this.EditButton.TabIndex = 4;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = false;
			this.EditButton.Click += new System.EventHandler(this.OnEditButtonClick);
			// 
			// NameTextBox
			// 
			this.NameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.NameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.NameTextBox.BackColorWhenEditing = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
			this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NameTextBox.BorderStyleWhenEditing = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NameTextBox.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.ForeColor = System.Drawing.Color.White;
			this.NameTextBox.Location = new System.Drawing.Point(29, 47);
			this.NameTextBox.MaxLength = 40;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Restrict = "";
			this.NameTextBox.Size = new System.Drawing.Size(603, 41);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.Text = "CARBON (is the best)";
			this.NameTextBox.Watermark = "Group Name  \t   \t   \t   \t ";
			this.NameTextBox.TextChanged += new System.EventHandler(this.OnNameTextBoxTextChange);
			// 
			// GroupPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.Controls.Add(this.CodeTextBox);
			this.Controls.Add(this.InvalidCodeLabel);
			this.Controls.Add(this.OwnerLabel);
			this.Controls.Add(this.DescriptionTextBox);
			this.Controls.Add(this.MemberListSampleButton);
			this.Controls.Add(this.AdminLabel);
			this.Controls.Add(this.AddMemberButton);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.MemberTitleLabel);
			this.Controls.Add(this.AdvancedSettingButton);
			this.Controls.Add(this.SortMemberButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.CodeLabel);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "GroupPanel";
			this.Padding = new System.Windows.Forms.Padding(20);
			this.Size = new System.Drawing.Size(660, 675);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public CarboUiComponent.Carbotextbox DescriptionTextBox;
		public CarboUiComponent.Carbotextbox NameTextBox;
		public CarboUiComponent.Carbotextbox CodeTextBox;
		public CarboUiComponent.Carbobutton EditButton;
		public CarboUiComponent.Carbobutton DeleteButton;
		public System.Windows.Forms.Label InvalidCodeLabel;
		public System.Windows.Forms.Label CodeLabel;
		public System.Windows.Forms.Button MemberListSampleButton;
		public CarboUiComponent.Carbobutton AddMemberButton;
		public System.Windows.Forms.Label AdminLabel;
		public System.Windows.Forms.Label OwnerLabel;
		public CarboUiComponent.Carbobutton SortMemberButton;
		public CarboUiComponent.Carbobutton AdvancedSettingButton;
		public System.Windows.Forms.Label MemberTitleLabel;
	}
}
