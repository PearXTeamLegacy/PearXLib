namespace PearXLib.Forms
{
    partial class SelectLang
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
            this.listBoxLangs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxLangs
            // 
            this.listBoxLangs.FormattingEnabled = true;
            this.listBoxLangs.Location = new System.Drawing.Point(0, 0);
            this.listBoxLangs.Name = "listBoxLangs";
            this.listBoxLangs.Size = new System.Drawing.Size(286, 264);
            this.listBoxLangs.TabIndex = 0;
            this.listBoxLangs.SelectedIndexChanged += new System.EventHandler(this.listBoxLangs_SelectedIndexChanged);
            // 
            // SelectLang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.listBoxLangs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SelectLang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectLang_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLangs;
    }
}