using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine.Bases
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
    /// Base for all PearXLib's buttons.
    /// </summary>
    [DefaultEvent("Click")]
    public class XButtonBase : XTextControlBase
    {
        private string _Text = "A button.";
        private Image _Image;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleRight;
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        private XButtonState _State = XButtonState.NONE;
        private int _Border;

        /// <summary>
        /// Initializes a new instance of the <see cref="XButtonBase"/> class.
        /// </summary>
        public XButtonBase()
        {
            MouseDown += ControlMouseDown;
            MouseUp += ControlMouseUp;
            MouseEnter += ControlMouseEnter;
            MouseLeave += ControlMouseLeave;
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
        [DefaultValue(64)]
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set { _ImageAlign = value; Refresh(); }
        }

        /// <summary>
        /// Text alignment.
        /// </summary>
        [DefaultValue(32)]
        public ContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set { _TextAlign = value; Refresh(); }
        }

        /// <summary>
        /// Text on the button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text
        {
            get { return _Text; }
            set { _Text = value; Refresh(); }
        }

        /// <summary>
        /// Image on the button.
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

        /// <summary>
        /// </summary>
        [DefaultValue(typeof (Cursor), "Hand")]
        public override Cursor Cursor { get; set; } = Cursors.Hand;

        #endregion

        /// <summary>
        /// Paints the base.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected void PaintBase(PaintEventArgs e)
        {
            if(Image != null)
            {
                PointF point = PXL.AlignPoint(ImageAlign, Size, Image.Size, Border);
                e.Graphics.DrawImage(Image, point.X, point.Y, Image.Width, Image.Height);
            }

            if (!string.IsNullOrEmpty(Text))
            {
                PointF point = PXL.AlignPoint(TextAlign, Size, e.Graphics.MeasureString(Text, Font), Border);
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), point);
            }
        }

        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            State = XButtonState.CLICKED;
        }

        private void ControlMouseUp(object sender, MouseEventArgs e)
        {
            State = XButtonState.FOCUSED;
        }

        private void ControlMouseEnter(object sender, EventArgs e)
        {
            State = XButtonState.FOCUSED;
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            State = XButtonState.NONE;
        }
    }
}
