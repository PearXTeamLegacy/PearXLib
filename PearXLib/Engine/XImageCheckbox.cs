using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A checkbox, maked from images.
    /// </summary>
    public class XImageCheckbox : XCheckboxBase
    {
        private Image bg;
        private Image check;

        #region Params
        /// <summary>
        /// Checkbox's background.
        /// </summary>
        public Image CheckBG
        {
            get { return bg; }
            set { bg = value; Refresh(); }
        }

        /// <summary>
        /// Checkbox's check image.
        /// </summary>
        public Image Check
        {
            get { return check; }
            set { check = value; Refresh(); }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            if (CheckBG != null)
            {
                e.Graphics.DrawImage(bg, 0, 0, Width / 5, Height);
            }
            if (Check != null && Checked)
            {
                e.Graphics.DrawImage(check, 0, 0, Width / 5, Height);
            }
            base.OnPaint(e);
        }
    }
}
