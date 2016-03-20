using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful customizing form.
    /// </summary>
    public class XForm : Form
    {
        private bool _MaximizeBox = true;
        private bool _ToTrayBox = true;
        private bool _CloseBox = true;
        private int _BoxesDistance = 2;
        private int _BoxesTopDistance = 2;
        private Image _BarImage = FormIcons.BarImage;
        private Color _TextColor = Color.Black;

        private Image _ImageCloseBox = FormIcons.CloseBox;
        private Image _ImageCloseBoxFocused = FormIcons.CloseBoxFocused;
        private Image _ImageMaximizeBox = FormIcons.MaximizeBox;
        private Image _ImageMaximizeBoxFocused = FormIcons.MaximizeBoxFocused;
        private Image _ImageMinimizeBox = FormIcons.MinimizeBox;
        private Image _ImageMinimizeBoxFocused = FormIcons.MinimizeBoxFocused;
        private Image _ImageToTrayBox = FormIcons.ToTrayBox;
        private Image _ImageToTrayBoxFocused = FormIcons.ToTrayBoxFocused;
        
        private enum State { Move, None }
        /// <summary>
        /// Bar state.
        /// </summary>
        public enum BarState
        {
            /// <summary>
            /// Focused close button.
            /// </summary>
            Close,
            /// <summary>
            /// Focused to tray button.
            /// </summary>
            ToTray,
            /// <summary>
            /// Focused maximize button.
            /// </summary>
            Maximize,
            /// <summary>
            /// None focused.
            /// </summary>
            None
        }
        private State state = State.None;
        /// <summary>
        /// Last bar state.
        /// </summary>
        public BarState BarSt = BarState.None;
        private Point lastOffset;
        private Point lastMousePoint = MousePosition;
        /// <summary>
        /// True if form maximized, else false.
        /// </summary>
        public bool MaximizeState;
        private Size lastSize;
        private Point lastLocation;
        private int i;

        /// <summary>
        /// Initializates a new XForm component.
        /// </summary>
        public XForm()
        {
            AutoScaleMode = AutoScaleMode.Font;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
        }

        #region Params
        /// <summary>
        /// Performs on form minimized.
        /// </summary>
        public event EventHandler Minimized;

        /// <summary>
        /// Performs on form maximized.
        /// </summary>
        public event EventHandler Maximized;

        /// <summary>
        /// Performs on form turned to tray.
        /// </summary>
        public event EventHandler TurnedToTray;

        /// <summary>
        /// Performs on form expanded from tray.
        /// </summary>
        public event EventHandler ExpandedFromTray;

        /// <summary>
        /// Performs on any bar icon focused.
        /// </summary>
        public event EventHandler BarIconFocused;

        /// <summary>
        /// Is maximize box enabled?
        /// </summary>
        [Description("Is maximize box enabled?"), DefaultValue(true)]
        public new virtual bool MaximizeBox
        {
            get { return _MaximizeBox; }
            set { _MaximizeBox = value; Refresh(); }
        }

        /// <summary>
        /// Is turn to tray box enabled?
        /// </summary>
        [Description("Is turn to tray box enabled?"), DefaultValue(true)]
        public virtual bool ToTrayBox
        {
            get { return _ToTrayBox; }
            set { _ToTrayBox = value; Refresh(); }
        }

        /// <summary>
        /// Is close box enabled?
        /// </summary>
        [Description("Is close box enabled?"), DefaultValue(true)]
        public virtual bool CloseBox
        {
            get { return _CloseBox; }
            set { _CloseBox = value; Refresh(); }
        }

        /// <summary>
        /// Image for a close box.
        /// </summary>
        [Description("Image for a close box.")]
        public virtual Image ImageCloseBox
        {
            get { return _ImageCloseBox; }
            set { _ImageCloseBox = value; Refresh(); }
        }

        /// <summary>
        /// Image for a focused close box.
        /// </summary>
        [Description("Image for a focused close box.")]
        public virtual Image ImageCloseBoxFocused
        {
            get { return _ImageCloseBoxFocused; }
            set { _ImageCloseBoxFocused = value; Refresh(); }
        }

        /// <summary>
        /// Image for a maximize box.
        /// </summary>
        [Description("Image for a maximize box.")]
        public virtual Image ImageMaximizeBox
        {
            get { return _ImageMaximizeBox; }
            set { _ImageMaximizeBox = value; Refresh(); }
        }

        /// <summary>
        /// Image for a focused maximize box.
        /// </summary>
        [Description("Image for a focused maximize box.")]
        public virtual Image ImageMaximizeBoxFocused
        {
            get { return _ImageMaximizeBoxFocused; }
            set { _ImageMaximizeBoxFocused = value; Refresh(); }
        }

        /// <summary>
        /// Image for a minimize box.
        /// </summary>
        [Description("Image for a minimize box.")]
        public virtual Image ImageMinimizeBox
        {
            get { return _ImageMinimizeBox; }
            set { _ImageMinimizeBox = value; Refresh(); }
        }

        /// <summary>
        /// Image for a focused minimize box.
        /// </summary>
        [Description("Image for a focused minimize box.")]
        public virtual Image ImageMinimizeBoxFocused
        {
            get { return _ImageMinimizeBoxFocused; }
            set { _ImageMinimizeBoxFocused = value; Refresh(); }
        }

        /// <summary>
        /// Image for a turn to tray box.
        /// </summary>
        [Description("Image for a turn to tray box.")]
        public virtual Image ImageToTrayBox
        {
            get { return _ImageToTrayBox; }
            set { _ImageToTrayBox = value; Refresh(); }
        }
        
        /// <summary>
        /// Image for a focused turn to tray box.
        /// </summary>
        [Description("Image for a focused turn to tray box.")]
        public virtual Image ImageToTrayBoxFocused
        {
            get { return _ImageToTrayBoxFocused; }
            set { _ImageToTrayBoxFocused = value; Refresh(); }
        }

        /// <summary>
        /// Boxes distance from one to other.
        /// </summary>
        [Description("Boxes distance from one to other."), DefaultValue(2)]
        public virtual int BoxesDistance
        {
            get { return _BoxesDistance; }
            set { _BoxesDistance = value; Refresh(); }
        }

        /// <summary>
        /// Boxes distance from form top.
        /// </summary>
        [Description("Boxes distance from form top."), DefaultValue(2)]
        public virtual int BoxesTopDistance
        {
            get { return _BoxesTopDistance; }
            set { _BoxesTopDistance = value; Refresh(); }
        }

        /// <summary>
        /// Form bar background image.
        /// </summary>
        [Description("Form bar background image.")]
        public virtual Image BarImage
        {
            get { return _BarImage; }
            set { _BarImage = value; Refresh(); }
        }

        /// <summary>
        /// Color of the Form Name.
        /// </summary>
        [Description("Color of the Form Name."), DefaultValue(typeof(Color), "Black")]
        public virtual Color TextColor
        {
            get { return _TextColor; }
            set { _TextColor = value; Refresh(); }
        }
        #endregion

        #region Private state
        private State GetState()
        {
            if (BarImage == null)
            {
                if (PXL.IsCursorOnElement(Location, Location + Size))
                {
                    return State.Move;
                }
                else
                {
                    return State.None;
                }
            }
            else
            {
                if (PXL.IsCursorOnElement(Location, new Point(Location.X + Size.Width, Location.Y + BarImage.Height)))
                {
                    return State.Move;
                }
                else
                {
                    return State.None;
                }
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BarImage != null)
            {
                TextureBrush tb = new TextureBrush(BarImage);
                e.Graphics.FillRectangle(tb, 0, 0, Size.Width, BarImage.Height);
            }
            if (CloseBox)
            {
                if (BarSt == BarState.Close && ImageCloseBoxFocused != null)
                {
                    e.Graphics.DrawImage(ImageCloseBoxFocused, Size.Width - (32 + BoxesDistance), BoxesTopDistance, 32, 32);
                }
                else if (ImageCloseBox != null)
                {
                    e.Graphics.DrawImage(ImageCloseBox, Size.Width - (32 + BoxesDistance), BoxesTopDistance, 32, 32);
                }
            }

            if (MaximizeBox)
            {
                if (MaximizeState == false)
                {
                    if (BarSt == BarState.Maximize && ImageMaximizeBoxFocused != null)
                    {
                        e.Graphics.DrawImage(ImageMaximizeBoxFocused, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                    else if (ImageMaximizeBox != null)
                    {
                        e.Graphics.DrawImage(ImageMaximizeBox, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                }
                else
                {
                    if (BarSt == BarState.Maximize && ImageMinimizeBoxFocused != null)
                    {
                        e.Graphics.DrawImage(ImageMinimizeBoxFocused, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                    else if (ImageMinimizeBox != null)
                    {
                        e.Graphics.DrawImage(ImageMinimizeBox, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                }
            }

            if (ToTrayBox)
            {
                if (BarSt == BarState.ToTray && ImageToTrayBoxFocused != null)
                {
                    e.Graphics.DrawImage(ImageToTrayBoxFocused, Size.Width - (96 + (BoxesDistance * 3)), BoxesTopDistance, 32, 32);
                }
                else if (ImageToTrayBox != null)
                {
                    e.Graphics.DrawImage(ImageToTrayBox, Size.Width - (96 + (BoxesDistance * 3)), BoxesTopDistance, 32, 32);
                }
            }

            if (Text != null)
            {
                e.Graphics.DrawString(Text, Font, new SolidBrush(TextColor), new PointF(1, 1));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            state = GetState();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            lastOffset = new Point(MousePosition.X - lastMousePoint.X, MousePosition.Y - lastMousePoint.Y);
            if (state == State.Move)
            {
                Location = new Point(Location.X + lastOffset.X, Location.Y + lastOffset.Y);
            }
            lastMousePoint = MousePosition;

            //Close Box:
            if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - (32 + BoxesDistance), Location.Y + BoxesTopDistance), new Point((Location.X + Size.Width) - BoxesDistance, Location.Y + (32 + BoxesTopDistance))) && CloseBox)
            {
                if (BarSt != BarState.Close)
                {
                    BarSt = BarState.Close;
                    Cursor = Cursors.Hand;
                    Refresh();
                }
            }

            //Maximize Box:
            else if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - (64 + (BoxesDistance * 2)), Location.Y + BoxesTopDistance), new Point((Location.X + Size.Width) - (32 + (BoxesDistance * 2)), Location.Y + (32 + BoxesTopDistance))) && MaximizeBox)
            {
                if (BarSt != BarState.Maximize)
                {
                    BarSt = BarState.Maximize;
                    Cursor = Cursors.Hand;
                    Refresh();
                }
            }

            //ToTray Box:
            else if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - (96 + (BoxesDistance * 3)), Location.Y + BoxesTopDistance), new Point((Location.X + Size.Width) - (64 + (BoxesDistance * 3)), Location.Y + (32 + BoxesTopDistance))) && ToTrayBox)
            {
                if (BarSt != BarState.ToTray)
                {
                    BarSt = BarState.ToTray;
                    Cursor = Cursors.Hand;
                    Refresh();
                }
            }

            else if (BarSt != BarState.None)
            {
                BarSt = BarState.None;
                i = 0;
                Refresh();
            }
            else
                Cursor = Cursors.Arrow;

            if (BarSt != BarState.None)
            {
                if (BarIconFocused != null && i == 0)
                    BarIconFocused(this, new EventArgs());
                i = 1;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            state = State.None;

            if (BarSt == BarState.Close && CloseBox)
            {
                Close();
            }
            else if (BarSt == BarState.Maximize && MaximizeBox)
            {
                if (MaximizeState == false)
                {
                    MaximizeState = true;
                    lastLocation = Location;
                    lastSize = Size;
                    Location = new Point(0, 0);
                    Size = Screen.PrimaryScreen.WorkingArea.Size;
                    Refresh();
                    Maximized?.Invoke(this, new EventArgs());
                }
                else
                {
                    MaximizeState = false;
                    Location = lastLocation;
                    Size = lastSize;
                    Refresh();
                    Minimized?.Invoke(this, new EventArgs());
                }
            }
            else if (BarSt == BarState.ToTray && ToTrayBox)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Minimized;
                    TurnedToTray?.Invoke(this, new EventArgs());
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    ExpandedFromTray?.Invoke(this, new EventArgs());
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BarSt = BarState.None;
            Refresh();
        }
    }
}
