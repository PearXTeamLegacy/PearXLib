using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using PearXLib.Properties;

namespace PearXLib.Engine
{
    public partial class XIcon : UserControl
    {
        private Image _Icon;
        private bool _PlaySound = true;
        public XIcon() 
        {
            InitializeComponent();
            foreach (Control c in Controls)
            {
                c.Click += c_Click;
                c.DoubleClick += c_DoubleClick;
                c.MouseEnter += c_MouseEnter;
                c.MouseLeave += c_MouseLeave;
                c.MouseDoubleClick += c_MouseDoubleClick;
                c.MouseDown += c_MouseDown;
                c.MouseUp += c_MouseUp;
                c.MouseHover += c_MouseHover;
                c.MouseMove += c_MouseMove;
            }
        }

        #region Properties.
        public Image Icon
        {
            get { return _Icon; }
            set
            {
                _Icon = value;
                BackgroundImage = _Icon;
            }
        }

        [DefaultValue(true)]
        public bool PlaySound
        {
            get { return _PlaySound; }
            set { _PlaySound = value; }
        }
        #endregion

        #region Fixed events.
        private void c_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        private void c_MouseHover(object sender, EventArgs e)
        {
            OnMouseHover(e);
        }

        private void c_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private void c_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void c_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        private void c_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void c_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void c_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void c_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
        #endregion

        private void XIcon_MouseEnter(object sender, EventArgs e)
        {
            Location = new Point(Location.X - 15, Location.Y - 15);
            Size = new Size(Size.Width + 15, Size.Height + 15);
            if (PlaySound)
            {
                SoundPlayer sp = new SoundPlayer(Resources.bd);
                sp.Play();
            }
        }

        private void XIcon_MouseLeave(object sender, EventArgs e)
        {
            Location = new Point(Location.X + 15, Location.Y + 15);
            Size = new Size(Size.Width - 15, Size.Height - 15);
        }
    }
}
