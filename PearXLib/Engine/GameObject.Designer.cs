namespace PearXLib.Engine
{
    partial class GameObject
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
            // GameObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "GameObject";
            this.ResumeLayout(false);

        }

        #endregion

    }
}
