using System;

namespace PearXLib
{
	/// <summary>
	/// PearXLib's SQLUtils.
	/// </summary>
	public static class SQLUtils
	{
		/// <summary>
		/// Makes string safe for MySQL requests.
		/// </summary>
		/// <returns>An input string.</returns>
		/// <param name="req">Formatted string.</param>
		[Obsolete("Use prepared statements!")]
		public static string FormatRequest(string req)
		{
			return req.Replace(@"\", @"\\").Replace("'", @"\'").Replace("\"", "\\\"").Replace("%", @"\%").Replace("\n", @"\n").Replace("_", @"\_");
		}

		/// <summary>
		/// Escapes a prepared statement argument.
		/// </summary>
		/// <returns>Escaped preapred statement argument.</returns>
		/// <param name="prep">Prepared statement argument.</param>
		public static string EscapePrepared(string prep)
		{
			return prep.Replace("%", @"\%").Replace("_", @"\_");
		}
	}
}
