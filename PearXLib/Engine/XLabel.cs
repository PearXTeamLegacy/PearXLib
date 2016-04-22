using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    public class XLabel : XTextControlBase
    {
        private string text;

        #region Params
        /// <summary>
        /// The text on the control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text
        {
            get { return text; }
            set { text = value; Refresh(); }
        }
        #endregion

        private Graphics g;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Size s = e.Graphics.MeasureString(Text, Font).ToSize();
            MinimumSize = s;
            MaximumSize = s;
            DrawFancyText(e.Graphics, Text, Font, new SolidBrush(ForeColor), new Point(0, 0));
        }
    }
}
