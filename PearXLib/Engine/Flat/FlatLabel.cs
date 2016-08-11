using System.ComponentModel;
using System.Drawing;

namespace PearXLib.Engine.Flat
{
    /// <summary>
    /// Class FlatLabel.
    /// </summary>
    /// <seealso cref="XLabel" />
    public class FlatLabel : XLabel
    {
        private bool shadow = true;
        private Color forecolor = Color.FromArgb(41, 128, 185);


        /// <summary>
        /// Draw control's shadow?
        /// </summary>
        [DefaultValue(true)]
        public override bool Shadow { get { return shadow; } set { shadow = value; } }

        /// <summary>
        /// The color of the fore.
        /// </summary>
        public override Color ForeColor { get { return forecolor; } set { forecolor = value; } }
    }
}
