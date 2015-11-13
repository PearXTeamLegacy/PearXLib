using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// PearXLib Updating Utils.
    /// </summary>
    public class UpdateUtils
    {
        /// <summary>
        /// Prepares and runs app update.
        /// </summary>
        /// <param name="appName">Application name.</param>
        /// <param name="exeName">Executable file name.</param>
        /// <param name="exeOnSite">Path to executable file on website.</param>
        public static void PrepareUpdate(string appName, string exeName, string exeOnSite)
        {
            File.WriteAllLines("upd.txt", new string[] {appName, exeName, exeOnSite});
            Process.Start("upd.exe");
        }
    }
}
