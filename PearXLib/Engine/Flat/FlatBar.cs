using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PearXLib.Engine.Flat
{
    public class FlatBar : XBar
    {
        private Color gc = Color.FromArgb(41, 128, 185);
        private Color bg = Color.FromArgb(37, 38, 41);

        public override Color GradientColor1
        {
            get { return gc; } set { gc = value; }
        }

        public override Color GradientColor2
        {
            get { return gc; } set { gc = value; }
        }

        public override Color BGColor
        {
            get { return bg; } set { bg = value; }
        }
    }
}
