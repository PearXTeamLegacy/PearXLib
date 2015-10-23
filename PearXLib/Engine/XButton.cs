using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PearXLib.Properties;

namespace PearXLib.Engine
{
    [DefaultEvent("Clicked")]
    public partial class XButton : UserControl
    {
        private string _XText;
        private Font _XFont;
        /// <summary>
        /// Text on Button.
        /// </summary>
        [Description("Text on Button.")]
        public string XText
        {
            get { return _XText; }
            set
            {
                _XText = value;
                labelText.Text = _XText;
                int _bWidth = b.Size.Width / 2;
                int _tWidth = labelText.Size.Width / 2;
                int _tHeight = labelText.Size.Height / 2;
                int _bHeight = b.Size.Height / 2;
                labelText.Location = new Point(_bWidth - _tWidth, _bHeight - _tHeight);
            }
        }
        /// <summary>
        /// Button's Font.
        /// </summary>
        [Description("Button's Font.")]
        public Font XFont 
        {
            get { return _XFont; }
            set
            {
                _XFont = value;
                labelText.Font = XFont;
                int _bWidth = b.Size.Width / 2;
                int _tWidth = labelText.Size.Width / 2;
                int _tHeight = labelText.Size.Height / 2;
                int _bHeight = b.Size.Height / 2;
                labelText.Location = new Point(_bWidth - _tWidth, _bHeight - _tHeight);
            }
        }
        /// <summary>
        /// Button Click Event.
        /// </summary>
        [Description("Click Event.")]
        public event EventHandler Clicked
        {
            add { b.Click += value; labelText.Click += value; }
            remove { b.Click -= value; labelText.Click -= value; }
        }
        public XButton()
        {
            InitializeComponent();
            labelText.Parent = b;
        }

        void setToXButton(object sender, EventArgs e)
        {
            b.Image = Resources.XButton;
        }

        void setToXButtonFocused(object sender, EventArgs e)
        {
            b.Image = Resources.XButtonFocused;
        }

        void setToXButtonPressed(object sender, EventArgs e)
        {
            b.Image = Resources.XButtonPressed;
        }

        private void b_Resize(object sender, EventArgs e)
        {
            int _bWidth = b.Size.Width / 2;
            int _tWidth = labelText.Size.Width / 2;
            int _tHeight = labelText.Size.Height / 2;
            int _bHeight = b.Size.Height / 2;
            labelText.Location = new Point(_bWidth - _tWidth, _bHeight - _tHeight);
        }
    }
}
