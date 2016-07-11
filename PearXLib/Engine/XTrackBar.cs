using System.ComponentModel;
using System.Drawing;
using PearXLib.Engine.Bases;

namespace PearXLib.Engine
{
    //WIP
    public class XTrackbar : XControlBase
    {
        private TrackbarType _Type = TrackbarType.Horizontal;
        private Color _LineColor = FlatColors.PeterRiver;
        private Color _LineSelectedColor = FlatColors.BelizeHole;

        #region Params
        [DefaultValue(0)]
        public TrackbarType Type { get { return _Type; } set { _Type = value; Refresh(); } }

        [DefaultValue(typeof(Color), "52, 152, 219")]
        public Color LineColor { get { return _LineColor;} set { _LineColor = value; Refresh(); } }

        [DefaultValue(typeof(Color), "41, 128, 185")]
        public Color LineSelectedColor { get { return _LineSelectedColor; } set { _LineSelectedColor = value; Refresh(); } }
        #endregion
    }

    public enum TrackbarType
    {
        Horizontal = 0,
        Vertical = 1,
        Radial = 2
    }
}