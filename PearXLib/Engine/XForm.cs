using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful customizing form.
    /// </summary>
    public class XForm : XFormBase
    {
        private Image _BarImage = FormIcons.BarImage;
        private int _BoxSizes = 32;
        private int _BoxDistance = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="XForm"/> class.
        /// </summary>
        public XForm()
        {
            Boxes.CloseBox = new XFormBox();
            Boxes.MaximizeBox = new XFormBox();
            Boxes.ToTrayBox = new XFormBox();

            for (int i = 0; i < Boxes.Count; i++)
            {
                XFormBox box = Boxes[i] as XFormBox;
                switch (i)
                {
                    case 0:
                        box.Image = FormIcons.CloseBox;
                        box.FocusedImage = FormIcons.CloseBoxFocused;
                        break;
                    case 1:
                        box.Image = FormIcons.MaximizeBox;
                        box.FocusedImage = FormIcons.MaximizeBoxFocused;
                        break;
                    case 2:
                        box.Image = FormIcons.ToTrayBox;
                        box.FocusedImage = FormIcons.ToTrayBoxFocused;
                        break;
                }
            }

            Paint += ControlPaint;
        }

        #region Params
        /// <summary>
        /// Form bar background image.
        /// </summary>
        public virtual Image BarImage
        {
            get { return _BarImage; }
            set { _BarImage = value; Refresh(); }
        }

        /// <summary>
        /// Box sizes.
        /// </summary>
        [DefaultValue(32)]
        public int BoxSizes { get { return _BoxSizes; } set { _BoxSizes = value; Refresh(); } }

        /// <summary>
        /// Distance from first box to second.
        /// </summary>
        public int BoxDistance { get { return _BoxDistance; } set { _BoxDistance = value; Refresh(); } }
        #endregion

        /// <summary>
        /// Occurs when form repainted.
        /// </summary>
        public override void UpdateRectangles()
        {
            Boxes.CloseBox.Rectangle = new Rectangle(Width - BoxSizes, 0, BoxSizes, BoxSizes);
            Boxes.MaximizeBox.Rectangle = new Rectangle(Width - BoxSizes * 2 - BoxDistance, 0, BoxSizes, BoxSizes);
            Boxes.ToTrayBox.Rectangle = new Rectangle(Width - BoxSizes * 3 - BoxDistance * 2, 0, BoxSizes, BoxSizes);
        }

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            if (BarImage != null)
            {
                TextureBrush tb = new TextureBrush(BarImage);
                e.Graphics.FillRectangle(tb, 0, 0, Size.Width, BoxSizes);
            }

            for (int i = 0; i < Boxes.Count; i++)
            {
                XFormBox box = Boxes[i] as XFormBox;
                Image img = box.Focused ? box.FocusedImage : box.Image;
                e.Graphics.DrawImage(img, box.Rectangle);
            }

            if (DrawTitle)
            {
                SizeF size = e.Graphics.MeasureString(Text, Font);
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 0, (BoxSizes - size.Height) / 2f);
            }
        }
    }

    /// <summary>
    /// <see cref="FormBox"/> for the <see cref="XForm"/>
    /// </summary>
    /// <seealso cref="PearXLib.Engine.FormBox" />
    public class XFormBox : FormBox
    {
        /// <summary>
        /// Image for the focused box.
        /// </summary>
        public Image FocusedImage { get; set; }

        /// <summary>
        /// Image for the unfocused box.
        /// </summary>
        public Image Image { get; set; }
    }
}