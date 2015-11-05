using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// PearXLib logging utils.
    /// </summary>
    public class Logging
    {
        /// <summary>
        /// Log type enum.
        /// </summary>
        public enum LogType {
            /// <summary>
            /// Warning!
            /// </summary>
            Warning,
            /// <summary>
            /// Error!
            /// </summary>
            Error,
            /// <summary>
            /// Information.
            /// </summary>
            Info
        };

        /// <summary>
        /// Log path.
        /// </summary>
        public static string logPath = d.pxDir + PXL.s + "pearxApp.log";

        /// <summary>
        /// Log string
        /// </summary>
        public static string log;

        /// <summary>
        /// Adds a line to log.
        /// </summary>
        /// <param name="line">Message text</param>
        /// <param name="lt">Log type</param>
        public static void add(string line, LogType lt)
        {
            string newStr = "[" + DateTime.Now + "]" + "[" + lt.ToString() + "]" + line + "\n";
            log += newStr;
            File.AppendAllLines(logPath, new string[]{newStr});
        }
    }
}
