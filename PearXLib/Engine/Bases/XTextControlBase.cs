using System.ComponentModel;
using System.Drawing;

namespace PearXLib.Engine.Bases
{
    /// <summary>
    /// Base for all PearXLib's text controls.
    /// </summary>
    /// <seealso cref="XControlBase" />
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
            set { shadow = value; Invalidate(); }
        }

        /// <summary>
        /// Color of the text's shadow.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        public virtual Color ShadowColor
        {
            get { return c_shadow; }
            set { c_shadow = value; Invalidate(); }
        }

        /// <summary>
        /// Shadow's offset.
        /// </summary>
        [DefaultValue(typeof(short), "2")]
        public virtual short ShadowOffset
        {
            get { return shadow_offset; }
            set { shadow_offset = value; Invalidate(); }
        }

        /// <summary>
        /// Draws a fancy text with shadow.
        /// </summary>
        /// <param name="gfx">Your graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="location">Location of the text.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
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
        /// <param name="brush">The brush.</param>
        /// <param name="rect">A text's rectangle.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
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
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="location">The text's location.</param>
        /// <param name="shadow">Draw shadow?</param>
        /// <param name="shadowcolor">The shadow's color.</param>
        /// <param name="shadowoffset">The shadow's offset.</param>
        public static void DrawFancyText(Graphics gfx, string text, Font font, Brush brush, PointF location, bool shadow = false, Color ? shadowcolor = null, short shadowoffset = 2)
        {
            if (shadowcolor == null)
                shadowcolor = Color.Black;
            if (shadow)
            {
                gfx.DrawString(text, font, new SolidBrush(shadowcolor.Value), location.X + shadowoffset, location.Y + shadowoffset);
            }
            gfx.DrawString(text, font, brush, location);
        }

        /// <summary>
        /// Draws a fancy text with shadow.
        /// </summary>
        /// <param name="gfx">Your graphics.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rect">A text's rectangle</param>
        /// <param name="shadow">Draw shadow?</param>
        /// <param name="shadowcolor">The shadow's color.</param>
        /// <param name="shadowoffset">The shadow's offset.</param>
        public static void DrawFancyText(Graphics gfx, string text, Font font, Brush brush, Rectangle rect, bool shadow = false, Color ? shadowcolor = null, short shadowoffset = 2)
        {
            if (shadowcolor == null)
                shadowcolor = Color.Black;
            if (shadow)
            {
                Rectangle shadowRect = rect;
                shadowRect.X += shadowoffset;
                shadowRect.Y += shadowoffset;
                gfx.DrawString(text, font, new SolidBrush(shadowcolor.Value), shadowRect);
            }
            gfx.DrawString(text, font, brush, rect);
        }
    }
}
