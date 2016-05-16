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
    /// PearXLib logging utilities.
    /// </summary>
    public class Logging
    {
        private readonly string logPath;

        /// <summary>
        /// Log changed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="logString">New log string</param>
        public delegate void LogHandler(object sender, string logString);

        /// <summary>
        /// Executes, when log changed.
        /// </summary>
        public event LogHandler LogChanged;

        /// <summary>
        /// Log string.
        /// </summary>
        public string Log { get; set; }

        /// <summary>
        /// Initializes a new Logging component.
        /// </summary>
        /// <param name="logpath">Path to the log file.</param>
        /// <param name="force">If true, deletes old log file.</param>
        public Logging(string logpath, bool force = false)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(logpath));
            if (force)
                File.Delete(logpath);
            logPath = logpath;
        }

        /// <summary>
        /// Adds a line to the log.
        /// </summary>
        /// <param name="line">Message text</param>
        /// <param name="lt">Log type</param>
        public void Add(string line, LogType lt)
        {
            string newStr = "[" + DateTime.Now + "]" + "[" + lt + "]" + line + "\n";
            Log += newStr;
            File.AppendAllText(logPath, newStr);
            if (LogChanged != null)
            {
                LogChanged(this, newStr);
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
            File.AppendAllText(logPath, newStr);
            if (LogChanged != null)
            {
                LogChanged(this, newStr);
            }
        }

        /// <summary>
        /// Adds a line to the log.
        /// </summary>
        /// <param name="line">Message text</param>
        public void Add(string line)
        {
            string newStr = "[" + DateTime.Now + "]" + line + "\n";
            Log += newStr;
            File.AppendAllText(logPath, newStr);

            if (LogChanged != null)
            {
                LogChanged(this, newStr);
            }
        }
    }
}
