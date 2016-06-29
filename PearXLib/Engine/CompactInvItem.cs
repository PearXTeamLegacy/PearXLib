using System;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    public class CompactInvItem : InvItemBase
    {
        public TooltipForm Tooltip { get; set; }

        public CompactInvItem()
        {
            Size = new Size(64, 64);
            Tooltip = new TooltipForm();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ItemImage != null)
            {
                e.Graphics.DrawImage(ItemImage, 0, 0, Width, Height);
            }
            if (ShowAmount)
            {
                SizeF s = e.Graphics.MeasureString(ItemAmount.ToString(), Font);
                DrawFancyText(e.Graphics, ItemAmount.ToString(), Font, new SolidBrush(ColorAmount), new PointF(Width - s.Width, Height - s.Height));
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Tooltip.NameText = ItemName;
            Tooltip.TooltipText = ItemDesc;
            UpdateTooltipPos();
            Tooltip.Show();
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            Tooltip.Hide();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            UpdateTooltipPos();
        }

        private void UpdateTooltipPos()
        {
            Tooltip.Location = new Point(MousePosition.X + Cursor.Size.Width, MousePosition.Y);
        }
    }
}
