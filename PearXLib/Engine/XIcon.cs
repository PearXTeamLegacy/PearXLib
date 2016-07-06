using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;


namespace PearXLib.Engine
{
    /// <summary>
    /// An expanding icon from PearX Engine.
    /// </summary>
    [DefaultEvent("Click")]
    public class XIcon : XTextControlBase
    {
        private bool mouseIn;
        private Image _Icon;
        private string _Title = "";

        /// <summary>
        /// Initializes a new XIcon component.
        /// </summary>
        public XIcon()
        {
            Size = new Size(64, 64);
            Paint += ControlPaint;
            MouseEnter += ControlMouseEnter;
            MouseLeave += ControlMouseLeave;
        }

        #region Params

        [DefaultValue(typeof (Cursor), "Hand")]
        public override Cursor Cursor { get; set; } = Cursors.Hand;

        /// <summary>
        /// Icon image.
        /// </summary>
        [DefaultValue(null)]
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
        /// Icon title (will be displayed on the control).
        /// </summary>
        [DefaultValue("")]
        public virtual string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Refresh();
            }
        }

        /// <summary>
        /// How much to expand on mouse enter?
        /// </summary>
        [DefaultValue(10)]
        public virtual int Expand { get; set; } = 10;

        #endregion

        /// <summary>
        /// Title size and width.
        /// </summary>
        public SizeF TitleWidthHeight => CreateGraphics().MeasureString(Title, Font);

        private void ControlMouseEnter(object sender, EventArgs e)
        {
            mouseIn = true;
            Refresh();
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            mouseIn = false;
            Refresh();
        }

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            Brush b = new SolidBrush(ForeColor);
            SizeF strWH = e.Graphics.MeasureString(Title, Font);
            bool text = !string.IsNullOrEmpty(Title);
            bool icon = Icon != null;
            float x = 0, y = 0, width, height;
            float textX = 0, textY = 0;
            if (!mouseIn)
            {
                x = Expand;
                y = Expand;
                width = Width - Expand*2;
                if (text)
                {
                    height = Height - Expand*2 - strWH.Height;
                    textX = (Width - strWH.Width)/2;
                    textY = Height - strWH.Height;
                }
                else
                    height = Height - Expand*2;
            }
            else
            {
                if (text)
                {
                    width = Width;
                    height = Height - strWH.Height;
                    textX = (Width - strWH.Width)/2;
                    textY = Height - strWH.Height;
                }
                else
                {
                    width = Width;
                    height = Height;
                }
            }
            if (icon)
                e.Graphics.DrawImage(Icon, x, y, width, height);
            if(text)
                DrawFancyText(e.Graphics, Title, Font, b, new PointF(textX, textY));
        }
    }
}
