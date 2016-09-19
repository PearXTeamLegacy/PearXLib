using System;
using System.IO;

namespace PearXLib
{
	/// <summary>
	/// PearXLib logging utilities.
	/// </summary>
	public class Logging
	{
		public string LogPath { get; private set; }

		/// <summary>
		/// Out this log to console?
		/// </summary>
		public bool OutToConsole { get; set; }

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
		/// <param name="force">If true, removes old log file.</param>
		/// <param name="outToConsole">Out this log to console?</param>
		public Logging(string logpath, bool outToConsole, bool force = false)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(logpath));
			if (force)
				File.Delete(logpath);
			LogPath = logpath;
			OutToConsole = outToConsole;
		}

		/// <summary>
		/// Adds a line to the log.
		/// </summary>
		/// <param name="line">Message text</param>
		/// <param name="lt">Log type</param>
		public void Add(string line, LogType lt)
		{
			AddToLog(line, $"[{lt}]");
		}

		/// <summary>
		/// Adds a line to the log.
		/// </summary>
		/// <param name="line">Message text</param>
		/// <param name="prefix">Message prefix.</param>
		/// <param name="lt">Log type</param>
		public void Add(string line, string prefix, LogType lt)
		{
			AddToLog(line, $"[{lt}][{prefix}]");
		}

		/// <summary>
		/// Adds a line to the log.
		/// </summary>
		/// <param name="line">Message text</param>
		/// <param name="prefix">Message prefix.</param>
		public void Add(string line, string prefix)
		{
			AddToLog(line, $"[{prefix}]");
		}

		/// <summary>
		/// Adds a line to the log.
		/// </summary>
		/// <param name="line">Message text</param>
		/// <param name="debug">Is this message used for debugging?</param>
		public void Add(string line)
		{
			AddToLog(line, "");
		}

		protected void AddToLog(string line, string prefix)
		{
			string newStr = "[" + DateTime.Now + "]" + prefix + line + "\n";
			Log += newStr;
			File.AppendAllText(LogPath, newStr);

			if (OutToConsole)
				Console.WriteLine(newStr);

			LogChanged?.Invoke(this, newStr);
		}
	}

	/// <summary>
	/// Log type enum.
	/// </summary>
	public enum LogType
	{
		Warning,
		Error,
		Info,
		Other,
		Debug
	}
}
