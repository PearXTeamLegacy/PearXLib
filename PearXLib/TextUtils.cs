using System;
namespace PearXLib
{
	/// <summary>
	/// Text utilities from PearXLib.
	/// </summary>
	public static class TextUtils
	{
		public static string ClearText(string s, string whitelistChars, bool multithreading = true)
		{
			//TODO: Multithreading
			string newString = "";
			foreach (char c in s)
			{
				foreach (char ch in whitelistChars)
				{
					if (c == ch)
					{
						newString += c;
						break;
					}
				}
			}
			return newString;
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
	}
}
