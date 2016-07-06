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
        /// Use interpolation?
        /// </summary>
        [DefaultValue(false)]
        public bool UseInterpolation
        {
            get { return useInterpolation; }
            set { useInterpolation = value; Invalidate(); }
        }

        [DefaultValue(true)]
        protected override bool DoubleBuffered { get; set; } = true;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!UseInterpolation)
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            base.OnPaint(e);
        }
    }
}
