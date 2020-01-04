namespace Carbon
{
	partial class SettingItem
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
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.ValueComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.Location = new System.Drawing.Point(6, 10);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(160, 22);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "Delete System32";
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.ForeColor = System.Drawing.Color.Gray;
			this.DescriptionLabel.Location = new System.Drawing.Point(9, 36);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(455, 44);
			this.DescriptionLabel.TabIndex = 1;
			this.DescriptionLabel.Text = "Users with this permission can delete Windows/System32!";
			// 
			// ValueLabel
			// 
			this.ValueLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ValueLabel.ForeColor = System.Drawing.Color.SkyBlue;
			this.ValueLabel.Location = new System.Drawing.Point(432, 18);
			this.ValueLabel.Name = "ValueLabel";
			this.ValueLabel.Size = new System.Drawing.Size(206, 23);
			this.ValueLabel.TabIndex = 0;
			this.ValueLabel.Text = "Everyone";
			this.ValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ValueComboBox
			// 
			this.ValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ValueComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ValueComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ValueComboBox.FormattingEnabled = true;
			this.ValueComboBox.Location = new System.Drawing.Point(478, 10);
			this.ValueComboBox.Name = "ValueComboBox";
			this.ValueComboBox.Size = new System.Drawing.Size(161, 29);
			this.ValueComboBox.TabIndex = 2;
			this.ValueComboBox.SelectedIndexChanged += new System.EventHandler(this.OnValueComboBoxSelectedIndexChanged);
			// 
			// SettingItem
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(65)))), ((int)(((byte)(130)))));
			this.Controls.Add(this.ValueComboBox);
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.ValueLabel);
			this.Controls.Add(this.TitleLabel);
			this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "SettingItem";
			this.Size = new System.Drawing.Size(650, 80);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label TitleLabel;
		public System.Windows.Forms.Label DescriptionLabel;
		public System.Windows.Forms.Label ValueLabel;
		public System.Windows.Forms.ComboBox ValueComboBox;
	}
}
