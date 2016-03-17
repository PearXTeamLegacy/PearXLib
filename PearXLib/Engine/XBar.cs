using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful progress bar from PearXLib.
    /// </summary>
    public class XBar : UserControl
    {
        private int _Value = 0;
        private int _Maximum = 100;
        private Color _GradientColor1 = Color.FromArgb(102, 204, 0);
        private Color _GradientColor2 = Color.White;
        private Color _BGColor = Color.Gray;
        private string _ProgressText = String.Empty;
        private Color _ProgressTextColor = Color.Black;

        /// <summary>
        /// Initializes the new XBar component.
        /// </summary>
        public XBar()
        {
            DoubleBuffered = true;
            Size = new Size(349, 52);
            BackColor = Color.Transparent;
            ResizeRedraw = true;
        }

        #region Params.
        /// <summary>
        /// XBar event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">XBar Event Args <see cref="XBarEventArgs"/></param>
        public delegate void XBarEventHandler(object sender, XBarEventArgs e);

        /// <summary>
        /// Performs on bar value changed.
        /// </summary>
        public event XBarEventHandler ValueChanged;

        /// <summary>
        /// Progress value.
        /// </summary>
        [Description("Progress value."), DefaultValue(0)]
        public virtual int Value
        {
            get { return _Value; }
            set 
            {
                if (!(value > Maximum))
                {
                    _Value = value; Refresh();
                }
                else
                {
                    _Value = Maximum; Refresh();
                }
                if (ValueChanged != null)
                    ValueChanged(this, new XBarEventArgs(value, Maximum));
            }
        }

        /// <summary>
        /// Maximum value.
        /// </summary>
        [Description("Maximum value."), DefaultValue(100)]
        public virtual int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < Value)
                    Value = value;
                _Maximum = value;
                Refresh();
            }
        }

        /// <summary>
        /// Value bar gradient color 1.
        /// </summary>
        [Description("Value bar gradient color 1."), DefaultValue(typeof(Color), "102, 204, 0")]
        public virtual Color GradientColor1
        {
            get { return _GradientColor1; }
            set { _GradientColor1 = value; Refresh(); }
        }

        /// <summary>
        /// Value bar gradient color 2.
        /// </summary>
        [Description("Value bar gradient color 2."), DefaultValue(typeof(Color), "White")]
        public virtual Color GradientColor2
        {
            get { return _GradientColor2; }
            set { _GradientColor2 = value; Refresh(); }
        }

        /// <summary>
        /// Bar background color.
        /// </summary>
        [Description("Bar background color."), DefaultValue(typeof(Color), "Gray")]
        public virtual Color BGColor
        {
            get { return _BGColor; }
            set { _BGColor = value; Refresh(); }
        }

        /// <summary>
        /// Text on bar.
        /// </summary>
        [Description("Text on bar."), DefaultValue("")]
        public virtual string ProgressText
        {
            get { return _ProgressText; }
            set { _ProgressText = value; Refresh(); }
        }

        /// <summary>
        /// Color of a text on a bar.
        /// </summary>
        [Description("Color of a text on a bar."), DefaultValue(typeof(Color), "Black")]
        public virtual Color ProgressTextColor
        {
            get { return _ProgressTextColor; }
            set { _ProgressTextColor = value; Refresh(); }
        }

        /// <summary>
        /// Control's background color.
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor { get; set; }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush sb = new SolidBrush(BGColor);
            Pen p = new Pen(sb, 4);
            p.LineJoin = LineJoin.Bevel;
            e.Graphics.DrawRectangle(p, 4, 4, Size.Width - 8, Size.Height - 8);
            e.Graphics.FillRectangle(sb, 4, 4, Size.Width - 8, Size.Height - 8);

            LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(Size.Width, Size.Height), GradientColor1, GradientColor2);
            e.Graphics.FillRectangle(lgb, 5, 5, ((float)((Size.Width - 10)) / Maximum) * Value, Size.Height - 10);

            Brush bf = new SolidBrush(ProgressTextColor);
            e.Graphics.DrawString(ProgressText, Font, bf, new PointF((Size.Width - e.Graphics.MeasureString(ProgressText, Font).Width) / 2, (Size.Height - e.Graphics.MeasureString(ProgressText, Font).Height) / 2));
        }
    }
}
