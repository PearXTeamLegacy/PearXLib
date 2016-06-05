using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PearXLib.Engine.Flat;

namespace PearXLib.Engine
{
    public class TooltipForm : OutsideForm
    {
        public XLabel NameLabel = new XLabel();
        public XLabel TooltipLabel = new XLabel();
        private int _TextOffset = 3;

        public int TextOffset
        {
            get { return _TextOffset; }
            set { _TextOffset = value; RefreshControls(); }
        }

        public string NameText
        {
            get { return NameLabel.Text; }
            set { NameLabel.Text = value; RefreshControls(); }
        }

        public string TooltipText
        {
            get { return TooltipLabel.Text; }
            set { TooltipLabel.Text = value; RefreshControls(); }
        }

        public TooltipForm()
        {
            TooltipLabel.DrawInRectangle = true;
            Controls.Add(NameLabel);
            Controls.Add(TooltipLabel);
            RefreshControls();
        }

        public void RefreshControls()
        {
            NameLabel.Location = new Point(TextOffset, TextOffset);
            TooltipLabel.Location = new Point(TextOffset, TextOffset + NameLabel.Size.Height);
            TooltipLabel.Size = new Size(Width - TextOffset*2, Height - TextOffset*2 - NameLabel.Size.Height);
        }
    }
}
