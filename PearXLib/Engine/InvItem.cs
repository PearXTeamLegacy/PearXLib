using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    /// <summary>
    /// A control to display items in the inventory.
    /// </summary>
    /// <seealso cref="InvItemBase" />
    public class InvItem : InvItemBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvItem"/> class.
        /// </summary>
        public InvItem()
        {
            Paint += ControlPaint;
        }

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            if (ItemImage != null)
            {
                e.Graphics.DrawImage(ItemImage, 0, 0, Size.Width / 3, Size.Height);
            }
            DrawFancyText(e.Graphics, ItemName, Font, new SolidBrush(ColorName), new PointF(Size.Width / 3.0f, 0));
            DrawFancyText(e.Graphics, ItemDesc, new Font(Font.FontFamily, Font.Size * 0.5F), new SolidBrush(ColorDesc), new PointF(Size.Width / 3f, e.Graphics.MeasureString(ItemDesc, Font).Height));
            if(ShowAmount)
                DrawFancyText(e.Graphics, ItemAmount.ToString(), Font, new SolidBrush(ColorAmount), new PointF(Size.Width / 3f, Size.Height - e.Graphics.MeasureString(ItemAmount.ToString(), Font).Height));
        }
    }
}
