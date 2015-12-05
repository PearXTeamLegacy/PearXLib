namespace PearXLib.Engine
{
    partial class InvItem
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Dispose all using resources.
        /// </summary>
        /// <param name="disposing">true, if controlled resource should be disposed; else false.</param>
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
            // InvItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "InvItem";
            this.Size = new System.Drawing.Size(270, 90);
            this.SizeChanged += new System.EventHandler(this.InvItem_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InvItem_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
