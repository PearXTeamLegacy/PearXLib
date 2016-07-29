using System;
using System.Text;

namespace PearXLib.EncodingAlgorithms
{
	/// <summary>
	/// PXInterference Algorithm. 
	/// 1. Add "n" random false chars.
	/// 2. Add true char.
	/// 3. Repeat.
	/// Keys - interference count for every true char.
	/// </summary>
	public class PXInterference
	{
		/// <summary>
		/// Encodes string by a PXInterference algorithm.
		/// </summary>
		/// <param name="s">Input string.</param>
		/// <param name="interference">False characters list (ex. "qwertyQWERTY123456")</param>
		/// <param name="maxInterference">Max interference count per true character</param>
		/// <param name="rand">Your random</param>
		/// <param name="keys">Keys for decoding.</param>
		/// <returns>Encoded string.</returns>
		public static string Encode(string s, string interference, int maxInterference, Random rand, out int[] keys)
		{
			StringBuilder sbOut = new StringBuilder();
			keys = new int[s.Length];
			for (int i = 0; i < s.Length; i++)
			{
				int interferenceCount = rand.Next(maxInterference + 1);
				keys[i] = interferenceCount;
				for (int j = 0; j < interferenceCount; j++)
				{
					sbOut.Append(interference[rand.Next(interference.Length)]);
				}
				sbOut.Append(s[i]);
			}
			return sbOut.ToString();
		}

		/// <summary>
		/// Decodes string by a PXInterference algorithm.
		/// </summary>
		/// <param name="s">Encoded string</param>
		/// <param name="keys">Keys for decoding</param>
		/// <returns>Decoded string</returns>
		public static string Decode(string s, int[] keys)
		{
			StringBuilder sbOut = new StringBuilder();
			int j = 0;
			for (int i = 0; i < keys.Length; i++)
			{
				j += keys[i];
				sbOut.Append(s[j]);
				j += 1;
			}
			return sbOut.ToString();
		}
	}
}
