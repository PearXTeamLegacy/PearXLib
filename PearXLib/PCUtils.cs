using System;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;

namespace PearXLib
{
	/// <summary>
	/// PearXLib Computer Utilities.
	/// </summary>
	public static class PCUtils
	{
		/// <summary>
		/// Is current OS - Windows
		/// </summary>
		/// <returns>If current OS is Windows, returns true.</returns>
		public static bool IsWindows()
		{
			return Environment.OSVersion.ToString().ToLower().StartsWith("microsoft windows", StringComparison.Ordinal);
		}

		/// <summary>
		/// Starts executable file.
		/// </summary>
		/// <param name="path">Path to .exe</param>
		public static void RunExe(string path)
		{
			ProcessStartInfo inf = new ProcessStartInfo();

			if (IsWindows())
			{
				inf.FileName = path;
				Process.Start(inf);
			}
			else
			{
				inf.FileName = "mono";
				inf.Arguments = path;
				Process.Start(inf);
			}
		}

		/// <summary>
		/// Gets a Windows info. https://msdn.microsoft.com/en-us/library/windows/desktop/aa394239(v=vs.85).aspx - docs.
		/// </summary>
		/// <param name="what">Caption</param>
		/// <returns>Result</returns>
		public static string GetFromWindows(string what)
		{
			using (var ser = new ManagementObjectSearcher("SELECT " + what + " FROM Win32_OperatingSystem"))
			{
				foreach (ManagementBaseObject mo in ser.Get())
				{
					return mo[what].ToString();
				}
			}
			return null;
		}

		/// <summary>
		/// Gets a path to the Java directory.
		/// </summary>
		/// <returns>A path to the Java folder.</returns>
		public static string GetJavaPath()
		{
			if (IsWindows())
			{
				string javaKey = @"SOFTWARE\JavaSoft\Java Runtime Environment";
				using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
				{
					string currentVersion = baseKey.GetValue("CurrentVersion").ToString();
					using (var homeKey = baseKey.OpenSubKey(currentVersion))
						return homeKey.GetValue("JavaHome").ToString();
				}
			}
			else
				return "java";
		}

		/// <summary>
		/// Gets an information about PC's memory.
		/// </summary>
		/// <returns>An information about PC's memory.</returns>
		public static RamInfo GetRamInfo()
		{
			RamInfo ram = new RamInfo();
			if (IsWindows())
			{
				long total = Convert.ToInt64(GetFromWindows("TotalVisibleMemorySize"));
				long available = Convert.ToInt64(GetFromWindows("FreePhysicalMemory"));
				ram.Total = total;
				ram.Available = available;
				ram.Used = total - available;
			}
			else
			{
				MemInfo info = new MemInfo();
				long total = info.Get("MemTotal");
				long available = info.Get("MemAvailable");
				ram.Total = total;
				ram.Available = available;
				ram.Used = total - available;
			}
			return ram;
		}
	}
}
