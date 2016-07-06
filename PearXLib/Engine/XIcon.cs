using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace PearXLib.Engine
{
    /// <summary>
    /// An expanding icon from PearX Engine.
    /// </summary>
    [DefaultEvent("Click")]
    public class XIcon : XControlBase
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
                Invalidate();
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
                Invalidate();
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

        protected override void OnMouseEnter(EventArgs e)
        {
            mouseIn = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mouseIn = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Control's paint event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected void ControlPaint(object sender, PaintEventArgs e)
        {
            Brush b = new SolidBrush(ForeColor);
            SizeF strWH = e.Graphics.MeasureString(Title, Font);
            bool text = !string.IsNullOrEmpty(Title);
            bool icon = Icon != null;
            float x = 0, y = 0, width = 0, height = 0;
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
                e.Graphics.DrawString(Title, Font, b, textX, textY);
        }
    }
}
