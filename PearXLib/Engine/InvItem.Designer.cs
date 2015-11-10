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
            this.imageImg = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageImg)).BeginInit();
            this.SuspendLayout();
            // 
            // imageImg
            // 
            this.imageImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageImg.BackColor = System.Drawing.Color.Transparent;
            this.imageImg.Location = new System.Drawing.Point(0, 0);
            this.imageImg.Name = "imageImg";
            this.imageImg.Size = new System.Drawing.Size(96, 96);
            this.imageImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageImg.TabIndex = 0;
            this.imageImg.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.Red;
            this.labelName.Location = new System.Drawing.Point(102, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(62, 25);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Cake";
            // 
            // labelDesc
            // 
            this.labelDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDesc.AutoSize = true;
            this.labelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDesc.ForeColor = System.Drawing.Color.Blue;
            this.labelDesc.Location = new System.Drawing.Point(104, 25);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(86, 18);
            this.labelDesc.TabIndex = 2;
            this.labelDesc.Text = "Cake - a lie.";
            // 
            // labelAmount
            // 
            this.labelAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAmount.ForeColor = System.Drawing.Color.Green;
            this.labelAmount.Location = new System.Drawing.Point(102, 71);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(24, 25);
            this.labelAmount.TabIndex = 3;
            this.labelAmount.Text = "0";
            // 
            // InvItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.imageImg);
            this.Name = "InvItem";
            this.Size = new System.Drawing.Size(320, 96);
            ((System.ComponentModel.ISupportInitialize)(this.imageImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageImg;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label labelAmount;
    }
}
