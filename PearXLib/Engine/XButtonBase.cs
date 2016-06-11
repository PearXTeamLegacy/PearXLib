﻿using System;
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
    public class XButtonBase : XTextControlBase
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

        /// <summary>
        /// </summary>
        [DefaultValue(typeof(Cursor), "Hand")]
        public override Cursor Cursor { get { return base.Cursor; } set { base.Cursor = value; } }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(Image != null)
            {
                Size s = Image.Size;
                float x = 0;
                float y = 0;
                switch(ImageAlign)
                {
                    case ContentAlignment.BottomCenter:
                        x = (Width - s.Width) / 2;
                        y = Height - s.Height - Border;
                        break;
                    case ContentAlignment.BottomLeft:
                        x = Border;
                        y = Height - s.Height - Border;
                        break;
                    case ContentAlignment.BottomRight:
                        x = Width - s.Width - Border;
                        y = Height - s.Height - Border;
                        break;
                    case ContentAlignment.MiddleCenter:
                        x = (Width - s.Width) / 2;
                        y = (Height - s.Height) / 2;
                        break;
                    case ContentAlignment.MiddleLeft:
                        x = Border;
                        y = (Height - s.Height) / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        x = Width - s.Width - Border;
                        y = (Height - s.Height) / 2;
                        break;
                    case ContentAlignment.TopCenter:
                        x = (Width - s.Width) / 2;
                        y = Border;
                        break;
                    case ContentAlignment.TopLeft:
                        x = Border;
                        y = Border;
                        break;
                    case ContentAlignment.TopRight:
                        x = Width - s.Width - Border;
                        y = Border;
                        break;
                }
                e.Graphics.DrawImage(Image, x, y, Image.Width, Image.Height);
            }

            if (!string.IsNullOrEmpty(Text))
            {
                SizeF s = e.Graphics.MeasureString(Text, Font);
                float x = 0;
                float y = 0;
                switch (TextAlign)
                {
                    case ContentAlignment.BottomCenter:
                        x = (Width - s.Width)/2;
                        y = Height - s.Height - Border;
                        break;
                    case ContentAlignment.BottomLeft:
                        x = Border;
                        y = Height - s.Height - Border;
                        break;
                    case ContentAlignment.BottomRight:
                        x = Width - s.Width - Border;
                        y = Height - s.Height - Border;
                        break;
                    case ContentAlignment.MiddleCenter:
                        x = (Width - s.Width)/2;
                        y = (Height - s.Height)/2;
                        break;
                    case ContentAlignment.MiddleLeft:
                        x = Border;
                        y = (Height - s.Height) / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        x = Width - s.Width - Border;
                        y = (Height - s.Height) / 2;
                        break;
                    case ContentAlignment.TopCenter:
                        x = (Width - s.Width)/2;
                        y = Border;
                        break;
                    case ContentAlignment.TopLeft:
                        x = Border;
                        y = Border;
                        break;
                    case ContentAlignment.TopRight:
                        x = Width - s.Width - Border;
                        y = Border;
                        break;
                }
                DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new PointF(x, y));
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
