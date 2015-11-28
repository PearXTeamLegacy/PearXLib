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
    public partial class XIcon : UserControl
    {
        private Image _Icon;
        private bool _PlaySound = true;
        private string _Title = String.Empty;
        private Font _TitleFont = SystemFonts.DefaultFont;
        private int _Expand = 10;
        /// <summary>
        /// Initializes a new XIcon component.
        /// </summary>
        public XIcon() 
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
        }

        #region Properties.
        /// <summary>
        /// Icon image.
        /// </summary>
        [DefaultValue(null), Description("Icon image.")]
        public Image Icon
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
        public bool PlaySound
        {
            get { return _PlaySound; }
            set { _PlaySound = value; }
        }

        /// <summary>
        /// Icon title (will be displayed on the control).
        /// </summary>
        [DefaultValue(""), Description("Icon title (will be displayed on the control).")]
        public string Title
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
        public int Expand
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
        /// Title font.
        /// </summary>
        [Description("Title font.")]
        public override Font Font
        {
            get
            {
                return _TitleFont;
            }
            set
            {
                _TitleFont = value;
                Refresh();
            }
        }
        #endregion

        /// <summary>
        /// Title size and width.
        /// </summary>
        public SizeF TitleWidthHeight
        {
            get { return CreateGraphics().MeasureString(Title, Font); }
        }

        private void XIcon_MouseEnter(object sender, EventArgs e)
        {
            Size = new Size(Size.Width + (Expand * 2), Size.Height + (Expand * 2));
            Location = new Point(Location.X - Expand, Location.Y - Expand);
            BringToFront();
            if (PlaySound)
            {
                SoundPlayer sp = new SoundPlayer(Resources.bd);
                sp.Play();
            }
        }

        private void XIcon_MouseLeave(object sender, EventArgs e)
        {
            Size = new Size(Size.Width - (Expand * 2), Size.Height - (Expand * 2));
            Location = new Point(Location.X + Expand, Location.Y + Expand);
        }

        private void XIcon_Paint(object sender, PaintEventArgs e)
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
    }
}
