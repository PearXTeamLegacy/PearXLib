using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A control to display the item.
    /// </summary>
    public class InvItem : UserControl
    {
        private Image _ItemImage = null;
        private string _ItemDesc = "Cake - a lie.";
        private int _ItemAmount = 0;
        private string _ItemName = "Cake";
        private Color _ColorName = Color.Red;
        private Color _ColorDesc = Color.Blue;
        private Color _ColorAmount = Color.Green;

        /// <summary>
        /// Initializes new InvItem component.
        /// </summary>
        public InvItem()
        {
            BackColor = Color.Transparent;
            Font = new Font("Microsoft Sans Serif", 15.75F);
            ResizeRedraw = true;
        }

        #region Props
        /// <summary>
        /// Inventory Item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">InvItem event args. <see cref="InvItemEventArgs"/></param>
        public delegate void InvItemEventHandler(object sender, InvItemEventArgs e);

        /// <summary>
        /// Performs on item amount changed.
        /// </summary>
        public event InvItemEventHandler AmountChanged;

        /// <summary>
        /// Item image.
        /// </summary>
        [Description("Item image."), DefaultValue(null)]
        public virtual Image ItemImage
        {
            get
            {
                return _ItemImage;
            }
            set
            {
                _ItemImage = value;
                Refresh();
            }
        }
        
        /// <summary>
        /// Item description.
        /// </summary>
        [Description("Item description."), DefaultValue("Cake - a lie.")]
        public virtual string ItemDesc
        {
            get
            {
                return _ItemDesc;
            }
            set
            {
                _ItemDesc = value;
                Refresh();
            }
        }

        /// <summary>
        /// Item amount.
        /// </summary>
        [Description("Item amount."), DefaultValue(0)]
        public virtual int ItemAmount
        {
            get
            {
                return _ItemAmount;
            }
            set
            {
                _ItemAmount = value;
                Refresh();
                if (AmountChanged != null)
                    AmountChanged(this, new InvItemEventArgs(value));
            }
        }

        /// <summary>
        /// Item name.
        /// </summary>
        [Description("Item name."), DefaultValue("Cake")]
        public virtual string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
                Refresh();
            }
        }

        /// <summary>
        /// Name label color.
        /// </summary>
        [Description("Name label color."), DefaultValue(typeof(Color), "Red")]
        public virtual Color ColorName
        {
            get
            {
                return _ColorName;
            }
            set
            {
                _ColorName = value;
                Refresh();
            }
        }

        /// <summary>
        /// Description label color.
        /// </summary>
        [Description("Description label color."), DefaultValue(typeof(Color), "Blue")]
        public virtual Color ColorDesc
        {
            get
            {
                return _ColorDesc;
            }
            set
            {
                _ColorDesc = value;
                Refresh();
            }
        }

        /// <summary>
        /// Amount label color.
        /// </summary>
        [Description("Amount label color."), DefaultValue(typeof(Color), "Green")]
        public virtual Color ColorAmount
        {
            get
            {
                return _ColorAmount;
            }
            set
            {
                _ColorAmount = value;
                Refresh();
            }
        }

        /// <summary>
        /// Control background color.
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor { get; set; }
        #endregion Props

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ItemImage != null)
            {
                e.Graphics.DrawImage(ItemImage, 0, 0, Size.Width / 3, Size.Height);
            }
            e.Graphics.DrawString(ItemName, Font, new SolidBrush(ColorName), Size.Width / 3, 0);
            e.Graphics.DrawString(ItemDesc, new Font(Font.FontFamily, Font.Size / 1.5F), new SolidBrush(ColorDesc), Size.Width / 3, 0 + e.Graphics.MeasureString(ItemDesc, Font).Height);
            e.Graphics.DrawString(ItemAmount.ToString(), Font, new SolidBrush(ColorAmount), Size.Width / 3, Size.Height - e.Graphics.MeasureString(ItemAmount.ToString(), Font).Height);
        }
    }
}
