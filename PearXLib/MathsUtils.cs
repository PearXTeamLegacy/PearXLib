using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        /// <summary>
        /// Gets a number of numbers! (seriously)
        /// </summary>
        /// <param name="count">Number</param>
        /// <returns>Number of numbers!</returns>
        public static BigInteger GetNumberOfNumbers(int count)
        {
            string s = null;
            for(int i = 1; i <= count; i++)
            {
                for(int i2 = 0; i2 < i; i2++)
                {
                    s += i;
                }
            }
            return BigInteger.Parse(s);
        }
    }
}
