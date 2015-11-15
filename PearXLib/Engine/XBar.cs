using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful progress bar from PearXLib.
    /// </summary>
    public partial class XBar : UserControl
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
            InitializeComponent();
        }

        #region Params.
        /// <summary>
        /// Progress value.
        /// </summary>
        [Description("Progress value."), DefaultValue(0)]
        public int Value
        {
            get { return _Value; }
            set 
            {
                if (!(value > Maximum))
                {
                    _Value = value; Refresh(); 
                }
            }
        }

        /// <summary>
        /// Maximum value.
        /// </summary>
        [Description("Maximum value."), DefaultValue(100)]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value > Value)
                    Value = value;
                _Maximum = value;
                Refresh();
            }
        }

        /// <summary>
        /// Value bar gradient color 1.
        /// </summary>
        [Description("Value bar gradient color 1."), DefaultValue(typeof(Color), "102, 204, 0")]
        public Color GradientColor1
        {
            get { return _GradientColor1; }
            set { _GradientColor1 = value; Refresh(); }
        }

        /// <summary>
        /// Value bar gradient color 2.
        /// </summary>
        [Description("Value bar gradient color 2."), DefaultValue(typeof(Color), "White")]
        public Color GradientColor2
        {
            get { return _GradientColor2; }
            set { _GradientColor2 = value; Refresh(); }
        }

        /// <summary>
        /// Bar background color.
        /// </summary>
        [Description("Bar background color."), DefaultValue(typeof(Color), "Gray")]
        public Color BGColor
        {
            get { return _BGColor; }
            set { _BGColor = value; Refresh(); }
        }

        /// <summary>
        /// Text on bar.
        /// </summary>
        [Description("Text on bar."), DefaultValue("")]
        public string ProgressText
        {
            get { return _ProgressText; }
            set { _ProgressText = value; Refresh(); }
        }

        /// <summary>
        /// Color of a text on a bar.
        /// </summary>
        [Description("Color of a text on a bar."), DefaultValue(typeof(Color), "Black")]
        public Color ProgressTextColor
        {
            get { return _ProgressTextColor; }
            set { _ProgressTextColor = value; Refresh(); }
        }
        #endregion

        #region Overriding props
        /// <summary>
        /// Not working. Don't change this.
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return Color.Transparent;
            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// A font of a text on a bar.
        /// </summary>
        [Description("A font of a text on a bar.")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }
        #endregion

        private void XBar_Paint(object sender, PaintEventArgs e)
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
