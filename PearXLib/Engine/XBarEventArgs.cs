namespace PearXLib.Engine
{
    /// <summary>
    /// XBar event arguments.
    /// </summary>
    public class XBarEventArgs
    {
        /// <summary>
        /// Initializates a new XBarEventArgs class.
        /// </summary>
        /// <param name="val">Bar value.</param>
        /// <param name="max">Maximal bar value.</param>
        public XBarEventArgs(int val, int max)
        {
            Value = val;
            Maximal = max;
            InPercents = MathsUtils.GetInPercents(max, val);
        }

        /// <summary>
        /// Bar value.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Maximal bar value.
        /// </summary>
        public int Maximal { get; private set; }

        /// <summary>
        /// Bar value in percents.
        /// </summary>
        public double InPercents { get; private set; }
    }
}
