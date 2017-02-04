using System.Drawing;
using System.Linq;
using System.Numerics;

namespace PearXLib.Maths
{
	/// <summary>
	/// PearXLib mathematics utilities.
	/// </summary>
	public static class MathUtils
	{
		/// <summary>
		/// Gets an arithmetical average.
		/// </summary>
		/// <param name="ints">Input integers.</param>
		/// <returns>Arithmetical average.</returns>
		public static int GetAverage(int[] ints)
		{
			int temp = 0;
			foreach (int i in ints)
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
			for (int i = 1; i <= count; i++)
			{
				for (int j = 0; j < i; j++)
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
			return value / (maximum / 100);
		}

		/// <summary>
		/// Gets the distance between two points.
		/// </summary>
		/// <returns>The distance between two points.</returns>
		/// <param name="p1">First point.</param>
		/// <param name="p2">Second point.</param>
		public static double GetPointDistance(Point p1, Point p2)
		{
			int x = p1.X - p2.X;
			int y = p1.Y - p2.Y;
			return (x * x + y * y);
		}

		/// <summary>
		/// Is value even7
		/// </summary>
		/// <returns><c>true</c>, if value is even, <c>false</c> otherwise.</returns>
		/// <param name="l">Value.</param>
		public static bool IsEven(long l)
		{
			return l % 2 == 0;
		}

		public static PointF[] LinePoints(Point po1, Point po2, int dots)
		{
			PointF[] pnts = new PointF[dots]; //point array for output

			var p1 = Point.Empty; //                                zero-based values (without first point)
			var p2 = new Point(po2.X - po1.X, po2.Y - po1.Y); // ^

			bool single = dots == 1; // if single dot
			float dts = single ? 2 : dots - 1; //lines: if single dot - 2, otherwise - dots - 1.
			PointF sz = new PointF(p2.X / dts, p2.Y / dts); // Every line size
			for (int i = 0; i < dots; i++) // foreach dot
			{
				int j = single ? 1 : i; //multiplier: if single dot - 1, otherwise - i.
				pnts[i] = new PointF(sz.X * j + po1.X, sz.Y * j + po1.Y); //line size * dot number + first point
			}
			return pnts;
		}

		/// <summary>
		/// Gets a Greatest Common Divider. For more details, see <see cref="GetGcdEuclid"/>.
		/// </summary>
		/// <returns>Greatest Common Divider.</returns>
		/// <param name="vals">Numbers.</param>
		public static long GetGcd(params long[] vals)
		{
			long gcdTemp = vals[0];
			for (int i = 1; i < vals.Length; i++)
			{
				gcdTemp = GetGcdEuclid(gcdTemp, vals[i]);
			}
			return gcdTemp;
		}

		/// <summary>
		/// Gets a Greatest Common Divider using the Euclid's algorithm.
		/// </summary>
		/// <returns>Greatest Common Divider.</returns>
		/// <param name="a">First number.</param>
		/// <param name="b">Second number.</param>
		public static long GetGcdEuclid(long a, long b)
		{
			var arr = new long[] { a, b };
			return GetGcdEuclid_(arr.Max(), arr.Min());
		}


		static long GetGcdEuclid_(long bigger, long lower)
		{
			if (bigger == 0 || lower == 0)
				return 0;
			while (lower != 0)
			{
				var tmp = bigger % lower;
				bigger = lower;
				lower = tmp;
			}
			return bigger;
		}
	}
}
