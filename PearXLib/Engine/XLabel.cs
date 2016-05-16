using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    public class XLabel : XTextControlBase
    {
        private string text;
        private bool drawinrect;

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
                Size s = TextRenderer.MeasureText(Text, Font);
                if (!DrawInRectangle)
                {
                    MinimumSize = s;
                    MaximumSize = s;
                    Size = s;
                }
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
                Size s = TextRenderer.MeasureText(Text, Font);
                if (!DrawInRectangle)
                {
                    MinimumSize = s;
                    MaximumSize = s;
                    Size = s;
                }
                Refresh();
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Size s = TextRenderer.MeasureText(Text, Font);
            if (!DrawInRectangle)
            {
                MinimumSize = s;
                MaximumSize = s;
                Size = s;
            }
            if (DrawInRectangle)
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width, Height));
            else
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new Point(0, 0));

        }
    }
}
