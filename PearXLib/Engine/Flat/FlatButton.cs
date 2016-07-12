using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using PearXLib.Engine.Bases;

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
            Paint += ControlPaint;
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

        /// <summary>
        /// Draw control's shadow?
        /// </summary>
        [DefaultValue(true)]
        public override bool Shadow { get; set; } = true;

        /// <summary>
        /// See <see cref="Control.ForeColor"/>.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public override Color ForeColor { get; set; } = Color.White;

        /// <summary>
        /// What state set for Button after MouseUp event?
        /// </summary>
        [DefaultValue(2)]
        public override XButtonState MouseUpState { get; set; } = XButtonState.FOCUSED;
        #endregion

        private Bitmap bm;
        private bool isDrawing;

        private void ControlPaint(object sender, PaintEventArgs e)
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
                        new Thread(() =>
                        {
                            using (bm = new Bitmap(Width, Height))
                            {
                                using (Graphics gr = Graphics.FromImage(bm))
                                {
                                    isDrawing = true;
                                    Point p = new Point();
                                    Invoke(new MethodInvoker(() => { p = PointToClient(Cursor.Position); }));
                                    gr.FillRectangle(new SolidBrush(ColorFocused), rect);
                                    int j = (Width + Height)/36;
                                    for (int i = 0; i <= Width*2 + j; i += j)
                                    {
                                        gr.FillEllipse(new SolidBrush(Color), p.X - i/2, p.Y - i/2, i, i);
                                        try
                                        {
                                            Invoke(new MethodInvoker(Refresh));
                                        }
                                        catch
                                        {
                                            return;
                                        }
                                        Thread.Sleep(5);
                                        if (i >= (Width*2))
                                        {
                                            isDrawing = false;
                                            Invoke(new MethodInvoker(() => State = XButtonState.NONE));
                                        }
                                    }
                                }
                            }
                        }).Start();
                        break;
                }
            }
            else
            {
                e.Graphics.DrawImage(bm, 0, 0);
            }
            PaintBase(e);
        }
    }
}
