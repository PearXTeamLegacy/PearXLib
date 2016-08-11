using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine.Flat
{
    /// <summary>
    /// Flat Form.
    /// </summary>
    public class FlatForm : XFormBase
    {
        private Color _PanelColor = Color.FromArgb(37, 38, 41);
        private bool _Rim = true;
        private Color _RimColor = Color.FromArgb(18, 107, 166);
        private bool _DrawPanel = true;
        private int _RimSize = 1;
        private int _BoxSizes = 32;

        /// <summary>
        /// Initializes a new XForm component.
        /// </summary>
        public FlatForm()
        {
            
            Boxes.CloseBox = new FlatFormBox();
            Boxes.MaximizeBox = new FlatFormBox();
            Boxes.ToTrayBox = new FlatFormBox();

            for(int i = 0; i < Boxes.Count; i++)
            {
                FlatFormBox box = Boxes[i] as FlatFormBox;
                switch (i)
                {
                    case 0:
                        box.Color = Color.FromArgb(192, 57, 43);
                        box.FocusedColor = Color.FromArgb(231, 76, 60);
                        break;
                    case 1:
                        box.Color = Color.FromArgb(41, 128, 185);
                        box.FocusedColor = Color.FromArgb(52, 152, 219);
                        break;
                    case 2:
                        box.Color = Color.FromArgb(39, 174, 96);
                        box.FocusedColor = Color.FromArgb(46, 204, 113);
                        break;
                }
            }

            BackColor = FlatColors.NotQuiteBlack;
            ForeColor = Color.White;
            Paint += ControlPaint;
        }

        #region Params

        /// <summary>
        /// Color of the panel.
        /// </summary>
        public Color PanelColor { get { return _PanelColor; } set { _PanelColor = value; Refresh(); } }

        /// <summary>
        /// Color of the form rim.
        /// </summary>
        public Color RimColor { get { return _RimColor; } set { _RimColor = value; Refresh(); } }

        /// <summary>
        /// Enable form rim?
        /// </summary>
        [DefaultValue(true)]
        public bool Rim { get { return _Rim; } set { _Rim = value; Refresh(); } }

        /// <summary>
        /// The form rim thickness.
        /// </summary>
        [DefaultValue(1)]
        public int RimSize { get { return _RimSize; } set { _RimSize = value; Refresh(); } }

        /// <summary>
        /// Draw Panel?
        /// </summary>
        [DefaultValue(true)]
        public bool DrawPanel { get { return _DrawPanel; } set { _DrawPanel = value; Refresh(); } }

        /// <summary>
        /// Box sizes.
        /// </summary>
        [DefaultValue(32)]
        public int BoxSizes { get { return _BoxSizes; } set { _BoxSizes = value; Refresh(); } }
        #endregion

        public override void UpdateRectangles()
        {
            Boxes.CloseBox.Rectangle = new Rectangle(Width - RimSize - BoxSizes, RimSize, BoxSizes, BoxSizes);
            Boxes.MaximizeBox.Rectangle = new Rectangle(Width - RimSize - BoxSizes*2, RimSize, BoxSizes, BoxSizes);
            Boxes.ToTrayBox.Rectangle = new Rectangle(Width - RimSize - BoxSizes*3, RimSize, BoxSizes, BoxSizes);
        }

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            if(DrawPanel)
                e.Graphics.FillRectangle(new SolidBrush(PanelColor), 0, 0, Size.Width, BoxSizes);
            for(int i = 0; i < Boxes.Count; i++)
            {
                if (Boxes[i].Enabled)
                {
                    FlatFormBox box = Boxes[i] as FlatFormBox;
                    Color c = box.Focused ? box.FocusedColor : box.Color;
                    e.Graphics.FillRectangle(new SolidBrush(c), box.Rectangle);
                }
            }

            if (DrawTitle)
            {
                SizeF size = e.Graphics.MeasureString(Text, Font);
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), RimSize, (BoxSizes - size.Height) / 2f);
            }

            if (Rim)
            {
                float f = RimSize/2f;
                e.Graphics.DrawRectangle(new Pen(RimColor, RimSize), f, f, Width - RimSize, Height - RimSize);
            }
        }
    }

    /// <summary>
    /// <see cref="FormBox"/> for the <see cref="FlatForm"/>
    /// </summary>
    /// <seealso cref="FormBox" />
    public class FlatFormBox : FormBox
    {
        /// <summary>
        /// Color for the focused box.
        /// </summary>
        public Color FocusedColor { get; set; }

        /// <summary>
        /// Color for the unfocused box.
        /// </summary>
        public Color Color { get; set; }
    }
}