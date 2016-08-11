using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// Type of the Indicator
    /// </summary>
    public enum IndicatorType
    {
        /// <summary>
        /// Red, Yellow, Green lines on the Indicator.
        /// </summary>
        ThreeLines,
        /// <summary>
        /// Red => Green gradient.
        /// </summary>
        Gradient,

        /// <summary>
        /// Red, Yellow, Green triangles on the Indicator.
        /// </summary>
        ThreeTriangles
    }

    /// <summary>
    /// Indicator.
    /// </summary>
    public class Indicator : XControlBase
    {
        private IndicatorType it = IndicatorType.Gradient;
        private Color c1 = Color.Green;
        private Color c2 = Color.Yellow;
        private Color c3 = Color.Red;

        /// <summary>
        /// Initializes a new instance of the <see cref="Indicator"/> class.
        /// </summary>
        public Indicator()
        {
            Size = new Size(273, 84);
            Paint += ControlPaint;
        }

        #region Params.
        /// <summary>
        /// Type of the indicator.
        /// </summary>
        [DefaultValue(1)]
        public IndicatorType Type
        {
            get { return it; }
            set { it = value; Refresh(); }
        }

        /// <summary>
        /// Color of the right val.
        /// </summary>
        [DefaultValue(typeof(Color), "Green")]
        public Color Color1
        {
            get { return c1; }
            set { c1 = value; Refresh(); }
        }

        /// <summary>
        /// Color of the center val.
        /// </summary>
        [DefaultValue(typeof(Color), "Yellow")]
        public Color Color2
        {
            get { return c2; }
            set { c2 = value; Refresh(); }
        }

        /// <summary>
        /// Color of the left val.
        /// </summary>
        [DefaultValue(typeof(Color), "Red")]
        public Color Color3
        {
            get { return c3; }
            set { c3 = value; Refresh(); }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor { get; set; } = Color.Transparent;

        #endregion

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            switch (Type)
            {
                case IndicatorType.Gradient:
                    LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(Width, Height), Color3, Color1);
                    e.Graphics.FillRectangle(lgb, 0, 0, Width, Height);
                    break;
                case IndicatorType.ThreeLines:
                    SolidBrush b1 = new SolidBrush(Color1);
                    SolidBrush b2 = new SolidBrush(Color2);
                    SolidBrush b3 = new SolidBrush(Color3);
                    e.Graphics.FillRectangle(b3, 0, 0, 3, Height);
                    e.Graphics.FillRectangle(b1, Width - 3, 0, 3, Height);
                    e.Graphics.FillRectangle(b2, (Width - 3)/2, 0, 3, Height);
                    break;
                case IndicatorType.ThreeTriangles:
                    b1 = new SolidBrush(Color1);
                    b2 = new SolidBrush(Color2);
                    b3 = new SolidBrush(Color3);
                    e.Graphics.FillPolygon(b3, new[] {new PointF(0, Height), new PointF(10, Height), new PointF(5, 0)});
                    e.Graphics.FillPolygon(b1, new[] {new PointF(Width, Height), new PointF(Width - 10, Height), new PointF(Width - 5, 0)});
                    e.Graphics.FillPolygon(b2, new[] {new PointF((Width - 10f)/2, Height), new PointF((Width + 10f)/2, Height), new PointF(Width/2f, 0)});
                    break;
            }
        }
    }
}
