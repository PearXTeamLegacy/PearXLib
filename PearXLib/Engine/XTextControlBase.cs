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
        [DefaultValue(typeof(short), "2")]
        public virtual short ShadowOffset
        {
            get { return shadow_offset; }
            set { shadow_offset = value; Refresh(); }
        }

        /// <summary>
        /// Draws a fancy text with shadow.
        /// </summary>
        /// <param name="gfx">Your graphics.</param>
        /// <param name="location">Location of the text.</param>
        public void DrawFancyText(Graphics gfx, string text, Font font, Brush brush, PointF location)
        {
            if (Shadow)
            {
                gfx.DrawString(text, font, new SolidBrush(ShadowColor), location.X + ShadowOffset, location.Y + ShadowOffset);
            }
            gfx.DrawString(text, font, brush, location);
        }

        /// <summary>
        /// Draws a fancy text with shadow.
        /// </summary>
        /// <param name="gfx">Your graphics.</param>
        /// <param name="rect">A text's rectangle.</param>
        public void DrawFancyText(Graphics gfx, string text, Font font, Brush brush, Rectangle rect)
        {
            if (Shadow)
            {
                Rectangle shadowRect = rect;
                shadowRect.X += ShadowOffset;
                shadowRect.Y += ShadowOffset;
                gfx.DrawString(text, font, new SolidBrush(ShadowColor), shadowRect);
            }
            gfx.DrawString(text, font, brush, rect);
        }

        /// <summary>
        /// Draws a fancy text with shadow.
        /// </summary>
        /// <param name="gfx">Your graphics.</param>
        public static void DrawFancyText(Graphics gfx, string text, Font font, Brush brush, PointF location, Color shadowcolor, bool shadow = false, short shadowoffset = 2)
        {
            if (shadow)
            {
                gfx.DrawString(text, font, new SolidBrush(shadowcolor), location.X + shadowoffset, location.Y + shadowoffset);
            }
            gfx.DrawString(text, font, brush, location);
        }

        /// <summary>
        /// Draws a fancy text with shadow.
        /// </summary>
        /// <param name="gfx">Your graphics.</param>
        /// <param name="rect">A text's rectangle.</param>
        public static void DrawFancyText(Graphics gfx, string text, Font font, Brush brush, Rectangle rect, Color shadowcolor, bool shadow = false, short shadowoffset = 2)
        {
            if (shadow)
            {
                Rectangle shadowRect = rect;
                shadowRect.X += shadowoffset;
                shadowRect.Y += shadowoffset;
                gfx.DrawString(text, font, new SolidBrush(shadowcolor), shadowRect);
            }
            gfx.DrawString(text, font, brush, rect);
        }
    }
}
