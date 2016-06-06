using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// Base for all PearXLib's controls.
    /// </summary>
    public class XControlBase : UserControl
    {
        private bool useinterpolation;


        public XControlBase()
        {
            DoubleBuffered = true;
        }
        /// <summary>
        /// Use interpolation?
        /// </summary>
        [DefaultValue(false)]
        public bool UseInterpolation
        {
            get { return useinterpolation; }
            set { useinterpolation = value; Refresh(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!UseInterpolation)
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        }
    }
}
