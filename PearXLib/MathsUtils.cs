using System;
using System.Numerics;

namespace PearXLib
{
    /// <summary>
    /// PearXLib mathematics utilities.
    /// </summary>
    public class MathsUtils
    {
        /// <summary>
        /// Gets an arithmetical average.
        /// </summary>
        /// <param name="ints">Input integers.</param>
        /// <returns>Arithmetical average.</returns>
        public static int GetAverage(int[] ints)
        {
            int temp = 0; 
            foreach(int i in ints)
                temp += i;
            return temp / ints.Length;
        }

        /// <summary>
        /// Gets an exactly arithmetical average.
        /// </summary>
        /// <param name="doubles">Input doubles.</param>
        /// <returns>Exactly arithmetical average</returns>
        public static double GetAverageExactly(double[] doubles)
        {
            double temp = 0;
            foreach (double d in doubles)
                temp += d;
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
                for(int j = 0; j < i; j++)
                {
                    s += i;
                }
            }
            return BigInteger.Parse(s);
        }

        /// <summary>
        /// Get a number in percents.
        /// </summary>
        /// <param name="maximum">100 percents.</param>
        /// <param name="value">Value</param>
        /// <returns>Value in percents.</returns>
        public static double GetInPercents(double maximum, double value)
        {
            return  value / (maximum / 100);
        }
    }

    /// <summary>
    /// A fraction class.
    /// </summary>
    public class Fraction
    {
        /// <summary>
        /// A numerator of the fraction.
        /// </summary>
        public long Numerator { get; set; }

        /// <summary>
        /// A denominator of the fraction.
        /// </summary>
        public long Denominator { get; set; }

        /// <summary>
        /// Initializes a new fraction
        /// </summary>
        /// <param name="num">Numerator</param>
        /// <param name="den">Denominator</param>
        public Fraction(long num, long den)
        {
            Numerator = num;
            Denominator = den;
        }

        /// <summary>
        /// *
        /// </summary>
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        /// <summary>
        /// /
        /// </summary>
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }
    }
}
