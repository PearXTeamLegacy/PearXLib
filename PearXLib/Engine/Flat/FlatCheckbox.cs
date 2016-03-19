using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine.Flat
{
    /// <summary>
    /// A beautiful flat-style checkbox.
    /// </summary>
    public class FlatCheckbox : XCheckboxBase
    {
        private Color cbg = Color.FromArgb(37, 38, 41);
        private Color cc = Color.FromArgb(18, 107, 166);
        private Color cc_focused = Color.FromArgb(41, 128, 185);

        #region Params
        /// <summary>
        /// Checkbox background color.
        /// </summary>
        public Color ColorBG
        {
            get { return cbg; }
            set { cbg = value; Refresh(); }
        }

        /// <summary>
        /// Checkbox's check color.
        /// </summary>
        public Color ColorCheck
        {
            get { return cc; }
            set { cc = value; Refresh(); }
        }

        /// <summary>
        /// Focused checkbox's color.
        /// </summary>
        public Color ColorCheckFocused
        {
            get { return cc_focused; }
            set { cc_focused = value; Refresh(); }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush b = null;
            switch (State)
            {
                case CheckboxState.Focused:
                    b = new SolidBrush(ColorCheckFocused);
                    break;
                case CheckboxState.None:
                    b = new SolidBrush(ColorCheck);
                    break;
            }
            e.Graphics.FillRectangle(new SolidBrush(ColorBG), 0, 0, Width / 5, Height);
            if(Checked)
            {
                e.Graphics.FillRectangle(b, 3, 3, (Width / 5) - 6, Height - 6);
            }
            base.OnPaint(e);
        }
    }
}
