namespace DontDeleteThisStefan
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
        protected override void Dispose(bool disposing)
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
			this.LabelContent = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LabelContent
			// 
			this.LabelContent.AutoSize = true;
			this.LabelContent.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelContent.ForeColor = System.Drawing.Color.White;
			this.LabelContent.Location = new System.Drawing.Point(-6, -1);
			this.LabelContent.Margin = new System.Windows.Forms.Padding(10);
			this.LabelContent.Name = "LabelContent";
			this.LabelContent.Padding = new System.Windows.Forms.Padding(10);
			this.LabelContent.Size = new System.Drawing.Size(621, 503);
			this.LabelContent.TabIndex = 0;
			this.LabelContent.Text = resources.GetString("LabelContent.Text");
			// 
			// FormHelp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(634, 511);
			this.Controls.Add(this.LabelContent);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormHelp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Carbon - Help";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label LabelContent;
	}
}