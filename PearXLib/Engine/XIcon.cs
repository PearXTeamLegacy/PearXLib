using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace PearXLib.Engine
{
    /// <summary>
    /// An expanding icon from PearX Engine.
    /// </summary>
    public class XIcon : UserControl
    {
        private Image _Icon;
        private string _Title = "";

        /// <summary>
        /// Initializes a new XIcon component.
        /// </summary>
        public XIcon() 
        {
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            Size = new Size(64, 64);
            Expand = 10;
            Cursor = Cursors.Hand;
        }

        #region Params
        /// <summary>
        /// Icon image.
        /// </summary>
        [DefaultValue(null)]
        public virtual Image Icon
        {
            get { return _Icon; }
            set { _Icon = value; Refresh(); }
        }

        /// <summary>
        /// Icon title (will be displayed on the control).
        /// </summary>
        [DefaultValue("")]
        public virtual string Title
        {
            get { return _Title; }
            set { _Title = value; Refresh(); }
        }

        /// <summary>
        /// How much to expand on mouse enter?
        /// </summary>
        [DefaultValue(10)]
        public virtual int Expand { get; set; }
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
                if (!string.IsNullOrEmpty(Title))
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
