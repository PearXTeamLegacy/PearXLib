using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PearXLib.Properties;

namespace PearXLib.Engine
{
    /// <summary>
    /// A fancy button from PearX Engine.
    /// </summary>
    [DefaultEvent("Clicked")]
    public partial class XButton : UserControl
    {
        private string _XText = "A Button";
        private Font _XFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
        private Align _XAlignText = Align.CENTER;
        private Align _XAlignImage = Align.LEFT;
        private Image _XImage;

        public XButton()
        {
            InitializeComponent();
            labelText.Parent = b;
            image.Parent = b;
        }

        void AlignText()
        {
            int _bWidth2 = b.Size.Width / 2;
            int _tWidth2 = labelText.Size.Width / 2;
            int _tHeight2 = labelText.Size.Height / 2;
            int _bHeight2 = b.Size.Height / 2;
            int _bWidth = b.Size.Width;
            int _tWidth = labelText.Size.Width;
            int _bHeight = b.Size.Height;
            int _tHeight = labelText.Size.Height;

            if (XAlignText == Align.CENTER)
            {
                labelText.Location = new Point(_bWidth2 - _tWidth2, _bHeight2 - _tHeight2);
            }
            else if (XAlignText == Align.RIGHT)
            {
                labelText.Location = new Point(_bWidth - _tWidth, _bHeight2 - _tHeight2);
            }
            else if (XAlignText == Align.LEFT)
            {
                labelText.Location = new Point(0, _bHeight2 - _tHeight2);
            }
            else if (XAlignText == Align.TOP)
            {
                labelText.Location = new Point(_bWidth2 - _tWidth2, 0);
            }
            else if (XAlignText == Align.BOTTOM)
            {
                labelText.Location = new Point(_bWidth2 - _tWidth2, _bHeight - _tHeight);
            }
        }
        void AlignImage()
        {
            int _bWidth2 = b.Size.Width / 2;
            int _iWidth2 = image.Size.Width / 2;
            int _iHeight2 = image.Size.Height / 2;
            int _bHeight2 = b.Size.Height / 2;
            int _bWidth = b.Size.Width;
            int _iWidth = image.Size.Width;
            int _bHeight = b.Size.Height;
            int _iHeight = image.Size.Height;
            if (XAlignImage == Align.CENTER)
            {
                image.Location = new Point(_bWidth2 - _iWidth2, _bHeight2 - _iHeight2);
            }
            else if (XAlignImage == Align.LEFT)
            {
                image.Location = new Point(0, _bHeight2 - _iHeight2);
            }
            else if (XAlignImage == Align.RIGHT)
            {
                image.Location = new Point(_bWidth - _iWidth, _bHeight2 - _iHeight2);
            }
            else if (XAlignImage == Align.TOP)
            {
                image.Location = new Point(_bWidth2 - _iWidth2, 0);
            }
            else if (XAlignImage == Align.BOTTOM)
            {
                image.Location = new Point(_bWidth2 - _iWidth2, _bHeight - _iHeight);
            }
        }

        #region Params

        /// <summary>
        /// Button's Align.
        /// </summary>
        [Description("Button's Align.")]
        public Align XAlignText
        {
            get { return _XAlignText; }
            set
            {
                _XAlignText = value;
                AlignText();
            }
        }

        /// <summary>
        /// Image's Align.
        /// </summary>
        [Description("Image's Align.")]
        public Align XAlignImage
        {
            get { return _XAlignImage; }
            set
            {
                _XAlignImage = value;
                AlignImage();
            }
        }
        /// <summary>
        /// Text on Button.
        /// </summary>
        [Description("Text on Button.")]
        public string XText
        {
            get { return _XText; }
            set
            {
                _XText = value;
                labelText.Text = _XText;
                AlignText();
            }
        }
        /// <summary>
        /// Button's Font.
        /// </summary>
        [Description("Button's Font.")]
        public Font XFont 
        {
            get { return _XFont; }
            set
            {
                _XFont = value;
                labelText.Font = XFont;
                AlignText();
            }
        }
        /// <summary>
        /// Button Click Event.
        /// </summary>
        [Description("Click Event.")]
        public event EventHandler Clicked
        {
            add { b.Click += value; labelText.Click += value; image.Click += value; }
            remove { b.Click -= value; labelText.Click -= value; image.Click -= value; }
        }

        public Image XImage
        {
            get { return _XImage; }
            set
            {
                _XImage = value;
                image.Image = XImage;
                AlignImage();
            }
        }

        #endregion

        #region Button's Background Functions
        void setToXButton(object sender, EventArgs e)
        {
            b.Image = Resources.XButton;
        }

        void setToXButtonFocused(object sender, EventArgs e)
        {
            b.Image = Resources.XButtonFocused;
        }

        void setToXButtonPressed(object sender, EventArgs e)
        {
            b.Image = Resources.XButtonPressed;
        }

        #endregion

        private void b_Resize(object sender, EventArgs e)
        {
            AlignText();
            AlignImage();
        }

        #region Overriding Props
        [Browsable(false)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }
        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }
        [Browsable(false)]
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
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }
        #endregion

        private void XButton_Load(object sender, EventArgs e)
        {
            AlignImage();
            AlignText();
        }
    }
}
