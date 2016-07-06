using System.Windows.Forms;

namespace PearXLib
{
    /// <summary>
    /// PearXLib's random extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Clears the ControlCollection and dispose.
        /// </summary>
        /// <param name="coll">The your ControlCollection.</param>
        public static void ClearAndDispose(this Control.ControlCollection coll)
        {
            for(int i = 0; i < coll.Count; i++)
            {
                coll[i].Dispose();
            }
            coll.Clear();
        }
    }
}
