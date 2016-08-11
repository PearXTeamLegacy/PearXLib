using System;
using System.Drawing;

namespace PearXLib.Engine
{
    /// <summary>
    /// THe Form, created for making tooltips.
    /// </summary>
    /// <seealso cref="OutsideForm" />
    public class TooltipForm : OutsideForm
    {
        /// <summary>
        /// Item Name's label.
        /// </summary>
        public XLabel NameLabel = new XLabel();
        /// <summary>
        /// Item Tooltip's label.
        /// </summary>
        public XLabel TooltipLabel = new XLabel();

        /// <summary>
        /// The right, left, top, bottom text offset.
        /// </summary>
        public int TextOffset { get; set; } = 3;

        /// <summary>
        /// The NameLabel's text.
        /// </summary>
        public string NameText
        {
            get { return NameLabel.Text; }
            set { NameLabel.Text = value; }
        }

        /// <summary>
        /// The TooltipLabel's text.
        /// </summary>
        public string TooltipText
        {
            get { return TooltipLabel.Text; }
            set { TooltipLabel.Text = value; }
        }

        /// <summary>
        /// The NameLabel's font.
        /// </summary>
        public Font NameFont
        {
            get { return NameLabel.Font; }
            set { NameLabel.Font = value; }
        }

        /// <summary>
        /// The TooltipLabel's font
        /// </summary>
        public Font TooltipFont
        {
            get { return TooltipLabel.Font; }
            set { TooltipLabel.Font = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooltipForm"/> class.
        /// </summary>
        public TooltipForm()
        {
            Controls.Add(NameLabel);
            Controls.Add(TooltipLabel);
        }

        /// <summary>
        /// Refreshes the size and controls.
        /// </summary>
        public void RefreshControls()
        {
            NameLabel.Location = new Point(TextOffset, TextOffset);
            TooltipLabel.Location = new Point(TextOffset, TextOffset + NameLabel.Size.Height);
            Size = new Size(TextOffset * 2 + Math.Max(NameLabel.Width, TooltipLabel.Width), TextOffset * 2 + NameLabel.Height + TooltipLabel.Height);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            RefreshControls();
        }
    }
}
