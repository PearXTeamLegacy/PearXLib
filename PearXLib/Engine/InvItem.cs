using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A control to display the item.
    /// </summary>
    public partial class InvItem : UserControl
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
            InitializeComponent();
        }

        #region Props
        /// <summary>
        /// Item image.
        /// </summary>
        [Description("Item image."), DefaultValue(null)]
        public Image ItemImage
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
        public string ItemDesc
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
        public int ItemAmount
        {
            get
            {
                return _ItemAmount;
            }
            set
            {
                _ItemAmount = value;
                Refresh();
            }
        }

        /// <summary>
        /// Item name.
        /// </summary>
        [Description("Item name."), DefaultValue("Cake")]
        public string ItemName
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
        public Color ColorName
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
        public Color ColorDesc
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
        public Color ColorAmount
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
        /// A font of an InvItem.
        /// </summary>
        [Description("A font of an InvItem.")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor { get; set; }
        #endregion Props

        private void InvItem_Paint(object sender, PaintEventArgs e)
        {
            if (ItemImage != null)
            {
                e.Graphics.DrawImage(ItemImage, 0, 0, Size.Width / 3, Size.Height);
            }
            e.Graphics.DrawString(ItemName, Font, new SolidBrush(ColorName), Size.Width / 3 , 0);
            e.Graphics.DrawString(ItemDesc, new Font(Font.FontFamily, Font.Size / 1.5F), new SolidBrush(ColorDesc), Size.Width / 3, 0 + e.Graphics.MeasureString(ItemDesc, Font).Height);
            e.Graphics.DrawString(ItemAmount.ToString(), Font, new SolidBrush(ColorAmount), Size.Width / 3, Size.Height - e.Graphics.MeasureString(ItemAmount.ToString(), Font).Height);
        }

        private void InvItem_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
