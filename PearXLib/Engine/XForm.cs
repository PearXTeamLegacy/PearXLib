using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    public partial class XForm : Form
    {
        private bool _MaximizeBox = true;
        private bool _ToTrayBox = true;
        private bool _CloseBox = true;

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
        #endregion

        #region Private state
        private State GetState()
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
        #endregion

        private void XForm_Paint(object sender, PaintEventArgs e)
        {
            if(CloseBox)
            {
                if (barstate == BarState.Close)
                {
                    e.Graphics.DrawImage(ImageCloseBoxFocused, Size.Width - 34, 2, 32, 32);
                }
                else
                {
                    e.Graphics.DrawImage(ImageCloseBox, Size.Width - 34, 2, 32, 32);
                }
            }

            if(MaximizeBox)
            {
                if (maximizeState == false)
                {
                    if (barstate == BarState.Maximize)
                    {
                        e.Graphics.DrawImage(ImageMaximizeBoxFocused, Size.Width - 68, 2, 32, 32);
                    }
                    else
                    {
                        e.Graphics.DrawImage(ImageMaximizeBox, Size.Width - 68, 2, 32, 32);
                    }
                }
                else
                {
                    if (barstate == BarState.Maximize)
                    {
                        e.Graphics.DrawImage(ImageMinimizeBoxFocused, Size.Width - 68, 2, 32, 32);
                    }
                    else
                    {
                        e.Graphics.DrawImage(ImageMinimizeBox, Size.Width - 68, 2, 32, 32);
                    }
                }
            }

            if (ToTrayBox)
            {
                if (barstate == BarState.ToTray)
                {
                    e.Graphics.DrawImage(ImageToTrayBoxFocused, Size.Width - 102, 2, 32, 32);
                }
                else
                {
                    e.Graphics.DrawImage(ImageToTrayBox, Size.Width - 102, 2, 32, 32);
                }
            }
        }

        private void XForm_MouseDown(object sender, MouseEventArgs e)
        {
            state = GetState();
            if (barstate == BarState.Close && CloseBox)
            {
                Close();
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
                    Maximized(this, new EventArgs());
                }
                else
                {
                    maximizeState = false;
                    Location = lastLocation;
                    Size = lastSize;
                    Refresh();
                    Minimized(this, new EventArgs());
                }
            }
            else if (barstate == BarState.ToTray && ToTrayBox)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Minimized;
                    TurnedToTray(this, new EventArgs());
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    ExpandedFromTray(this, new EventArgs());
                }
            }
        }

        private void XForm_Load(object sender, EventArgs e)
        {
            MouseHook.MouseMove += MouseHook_MouseMove;
            MouseHook.MouseUp += MouseHook_MouseUp;
            MouseHook.InstallHook();
        }

        private void XForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Close Box:
            if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - 34, Location.Y + 2), new Point((Location.X + Size.Width) - 2, Location.Y + 34)))
            {
                if (barstate != BarState.Close)
                {
                    barstate = BarState.Close;
                    Refresh();
                }
            }

            //Maximize Box:
            else if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - 68, Location.Y + 2), new Point((Location.X + Size.Width) - 36, Location.Y + 32)))
            {
                if (barstate != BarState.Maximize)
                {
                    barstate = BarState.Maximize;
                    Refresh();
                }
            }

            //ToTray Box:
            else if (PXL.IsCursorOnElement(new Point((Location.X + Size.Width) - 102, Location.Y + 2), new Point((Location.X + Size.Width) - 70, Location.Y + 32)))
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
                Refresh();
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

        private void XForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MouseHook.UnInstallHook();
        }
    }
}
