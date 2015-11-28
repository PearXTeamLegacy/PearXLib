using System;
using System.IO;

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
        Info,
        /// <summary>
        /// Other.
        /// </summary>
        Other
    };

    /// <summary>
    /// PearXLib logging utils.
    /// </summary>
    public class Logging
    {
        private string logPath;

        /// <summary>
        /// Executs, when log changed.
        /// </summary>
        public event EventHandler LogChanged;
        /// <summary>
        /// Log string.
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
        /// Adds a line to a log.
        /// </summary>
        /// <param name="line">Message text</param>
        /// <param name="lt">Log type</param>
        public void Add(string line, LogType lt)
        {
            string newStr = "[" + DateTime.Now + "]" + "[" + lt.ToString() + "]" + line + "\n";
            Log += newStr;
            File.AppendAllLines(logPath, new string[]{newStr});
            if (LogChanged != null)
            {
                LogChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Adds a line to a log.
        /// </summary>
        /// <param name="line">Message text</param>
        /// <param name="prefix">Prefix (if prefix equals "a simple prefix =)", then log string equals "[DATETIME][a simple prefix =)]MESSAGE"</param>
        public void Add(string line, string prefix)
        {
            string newStr = "[" + DateTime.Now + "]" + "[" + prefix + "]" + line + "\n";
            Log += newStr;
            File.AppendAllLines(logPath, new string[] { newStr });
            if (LogChanged != null)
            {
                LogChanged(this, new EventArgs());
            }
        }
    }
}
