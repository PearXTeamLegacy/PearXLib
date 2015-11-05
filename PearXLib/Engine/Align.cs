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
        /// # # #
        /// # # *
        /// # # #
        /// </summary>
        RIGHT,
        /// <summary>
        /// # # #
        /// # * #
        /// # # #
        /// </summary>
        CENTER,
        /// <summary>
        /// # # #
        /// * # #
        /// # # #
        /// </summary>
        LEFT,
        /// <summary>
        /// # * #
        /// # # #
        /// # # #
        /// </summary>
        TOP,
        /// <summary>
        /// # # #
        /// # # #
        /// # * #
        /// </summary>
        BOTTOM
    }
}
