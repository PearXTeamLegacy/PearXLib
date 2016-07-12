using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    public class XTrackbar : XControlBase
    {
        private TrackbarType _Type = TrackbarType.Horizontal;
        private Color _LineColor = FlatColors.Asbestos;
        private Color _PointerColor = FlatColors.BelizeHole;
        private Color _PointerFocusedColor = FlatColors.PeterRiver;
        private int _Maximum = 100;
        private int _Value = 0;
        private short _PointerSize = 15;
        private bool Focused = false;
        private bool Clicked = false;
        private int _LineSize = 10;

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
        public event XBarEventHandler ValueChanged;

        [DefaultValue(0)]
        public virtual TrackbarType Type { get { return _Type; } set { _Type = value; Refresh(); } }

        public virtual Color LineColor { get { return _LineColor; } set { _LineColor = value; Refresh(); } }

        public virtual Color PointerColor { get { return _PointerColor; } set { _PointerColor = value; Refresh(); } }

        public virtual Color PointerFocusedColor { get { return _PointerFocusedColor; } set { _PointerFocusedColor = value; Refresh(); } }

        public virtual int Maximum { get { return _Maximum; } set { _Maximum = value; Refresh(); } }

        public virtual int Value
        {
            get { return _Value; }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > Maximum)
                    value = Maximum;
                _Value = value;
                OnValueChanged(new XBarEventArgs(Value, Maximum));
                Refresh();
            } 
            
        }

        public virtual short PointerSize { get { return _PointerSize; } set { _PointerSize = value; Refresh(); } }

        public override Cursor Cursor { get; set; } = Cursors.Hand;

        public virtual int LineSize { get { return _LineSize; } set { _LineSize = value; Refresh(); } }

        #endregion

        public virtual void OnValueChanged(XBarEventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

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
            Focused = false;
            Refresh();
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            Focused = true;
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
            Color cPointer = Focused ? PointerFocusedColor : PointerColor;
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

    public enum TrackbarType
    {
        Horizontal = 0,
        Vertical = 1
    }

    public class TrackbarEventArgs
    {
        public int Maximum { get; set; }
        public int Value { get; set; }
    }
}