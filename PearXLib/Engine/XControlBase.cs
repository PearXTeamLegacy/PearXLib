using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// Base for all PearXLib's controls.
    /// </summary>
    public class XControlBase : UserControl
    {
        private bool useinterpolation;

        /// <summary>
        /// Use interpolation?
        /// </summary>
        public bool UseInterpolation
        {
            get { return useinterpolation; }
            set { useinterpolation = value; Refresh(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!UseInterpolation)
                e.Graphics.InterpolationMode = InterpolationMode.Low;
        }
    }
}
