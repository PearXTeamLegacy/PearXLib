using System;
using System.Text;

namespace PearXLib.EncodingAlgorithms
{
	/// <summary>
	/// PXMultiple Algorithm.
	/// 1. Convert char to integer.
	/// 2. Char * salt.
	/// 3. Repeat
	/// </summary>
	public class PXMultiple
	{
		/// <summary>
		/// Encodes string by algorithm "PXMultiple".
		/// </summary>
		/// <param name="input">Input string</param>
		/// <param name="salt">Salt</param>
		/// <returns>Encoded string</returns>
		public static string Encode(string input, int salt)
		{
			byte[] ba = Encoding.UTF8.GetBytes(input.ToCharArray());
			long[] la = new long[ba.Length];

			for (int j = 0; j < ba.Length; j++)
			{
				long i = Convert.ToInt64(ba[j]);
				i *= salt;
				la[j] = i;
			}
			return string.Join(" ", la);
		}

		/// <summary>
		/// Decodes string by algorithm "PXMultiple".
		/// </summary>
		/// <param name="input">Input string</param>
		/// <param name="salt">Salt</param>
		/// <returns>Decoded string</returns>
		public static string Decode(string input, int salt)
		{
			string[] s = input.Split(' ');

			long[] la = new long[s.Length];
			byte[] ba = new byte[s.Length];

			for (int i = 0; i < s.Length; i++)
			{
				la[i] = long.Parse(s[i]);
			}

			for (int i = 0; i < s.Length; i++)
			{
				ba[i] = Convert.ToByte(la[i] / salt);
			}

			return new string(Encoding.UTF8.GetChars(ba));
		}
	}
}