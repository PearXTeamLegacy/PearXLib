using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PearXLib.Engine.Flat
{
    public class FlatDialog : FlatForm
    {
        private Image cicon;
        private string msg = "";
        private XDialogIcon icon;
        private Color cmsg = Color.White;

        public XDialogSelected Selected;

        #region Params

        [DefaultValue(null)]
        public Image CustomIcon { get { return cicon; } set { cicon = value; Refresh(); } }

        [DefaultValue("")]
        public string Message { get { return msg; } set { msg = value; Refresh(); } }

        [DefaultValue(0)]
        public XDialogIcon Icon { get { return icon; } set { icon = value; Refresh(); } }

        [DefaultValue(typeof(Color), "White")]
        public Color MessageColor { get { return cmsg; } set { cmsg = value; Refresh(); } }
        #endregion

        FlatButton b_ok = new FlatButton();

        FlatButton b_y = new FlatButton();
        FlatButton b_n = new FlatButton();

        public FlatDialog(XDialogButtons btns, string yes = "Yes", string no = "No", string ok = "OK")
        {
            CloseBox = false;
            MinimizeBox = false;
            MaximizeBox = false;
            ToTrayBox = false;
            Size = new Size(256, 128);
            StartPosition = FormStartPosition.CenterScreen;

            switch (btns)
            {
                case XDialogButtons.Ok:
                    b_ok.Size = new Size(32, 16);
                    b_ok.Text = ok;
                    b_ok.Location = new Point((Size.Width - 32) / 2, Size.Height - 24);
                    b_ok.Click += (sender, args) => Close();
                    b_ok.ForeColor = Color.White;
                    b_ok.Font = new Font("Microsoft Sans Serif", 8F);
                    Controls.Add(b_ok);
                    break;
                case XDialogButtons.YesNo:
                    b_y.Size = new Size(32, 16);
                    b_y.Text = yes;
                    b_y.Location = new Point(Width / 2 - 32, Size.Height - 24);
                    b_y.Click += (sender, args) => { Selected = XDialogSelected.Yes; Close(); };
                    b_y.ForeColor = Color.White;
                    b_y.Font = new Font("Microsoft Sans Serif", 8F);
                    Controls.Add(b_y);

                    b_n.Size = new Size(32, 16);
                    b_n.Text = no;
                    b_n.Location = new Point(Width / 2 + 32, Size.Height - 24);
                    b_n.Click += (sender, args) => { Selected = XDialogSelected.No; Close(); };
                    b_n.ForeColor = Color.White;
                    b_n.Font = new Font("Microsoft Sans Serif", 8F);
                    Controls.Add(b_n);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Image img = CustomIcon;
            switch (Icon)
            {
                case XDialogIcon.Info:
                    img = FormIcons.DialogInfo;
                    break;
                case XDialogIcon.Question:
                    img = FormIcons.DialogQuestion;
                    break;
                case XDialogIcon.Warning:
                    img = FormIcons.DialogWarn;
                    break;
                case XDialogIcon.Error:
                    img = FormIcons.DialogError;
                    break;
            }
            e.Graphics.DrawImage(img, 16, (Height - img.Height + 32) / 2, img.Width, img.Height);
            SizeF s = e.Graphics.MeasureString(Message, Font);
            e.Graphics.DrawString(Message, Font, new SolidBrush(MessageColor), 32 + img.Width, (Height - s.Height) / 2);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            b_ok.Location = new Point((Size.Width - 32) / 2, Size.Height - 24);
            b_y.Location = new Point(Width / 2 - 32, Size.Height - 24);
            b_n.Location = new Point(Width / 2 + 32, Size.Height - 24);
        }
    }
}
