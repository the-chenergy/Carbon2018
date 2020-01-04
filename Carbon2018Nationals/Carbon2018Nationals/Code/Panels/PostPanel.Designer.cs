namespace Carbon
{/*			this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
*/
	partial class PostPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostPanel));
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.TagListSampleButton = new System.Windows.Forms.Button();
			this.TextControlPanel = new System.Windows.Forms.Panel();
			this.RedoButton = new CarboUiComponent.Carbobutton();
			this.AlignRightButton = new CarboUiComponent.Carbobutton();
			this.UnderlineButton = new CarboUiComponent.Carbobutton();
			this.AlignLeftButton = new CarboUiComponent.Carbobutton();
			this.UndoButton = new CarboUiComponent.Carbobutton();
			this.BoldButton = new CarboUiComponent.Carbobutton();
			this.AlignMiddleButton = new CarboUiComponent.Carbobutton();
			this.ItalicButton = new CarboUiComponent.Carbobutton();
			this.ColorButton = new CarboUiComponent.Carbobutton();
			this.SizeButton = new CarboUiComponent.Carbobutton();
			this.SizeListSampleButton = new System.Windows.Forms.Button();
			this.ColorListSampleButton = new System.Windows.Forms.Button();
			this.AttachmentListSampleButton = new System.Windows.Forms.Button();
			this.AttachmentDescriptionLabel = new System.Windows.Forms.Label();
			this.AttachFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.AttachmentListLabel = new System.Windows.Forms.Label();
			this.AddTagTextBox = new CarboUiComponent.Carbotextbox();
			this.TitleTextBox = new CarboUiComponent.Carbotextbox();
			this.ContentTextBox = new CarboUiComponent.CarboRichTextbox();
			this.DeleteButton = new CarboUiComponent.Carbobutton();
			this.AttachmentButton = new CarboUiComponent.Carbobutton();
			this.EditButton = new CarboUiComponent.Carbobutton();
			this.AddAttachmentButton = new CarboUiComponent.Carbobutton();
			this.AuthorImageBox = new CarboUiComponent.Carbobutton();
			this.TextControlPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.ForeColor = System.Drawing.Color.DimGray;
			this.DescriptionLabel.Location = new System.Drawing.Point(28, 74);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(603, 37);
			this.DescriptionLabel.TabIndex = 3;
			this.DescriptionLabel.Text = "By Asian Boii on Thursday, January 1, 1970 at 12:00 AM";
			this.DescriptionLabel.UseMnemonic = false;
			// 
			// TagListSampleButton
			// 
			this.TagListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TagListSampleButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TagListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.TagListSampleButton.Location = new System.Drawing.Point(30, 114);
			this.TagListSampleButton.MinimumSize = new System.Drawing.Size(0, 26);
			this.TagListSampleButton.Name = "TagListSampleButton";
			this.TagListSampleButton.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
			this.TagListSampleButton.Size = new System.Drawing.Size(600, 30);
			this.TagListSampleButton.TabIndex = 4;
			this.TagListSampleButton.Text = "Tag TileList";
			this.TagListSampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.TagListSampleButton.UseVisualStyleBackColor = false;
			this.TagListSampleButton.Visible = false;
			// 
			// TextControlPanel
			// 
			this.TextControlPanel.Controls.Add(this.RedoButton);
			this.TextControlPanel.Controls.Add(this.AlignRightButton);
			this.TextControlPanel.Controls.Add(this.UnderlineButton);
			this.TextControlPanel.Controls.Add(this.AlignLeftButton);
			this.TextControlPanel.Controls.Add(this.UndoButton);
			this.TextControlPanel.Controls.Add(this.BoldButton);
			this.TextControlPanel.Controls.Add(this.AlignMiddleButton);
			this.TextControlPanel.Controls.Add(this.ItalicButton);
			this.TextControlPanel.Controls.Add(this.ColorButton);
			this.TextControlPanel.Controls.Add(this.SizeButton);
			this.TextControlPanel.Location = new System.Drawing.Point(28, 564);
			this.TextControlPanel.Name = "TextControlPanel";
			this.TextControlPanel.Size = new System.Drawing.Size(602, 30);
			this.TextControlPanel.TabIndex = 6;
			// 
			// RedoButton
			// 
			this.RedoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.RedoButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.RedoButton.FlatAppearance.BorderSize = 0;
			this.RedoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RedoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RedoButton.ForeColor = System.Drawing.Color.White;
			this.RedoButton.Image = global::Carbon.Properties.Resources.RedoIcon;
			this.RedoButton.Location = new System.Drawing.Point(360, 0);
			this.RedoButton.Margin = new System.Windows.Forms.Padding(0);
			this.RedoButton.Name = "RedoButton";
			this.RedoButton.Size = new System.Drawing.Size(30, 30);
			this.RedoButton.TabIndex = 2;
			this.RedoButton.Tag = "1";
			this.RedoButton.UseCompatibleTextRendering = true;
			this.RedoButton.UseVisualStyleBackColor = false;
			this.RedoButton.Click += new System.EventHandler(this.OnRedoButtonClick);
			// 
			// AlignRightButton
			// 
			this.AlignRightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AlignRightButton.BackgroundImage = global::Carbon.Properties.Resources.AlignRightIcon;
			this.AlignRightButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AlignRightButton.FlatAppearance.BorderSize = 0;
			this.AlignRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AlignRightButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AlignRightButton.ForeColor = System.Drawing.Color.White;
			this.AlignRightButton.Location = new System.Drawing.Point(290, 0);
			this.AlignRightButton.Margin = new System.Windows.Forms.Padding(0);
			this.AlignRightButton.Name = "AlignRightButton";
			this.AlignRightButton.Size = new System.Drawing.Size(30, 30);
			this.AlignRightButton.TabIndex = 2;
			this.AlignRightButton.Tag = "1";
			this.AlignRightButton.UseCompatibleTextRendering = true;
			this.AlignRightButton.UseVisualStyleBackColor = false;
			this.AlignRightButton.Click += new System.EventHandler(this.OnAlignButtonClick);
			// 
			// UnderlineButton
			// 
			this.UnderlineButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.UnderlineButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.UnderlineButton.FlatAppearance.BorderSize = 0;
			this.UnderlineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UnderlineButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UnderlineButton.ForeColor = System.Drawing.Color.White;
			this.UnderlineButton.Location = new System.Drawing.Point(60, 0);
			this.UnderlineButton.Margin = new System.Windows.Forms.Padding(0);
			this.UnderlineButton.Name = "UnderlineButton";
			this.UnderlineButton.Size = new System.Drawing.Size(30, 30);
			this.UnderlineButton.TabIndex = 2;
			this.UnderlineButton.Text = "U";
			this.UnderlineButton.UseCompatibleTextRendering = true;
			this.UnderlineButton.UseVisualStyleBackColor = false;
			this.UnderlineButton.Click += new System.EventHandler(this.OnUnderlineButtonClick);
			// 
			// AlignLeftButton
			// 
			this.AlignLeftButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AlignLeftButton.BackgroundImage = global::Carbon.Properties.Resources.AlignLeftIcon;
			this.AlignLeftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.AlignLeftButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AlignLeftButton.FlatAppearance.BorderSize = 0;
			this.AlignLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AlignLeftButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AlignLeftButton.ForeColor = System.Drawing.Color.White;
			this.AlignLeftButton.Location = new System.Drawing.Point(230, 0);
			this.AlignLeftButton.Margin = new System.Windows.Forms.Padding(0);
			this.AlignLeftButton.Name = "AlignLeftButton";
			this.AlignLeftButton.Size = new System.Drawing.Size(30, 30);
			this.AlignLeftButton.TabIndex = 2;
			this.AlignLeftButton.Tag = "0";
			this.AlignLeftButton.UseCompatibleTextRendering = true;
			this.AlignLeftButton.UseVisualStyleBackColor = false;
			this.AlignLeftButton.Click += new System.EventHandler(this.OnAlignButtonClick);
			// 
			// UndoButton
			// 
			this.UndoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.UndoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UndoButton.BackgroundImage")));
			this.UndoButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.UndoButton.FlatAppearance.BorderSize = 0;
			this.UndoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UndoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UndoButton.ForeColor = System.Drawing.Color.White;
			this.UndoButton.Location = new System.Drawing.Point(330, 0);
			this.UndoButton.Margin = new System.Windows.Forms.Padding(0);
			this.UndoButton.Name = "UndoButton";
			this.UndoButton.Size = new System.Drawing.Size(30, 30);
			this.UndoButton.TabIndex = 2;
			this.UndoButton.Tag = "2";
			this.UndoButton.UseCompatibleTextRendering = true;
			this.UndoButton.UseVisualStyleBackColor = false;
			this.UndoButton.Click += new System.EventHandler(this.OnUndoButtonClick);
			// 
			// BoldButton
			// 
			this.BoldButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.BoldButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.BoldButton.FlatAppearance.BorderSize = 0;
			this.BoldButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BoldButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BoldButton.ForeColor = System.Drawing.Color.White;
			this.BoldButton.Location = new System.Drawing.Point(0, 0);
			this.BoldButton.Margin = new System.Windows.Forms.Padding(0);
			this.BoldButton.Name = "BoldButton";
			this.BoldButton.Size = new System.Drawing.Size(30, 30);
			this.BoldButton.TabIndex = 2;
			this.BoldButton.Text = "B";
			this.BoldButton.UseCompatibleTextRendering = true;
			this.BoldButton.UseVisualStyleBackColor = false;
			this.BoldButton.Click += new System.EventHandler(this.OnBoldButtonClick);
			// 
			// AlignMiddleButton
			// 
			this.AlignMiddleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AlignMiddleButton.BackgroundImage = global::Carbon.Properties.Resources.AlignMiddleIcon;
			this.AlignMiddleButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AlignMiddleButton.FlatAppearance.BorderSize = 0;
			this.AlignMiddleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AlignMiddleButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AlignMiddleButton.ForeColor = System.Drawing.Color.White;
			this.AlignMiddleButton.Location = new System.Drawing.Point(260, 0);
			this.AlignMiddleButton.Margin = new System.Windows.Forms.Padding(0);
			this.AlignMiddleButton.Name = "AlignMiddleButton";
			this.AlignMiddleButton.Size = new System.Drawing.Size(30, 30);
			this.AlignMiddleButton.TabIndex = 2;
			this.AlignMiddleButton.Tag = "2";
			this.AlignMiddleButton.UseCompatibleTextRendering = true;
			this.AlignMiddleButton.UseVisualStyleBackColor = false;
			this.AlignMiddleButton.Click += new System.EventHandler(this.OnAlignButtonClick);
			// 
			// ItalicButton
			// 
			this.ItalicButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.ItalicButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.ItalicButton.FlatAppearance.BorderSize = 0;
			this.ItalicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ItalicButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ItalicButton.ForeColor = System.Drawing.Color.White;
			this.ItalicButton.Location = new System.Drawing.Point(30, 0);
			this.ItalicButton.Margin = new System.Windows.Forms.Padding(0);
			this.ItalicButton.Name = "ItalicButton";
			this.ItalicButton.Size = new System.Drawing.Size(30, 30);
			this.ItalicButton.TabIndex = 2;
			this.ItalicButton.Text = "I";
			this.ItalicButton.UseCompatibleTextRendering = true;
			this.ItalicButton.UseVisualStyleBackColor = false;
			this.ItalicButton.Click += new System.EventHandler(this.OnItalicButtonClick);
			// 
			// ColorButton
			// 
			this.ColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.ColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.ColorButton.FlatAppearance.BorderSize = 0;
			this.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ColorButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ColorButton.ForeColor = System.Drawing.Color.White;
			this.ColorButton.Location = new System.Drawing.Point(170, 0);
			this.ColorButton.Margin = new System.Windows.Forms.Padding(0);
			this.ColorButton.Name = "ColorButton";
			this.ColorButton.Size = new System.Drawing.Size(50, 30);
			this.ColorButton.TabIndex = 2;
			this.ColorButton.Text = "A ▼";
			this.ColorButton.UseCompatibleTextRendering = true;
			this.ColorButton.UseVisualStyleBackColor = false;
			this.ColorButton.Click += new System.EventHandler(this.OnColorButtonClick);
			// 
			// SizeButton
			// 
			this.SizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.SizeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.SizeButton.FlatAppearance.BorderSize = 0;
			this.SizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SizeButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
			this.SizeButton.ForeColor = System.Drawing.Color.White;
			this.SizeButton.Location = new System.Drawing.Point(100, 0);
			this.SizeButton.Margin = new System.Windows.Forms.Padding(0);
			this.SizeButton.Name = "SizeButton";
			this.SizeButton.Size = new System.Drawing.Size(60, 30);
			this.SizeButton.TabIndex = 2;
			this.SizeButton.Text = "14 ▼";
			this.SizeButton.UseCompatibleTextRendering = true;
			this.SizeButton.UseVisualStyleBackColor = false;
			this.SizeButton.Click += new System.EventHandler(this.OnSizeButtonClick);
			// 
			// SizeListSampleButton
			// 
			this.SizeListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SizeListSampleButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
			this.SizeListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.SizeListSampleButton.Location = new System.Drawing.Point(128, 413);
			this.SizeListSampleButton.MinimumSize = new System.Drawing.Size(0, 30);
			this.SizeListSampleButton.Name = "SizeListSampleButton";
			this.SizeListSampleButton.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
			this.SizeListSampleButton.Size = new System.Drawing.Size(60, 150);
			this.SizeListSampleButton.TabIndex = 4;
			this.SizeListSampleButton.Text = "Font Size List";
			this.SizeListSampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.SizeListSampleButton.UseVisualStyleBackColor = false;
			this.SizeListSampleButton.Visible = false;
			// 
			// ColorListSampleButton
			// 
			this.ColorListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ColorListSampleButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
			this.ColorListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.ColorListSampleButton.Location = new System.Drawing.Point(198, 503);
			this.ColorListSampleButton.MinimumSize = new System.Drawing.Size(28, 28);
			this.ColorListSampleButton.Name = "ColorListSampleButton";
			this.ColorListSampleButton.Padding = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.ColorListSampleButton.Size = new System.Drawing.Size(175, 60);
			this.ColorListSampleButton.TabIndex = 4;
			this.ColorListSampleButton.Text = "Font Color TileList";
			this.ColorListSampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ColorListSampleButton.UseVisualStyleBackColor = false;
			this.ColorListSampleButton.Visible = false;
			// 
			// AttachmentListSampleButton
			// 
			this.AttachmentListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AttachmentListSampleButton.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AttachmentListSampleButton.ForeColor = System.Drawing.Color.SteelBlue;
			this.AttachmentListSampleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.AttachmentListSampleButton.Location = new System.Drawing.Point(36, 188);
			this.AttachmentListSampleButton.MinimumSize = new System.Drawing.Size(0, 60);
			this.AttachmentListSampleButton.Name = "AttachmentListSampleButton";
			this.AttachmentListSampleButton.Padding = new System.Windows.Forms.Padding(10, 1, 0, 0);
			this.AttachmentListSampleButton.Size = new System.Drawing.Size(590, 394);
			this.AttachmentListSampleButton.TabIndex = 4;
			this.AttachmentListSampleButton.Text = "Attachment List";
			this.AttachmentListSampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.AttachmentListSampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.AttachmentListSampleButton.UseVisualStyleBackColor = false;
			this.AttachmentListSampleButton.Visible = false;
			// 
			// AttachmentDescriptionLabel
			// 
			this.AttachmentDescriptionLabel.AutoSize = true;
			this.AttachmentDescriptionLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AttachmentDescriptionLabel.ForeColor = System.Drawing.Color.Tan;
			this.AttachmentDescriptionLabel.Location = new System.Drawing.Point(276, 633);
			this.AttachmentDescriptionLabel.Name = "AttachmentDescriptionLabel";
			this.AttachmentDescriptionLabel.Size = new System.Drawing.Size(132, 16);
			this.AttachmentDescriptionLabel.TabIndex = 3;
			this.AttachmentDescriptionLabel.Text = "NaN Files Attached";
			this.AttachmentDescriptionLabel.UseMnemonic = false;
			// 
			// AttachFileDialog
			// 
			this.AttachFileDialog.Multiselect = true;
			this.AttachFileDialog.Title = "Attach Files to Post";
			// 
			// AttachmentListLabel
			// 
			this.AttachmentListLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AttachmentListLabel.ForeColor = System.Drawing.Color.DarkGray;
			this.AttachmentListLabel.Location = new System.Drawing.Point(32, 149);
			this.AttachmentListLabel.Name = "AttachmentListLabel";
			this.AttachmentListLabel.Size = new System.Drawing.Size(410, 33);
			this.AttachmentListLabel.TabIndex = 7;
			this.AttachmentListLabel.Text = "Attachments: (double click to open)";
			this.AttachmentListLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.AttachmentListLabel.UseMnemonic = false;
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
			this.AddTagTextBox.Location = new System.Drawing.Point(32, 116);
			this.AddTagTextBox.MaxLength = 15;
			this.AddTagTextBox.Name = "AddTagTextBox";
			this.AddTagTextBox.Restrict = "[^A-Za-z0-9\\&]";
			this.AddTagTextBox.Size = new System.Drawing.Size(46, 15);
			this.AddTagTextBox.TabIndex = 5;
			this.AddTagTextBox.Text = "Add";
			this.AddTagTextBox.Visible = false;
			this.AddTagTextBox.Watermark = "";
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.TitleTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.TitleTextBox.BackColorWhenEditing = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(46)))));
			this.TitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TitleTextBox.BorderStyleWhenEditing = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TitleTextBox.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleTextBox.ForeColor = System.Drawing.Color.White;
			this.TitleTextBox.Location = new System.Drawing.Point(28, 34);
			this.TitleTextBox.MaxLength = 40;
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Restrict = "";
			this.TitleTextBox.Size = new System.Drawing.Size(547, 37);
			this.TitleTextBox.TabIndex = 0;
			this.TitleTextBox.Text = "Post Title";
			this.TitleTextBox.Watermark = "Post Title";
			this.TitleTextBox.TextChanged += new System.EventHandler(this.OnTitleTextBoxTextChanged);
			// 
			// ContentTextBox
			// 
			this.ContentTextBox.AcceptsTab = true;
			this.ContentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.ContentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ContentTextBox.Font = new System.Drawing.Font("Century Gothic", 14F);
			this.ContentTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.ContentTextBox.Location = new System.Drawing.Point(29, 158);
			this.ContentTextBox.Name = "ContentTextBox";
			this.ContentTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.ContentTextBox.Size = new System.Drawing.Size(602, 400);
			this.ContentTextBox.TabIndex = 1;
			this.ContentTextBox.Text = "Post content!!!!";
			this.ContentTextBox.Watermark = "Post content...";
			this.ContentTextBox.TextChanged += new System.EventHandler(this.OnContentTextBoxTextChanged);
			this.ContentTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnContentTextBoxMouseUp);
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
			this.DeleteButton.TabIndex = 3;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.UseCompatibleTextRendering = true;
			this.DeleteButton.UseVisualStyleBackColor = false;
			this.DeleteButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
			// 
			// AttachmentButton
			// 
			this.AttachmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AttachmentButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AttachmentButton.FlatAppearance.BorderSize = 0;
			this.AttachmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AttachmentButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AttachmentButton.ForeColor = System.Drawing.Color.White;
			this.AttachmentButton.Location = new System.Drawing.Point(103, 626);
			this.AttachmentButton.Name = "AttachmentButton";
			this.AttachmentButton.Size = new System.Drawing.Size(167, 30);
			this.AttachmentButton.TabIndex = 2;
			this.AttachmentButton.Text = "Attach Files to Post";
			this.AttachmentButton.UseCompatibleTextRendering = true;
			this.AttachmentButton.UseVisualStyleBackColor = false;
			this.AttachmentButton.Click += new System.EventHandler(this.OnAttachmentButtonClick);
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
			this.EditButton.UseCompatibleTextRendering = true;
			this.EditButton.UseVisualStyleBackColor = false;
			this.EditButton.Click += new System.EventHandler(this.OnEditButtonClick);
			// 
			// AddAttachmentButton
			// 
			this.AddAttachmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.AddAttachmentButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.AddAttachmentButton.FlatAppearance.BorderSize = 0;
			this.AddAttachmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddAttachmentButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddAttachmentButton.ForeColor = System.Drawing.Color.White;
			this.AddAttachmentButton.Location = new System.Drawing.Point(486, 159);
			this.AddAttachmentButton.Name = "AddAttachmentButton";
			this.AddAttachmentButton.Size = new System.Drawing.Size(131, 23);
			this.AddAttachmentButton.TabIndex = 2;
			this.AddAttachmentButton.Text = "Add Attachments";
			this.AddAttachmentButton.UseCompatibleTextRendering = true;
			this.AddAttachmentButton.UseVisualStyleBackColor = false;
			this.AddAttachmentButton.Click += new System.EventHandler(this.OnAddAttachmentButtonClick);
			// 
			// AuthorImageBox
			// 
			this.AuthorImageBox.BackgroundImage = global::Carbon.Properties.Resources.DefaultUserImage;
			this.AuthorImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.AuthorImageBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AuthorImageBox.FlatAppearance.BorderSize = 0;
			this.AuthorImageBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AuthorImageBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AuthorImageBox.Location = new System.Drawing.Point(581, 29);
			this.AuthorImageBox.Name = "AuthorImageBox";
			this.AuthorImageBox.Size = new System.Drawing.Size(50, 50);
			this.AuthorImageBox.TabIndex = 8;
			this.AuthorImageBox.UseVisualStyleBackColor = true;
			this.AuthorImageBox.Click += new System.EventHandler(this.OnAuthorImageBoxClick);
			// 
			// PostPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.Controls.Add(this.AuthorImageBox);
			this.Controls.Add(this.TextControlPanel);
			this.Controls.Add(this.AddTagTextBox);
			this.Controls.Add(this.ColorListSampleButton);
			this.Controls.Add(this.SizeListSampleButton);
			this.Controls.Add(this.TagListSampleButton);
			this.Controls.Add(this.TitleTextBox);
			this.Controls.Add(this.ContentTextBox);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.AttachmentButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.AttachmentDescriptionLabel);
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.AttachmentListSampleButton);
			this.Controls.Add(this.AttachmentListLabel);
			this.Controls.Add(this.AddAttachmentButton);
			this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "PostPanel";
			this.Size = new System.Drawing.Size(655, 660);
			this.TextControlPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.Label DescriptionLabel;
		public CarboUiComponent.Carbobutton EditButton;
		public CarboUiComponent.Carbobutton DeleteButton;
		public CarboUiComponent.CarboRichTextbox ContentTextBox;
		public CarboUiComponent.Carbotextbox TitleTextBox;
		public System.Windows.Forms.Button TagListSampleButton;
		public CarboUiComponent.Carbotextbox AddTagTextBox;
		public CarboUiComponent.Carbobutton BoldButton;
		public CarboUiComponent.Carbobutton ItalicButton;
		public CarboUiComponent.Carbobutton UnderlineButton;
		public CarboUiComponent.Carbobutton SizeButton;
		public CarboUiComponent.Carbobutton ColorButton;
		public System.Windows.Forms.Button SizeListSampleButton;
		public System.Windows.Forms.Button ColorListSampleButton;
		public CarboUiComponent.Carbobutton AlignRightButton;
		public CarboUiComponent.Carbobutton AlignLeftButton;
		public CarboUiComponent.Carbobutton AlignMiddleButton;
		public CarboUiComponent.Carbobutton RedoButton;
		public CarboUiComponent.Carbobutton UndoButton;
		public CarboUiComponent.Carbobutton AttachmentButton;
		public System.Windows.Forms.Button AttachmentListSampleButton;
		public System.Windows.Forms.Label AttachmentDescriptionLabel;
		public System.Windows.Forms.OpenFileDialog AttachFileDialog;
		public System.Windows.Forms.Panel TextControlPanel;
		public System.Windows.Forms.Label AttachmentListLabel;
		public CarboUiComponent.Carbobutton AddAttachmentButton;
		public CarboUiComponent.Carbobutton AuthorImageBox;
	}
}
