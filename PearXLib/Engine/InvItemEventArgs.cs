namespace PearXLib.Engine
{
    /// <summary>
    /// Inventory Item event arguments.
    /// </summary>
    public class InvItemEventArgs
    {
        /// <summary>
        /// Inventory Item event arguments.
        /// </summary>
        /// <param name="amount">Item amount.</param>
        public InvItemEventArgs(int amount)
        {
            Amount = amount;
        }

        /// <summary>
        /// Item amount.
        /// </summary>
        public int Amount { get; private set; }
    }
}
