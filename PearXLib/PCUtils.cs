using System;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;

namespace PearXLib
{
    /// <summary>
    /// PearXLib Computer Utilities.
    /// </summary>
    public class PCUtils
    {
        /// <summary>
        /// Is current OS - Windows
        /// </summary>
        /// <returns>If current OS is Windows, returns true.</returns>
        public static bool IsWindows()
        {
            return Environment.OSVersion.ToString().ToLower().StartsWith("microsoft windows");
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
        /// Gets a PC info
        /// </summary>
        /// <param name="what">Caption</param>
        /// <returns>Result</returns>
        public static string GetFromPC(string what)
        {
            ManagementObjectSearcher ser = new ManagementObjectSearcher("SELECT " + what + " FROM Win32_OperatingSystem");
            foreach (ManagementBaseObject mo in ser.Get())
            {
                return mo[what].ToString();
            }
            return null;
        }

        /// <summary>
        /// Gets a path to the Java folder.
        /// </summary>
        /// <returns>A path to the Java folder.</returns>
        public static string GetJavaPath()
        {
            string javaKey = @"SOFTWARE\JavaSoft\Java Runtime Environment";
            using (
                var baseKey =
                    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey))
            {
                string currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                using (var homeKey = baseKey.OpenSubKey(currentVersion))
                    return homeKey.GetValue("JavaHome").ToString();
            }
        }
    }
}
