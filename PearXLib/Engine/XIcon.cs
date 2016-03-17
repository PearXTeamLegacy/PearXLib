using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using PearXLib.Properties;

namespace PearXLib.Engine
{
    /// <summary>
    /// An expanding icon from PearX Engine.
    /// </summary>
    public class XIcon : UserControl
    {
        private Image _Icon;
        private bool _PlaySound = true;
        private string _Title = String.Empty;
        private int _Expand = 10;

        /// <summary>
        /// Initializes a new XIcon component.
        /// </summary>
        public XIcon() 
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            Size = new Size(64, 64);
        }

        #region Params
        /// <summary>
        /// Icon image.
        /// </summary>
        [DefaultValue(null), Description("Icon image.")]
        public virtual Image Icon
        {
            get { return _Icon; }
            set
            {
                _Icon = value;
                Refresh();
            }
        }

        /// <summary>
        /// Play sound, when mouse focused on this component?
        /// </summary>
        [DefaultValue(true), Description("Play sound, when mouse focused on this component?")]
        public virtual bool PlaySound
        {
            get { return _PlaySound; }
            set { _PlaySound = value; }
        }

        /// <summary>
        /// Icon title (will be displayed on the control).
        /// </summary>
        [DefaultValue(""), Description("Icon title (will be displayed on the control).")]
        public virtual string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                Refresh();
            }
        }

        /// <summary>
        /// How much to expand on mouse enter?
        /// </summary>
        [Description("How much to expand on mouse enter?"), DefaultValue(10)]
        public virtual int Expand
        {
            get
            {
                return _Expand;
            }
            set
            {
                _Expand = value;
            }
        }

        /// <summary>
        /// A font of a title text.
        /// </summary>
        [Description("A font of a title text.")]
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
        /// A cursor for a control.
        /// </summary>
        [DefaultValue(typeof(Cursor), "Hand")]
        public override Cursor Cursor { get; set; }

        /// <summary>
        /// Control background color.
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor { get; set; }
        #endregion

        /// <summary>
        /// Title size and width.
        /// </summary>
        public SizeF TitleWidthHeight
        {
            get { return CreateGraphics().MeasureString(Title, Font); }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Size = new Size(Size.Width + (Expand * 2), Size.Height + (Expand * 2));
            Location = new Point(Location.X - Expand, Location.Y - Expand);
            BringToFront();
            if (PlaySound)
            {
                using (SoundPlayer sp = new SoundPlayer(Resources.bd))
                {
                    sp.Play();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Size = new Size(Size.Width - (Expand * 2), Size.Height - (Expand * 2));
            Location = new Point(Location.X + Expand, Location.Y + Expand);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Icon != null)
            {
                Size s = Size;
                if (!String.IsNullOrEmpty(Title))
                {
                    Brush b = new SolidBrush(ForeColor);
                    SizeF strWH = e.Graphics.MeasureString(Title, Font);
                    e.Graphics.DrawImage(Icon, 0, 0, s.Width, s.Height - strWH.Height);
                    e.Graphics.DrawString(Title, Font, b, (s.Width - strWH.Width) / 2, s.Height - strWH.Height);
                }
                else
                {
                    e.Graphics.DrawImage(Icon, 0, 0, s.Width, s.Height);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Refresh();
        }
    }
}
