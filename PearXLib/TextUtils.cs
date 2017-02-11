using System;
using System.Collections.Generic;
using System.Text;

namespace PearXLib
{
	/// <summary>
	/// Text utilities from the PearXLib.
	/// </summary>
	public static class TextUtils
	{
		/// <summary>
		/// Clears the text.
		/// </summary>
		/// <returns>Cleared text.</returns>
		/// <param name="s">Input string.</param>
		/// <param name="listedChars">Whitelisted characters.</param>
		/// <param name="mode">Whitelist/Blacklist mode.</param>
		public static string ClearText(string s, string listedChars, ListMode mode)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in s)
			{
				if (listedChars.Contains(c) == (mode == ListMode.Whitelist))
						sb.Append(c);
			}
			return sb.ToString();
		}

		/// <summary>
		/// Replaces a first occurrence in the string.
		/// </summary>
		/// <param name="str">Input string.</param>
		/// <param name="replaceFrom">Replace from...</param>
		/// <param name="replaceTo">Replace to...</param>
		public static void ReplaceFirst(ref string str, string replaceFrom, string replaceTo)
		{
			int p = str.IndexOf(replaceFrom, StringComparison.Ordinal);
			str = str.Substring(0, p) + replaceTo + str.Substring(p + replaceFrom.Length);
		}

		/// <summary>
		/// Turns the specified string. If input is "abcd", output is "dcba"
		/// </summary>
		/// <param name="s">Input string.</param>
		public static string Turn(string s)
		{
			string str = "";
			for (int i = s.Length - 1; i >= 0; i--)
			{
				str += s[i];
			}
			return str;
		}

		/// <summary>
		/// Gets a substring of each array entry.
		/// </summary>
		/// <returns>The substring array.</returns>
		/// <param name="list">Input list.</param>
		/// <param name="from">Start substring from...</param>
		/// <param name="length">Substring length.</param>
		public static string[] Substring(this IEnumerable<string> list, int from, int length = -1)
		{
			List<string> lst = new List<string>();
			foreach (string str in list)
			{
				if (length == -1)
					lst.Add(str.Substring(from));
				else
					lst.Add(str.Substring(from, length));
			}
			return lst.ToArray();
		}

		/// <summary>
		/// Repeat the specified text n times.
		/// </summary>
		/// <returns>The repeated text.</returns>
		/// <param name="text">Text to repeat.</param>
		/// <param name="times">How many times to repeat.</param>
		public static string Repeat(string text, int times)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < times; i++)
			{
				sb.Append(text);
			}
			return sb.ToString();
		}
	}
}
