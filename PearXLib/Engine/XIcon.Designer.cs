namespace PearXLib.Engine
{
    partial class XIcon
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
            this.SuspendLayout();
            // 
            // XIcon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "XIcon";
            this.Size = new System.Drawing.Size(64, 64);
            this.SizeChanged += new System.EventHandler(this.XIcon_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XIcon_Paint);
            this.MouseEnter += new System.EventHandler(this.XIcon_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.XIcon_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
