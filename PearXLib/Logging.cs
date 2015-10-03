using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PearXLib
{
    public class Logging
    {

        public enum LogType {Warning, Error, Info};

        /// <summary>
        /// Log path.
        /// </summary>
        public static string logPath = PXL.pxDir + PXL.s + "pearxApp.log";

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
