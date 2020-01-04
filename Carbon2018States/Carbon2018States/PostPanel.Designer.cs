namespace DontDeleteThisStefan
{
	partial class PostPanel
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.DateLabel = new System.Windows.Forms.Label();
			this.AuthorLabel = new System.Windows.Forms.Label();
			this.TitleSampleTextBox = new System.Windows.Forms.TextBox();
			this.ContentSampleTextBox = new System.Windows.Forms.TextBox();
			this.EditButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DateLabel
			// 
			this.DateLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DateLabel.ForeColor = System.Drawing.Color.White;
			this.DateLabel.Location = new System.Drawing.Point(350, 99);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(281, 23);
			this.DateLabel.TabIndex = 3;
			this.DateLabel.Text = "Saturday, January 1st, 1970 00:00:00";
			this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// AuthorLabel
			// 
			this.AuthorLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AuthorLabel.ForeColor = System.Drawing.Color.White;
			this.AuthorLabel.Location = new System.Drawing.Point(350, 122);
			this.AuthorLabel.Name = "AuthorLabel";
			this.AuthorLabel.Size = new System.Drawing.Size(281, 23);
			this.AuthorLabel.TabIndex = 2;
			this.AuthorLabel.Text = "Group: Meeting";
			this.AuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TitleSampleTextBox
			// 
			this.TitleSampleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.TitleSampleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TitleSampleTextBox.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleSampleTextBox.ForeColor = System.Drawing.Color.White;
			this.TitleSampleTextBox.Location = new System.Drawing.Point(31, 46);
			this.TitleSampleTextBox.Name = "TitleSampleTextBox";
			this.TitleSampleTextBox.ReadOnly = true;
			this.TitleSampleTextBox.Size = new System.Drawing.Size(600, 30);
			this.TitleSampleTextBox.TabIndex = 1;
			this.TitleSampleTextBox.Text = "title";
			// 
			// ContentSampleTextBox
			// 
			this.ContentSampleTextBox.AcceptsReturn = true;
			this.ContentSampleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.ContentSampleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ContentSampleTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ContentSampleTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ContentSampleTextBox.ForeColor = System.Drawing.Color.White;
			this.ContentSampleTextBox.Location = new System.Drawing.Point(31, 172);
			this.ContentSampleTextBox.Multiline = true;
			this.ContentSampleTextBox.Name = "ContentSampleTextBox";
			this.ContentSampleTextBox.ReadOnly = true;
			this.ContentSampleTextBox.Size = new System.Drawing.Size(600, 443);
			this.ContentSampleTextBox.TabIndex = 0;
			this.ContentSampleTextBox.Text = "content!!!";
			// 
			// EditButton
			// 
			this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(52)))), ((int)(((byte)(81)))));
			this.EditButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.EditButton.FlatAppearance.BorderSize = 0;
			this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EditButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditButton.ForeColor = System.Drawing.Color.White;
			this.EditButton.Location = new System.Drawing.Point(562, 633);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(80, 30);
			this.EditButton.TabIndex = 4;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = false;
			this.EditButton.Click += new System.EventHandler(this.OnEditButtonClick);
			// 
			// DeleteButton
			// 
			this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(22)))), ((int)(((byte)(41)))));
			this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.DeleteButton.FlatAppearance.BorderSize = 0;
			this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DeleteButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DeleteButton.ForeColor = System.Drawing.Color.White;
			this.DeleteButton.Location = new System.Drawing.Point(17, 633);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(80, 30);
			this.DeleteButton.TabIndex = 4;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.UseVisualStyleBackColor = false;
			this.DeleteButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
			// 
			// PostPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.ContentSampleTextBox);
			this.Controls.Add(this.TitleSampleTextBox);
			this.Controls.Add(this.AuthorLabel);
			this.Controls.Add(this.DateLabel);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "PostPanel";
			this.Size = new System.Drawing.Size(660, 675);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.Label DateLabel;
		public System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.TextBox TitleSampleTextBox;
        private System.Windows.Forms.TextBox ContentSampleTextBox;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Button DeleteButton;
	}
}
