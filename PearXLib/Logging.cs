using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// Log type enum.
    /// </summary>
    public enum LogType
    {
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
    /// PearXLib logging utils.
    /// </summary>
    public class Logging
    {
        private string logPath;
        /// <summary>
        /// Log string
        /// </summary>
        public string Log;

        /// <summary>
        /// Initializates a new Logging component.
        /// </summary>
        /// <param name="logpath">Path to the log file.</param>
        public Logging(string logpath)
        {
            FileUtils.createDir(Path.GetDirectoryName(logpath));
            logPath = logpath;
        }

        /// <summary>
        /// Adds a line to log.
        /// </summary>
        /// <param name="line">Message text</param>
        /// <param name="lt">Log type</param>
        public void Add(string line, LogType lt)
        {
            string newStr = "[" + DateTime.Now + "]" + "[" + lt.ToString() + "]" + line + "\n";
            Log += newStr;
            File.AppendAllLines(logPath, new string[]{newStr});
        }
    }
}
