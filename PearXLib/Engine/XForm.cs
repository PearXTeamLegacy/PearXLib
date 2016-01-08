using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A beautiful customizing form.
    /// </summary>
    public partial class XForm : Form
    {
        private bool _MaximizeBox = true;
        private bool _ToTrayBox = true;
        private bool _CloseBox = true;
        private int _BoxesDistance = 2;
        private int _BoxesTopDistance = 2;
        private Image _BarImage = FormIcons.BarImage;

        private Image _ImageCloseBox = FormIcons.CloseBox;
        private Image _ImageCloseBoxFocused = FormIcons.CloseBoxFocused;
        private Image _ImageMaximizeBox = FormIcons.MaximizeBox;
        private Image _ImageMaximizeBoxFocused = FormIcons.MaximizeBoxFocused;
        private Image _ImageMinimizeBox = FormIcons.MinimizeBox;
        private Image _ImageMinimizeBoxFocused = FormIcons.MinimizeBoxFocused;
        private Image _ImageToTrayBox = FormIcons.ToTrayBox;
        private Image _ImageToTrayBoxFocused = FormIcons.ToTrayBoxFocused;
        
        private enum State { ResizeWS, ResizeEN, Move, None }
        private enum BarState { Close, ToTray, Maximize, None }
        private State state = State.None;
        private BarState barstate = BarState.None;
        private Point lastOffset;
        private Point lastMousePoint = MousePosition;
        private bool maximizeState = false;
        private Size lastSize;
        private Point lastLocation;
        private int i = 0;

        /// <summary>
        /// Initializates a new XForm component.
        /// </summary>
        public XForm()
        {
            InitializeComponent();
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
        public virtual new bool MaximizeBox
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

        private void XForm_Paint(object sender, PaintEventArgs e)
        {
            if (BarImage != null)
            {
                TextureBrush tb = new TextureBrush(BarImage);
                e.Graphics.FillRectangle(tb, 0, 0, Size.Width, BarImage.Height);
            }
            if(CloseBox)
            {
                if (barstate == BarState.Close)
                {
                    e.Graphics.DrawImage(ImageCloseBoxFocused, Size.Width - (32 + BoxesDistance), BoxesTopDistance, 32, 32);
                }
                else
                {
                    e.Graphics.DrawImage(ImageCloseBox, Size.Width - (32 + BoxesDistance), BoxesTopDistance, 32, 32);
                }
            }

            if(MaximizeBox)
            {
                if (maximizeState == false)
                {
                    if (barstate == BarState.Maximize)
                    {
                        e.Graphics.DrawImage(ImageMaximizeBoxFocused, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                    else
                    {
                        e.Graphics.DrawImage(ImageMaximizeBox, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                }
                else
                {
                    if (barstate == BarState.Maximize)
                    {
                        e.Graphics.DrawImage(ImageMinimizeBoxFocused, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                    else
                    {
                        e.Graphics.DrawImage(ImageMinimizeBox, Size.Width - (64 + (BoxesDistance * 2)), BoxesTopDistance, 32, 32);
                    }
                }
            }

            if (ToTrayBox)
            {
                if (barstate == BarState.ToTray)
                {
                    e.Graphics.DrawImage(ImageToTrayBoxFocused, Size.Width - (96 + (BoxesDistance * 3)), BoxesTopDistance, 32, 32);
                }
                else
                {
                    e.Graphics.DrawImage(ImageToTrayBox, Size.Width - (96 + (BoxesDistance * 3)), BoxesTopDistance, 32, 32);
                }
            }
        }

        private void XForm_MouseDown(object sender, MouseEventArgs e)
        {
            state = GetState();
            
        }

        private void XForm_Load(object sender, EventArgs e)
        {
            this.MouseMove += MouseHook_MouseMove;
            this.MouseUp += MouseHook_MouseUp;
        }

        private void XForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Close Box:
            if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - (32 + BoxesDistance), Location.Y + BoxesTopDistance), new Point((Location.X + Size.Width) - BoxesDistance, Location.Y + (32 + BoxesTopDistance))) && CloseBox)
            {
                if (barstate != BarState.Close)
                {
                    barstate = BarState.Close;
                    Refresh();
                }
            }

            //Maximize Box:
            else if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - (64 + (BoxesDistance * 2)), Location.Y + BoxesTopDistance), new Point((Location.X + Size.Width) - (32 + (BoxesDistance * 2)), Location.Y + (32 + BoxesTopDistance))) && MaximizeBox)
            {
                if (barstate != BarState.Maximize)
                {
                    barstate = BarState.Maximize;
                    Refresh();
                }
            }

            //ToTray Box:
            else if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - (96 + (BoxesDistance * 3)), Location.Y + BoxesTopDistance), new Point((Location.X + Size.Width) - (64 + (BoxesDistance * 3)), Location.Y + (32 + BoxesTopDistance))) && ToTrayBox)
            {
                if (barstate != BarState.ToTray)
                {
                    barstate = BarState.ToTray;
                    Refresh();
                }
            }

            else if (barstate != BarState.None)
            {
                barstate = BarState.None;
                i = 0;
                Refresh();
            }

            if (barstate != BarState.None)
            {
                if (BarIconFocused != null && i == 0)
                    BarIconFocused(this, new EventArgs());
                i = 1;
            }
        }

        private void MouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            state = State.None;
        }

        private void MouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            lastOffset = new Point(MousePosition.X - lastMousePoint.X, MousePosition.Y - lastMousePoint.Y);
            if (state == State.Move)
            {
                Location = new Point(Location.X + lastOffset.X, Location.Y + lastOffset.Y);
            }
            lastMousePoint = MousePosition;
        }

        private void XForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (barstate == BarState.Close && CloseBox)
            {
                base.Close();
            }
            else if (barstate == BarState.Maximize && MaximizeBox)
            {
                if (maximizeState == false)
                {
                    maximizeState = true;
                    lastLocation = Location;
                    lastSize = Size;
                    Location = new Point(0, 0);
                    Size = Screen.PrimaryScreen.WorkingArea.Size;
                    Refresh();
                    if (Maximized != null)
                        Maximized(this, new EventArgs());
                }
                else
                {
                    maximizeState = false;
                    Location = lastLocation;
                    Size = lastSize;
                    Refresh();
                    if (Minimized != null)
                        Minimized(this, new EventArgs());
                }
            }
            else if (barstate == BarState.ToTray && ToTrayBox)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Minimized;
                    if (TurnedToTray != null)
                        TurnedToTray(this, new EventArgs());
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    if (ExpandedFromTray != null)
                        ExpandedFromTray(this, new EventArgs());
                }
            }
        }

        private void XForm_MouseLeave(object sender, EventArgs e)
        {
            barstate = BarState.None;
            Refresh();
        }
    }
}
