using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine.Flat
{
    /// <summary>
    /// Flat Form.
    /// </summary>
    public class FlatForm : XForm
    {
        /// <summary>
        /// Initializes a new XForm component.
        /// </summary>
        public FlatForm()
        {
            BarImage = null;
            BackColor = Color.FromArgb(44, 47, 51);
            BoxesTopDistance = 1;
            BoxesDistance = 0;
            TextColor = Color.White;
            base.ImageCloseBox = null;
            base.ImageCloseBoxFocused = null;
            base.ImageToTrayBox = null;
            base.ImageToTrayBoxFocused = null;
            base.ImageMaximizeBox = null;
            base.ImageMaximizeBoxFocused = null;
            base.ImageMinimizeBox = null;
            base.ImageMinimizeBoxFocused = null;
        }



        private Color _CloseBoxColor = Color.FromArgb(192, 57, 43);
        private Color _CloseBoxFColor = Color.FromArgb(231, 76, 60);
        private Color _MinMaxBoxColor = Color.FromArgb(41, 128, 185);
        private Color _MinMaxBoxFColor = Color.FromArgb(52, 152, 219);
        private Color _ToTrayBoxColor = Color.FromArgb(39, 174, 96);
        private Color _ToTrayBoxFColor = Color.FromArgb(46, 204, 113);
        private Color _PanelBG = Color.FromArgb(37, 38, 41);
        private bool _Rim = true;
        private Color _RimColor = Color.FromArgb(18, 107, 166);

        /// <summary>
        /// Color of the close box.
        /// </summary>
        public Color CloseBoxColor { get { return _CloseBoxColor; } set { _CloseBoxColor = value; Refresh(); } }
        /// <summary>
        /// Color of the focused close box.
        /// </summary>
        public Color CloseBoxFColor { get { return _CloseBoxFColor; } set { _CloseBoxFColor = value; Refresh(); } }
        /// <summary>
        /// Color of the minimize and maximize boxes.
        /// </summary>
        public Color MinMaxBoxColor { get { return _MinMaxBoxColor; } set { _MinMaxBoxColor = value; Refresh(); } }
        /// <summary>
        /// Color of the focused minimize and maximize boxes.
        /// </summary>
        public Color MinMaxBoxFColor { get { return _MinMaxBoxFColor; } set { _MinMaxBoxFColor = value; Refresh(); } }
        /// <summary>
        /// Color of the to tray box.
        /// </summary>
        public Color ToTrayBoxColor { get { return _ToTrayBoxColor; } set { _ToTrayBoxColor = value; Refresh(); } }
        /// <summary>
        /// Color of the focused to tray box.
        /// </summary>
        public Color ToTrayBoxFColor { get { return _ToTrayBoxFColor; } set { _ToTrayBoxFColor = value; Refresh(); } }
        /// <summary>
        /// Color of the panel.
        /// </summary>
        public Color PanelBG { get { return _PanelBG; } set { _PanelBG = value; Refresh(); } }
        /// <summary>
        /// Color of the form rim.
        /// </summary>
        public Color RimColor { get { return _RimColor; } set { _RimColor = value; Refresh(); } }
        /// <summary>
        /// Enable form rim?
        /// </summary>
        public bool Rim { get { return _Rim; } set { _Rim = value; Refresh(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(PanelBG), 0, 0, Size.Width, 32);
            base.OnPaint(e);
            if (CloseBox)
            {
                if (BarSt == BarState.Close)
                {
                    e.Graphics.FillRectangle(new SolidBrush(CloseBoxFColor), Size.Width - (32 + BoxesDistance), BoxesTopDistance, 32, 32);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(CloseBoxColor), Size.Width - (32 + BoxesDistance), BoxesTopDistance, 32, 32);
                }
            }

            if (MaximizeBox)
            {
                if (BarSt == BarState.Maximize)
                {
                    e.Graphics.FillRectangle(new SolidBrush(MinMaxBoxFColor), Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(MinMaxBoxColor), Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                }
            }

            if (ToTrayBox)
            {
                if (BarSt == BarState.ToTray)
                {
                    e.Graphics.FillRectangle(new SolidBrush(ToTrayBoxFColor), Size.Width - (96 + (BoxesDistance * 3)), BoxesTopDistance, 32, 32);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(ToTrayBoxColor), Size.Width - (96 + (BoxesDistance * 3)), BoxesTopDistance, 32, 32);
                }
            }
            e.Graphics.DrawRectangle(new Pen(RimColor, 1), 0, 0, Size.Width - 1, Size.Height - 1);
        }
    }
}
