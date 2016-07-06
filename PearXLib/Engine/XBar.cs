﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// XBar Event Handler.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="XBarEventArgs"/> instance containing the event data.</param>
    public delegate void XBarEventHandler(object sender, XBarEventArgs e);

    /// <summary>
    /// A beautiful progress bar from PearXLib.
    /// </summary>
    public class XBar : XTextControlBase
    {
        private int _Value;
        private int _Maximum = 100;
        private Color _GradientColor1 = Color.FromArgb(102, 204, 0);
        private Color _GradientColor2 = Color.White;
        private string text = "";
        private Color _BackColor = Color.Gray;

        /// <summary>
        /// Initializes the new XBar component.
        /// </summary>
        public XBar()
        {
            Size = new Size(349, 52);
            ResizeRedraw = true;
            Paint += ControlPaint;
        }

        #region Params

        /// <summary>
        /// Performs on bar value changed.
        /// </summary>
        public event XBarEventHandler ValueChanged;

        /// <summary>
        /// Progress value.
        /// </summary>
        [DefaultValue(0)]
        public virtual int Value
        {
            get { return _Value; }
            set 
            {
                if (value < Maximum)
                {
                    _Value = value; Invalidate();
                }
                else
                {
                    _Value = Maximum; Invalidate();
                }
                OnValueChanged(new XBarEventArgs(Value, Maximum));
            }
        }

        /// <summary>
        /// Maximum value.
        /// </summary>
        [DefaultValue(100)]
        public virtual int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < Value)
                    Value = value;
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Bar's left gradient color.
        /// </summary>
        [DefaultValue(typeof(Color), "102, 204, 0")]
        public virtual Color GradientColor1
        {
            get { return _GradientColor1; }
            set { _GradientColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// Bar's right gradient color.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public virtual Color GradientColor2
        {
            get { return _GradientColor2; }
            set { _GradientColor2 = value; Invalidate(); }
        }

        /// <summary>
        /// The text on the control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }

        /// <summary>
        /// Control's background color.
        /// </summary>
        [DefaultValue(typeof (Color), "Gray")]
        public new virtual Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; Invalidate(); }
        }
        #endregion

        /// <summary>
        /// Raises the <see cref="E:ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="XBarEventArgs"/> instance containing the event data.</param>
        public void OnValueChanged(XBarEventArgs e)
        {
           ValueChanged?.Invoke(this, e); 
        }

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            Brush bgBrush = new SolidBrush(BackColor);
            Pen bgPen = new Pen(bgBrush, 4) {LineJoin = LineJoin.Bevel};

            e.Graphics.DrawRectangle(bgPen, 4, 4, Size.Width - 8, Size.Height - 8); // Draw bg
            e.Graphics.FillRectangle(bgBrush, 4, 4, Size.Width - 8, Size.Height - 8); // ^

            LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(Width, Height), GradientColor1, GradientColor2);
            e.Graphics.FillRectangle(lgb, 5, 5, (float)(Width - 10) / Maximum * Value, Height - 10); //Draw progress

            Brush bf = new SolidBrush(ForeColor);
            SizeF strWH = e.Graphics.MeasureString(Text, Font);
            DrawFancyText(e.Graphics, Text, Font, bf, new PointF((Width - strWH.Width) / 2, (Height - strWH.Height) / 2)); //Draw text
        }
    }

    /// <summary>
    /// XBar event arguments
    /// </summary>
    public class XBarEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XBarEventArgs"/> class.
        /// </summary>
        /// <param name="val">Bar's value.</param>
        /// <param name="max">Bar's maximum value.</param>
        public XBarEventArgs(int val, int max)
        {
            Value = val;
            Maximal = max;
            InPercents = MathsUtils.GetInPercents(max, val);
        }

        /// <summary>
        /// Bar's value.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Maximal bar's value.
        /// </summary>
        public int Maximal { get; private set; }

        /// <summary>
        /// Bar's value in percents.
        /// </summary>
        public double InPercents { get; private set; }
    }
}
