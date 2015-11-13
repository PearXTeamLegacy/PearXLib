using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
        private Font _Font = new Font("Microsoft Sans MS", 8F, FontStyle.Regular);
        /// <summary>
        /// Initializes new InvItem component.
        /// </summary>
        public InvItem()
        {
            InitializeComponent();
            foreach (Control c in Controls)
            {
                c.Click += c_Click;
                c.DoubleClick += c_DoubleClick;
                c.MouseEnter += c_MouseEnter;
                c.MouseLeave += c_MouseLeave;
                c.MouseDoubleClick += c_MouseDoubleClick;
                c.MouseDown += c_MouseDown;
                c.MouseUp += c_MouseUp;
                c.MouseHover += c_MouseHover;
                c.MouseMove += c_MouseMove;
            }
        }

        #region Fixed events.
        private void c_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        private void c_MouseHover(object sender, EventArgs e)
        {
            OnMouseHover(e);
        }

        private void c_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private void c_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void c_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        private void c_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void c_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void c_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void c_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
        #endregion

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
                imageImg.Image = _ItemImage;
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
                labelDesc.Text = value;
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
                labelAmount.Text = _ItemAmount.ToString();
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
                labelName.Text = _ItemName;
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
                labelName.ForeColor = _ColorName;
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
                labelDesc.ForeColor = _ColorDesc;
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
                labelAmount.ForeColor = _ColorAmount;
            }
        }

        /// <summary>
        /// Control font.
        /// </summary>
       [Description("Control font.")]
        public override Font Font
        {
            get
            {
                return _Font;
            }
            set
            {
                _Font = value;
                labelAmount.Font = new Font(_Font.FontFamily, labelAmount.Font.Size, _Font.Style);
            }
        }
        #endregion Props

        #region Overriding props
        /// <summary>
        /// Not working property. Don't use it.
        /// </summary>
        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return Color.Transparent;
            }
        }
        #endregion
    }
}
