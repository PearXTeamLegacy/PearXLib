using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    public class XLabel : XTextControlBase
    {
        private string text;
        private bool drawinrect;
        protected bool AlreadyDrawed;

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
                Refresh();
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
                Refresh();
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(AlreadyDrawed == false)
                AutoResize();
            if (DrawInRectangle)
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width, Height));
            else
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new Point(0, 0));
            AlreadyDrawed = true;

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