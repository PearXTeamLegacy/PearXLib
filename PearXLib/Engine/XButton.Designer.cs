namespace PearXLib.Engine
{
    partial class XButton
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.b = new System.Windows.Forms.PictureBox();
            this.labelText = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // b
            // 
            this.b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.b.Image = global::PearXLib.Properties.Resources.XButton;
            this.b.Location = new System.Drawing.Point(0, 0);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(128, 64);
            this.b.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b.TabIndex = 0;
            this.b.TabStop = false;
            this.b.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setToXButtonPressed);
            this.b.MouseEnter += new System.EventHandler(this.setToXButtonFocused);
            this.b.MouseLeave += new System.EventHandler(this.setToXButton);
            this.b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.setToXButtonFocused);
            this.b.Resize += new System.EventHandler(this.b_Resize);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.ForeColor = System.Drawing.Color.Black;
            this.labelText.Location = new System.Drawing.Point(40, 27);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(48, 13);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "A Button";
            this.labelText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setToXButtonPressed);
            this.labelText.MouseEnter += new System.EventHandler(this.setToXButtonFocused);
            this.labelText.MouseLeave += new System.EventHandler(this.setToXButton);
            this.labelText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.setToXButtonFocused);
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(3, 9);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(48, 48);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.image.TabIndex = 2;
            this.image.TabStop = false;
            this.image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setToXButtonPressed);
            this.image.MouseEnter += new System.EventHandler(this.setToXButtonFocused);
            this.image.MouseLeave += new System.EventHandler(this.setToXButton);
            this.image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.setToXButtonFocused);
            // 
            // XButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.image);
            this.Controls.Add(this.b);
            this.Name = "XButton";
            this.Size = new System.Drawing.Size(128, 64);
            this.Load += new System.EventHandler(this.XButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox b;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.PictureBox image;

    }
}
