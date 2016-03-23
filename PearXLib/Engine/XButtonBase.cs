using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// Button state enum.
    /// </summary>
    public enum XButtonState
    {
        /// <summary>
        /// Mouse is on the button.
        /// </summary>
        FOCUSED,
        /// <summary>
        /// Mouse is clicked the button.
        /// </summary>
        CLICKED,
        /// <summary>
        /// None.
        /// </summary>
        NONE
    }

    /// <summary>
    /// Base for the PearXLib's buttons.
    /// </summary>
    [DefaultEvent("Click")]
    public class XButtonBase : UserControl
    {
        private string _Text = "A button.";
        private Image _Image;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleRight;
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        private XButtonState _State = XButtonState.NONE;
        private int _Border;

        /// <summary>
        /// Initializes a new XButtonBase component.
        /// </summary>
        public XButtonBase()
        {
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
        }

        #region Params
        /// <summary>
        /// Current button state.
        /// </summary>
        [DefaultValue(typeof(XButtonState), "NONE"), Browsable(false)]
        public XButtonState State
        {
            get { return _State; }
            set { _State = value; Refresh(); }
        }

        /// <summary>
        /// Image alignment.
        /// </summary>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set { _ImageAlign = value; Refresh(); }
        }

        /// <summary>
        /// Text alignment.
        /// </summary>
        public ContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set { _TextAlign = value; Refresh(); }
        }

        /// <summary>
        /// The text on the button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text
        {
            get { return _Text; }
            set { _Text = value; Refresh(); }
        }

        /// <summary>
        /// The image on the button.
        /// </summary>
        [DefaultValue(null)]
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; Refresh(); }
        }

        /// <summary>
        /// The distance from button top.
        /// </summary>
        public int Border
        {
            get { return _Border; }
            set { _Border = value; Refresh(); }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(Image != null)
            {
                Size s = Image.Size;
                switch(ImageAlign)
                {
                    case ContentAlignment.BottomCenter:
                        e.Graphics.DrawImage(Image, (Width - s.Width) / 2, Height - s.Height - Border);
                        break;
                    case ContentAlignment.BottomLeft:
                        e.Graphics.DrawImage(Image, Border, Height - s.Height - Border);
                        break;
                    case ContentAlignment.BottomRight:
                        e.Graphics.DrawImage(Image, Width - s.Width - Border, Height - s.Height - Border);
                        break;
                    case ContentAlignment.MiddleCenter:
                        e.Graphics.DrawImage(Image, (Width - s.Width) / 2, (Height - s.Height) / 2);
                        break;
                    case ContentAlignment.MiddleLeft:
                        e.Graphics.DrawImage(Image, Border, (Height - s.Height) / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        e.Graphics.DrawImage(Image, Width - s.Width - Border, (Height - s.Height) / 2);
                        break;
                    case ContentAlignment.TopCenter:
                        e.Graphics.DrawImage(Image, (Width - s.Width) / 2, Border);
                        break;
                    case ContentAlignment.TopLeft:
                        e.Graphics.DrawImage(Image, Border, Border);
                        break;
                    case ContentAlignment.TopRight:
                        e.Graphics.DrawImage(Image, Width - s.Width - Border, Border);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(Text))
            {
                SizeF s = e.Graphics.MeasureString(Text, Font);
                switch (TextAlign)
                {
                    case ContentAlignment.BottomCenter:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), (Width - s.Width) / 2, Height - s.Height - Border);
                        break;
                    case ContentAlignment.BottomLeft:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Border, Height - s.Height - Border);
                        break;
                    case ContentAlignment.BottomRight:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Width - s.Width - Border, Height - s.Height - Border);
                        break;
                    case ContentAlignment.MiddleCenter:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), (Width - s.Width) / 2, (Height - s.Height) / 2);
                        break;
                    case ContentAlignment.MiddleLeft:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Border, (Height - s.Height) / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Width - s.Width - Border, (Height - s.Height) / 2);
                        break;
                    case ContentAlignment.TopCenter:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), (Width - s.Width) / 2, Border);
                        break;
                    case ContentAlignment.TopLeft:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Border, Border);
                        break;
                    case ContentAlignment.TopRight:
                        e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Width - s.Width - Border, Border);
                        break;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            State = XButtonState.CLICKED;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            State = XButtonState.FOCUSED;
            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            State = XButtonState.FOCUSED;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            State = XButtonState.NONE;
            Refresh();
            base.OnMouseLeave(e);
        }
    }
}
