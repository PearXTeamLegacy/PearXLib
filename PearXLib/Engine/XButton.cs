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
    [DefaultEvent("Click")]
    public partial class XButton : UserControl
    {
        private string _XText = "A Button";
        private Font _XFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
        private Align _XAlignText = Align.CENTER;
        private Align _XAlignImage = Align.LEFT;
        private Image _XImage;

        /// <summary>
        /// Initializes new XButton component.
        /// </summary>
        public XButton()
        {
            InitializeComponent();
            labelText.Parent = b;
            image.Parent = b;
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
            AlignImage();
            AlignText();
        }

        #region Fixed events
        void c_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        void c_MouseHover(object sender, EventArgs e)
        {
            OnMouseHover(e);
        }

        void c_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        void c_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        void c_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        void c_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        void c_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        void c_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        void c_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
        #endregion

        #region Methods
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
            switch(XAlignText)
            {
                case Align.CENTER:
                    labelText.Location = new Point(_bWidth2 - _tWidth2, _bHeight2 - _tHeight2);
                    break;
                case Align.RIGHT:
                    labelText.Location = new Point(_bWidth - _tWidth, _bHeight2 - _tHeight2);
                    break;
                case Align.LEFT:
                    labelText.Location = new Point(0, _bHeight2 - _tHeight2);
                    break;
                case Align.BOTTOM:
                    labelText.Location = new Point(_bWidth2 - _tWidth2, _bHeight - _tHeight);
                    break;
                case Align.TOP:
                    labelText.Location = new Point(_bWidth2 - _tWidth2, 0);
                    break;
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
            switch(XAlignImage)
            {
                case Align.CENTER:
                    image.Location = new Point(_bWidth2 - _iWidth2, _bHeight2 - _iHeight2);
                    break;
                case Align.LEFT:
                    image.Location = new Point(0, _bHeight2 - _iHeight2);
                    break;
                case Align.RIGHT:
                    image.Location = new Point(_bWidth - _iWidth, _bHeight2 - _iHeight2);
                    break;
                case Align.BOTTOM:
                    image.Location = new Point(_bWidth2 - _iWidth2, _bHeight - _iHeight);
                    break;
                case Align.TOP:
                    image.Location = new Point(_bWidth2 - _iWidth2, 0);
                    break;
            }
        }
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
        /// Image on XButton.
        /// </summary>
        [Description("Image on XButton.")]
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

        #region Overriding Props
        /// <summary>
        /// Not working property. Don't use it.
        /// </summary>
        [Browsable(false)]
        public override bool AutoScroll
        {
            get
            {
                return false;
            }
        }
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
        /// <summary>
        /// Not working property. Don't use it.
        /// </summary>
        [Browsable(false)]
        public override Font Font
        {
            get
            {
                return _XFont;
            }
        }
        /// <summary>
        /// Not working property. Don't use it.
        /// </summary>
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return Color.Transparent;
            }
        }
        /// <summary>
        /// Not working property. Don't use it.
        /// </summary>
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return null;
            }
        }
        #endregion

        private void b_Resize(object sender, EventArgs e)
        {
            AlignText();
            AlignImage();
        }
    }
}
