﻿using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace PearXLib.Engine.Flat
{
    /// <summary>
    /// Flat-style button.
    /// </summary>
    public class FlatButton : XButtonBase
    {
        private Color _Color = Color.FromArgb(18, 107, 166);
        private Color _ColorFocused = Color.FromArgb(41, 128, 185);

        /// <summary>
        /// Initializes a new FlatButton component.
        /// </summary>
        public FlatButton()
        {
            Size = new Size(128, 64);
        }

        #region Params
        /// <summary>
        /// Color of the button.
        /// </summary>
        [DefaultValue(typeof(Color), "18, 107, 166")]
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; Refresh(); }
        }
        
        /// <summary>
        /// Color of the focused button.
        /// </summary>
        [DefaultValue(typeof(Color), "41, 128, 185")]
        public Color ColorFocused
        {
            get { return _ColorFocused; }
            set { _ColorFocused = value; Refresh(); }
        }
        #endregion

        private Bitmap bm;
        private bool isDrawing;

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
                                //int x = Cursor.Position.X
                                //int y = Cursor.Position.Y - Top;
                                gr.FillRectangle(new SolidBrush(ColorFocused), rect);
                                for (int i = 0; i <= Width * 2; i++)
                                {
                                    gr.FillEllipse(new SolidBrush(Color), (Width - i) / 2, (Height - i) / 2, i, i);
                                    //gr.FillEllipse(new SolidBrush(Color), x - i / 2, y - i / 2, i, i);
                                    try
                                    {
                                        Invoke(new MethodInvoker(() => { Refresh(); }));
                                    }
                                    catch
                                    {
                                        return;
                                    }
                                    if (i == Width * 2)
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
