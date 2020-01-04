namespace Carbon
{
	partial class MenuBar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuBar));
			this.MenuButtonListSampleButton = new System.Windows.Forms.Button();
			this.UserImageBox = new CarboUiComponent.Carbobutton();
			this.ExpandButton = new CarboUiComponent.Carbobutton();
			this.SuspendLayout();
			// 
			// MenuButtonListSampleButton
			// 
			this.MenuButtonListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MenuButtonListSampleButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MenuButtonListSampleButton.ForeColor = System.Drawing.Color.DarkGray;
			this.MenuButtonListSampleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.MenuButtonListSampleButton.Location = new System.Drawing.Point(0, 50);
			this.MenuButtonListSampleButton.Margin = new System.Windows.Forms.Padding(0);
			this.MenuButtonListSampleButton.MinimumSize = new System.Drawing.Size(0, 50);
			this.MenuButtonListSampleButton.Name = "MenuButtonListSampleButton";
			this.MenuButtonListSampleButton.Size = new System.Drawing.Size(160, 250);
			this.MenuButtonListSampleButton.TabIndex = 0;
			this.MenuButtonListSampleButton.Text = "Menu";
			this.MenuButtonListSampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.MenuButtonListSampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.MenuButtonListSampleButton.UseVisualStyleBackColor = false;
			this.MenuButtonListSampleButton.Visible = false;
			this.MenuButtonListSampleButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
			// 
			// UserImageBox
			// 
			this.UserImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.UserImageBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UserImageBox.FlatAppearance.BorderSize = 0;
			this.UserImageBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UserImageBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UserImageBox.Location = new System.Drawing.Point(16, 537);
			this.UserImageBox.Name = "UserImageBox";
			this.UserImageBox.Size = new System.Drawing.Size(128, 128);
			this.UserImageBox.TabIndex = 3;
			this.UserImageBox.UseVisualStyleBackColor = true;
			// 
			// ExpandButton
			// 
			this.ExpandButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ExpandButton.FlatAppearance.BorderSize = 0;
			this.ExpandButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExpandButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExpandButton.Image = ((System.Drawing.Image)(resources.GetObject("ExpandButton.Image")));
			this.ExpandButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ExpandButton.Location = new System.Drawing.Point(0, 0);
			this.ExpandButton.Margin = new System.Windows.Forms.Padding(0);
			this.ExpandButton.Name = "ExpandButton";
			this.ExpandButton.Size = new System.Drawing.Size(160, 50);
			this.ExpandButton.TabIndex = 1;
			this.ExpandButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ExpandButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ExpandButton.UseVisualStyleBackColor = false;
			this.ExpandButton.Click += new System.EventHandler(this.OnExpandButtonClick);
			this.ExpandButton.MouseLeave += new System.EventHandler(this.OnMouseLeave);
			this.ExpandButton.MouseHover += new System.EventHandler(this.OnExpandButtonMouseHover);
			// 
			// MenuBar
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(5)))), ((int)(((byte)(16)))));
			this.Controls.Add(this.UserImageBox);
			this.Controls.Add(this.ExpandButton);
			this.Controls.Add(this.MenuButtonListSampleButton);
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "MenuBar";
			this.Size = new System.Drawing.Size(160, 681);
			this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
			this.ResumeLayout(false);

		}

		#endregion
		public CarboUiComponent.Carbobutton ExpandButton;
		public System.Windows.Forms.Button MenuButtonListSampleButton;
		public CarboUiComponent.Carbobutton UserImageBox;
	}
}
