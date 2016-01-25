using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;

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

        Bitmap bm;
        bool isDrawing = false;
        Random rand = new Random();

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!isDrawing)
            {
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                switch (State)
                {
                    case XButtonState.NONE:
                        e.Graphics.FillRectangle(new SolidBrush(Color), rect);
                        break;
                    case XButtonState.FOCUSED:
                        e.Graphics.FillRectangle(new SolidBrush(ColorFocused), rect);
                        break;
                    case XButtonState.CLICKED:
                        bm = new Bitmap(Width, Height);
                        Thread thr = new Thread(() =>
                        {
                        using (Graphics gr = Graphics.FromImage(bm))
                        {
                            isDrawing = true;
                            int x = MousePosition.X - Parent.Location.X - Location.X;
                            int y = MousePosition.Y - Parent.Location.Y - Location.Y;
                            for (int i = 0; i <= Width * 2; i++)
                            {
                                gr.FillRectangle(new SolidBrush(ColorFocused), rect);
                                //From center:
                                //gr.FillEllipse(new SolidBrush(Color), (Width - i) / 2, (Height - i) / 2, i, i);
                                gr.FillEllipse(new SolidBrush(Color), x - i / 2, y - i / 2, i, i);
                                try { Invoke(new MethodInvoker(() => { Refresh(); })); } catch { }
                                    if(i == Width * 2)
                                    {
                                        isDrawing = false;
                                    }
                                }
                            }
                        });
                        thr.Start();
                        break;
                }
            }
            else
            {
                e.Graphics.DrawImage(bm, 0, 0);
            }
            base.OnPaint(e);
        }
    }
}
