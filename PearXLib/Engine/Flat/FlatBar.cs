using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine.Flat
{
    /// <summary>
    /// Flat-style bar.
    /// </summary>
    public class FlatBar : XBar
    {
        /// <summary>
        /// Bar's left gradient color.
        /// </summary>
        [DefaultValue(typeof(Color), "41, 128, 185")]
        public override Color GradientColor1 { get; set; } = FlatColors.BelizeHole;

        /// <summary>
        /// Bar's right gradient color.
        /// </summary>
        [DefaultValue(typeof(Color), "41, 128, 185")]
        public override Color GradientColor2 { get; set; } = FlatColors.BelizeHole;

        /// <summary>
        /// Control's background color.
        /// </summary>
        [DefaultValue(typeof(Color), "37, 38, 41")]
        public override Color BackColor { get; set; } = Color.FromArgb(37, 38, 41);

        /// <summary>
        /// <see cref="Control.ForeColor"/>
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public override Color ForeColor { get; set; } = Color.White;
    }
}
