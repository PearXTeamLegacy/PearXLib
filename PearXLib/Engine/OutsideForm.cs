using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A form for outside using B)
    /// </summary>
    public class OutsideForm : Form
    {
        /// <summary>
        /// Initializes new OutsizeForm
        /// </summary>
        public OutsideForm()
        {
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            ShowInTaskbar = false;
            Size = new Size(256, 128);
        }
    }
}
