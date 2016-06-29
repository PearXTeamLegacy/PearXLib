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
        private bool useInterpolation;

        /// <summary>
        /// Initializes a new instance of the <see cref="XControlBase"/> class.
        /// </summary>
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
            get { return useInterpolation; }
            set { useInterpolation = value; Refresh(); }
        }

        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!UseInterpolation)
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        }
    }
}
