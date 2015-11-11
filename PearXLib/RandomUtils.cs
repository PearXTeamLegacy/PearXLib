using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// PearXLib Random Utilities.
    /// </summary>
    public class RandomUtils
    {
        /// <summary>
        /// Generates random character.
        /// </summary>
        /// <returns>Random character.</returns>
        public static char GenChar(Random rand)
        {
            int i = rand.Next(1, 27);
            return PXL.GetCharFromInt(i);
        }

        /// <summary>
        /// Generates random digit.
        /// </summary>
        /// <returns>Random digit</returns>
        public static int GenNumber(Random rand)
        {
            return rand.Next(0, 10);
        }

        /// <summary>
        /// Generate random number.
        /// </summary>
        /// <param name="min">Minimal random number (inclusive).</param>
        /// <param name="max">Maximal random number (inclusive).</param>
        /// <param name="rand">Your random.</param>
        /// <returns>Random number.</returns>
        public static int GenNumber(Random rand, int min, int max)
        {
            return rand.Next(min, max + 1);
        }

        /// <summary>
        /// Generates random symbol.
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
        public static char GenSymbol(Random rand)
        {
            int i = rand.Next(0, 26);
            switch (i)
            {
                case 0:
                    return '!';
                case 1:
                    return '@';
                case 2:
                    return '"';
                case 3:
                    return '#';
                case 4:
                    return '№';
                case 5:
                    return '$';
                case 6:
                    return ';';
                case 7:
                    return '%';
                case 8:
                    return '^';
                case 9:
                    return ':';
                case 10:
                    return '&';
                case 11:
                    return '?';
                case 12:
                    return '*';
                case 13:
                    return '(';
                case 14:
                    return ')';
                case 15:
                    return '-';
                case 16:
                    return '_';
                case 17:
                    return '+';
                case 18:
                    return '=';
                case 19:
                    return '\\';
                case 20:
                    return '|';
                case 21:
                    return '/';
                case 22:
                    return '\'';
                case 23:
                    return '~';
                case 24:
                    return '.';
                case 25:
                    return ',';
                default:
                    return '!';
            }
        }

        /// <summary>
        /// Generates random number/char/symbol.
        /// </summary>
        /// <returns>Random.</returns>
        public static char GenRandom(Random rand, bool useSymbols)
        {
            int i;
            if (useSymbols)
                i = rand.Next(0, 4);
            else
                i = rand.Next(0, 3);
            switch (i)
            {
                case 0:
                    return Convert.ToChar(GenNumber(rand).ToString());
                case 1:
                    return GenChar(rand);
                case 2:
                    return Convert.ToChar(GenChar(rand).ToString().ToUpper());
                case 3:
                    return GenSymbol(rand);
                default:
                    return '0';
            }

        }
    }
}
