using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib.Engine
{
    /// <summary>
    /// Alignment enum.
    /// </summary>
    public enum Align
    {
        /// <summary>
        /// # # #<para/>
        /// # # *<para/>
        /// # # #
        /// </summary>
        RIGHT,
        /// <summary>
        /// # # #<para/>
        /// # * #<para/>
        /// # # #
        /// </summary>
        CENTER,
        /// <summary>
        /// # # #<para/>
        /// * # #<para/>
        /// # # #
        /// </summary>
        LEFT,
        /// <summary>
        /// # * #<para/>
        /// # # #<para/>
        /// # # #
        /// </summary>
        TOP,
        /// <summary>
        /// # # #<para/>
        /// # # #<para/>
        /// # * #
        /// </summary>
        BOTTOM
    }
}
