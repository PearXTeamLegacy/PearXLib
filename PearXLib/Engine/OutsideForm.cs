using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PearXLib.Engine
{
    /// <summary>
    /// A form for outside using B)
    /// </summary>
    public class OutsideForm : XForm
    {
        /// <summary>
        /// Initializes new OutsizeForm
        /// </summary>
        public OutsideForm()
        {
            TopMost = true;
            CanMove = false;
            MaximizeBox = false;
            MinimizeBox = false;
            CloseBox = false;
            ToTrayBox = false;
            BackColor = Color.White;
            DrawTitle = false;
            BarImage = null;
            ShowInTaskbar = false;
            Size = new Size(256, 128);
        }
    }
}
