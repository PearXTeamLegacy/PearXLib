using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful button from PearX Engine.
    /// </summary>
    [DefaultEvent("Click")]
    public partial class XImgButton : UserControl
    {
        private enum State {PRESSED, FOCUSED, NONE};

        private State state = State.NONE;

        private Image _BackImage = null;
        private Image _BackImageFocused = null;
        private Image _BackImagePressed = null;
        private string _ButtonText = "A button.";
        private Image _Image = null;
        private Align _ButtonTextAlign = Align.CENTER;
        private Align _ImageAlign = Align.LEFT;
        private Color _ButtonTextColor = Color.Black;

        /// <summary>
        /// Initializes a new XImgButton component.
        /// </summary>
        public XImgButton()
        {
            InitializeComponent();
        }

        #region Properties.

        /// <summary>
        /// A text on a button.
        /// </summary>
        [Description("A text on a button."), DefaultValue("A button.")]
        public virtual string ButtonText
        {
            get { return _ButtonText; }
            set { _ButtonText = value; Refresh(); }
        }

        /// <summary>
        /// An image on a button
        /// </summary>
        [Description("An image on a button"), DefaultValue(null)]
        public virtual Image Image
        {
            get { return _Image; }
            set { _Image = value; Refresh(); }
        }

        /// <summary>
        /// Text align on a button.
        /// </summary>
        [Description("Text align on a button."), DefaultValue(Align.CENTER)]
        public Align ButtonTextAlign
        {
            get { return _ButtonTextAlign; }
            set { _ButtonTextAlign = value; Refresh(); }
        }

        /// <summary>
        /// Image align on a button.
        /// </summary>
        [Description("Image align on a button."), DefaultValue(Align.LEFT)]
        public virtual Align ImageAlign
        {
            get { return _ImageAlign; }
            set { _ImageAlign = value; Refresh(); }
        }

        /// <summary>
        /// A color of a text on a button.
        /// </summary>
        [Description("A color of a text on a button."), DefaultValue(typeof(Color), "Black")]
        public virtual Color ButtonTextColor
        {
            get { return _ButtonTextColor; }
            set { _ButtonTextColor = value; Refresh(); }
        }

        /// <summary>
        /// Control font.
        /// </summary>
        [Description("Control font.")]
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

        /// <summary>
        /// Button background.
        /// </summary>
        [Description("Button background.")]
        public virtual Image BackImage
        {
            get { return _BackImage; }
            set { _BackImage = value; Refresh(); }
        }

        /// <summary>
        /// Focused button background.
        /// </summary>
        [Description("Focused button background.")]
        public virtual Image BackImageFocused
        {
            get { return _BackImageFocused; }
            set { _BackImageFocused = value; Refresh(); }
        }

        /// <summary>
        /// Pressed button background.
        /// </summary>
        [Description("Pressed button background.")]
        public virtual Image BackImagePressed
        {
            get { return _BackImagePressed; }
            set { _BackImagePressed = value; Refresh(); }
        }

        [DefaultValue(typeof(Cursor), "Hand")]
        public override Cursor Cursor { get; set; }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor { get; set; }
        #endregion

        private void XImgButton_Paint(object sender, PaintEventArgs e)
        {
            if (BackImage != null && BackImageFocused != null && BackImagePressed != null)
            {
                switch (state)
                {
                    case State.NONE:
                        e.Graphics.DrawImage(BackImage, 0, 0, Size.Width, Size.Height);
                        break;
                    case State.FOCUSED:
                        e.Graphics.DrawImage(BackImageFocused, 0, 0, Size.Width, Size.Height);
                        break;
                    case State.PRESSED:
                        e.Graphics.DrawImage(BackImagePressed, 0, 0, Size.Width, Size.Height);
                        break;

                }
            }
            if(Image != null)
            {
                int imgSizeW = Image.Size.Width;
                int imgSizeH = Image.Size.Height;
                switch(ImageAlign)
                {
                    case Align.CENTER:
                        e.Graphics.DrawImage(Image, (Size.Width - imgSizeW) / 2, (Size.Height - imgSizeH) / 2);
                        break;
                    case Align.LEFT:
                        e.Graphics.DrawImage(Image, 4, (Size.Height - imgSizeH) / 2);
                        break;
                    case Align.RIGHT:
                        e.Graphics.DrawImage(Image, (Size.Width - imgSizeW) - 3, (Size.Height - imgSizeH) / 2);
                        break;
                    case Align.TOP:
                        e.Graphics.DrawImage(Image, (Size.Width - imgSizeW) / 2, 4);
                        break;
                    case Align.BOTTOM:
                        e.Graphics.DrawImage(Image, (Size.Width - imgSizeW) / 2, Size.Height - (imgSizeH + 3));
                        break;
                }
            }
            if (!String.IsNullOrEmpty(ButtonText))
            {
                Brush sb = new SolidBrush(ButtonTextColor);
                int textSizeW = (int)e.Graphics.MeasureString(ButtonText, Font).Width;
                int textSizeH = (int)e.Graphics.MeasureString(ButtonText, Font).Height;
                switch(ButtonTextAlign)
                {
                    case Align.CENTER:
                        e.Graphics.DrawString(ButtonText, Font, sb, (Size.Width - textSizeW) / 2, (Size.Height - textSizeH) / 2);
                        break;
                    case Align.LEFT:
                        e.Graphics.DrawString(ButtonText, Font, sb, 4, (Size.Height - textSizeH) / 2);
                        break;
                    case Align.RIGHT:
                        e.Graphics.DrawString(ButtonText, Font, sb, (Size.Width - textSizeW) - 3, (Size.Height - textSizeH) / 2);
                        break;
                    case Align.TOP:
                        e.Graphics.DrawString(ButtonText, Font, sb, (Size.Width - textSizeW) / 2, 4);
                        break;
                    case Align.BOTTOM:
                        e.Graphics.DrawString(ButtonText, Font, sb, (Size.Width - textSizeW) / 2, Size.Height - (textSizeH + 3));
                        break;
                }
            }
        }

        private void XImgButton_MouseEnter(object sender, EventArgs e)
        {
            state = State.FOCUSED;
            Refresh();
        }

        private void XImgButton_MouseLeave(object sender, EventArgs e)
        {
            state = State.NONE;
            Refresh();
        }

        private void XImgButton_MouseDown(object sender, MouseEventArgs e)
        {
            state = State.PRESSED;
            Refresh();
        }

        private void XImgButton_MouseUp(object sender, MouseEventArgs e)
        {
            state = State.FOCUSED;
            Refresh();
        }

        private void XImgButton_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
