using System;
using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// A compact <see cref="InvItem"/> variant.
    /// </summary>
    /// <seealso cref="InvItemBase" />
    public class CompactInvItem : InvItemBase
    {
        /// <summary>
        /// The tooltip class.
        /// </summary>
        public virtual TooltipForm Tooltip { get; set; } = new TooltipForm();

        /// <summary>
        /// Initializes a new instance of the <see cref="CompactInvItem"/> class.
        /// </summary>
        public CompactInvItem()
        {
            Size = new Size(64, 64);
            Paint += ControlPaint;
            MouseEnter += ControlMouseEnter;
            MouseLeave += ControlMouseLeave;
            MouseMove += ControlMouseMove;
        }

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            if (ItemImage != null)
                e.Graphics.DrawImage(ItemImage, 0, 0, Width, Height);
            if (ShowAmount)
            {
                SizeF s = e.Graphics.MeasureString(ItemAmount.ToString(), Font);
                DrawFancyText(e.Graphics, ItemAmount.ToString(), Font, new SolidBrush(ColorAmount), new PointF(Width - s.Width, Height - s.Height));
            }
        }

        private void ControlMouseEnter(object sender, EventArgs e)
        {
            Tooltip.NameText = ItemName;
            Tooltip.TooltipText = ItemDesc;
            UpdateTooltipPos();
            Tooltip.Show();
        }

        /// <summary>
        /// <see cref="Control.Dispose(bool)"/>
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try
            {
                Tooltip.Hide();
                Tooltip.Dispose();
            } catch{}
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            Tooltip.Hide();
        }

        private void ControlMouseMove(object sender, MouseEventArgs e)
        {
            UpdateTooltipPos();
        }

        private void UpdateTooltipPos()
        {
            Tooltip.Location = new Point(MousePosition.X + Cursor.Size.Width, MousePosition.Y);
        }
    }
}
