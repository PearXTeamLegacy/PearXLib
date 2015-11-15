using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful button from PearX Engine.
    /// </summary>
    public partial class XButton : UserControl
    {
        private enum State {PRESSED, FOCUSED, NONE};

        private State state = State.NONE;

        private Color _GradientColor1 = Color.FromArgb(102, 204, 0);
        private Color _GradientColor2 = Color.White;
        private Color _GradientColorFocused1 = Color.FromArgb(132, 234, 0);
        private Color _GradientColorFocused2 = Color.White;
        private Color _ColorPressed = Color.FromArgb(102, 204, 0);
        private string _ButtonText = "A button.";
        private Image _Image = null;
        private Align _ButtonTextAlign = Align.CENTER;
        private Align _ImageAlign = Align.LEFT;
        private Color _ButtonTextColor = Color.Black;

        /// <summary>
        /// Initializes a new XButton component.
        /// </summary>
        public XButton()
        {
            InitializeComponent();
        }

        #region Properties.
        /// <summary>
        /// A button gradient color 1. 
        /// </summary>
        [Description("A button gradient color 1."), DefaultValue(typeof(Color), "102, 204, 0")]
        public Color GradientColor1
        {
            get { return _GradientColor1; }
            set { _GradientColor1 = value; Refresh(); }
        }

        /// <summary>
        /// A button gradient color 2.
        /// </summary>
        [Description("A button gradient color 2."), DefaultValue(typeof(Color), "White")]
        public Color GradientColor2
        {
            get { return _GradientColor2; }
            set { _GradientColor2 = value; Refresh(); }
        }

        /// <summary>
        /// A text on a button.
        /// </summary>
        [Description("A text on a button."), DefaultValue("A button.")]
        public string ButtonText
        {
            get { return _ButtonText; }
            set { _ButtonText = value; Refresh(); }
        }

        /// <summary>
        /// An image on a button
        /// </summary>
        [Description("An image on a button"), DefaultValue(null)]
        public Image Image
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
        public Align ImageAlign
        {
            get { return _ImageAlign; }
            set { _ImageAlign = value; Refresh(); }
        }

        /// <summary>
        /// A focused button gradient color 1.
        /// </summary>
        [Description("A focused button gradient color 1."), DefaultValue(typeof(Color), "132, 234, 0")]
        public Color GradientColorFocused1
        {
            get { return _GradientColorFocused1; }
            set { _GradientColorFocused1 = value; Refresh(); }
        }

        /// <summary>
        /// A focused button gradient color 2.
        /// </summary>
        [Description("A focused button gradient color 2."), DefaultValue(typeof(Color), "White")]
        public Color GradientColorFocused2
        {
            get { return _GradientColorFocused2; }
            set { _GradientColorFocused2 = value; Refresh(); }
        }

        /// <summary>
        /// A color of a pressed button.
        /// </summary>
        [Description("A color of a pressed button."), DefaultValue(typeof(Color), "102, 204, 0")]
        public Color ColorPressed
        {
            get { return _ColorPressed; }
            set { _ColorPressed = value; Refresh(); }
        }

        /// <summary>
        /// A color of a text on a button.
        /// </summary>
        [Description("A color of a text on a button."), DefaultValue(typeof(Color), "Black")]
        public Color ButtonTextColor
        {
            get { return _ButtonTextColor; }
            set { _ButtonTextColor = value; Refresh(); }
        }
        #endregion

        private void XButton_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Brushes.Black, 3);
            p.LineJoin = LineJoin.Bevel;
            e.Graphics.DrawRectangle(p, 3, 3, Size.Width - 6, Size.Height - 6);
            Rectangle rectBG = new Rectangle(4, 4, Size.Width - 7, Size.Height - 7);
            switch (state)
            {
                case State.NONE:
                    LinearGradientBrush lgb1 = new LinearGradientBrush(new PointF(0, 0), new PointF(Size.Width, Size.Height), GradientColor1, GradientColor2);
                    e.Graphics.FillRectangle(lgb1, rectBG);
                    break;
                case State.FOCUSED:
                    LinearGradientBrush lgb2 = new LinearGradientBrush(new PointF(0, 0), new PointF(Size.Width, Size.Height), GradientColorFocused1, GradientColorFocused2);
                    e.Graphics.FillRectangle(lgb2, rectBG);
                    break;
                case State.PRESSED:
                    Brush b = new SolidBrush(ColorPressed);
                    e.Graphics.FillRectangle(b, rectBG);
                    break;

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

        private void XButton_MouseEnter(object sender, EventArgs e)
        {
            state = State.FOCUSED;
            Refresh();
        }

        private void XButton_MouseLeave(object sender, EventArgs e)
        {
            state = State.NONE;
            Refresh();
        }

        private void XButton_MouseDown(object sender, MouseEventArgs e)
        {
            state = State.PRESSED;
            Refresh();
        }

        private void XButton_MouseUp(object sender, MouseEventArgs e)
        {
            state = State.FOCUSED;
            Refresh();
        }
    }
}
