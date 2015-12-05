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
            this.SuspendLayout();
            // 
            // XButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Name = "XButton";
            this.Size = new System.Drawing.Size(128, 64);
            this.SizeChanged += new System.EventHandler(this.XButton_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XButton_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.XButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.XButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
