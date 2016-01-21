using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine.Flat
{
    public class FlatButton : XButtonBase
    {
        private Color _Color = Color.FromArgb(18, 107, 166);
        private Color _ColorFocused = Color.FromArgb(41, 128, 185);

        public FlatButton()
        {
            Size = new Size(128, 64);
        }

        #region Params
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; Refresh(); }
        }

        public Color ColorFocused
        {
            get { return _ColorFocused; }
            set { _ColorFocused = value; Refresh(); }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            switch(State)
            {
                case XButtonState.NONE:
                    e.Graphics.FillRectangle(new SolidBrush(Color), rect);
                    break;
                case XButtonState.FOCUSED:
                    e.Graphics.FillRectangle(new SolidBrush(ColorFocused), rect);
                    break;
                case XButtonState.CLICKED:
                    e.Graphics.FillRectangle(new SolidBrush(ColorFocused), rect);
                    break;
            }
            base.OnPaint(e);
        }
    }
}
