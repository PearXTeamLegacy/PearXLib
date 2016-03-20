using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Color cbg_focused = Color.FromArgb(54, 55, 59);
        private Color cc = Color.FromArgb(18, 107, 166);
        private Color cc_focused = Color.FromArgb(41, 128, 185);

        #region Params
        /// <summary>
        /// Checkbox background color.
        /// </summary>
        [DefaultValue(typeof(Color), "37, 38, 41")]
        public Color ColorBG
        {
            get { return cbg; }
            set { cbg = value; Refresh(); }
        }

        /// <summary>
        /// Checkbox's check color.
        /// </summary>
        [DefaultValue(typeof(Color), "18, 107, 166")]
        public Color ColorCheck
        {
            get { return cc; }
            set { cc = value; Refresh(); }
        }

        /// <summary>
        /// Focused checkbox's color.
        /// </summary>
        [DefaultValue(typeof(Color), "41, 128, 185")]
        public Color ColorCheckFocused
        {
            get { return cc_focused; }
            set { cc_focused = value; Refresh(); }
        }

        public Color ColorBGFocused
        {
            get { return cbg_focused; }
            set { cbg_focused = value; Refresh(); }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            float width = 0F;
            if (!string.IsNullOrEmpty(Text))
                width = Width / 5;
            else
                width = Width;

            SolidBrush b = null;
            SolidBrush bg = null;

            switch (State)
            {
                case CheckboxState.Focused:
                    b = new SolidBrush(ColorCheckFocused);
                    bg = new SolidBrush(ColorBGFocused);
                    break;
                case CheckboxState.None:
                    b = new SolidBrush(ColorCheck);
                    bg = new SolidBrush(ColorBG);
                    break;
            }
            e.Graphics.FillRectangle(bg, 0, 0, width, Height);
            if(Checked)
            {
                e.Graphics.FillRectangle(b, 3, 3, width - 6, Height - 6);
            }
            base.OnPaint(e);
        }
    }
}
