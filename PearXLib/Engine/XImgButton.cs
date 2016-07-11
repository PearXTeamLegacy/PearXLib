using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful button from PearX Engine.
    /// </summary>
    public class XImgButton : XButtonBase
    {
        private Image _BackImage;
        private Image _BackImageFocused;
        private Image _BackImagePressed;

        public XImgButton()
        {
            Paint += ControlPaint;
        }

        #region Properties.
        /// <summary>
        /// Button background.
        /// </summary>
        [Description("Button background.")]
        public virtual Image BackImage
        {
            get { return _BackImage; }
            set { _BackImage = value; Refresh(); }
        }

        /// <summary>
        /// Focused button background.
        /// </summary>
        [Description("Focused button background.")]
        public virtual Image BackImageFocused
        {
            get { return _BackImageFocused; }
            set { _BackImageFocused = value; Refresh(); }
        }

        /// <summary>
        /// Pressed button background.
        /// </summary>
        [Description("Pressed button background.")]
        public virtual Image BackImagePressed
        {
            get { return _BackImagePressed; }
            set { _BackImagePressed = value; Refresh(); }
        }
        #endregion

        private void ControlPaint(object sender, PaintEventArgs e)
        { 
            if (BackImage != null && BackImageFocused != null && BackImagePressed != null)
            {
                switch (State)
                {
                    case XButtonState.NONE:
                        e.Graphics.DrawImage(BackImage, 0, 0, Size.Width, Size.Height);
                        break;
                    case XButtonState.FOCUSED:
                        e.Graphics.DrawImage(BackImageFocused, 0, 0, Size.Width, Size.Height);
                        break;
                    case XButtonState.CLICKED:
                        e.Graphics.DrawImage(BackImagePressed, 0, 0, Size.Width, Size.Height);
                        break;

                }
            }
            PaintBase(e);
        }
    }
}
