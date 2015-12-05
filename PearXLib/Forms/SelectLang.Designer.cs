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
            this.listBoxLangs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLangs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxLangs.FormattingEnabled = true;
            this.listBoxLangs.ItemHeight = 24;
            this.listBoxLangs.Location = new System.Drawing.Point(0, 0);
            this.listBoxLangs.Name = "listBoxLangs";
            this.listBoxLangs.Size = new System.Drawing.Size(336, 318);
            this.listBoxLangs.TabIndex = 0;
            this.listBoxLangs.SelectedIndexChanged += new System.EventHandler(this.listBoxLangs_SelectedIndexChanged);
            // 
            // SelectLang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 318);
            this.Controls.Add(this.listBoxLangs);
            this.Name = "SelectLang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectLang_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLangs;
    }
}