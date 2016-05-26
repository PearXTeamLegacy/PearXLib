using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine
{
    /// <summary>
    /// A control to display the Items.
    /// </summary>
    public class InvItem : InvItemBase
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ItemImage != null)
            {
                e.Graphics.DrawImage(ItemImage, 0, 0, Size.Width / 3, Size.Height);
            }
            DrawFancyText(e.Graphics, ItemName, Font, new SolidBrush(ColorName), new PointF(Size.Width / 3, 0));
            DrawFancyText(e.Graphics, ItemDesc, new Font(Font.FontFamily, Font.Size / 1.5F), new SolidBrush(ColorDesc), new PointF(Size.Width / 3, 0 + e.Graphics.MeasureString(ItemDesc, Font).Height));
            if(ShowAmount)
                DrawFancyText(e.Graphics, ItemAmount.ToString(), Font, new SolidBrush(ColorAmount), new PointF(Size.Width / 3, Size.Height - e.Graphics.MeasureString(ItemAmount.ToString(), Font).Height));
        }
    }
}
