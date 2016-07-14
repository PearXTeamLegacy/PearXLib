using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful TrackBar from PearXLib.
    /// </summary>
    /// <seealso cref="XControlBase" />
    public class XTrackbar : XControlBase
    {
        private TrackbarType _Type = TrackbarType.Horizontal;
        private Color _LineColor = FlatColors.Asbestos;
        private Color _PointerColor = FlatColors.BelizeHole;
        private Color _PointerFocusedColor = FlatColors.PeterRiver;
        private int _Maximum = 100;
        private int _Value;
        private short _PointerSize = 15;
        private bool focus;
        private bool Clicked;
        private int _LineSize = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="XTrackbar"/> class.
        /// </summary>
        public XTrackbar()
        {
            Paint += OnPaint;
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            MouseMove += OnMouseMove;
        }

        #region Params        
        /// <summary>
        /// Occurs when <see cref="Value"/> changed.
        /// </summary>
        public event BarEventHandler ValueChanged;

        /// <summary>
        /// A type of the TrackBar.
        /// </summary>
        [DefaultValue(0)]
        public virtual TrackbarType Type { get { return _Type; } set { _Type = value; Refresh(); } }

        /// <summary>
        /// Color of the line.
        /// </summary>
        [DefaultValue(typeof(Color), "127, 140, 141")]
        public virtual Color LineColor { get { return _LineColor; } set { _LineColor = value; Refresh(); } }

        /// <summary>
        /// Color of the pointer.
        /// </summary>
        [DefaultValue(typeof(Color), "41, 128, 185")]
        public virtual Color PointerColor { get { return _PointerColor; } set { _PointerColor = value; Refresh(); } }

        /// <summary>
        /// Color of the focused pointer.
        /// </summary>
        [DefaultValue(typeof(Color), "52, 152, 219")]
        public virtual Color PointerFocusedColor { get { return _PointerFocusedColor; } set { _PointerFocusedColor = value; Refresh(); } }

        /// <summary>
        /// A maximum value of the Trackbar.
        /// </summary>
        [DefaultValue(100)]
        public virtual int Maximum { get { return _Maximum; } set { _Maximum = value; Refresh(); } }

        /// <summary>
        /// Value of the Trackbar.
        /// </summary>
        [DefaultValue(0)]
        public virtual int Value
        {
            get { return _Value; }
            set
            {
                int i = _Value;
                if (value < 0)
                    value = 0;
                if (value > Maximum)
                    value = Maximum;
                _Value = value;
                Refresh();
                OnValueChanged(new BarEventArgs(Value, Maximum, i));
            } 
            
        }

        /// <summary>
        /// Size of the pointer.
        /// </summary>
        [DefaultValue(15)]
        public virtual short PointerSize { get { return _PointerSize; } set { _PointerSize = value; Refresh(); } }

        /// <summary>
        /// <see cref="Control.Cursor"/>
        /// </summary>
        [DefaultValue(typeof(Cursor), "Hand")]
        public override Cursor Cursor { get; set; } = Cursors.Hand;

        /// <summary>
        /// Width or Height of the line.
        /// </summary>
        [DefaultValue(10)]
        public virtual int LineSize { get { return _LineSize; } set { _LineSize = value; Refresh(); } }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="BarEventArgs"/> instance containing the event data.</param>
        public virtual void OnValueChanged(BarEventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Gets a bar value from the cursor position.
        /// </summary>
        /// <param name="cursor">The cursor position.</param>
        public int GetValueByCursor(Point cursor)
        {
            switch(Type)
            {
                case TrackbarType.Horizontal:
                    float fW = (float)Width / Maximum;
                    float gW = cursor.X/fW;
                    return (int)Math.Round(gW, MidpointRounding.AwayFromZero);
                case TrackbarType.Vertical:
                    float fH = (float)Height / Maximum;
                    float gH = cursor.Y / fH;
                    return (int)Math.Round(gH, MidpointRounding.AwayFromZero);
            }
            return 0;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            focus = false;
            Refresh();
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            focus = true;
            Refresh();
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Clicked = false;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Clicked = true;
            Value = GetValueByCursor(e.Location);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Clicked)
                Value = GetValueByCursor(e.Location);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Color cPointer = focus ? PointerFocusedColor : PointerColor;
            switch (Type)
            {
                case TrackbarType.Horizontal:
                    e.Graphics.FillRectangle(new SolidBrush(LineColor), 0, (Height -  LineSize) / 2f, Width, LineSize);
                    float x = (float)Width/Maximum*Value;
                    float y = (Height - PointerSize) / 2f;
                    e.Graphics.FillEllipse(new SolidBrush(cPointer), x - PointerSize / 2f, y, PointerSize, PointerSize);
                    break;
                case TrackbarType.Vertical:
                    e.Graphics.FillRectangle(new SolidBrush(LineColor), (Width - LineSize) / 2f, 0, LineSize, Height);
                    x = (Width - PointerSize) / 2f;
                    y = (float)Height / Maximum * Value;
                    e.Graphics.FillEllipse(new SolidBrush(cPointer), x, y - PointerSize / 2f, PointerSize, PointerSize);
                    break;
            }
        }
    }

    /// <summary>
    /// Type of the <see cref="XTrackbar"/>.
    /// </summary>
    public enum TrackbarType
    {
        /// <summary>
        /// The horizontal bar.
        /// </summary>
        Horizontal = 0,

        /// <summary>
        /// The vertical bar.
        /// </summary>
        Vertical = 1
    }
}