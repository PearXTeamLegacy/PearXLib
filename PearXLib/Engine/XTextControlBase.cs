using System.ComponentModel;
using System.Drawing;

namespace PearXLib.Engine
{
    public class XTextControlBase : XControlBase
    {
        private bool shadow;
        private Color c_shadow = Color.Black;
        private short shadow_offset = 2;

        

        /// <summary>
        /// Draw control's shadow?
        /// </summary>
        [DefaultValue(false)]
        public virtual bool Shadow
        {
            get { return shadow; }
            set { shadow = value; Refresh(); }
        }

        /// <summary>
        /// Color of the text's shadow.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color ShadowColor
        {
            get { return c_shadow; }
            set { c_shadow = value; Refresh(); }
        }

        /// <summary>
        /// Shadow's offset.
        /// </summary>
        [DefaultValue(2)]
        public virtual short ShadowOffset
        {
            get { return shadow_offset; }
            set { shadow_offset = value; Refresh(); }
        }

        public void DrawFancyText(Graphics gfx, string text, Font font, Brush brush, PointF location)
        {
            if (Shadow)
            {
                gfx.DrawString(text, font, new SolidBrush(ShadowColor), location.X + ShadowOffset, location.Y + ShadowOffset);
            }
            gfx.DrawString(text, font, brush, location);
        }
    }
}
