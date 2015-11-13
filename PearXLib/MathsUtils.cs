using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// PearXLib mathematics utilities.
    /// </summary>
    public class MathsUtils
    {
        /// <summary>
        /// Gets an arithmetical averange.
        /// </summary>
        /// <param name="ints">Input integers.</param>
        /// <returns>Arithmetical averange.</returns>
        public static int GetAverage(int[] ints)
        {
            int temp = 0; 
            foreach(int i in ints)
            {
                temp += i;
            }
            return temp / ints.Length;
        }

        /// <summary>
        /// Gets an exactly arithmetical averange.
        /// </summary>
        /// <param name="doubles">Input doubles.</param>
        /// <returns>Exactly arithmetical averange</returns>
        public static double GetAverageExactly(double[] doubles)
        {
            double temp = 0;
            foreach (int i in doubles)
            {
                temp += i;
            }
            return temp / doubles.Length;
        }
    }
}
