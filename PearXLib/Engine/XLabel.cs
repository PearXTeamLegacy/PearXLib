using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful label.
    /// </summary>
    /// <seealso cref="XTextControlBase" />
    public class XLabel : XTextControlBase
    {
        private string text;
        private bool drawinrect;
        /// <summary>
        /// Is control drawn first time?
        /// </summary>
        protected bool FirstDrawn;

        /// <summary>
        /// Initializes a new instance of the <see cref="XLabel"/> class.
        /// </summary>
        public XLabel()
        {
            Paint += ControlPaint;
        }

        #region Params
        /// <summary>
        /// The text on the control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text
        {
            get { return text; }
            set
            {
                text = value;
                AutoResize();
                Invalidate();
            }
        }

        /// <summary>
        /// Draw the text in the rectangle?
        /// </summary>
        [DefaultValue(false)]
        public bool DrawInRectangle
        {
            get { return drawinrect; }
            set
            {
                drawinrect = value;
                AutoResize();
                Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                AutoResize();
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Control's paint event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected void ControlPaint(object sender, PaintEventArgs e)
        {
            if(!FirstDrawn)
                AutoResize();
            if (DrawInRectangle)
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width, Height));
            else
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new Point(0, 0));
            FirstDrawn = true;

        }

        private void AutoResize()
        {
            if (!DrawInRectangle)
            {
                using (var bm = new Bitmap(1, 1))
                {
                    using (var gfx = Graphics.FromImage(bm))
                    {
                        Size s = gfx.MeasureString(Text, Font).ToSize();
                        MinimumSize = s;
                        MaximumSize = s;
                        Size = s;
                    }
                }
            }
        }
    }
}