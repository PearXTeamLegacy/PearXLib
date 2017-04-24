using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PearXLib
{
	/// <summary>
	/// Information about PC's memory.
	/// </summary>
	public class RamInfo
	{
		/// <summary>
		/// Used memory.
		/// </summary>
		public long Used { get; set; }

		/// <summary>
		/// Available memory.
		/// </summary>
		public long Available { get; set; }

		/// <summary>
		/// Total memory.
		/// </summary>
		public long Total { get; set; }
	}

	/// <summary>
	/// C# wrapper for GNU Linux's /proc/meminfo.
	/// </summary>
	public class MemInfo
	{
		private readonly string[] mem = File.ReadAllLines("/proc/meminfo");

		/// <summary>
		/// Gets a meminfo parameter. For example "MemAvailable" or "MemTotal".
		/// </summary>
		/// <param name="what">Parameter name.</param>
		public long Get(string what)
		{
			var regex = new Regex($@"^{what}:\s+(\d+)");
			foreach (string s in mem)
			{
				Match m = regex.Match(s);
				if (m.Success)
				{
					return Convert.ToInt64(m.Groups[1].ToString());
				}
			}
			return 0;
		}
	}
}
