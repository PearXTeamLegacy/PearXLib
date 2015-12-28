namespace PearXLib.Engine
{
    partial class XForm
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
            this.SuspendLayout();
            // 
            // XForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XForm";
            this.Text = "XForm";
            this.Load += new System.EventHandler(this.XForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XForm_MouseDown);
            this.MouseLeave += new System.EventHandler(this.XForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.XForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}