using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// Checkbox state
    /// </summary>
    public enum CheckboxState
    {
        /// <summary>
        /// Mouse on checkbox.
        /// </summary>
        Focused,
        /// <summary>
        /// Mouse not on checkbox.
        /// </summary>
        None
    }

    /// <summary>
    /// A base for the checkboxes :P.
    /// </summary>
    public class XCheckboxBase : UserControl
    {
        private string text;
        private bool chkd = false;
        private CheckboxState state = CheckboxState.None;

        /// <summary>
        /// Initializes a new XCheckboxBase component.
        /// </summary>
        public XCheckboxBase()
        {
            Size = new Size(160, 32);
        }

        #region Params
        /// <summary>
        /// A EventHandler for the checkboxes.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="isChecked">Is checkbox checked?</param>
        public delegate void CheckboxHandler(object sender, bool isChecked);

        /// <summary>
        /// Performs on check/uncheck.
        /// </summary>
        public event CheckboxHandler CheckedChanged;

        /// <summary>
        /// The text on the checkbox.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return text; }
            set { text = value; Refresh(); }
        }

        /// <summary>
        /// Is checkbox checked?
        /// </summary>
        public bool Checked
        {
            get { return chkd; }
            set
            {
                chkd = value;
                Refresh();
                if(CheckedChanged != null)
                    CheckedChanged(this, value);
            }
        }

        /// <summary>
        /// Checkbox's current state.
        /// </summary>
        public CheckboxState State
        {
            get { return state; }
            set { state = value;}
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            if(Text != null)
            {
                SizeF pf = e.Graphics.MeasureString(Text, Font);
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 5, (Height - pf.Height) / 2);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            Checked = !Checked;
            base.OnClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            state = CheckboxState.Focused;
            base.OnMouseEnter(e);
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = CheckboxState.None;
            base.OnMouseLeave(e);
            Refresh();
        }
    }
}
