using System.Drawing;

namespace PearXLib.Engine.Flat
{
    /// <summary>
    /// Flat-style bar.
    /// </summary>
    public class FlatBar : XBar
    {
        private Color gc = Color.FromArgb(41, 128, 185);
        private Color gc2 = Color.FromArgb(41, 128, 185);
        private Color bg = Color.FromArgb(37, 38, 41);

        public override Color GradientColor1
        {
            get { return gc; } set { gc = value; }
        }

        public override Color GradientColor2
        {
            get { return gc2; } set { gc2 = value; }
        }

        public override Color BGColor
        {
            get { return bg; } set { bg = value; }
        }
    }
}
