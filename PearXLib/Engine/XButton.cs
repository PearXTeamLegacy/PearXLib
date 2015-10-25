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
        private string _XText = "A Button";
        private Font _XFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
        private Align _XAlign = Align.CENTER;

        void AlignText()
        {
            int _bWidth2 = b.Size.Width / 2;
            int _tWidth2 = labelText.Size.Width / 2;
            int _tHeight2 = labelText.Size.Height / 2;
            int _bHeight2 = b.Size.Height / 2;
            int _bWidth = b.Size.Width;
            int _tWidth = labelText.Size.Width;

            if (XAlign == Align.CENTER)
            {
                labelText.Location = new Point(_bWidth2 - _tWidth2, _bHeight2 - _tHeight2);
            }
            else if (XAlign == Align.RIGHT)
            {
                labelText.Location = new Point(_bWidth - _tWidth, _bHeight2 - _tHeight2);
            }
            else if (XAlign == Align.LEFT)
            {
                labelText.Location = new Point(0, _bHeight2 - _tHeight2);
            }
        }

        /// <summary>
        /// Button's Align
        /// </summary>
        [Description("Button's Align")]
        public Align XAlign
        {
            get { return _XAlign; }
            set
            {
                _XAlign = value;
                AlignText();
            }
        }
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
                AlignText();
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
            AlignText();
        }
    }
}
