namespace Carbon
{
    partial class HelpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
			this.MenuListSampleButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ContentTextBox = new CarboUiComponent.CarboRichTextbox();
			this.SuspendLayout();
			// 
			// MenuListSampleButton
			// 
			this.MenuListSampleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
			this.MenuListSampleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MenuListSampleButton.Font = new System.Drawing.Font("Century Gothic", 12.75F);
			this.MenuListSampleButton.ForeColor = System.Drawing.Color.DodgerBlue;
			this.MenuListSampleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.MenuListSampleButton.Location = new System.Drawing.Point(0, 0);
			this.MenuListSampleButton.Margin = new System.Windows.Forms.Padding(0);
			this.MenuListSampleButton.MinimumSize = new System.Drawing.Size(0, 60);
			this.MenuListSampleButton.Name = "MenuListSampleButton";
			this.MenuListSampleButton.Size = new System.Drawing.Size(160, 540);
			this.MenuListSampleButton.TabIndex = 8;
			this.MenuListSampleButton.Text = "Menu List";
			this.MenuListSampleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.MenuListSampleButton.UseVisualStyleBackColor = false;
			this.MenuListSampleButton.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(689, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 21);
			this.label1.TabIndex = 12;
			this.label1.Text = "label1";
			// 
			// ContentTextBox
			// 
			this.ContentTextBox.AcceptsTab = true;
			this.ContentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.ContentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ContentTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ContentTextBox.Editable = false;
			this.ContentTextBox.Font = new System.Drawing.Font("Century Gothic", 12.75F);
			this.ContentTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.ContentTextBox.HideSelection = false;
			this.ContentTextBox.ImageSelectable = false;
			this.ContentTextBox.Location = new System.Drawing.Point(175, 16);
			this.ContentTextBox.Name = "ContentTextBox";
			this.ContentTextBox.ReadOnly = true;
			this.ContentTextBox.Size = new System.Drawing.Size(692, 508);
			this.ContentTextBox.TabIndex = 11;
			this.ContentTextBox.Text = "";
			this.ContentTextBox.Watermark = null;
			// 
			// HelpForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(884, 540);
			this.Controls.Add(this.ContentTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MenuListSampleButton);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HelpForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Carbon - Help";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		public System.Windows.Forms.Button MenuListSampleButton;
		public CarboUiComponent.CarboRichTextbox ContentTextBox;
		private System.Windows.Forms.Label label1;
	}
}