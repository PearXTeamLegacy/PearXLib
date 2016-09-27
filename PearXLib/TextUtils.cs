using System;
using System.Collections.Generic;
using System.IO;
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
		/// Gets a relative string.
		/// </summary>
		/// <param name="full">Full string. For example: "/home/max/files/image.png"</param>
		/// <param name="relative">Program should make relative string with respect to this string. For example: "/home/max/files/".</param>
		/// <param name="ignoreCase">Ignore case?</param>
		/// <returns>Relative string. For example: "image.png".</returns>
		public static string GetRelativeString(string full, string relative, bool ignoreCase, char? dirSepChar = null)
		{
			StringComparison com = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
			if (dirSepChar != null)
			{
				switch (dirSepChar.Value)
				{
					case '/':
						full = full.Replace('\\', '/');
						relative = relative.Replace('\\', '/');
						break;
					case '\\':
						full = full.Replace('/', '\\');
						relative = relative.Replace('/', '\\');
						break;
				}
			}
			if (full.StartsWith(relative, com))
			{
				return full.Substring(relative.Length);
			}
			return full;
		}

		/// <summary>
		/// Gets an array of relative strings.
		/// </summary>
		/// <param name="full">Array of full strings. For example: "/home/max/files/image.png"</param>
		/// <param name="relative">Program should make relative string with respect to this string. For example: "/home/max/files/".</param>
		/// <param name="ignoreCase">Ignore case?</param>
		/// <returns>Relative string. For example: "image.png".</returns>
		public static string[] GetRelativeString(string[] full, string relative, bool ignoreCase, char? dirSepChar)
		{
			List<string> l = new List<string>();
			foreach (string s in full)
			{
				l.Add(GetRelativeString(s, relative, ignoreCase, dirSepChar));
			}
			return l.ToArray();
		}
	}
}
