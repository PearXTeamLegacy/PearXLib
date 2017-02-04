﻿using System.Collections.Generic;
using System.IO;

namespace PearXLib
{
	/// <summary>
	/// PearXLib file utilities.
	/// </summary>
	public static class FileUtils
	{
		/// <summary>
		/// Can system create file, named "filename"?
		/// </summary>
		/// <param name="filename">File's name.</param>
		/// <returns>If system can create file, returns true, else returns false.</returns>
		public static bool CanCreate(string filename)
		{
			char[] forbiddenChars = PCUtils.IsWindows() ? new char[] { '<', '>', ':', '\"', '\\', '/', '|', '?', '*' } : new char[] { '/' };

			if (filename.IndexOfAny(forbiddenChars) >= 0)
				return false;
			return true;
		}

		/// <summary>
		/// Gets all the files in the directory and subdirectories.
		/// </summary>
		/// <param name="dir">Path to the directory.</param>
		/// <returns>All files in directory and subdirectories.</returns>
		public static string[] GetFilesInDir(string dir)
		{
			List<string> l = new List<string>();
			GetFilesInDir(dir, l);
			return l.ToArray();
		}

	     static void GetFilesInDir(string dir, List<string> toAdd)
		{
			
			foreach (string d in Directory.GetDirectories(dir))
			{
				GetFilesInDir(d, toAdd);
			}
			foreach (string f in Directory.GetFiles(dir))
			{
				toAdd.Add(f);
			}
		}

		/// <summary>
		/// Gets all the directories in one directory.
		/// </summary>
		/// <returns>All the directories.</returns>
		/// <param name="dir">Directory to search.</param>
		public static string[] GetDirsInDir(string dir)
		{
			List<string> l = new List<string>();
			GetDirsInDir(dir, ref l);
			return l.ToArray();
		}

		static void GetDirsInDir(string dir, ref List<string> toAdd)
		{
			foreach (string d in Directory.GetDirectories(dir))
			{
				toAdd.Add(d);
				GetDirsInDir(d, ref toAdd);
			}
		}
	}
}