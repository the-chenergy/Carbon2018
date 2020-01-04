namespace Carbon
{
	partial class AddMeetingMemberForm
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
			this.SearchResultLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.RightBarBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TopBarBackground)).BeginInit();
			this.SuspendLayout();
			// 
			// SearchTextBox
			// 
			this.SearchTextBox.ForeColor = System.Drawing.Color.Gainsboro;
			// 
			// SearchButton
			// 
			this.SearchButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.SearchButton.FlatAppearance.BorderSize = 0;
			// 
			// DoneButton
			// 
			this.DoneButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
			this.DoneButton.FlatAppearance.BorderSize = 0;
			// 
			// CancelWindowButton
			// 
			this.CancelWindowButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.CancelWindowButton.FlatAppearance.BorderSize = 0;
			// 
			// SearchListSampleButton
			// 
			this.SearchListSampleButton.Location = new System.Drawing.Point(16, 165);
			this.SearchListSampleButton.Size = new System.Drawing.Size(374, 377);
			// 
			// TitleLabel
			// 
			this.TitleLabel.Size = new System.Drawing.Size(326, 23);
			this.TitleLabel.Text = "Add Group Members to Meeting";
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.Size = new System.Drawing.Size(231, 16);
			this.DescriptionLabel.Text = "to meeting News of group Carbon";
			// 
			// SearchHintLabel
			// 
			this.SearchHintLabel.Location = new System.Drawing.Point(12, 165);
			// 
			// SearchResultLabel
			// 
			this.SearchResultLabel.AutoSize = true;
			this.SearchResultLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SearchResultLabel.ForeColor = System.Drawing.Color.DarkGray;
			this.SearchResultLabel.Location = new System.Drawing.Point(12, 136);
			this.SearchResultLabel.Name = "SearchResultLabel";
			this.SearchResultLabel.Size = new System.Drawing.Size(193, 18);
			this.SearchResultLabel.TabIndex = 7;
			this.SearchResultLabel.Text = "Users going to be added:";
			// 
			// AddMeetingMemberForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(700, 600);
			this.Controls.Add(this.SearchResultLabel);
			this.Name = "AddMeetingMemberForm";
			this.Text = "AddMeetingMemberForm";
			this.Controls.SetChildIndex(this.RightBarBackground, 0);
			this.Controls.SetChildIndex(this.TopBarBackground, 0);
			this.Controls.SetChildIndex(this.TitleLabel, 0);
			this.Controls.SetChildIndex(this.SearchTextBox, 0);
			this.Controls.SetChildIndex(this.SearchButton, 0);
			this.Controls.SetChildIndex(this.CancelWindowButton, 0);
			this.Controls.SetChildIndex(this.DoneButton, 0);
			this.Controls.SetChildIndex(this.AddedListTitleLabel, 0);
			this.Controls.SetChildIndex(this.DescriptionLabel, 0);
			this.Controls.SetChildIndex(this.SearchListSampleButton, 0);
			this.Controls.SetChildIndex(this.AddedListSampleButton, 0);
			this.Controls.SetChildIndex(this.SearchHintLabel, 0);
			this.Controls.SetChildIndex(this.SearchResultLabel, 0);
			((System.ComponentModel.ISupportInitialize)(this.RightBarBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TopBarBackground)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label SearchResultLabel;
	}
}