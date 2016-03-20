using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A checkbox, maked from images.
    /// </summary>
    public class XImgCheckbox : XCheckboxBase
    {
        private Image bg;
        private Image bg_focused;
        private Image check_focused;
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
        /// Focused checkbox's check image.
        /// </summary>
        public Image CheckFocused
        {
            get { return check_focused; }
            set { check_focused = value; Refresh(); }
        }

        /// <summary>
        /// Focused checkbox's background.
        /// </summary>
        public Image CheckBGFocused
        {
            get { return bg_focused; }
            set { bg_focused = value; Refresh(); }
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
            float width;
            Image img_bg;
            Image img_check;

            if (!string.IsNullOrEmpty(Text))
                width = Width/5;
            else
                width = Width;

            if (State == CheckboxState.Focused)
            {
                img_bg = CheckBGFocused;
                img_check = CheckFocused;
            }
            else
            {
                img_bg = CheckBG;
                img_check = Check;
            }

            if (img_bg != null)
            {
                e.Graphics.DrawImage(img_bg, 0, 0, width, Height);
            }

            if (img_check != null)
            {
                e.Graphics.DrawImage(img_check, 0, 0, width, Height);
            }
            base.OnPaint(e);
        }
    }
}
