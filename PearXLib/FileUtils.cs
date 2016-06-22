using System;
using System.Collections.Generic;
using System.IO;

namespace PearXLib
{
    /// <summary>
    /// PearXLib file utilities.
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// Can system create file, named "filename"?
        /// </summary>
        /// <param name="filename">File name.</param>
        /// <returns>If system can create file, returns true, else returns false.</returns>
        public static bool CanCreate(string filename)
        {
            if(filename.Contains("\\") || filename.Contains("/") || filename.Contains(">") || filename.Contains("<") || filename.Contains("\"") || filename.Contains("?") || filename.Contains(":") || filename.Contains("*") || filename.Contains("|"))
            {
                return false;
            }
            return true;
        }

        private static List<string> files = new List<string>();

        private static void _DirSearch(string dir)
        {
            foreach (string f in Directory.GetFiles(dir))
                files.Add(f);
            foreach (string d in Directory.GetDirectories(dir))
            {
                _DirSearch(d);
            }
        }

        /// <summary>
        /// Getting the all files in the directory and subdirectories.
        /// </summary>
        /// <param name="dir">Directory name.</param>
        /// <returns>All files in directory and subdirectories.</returns>
        public static string[] GetFilesInDir(string dir)
        {
            foreach (string f in Directory.GetFiles(dir))
                files.Add(f);
            foreach (string d in Directory.GetDirectories(dir))
            {
                _DirSearch(d);
            }
            string[] list = files.ToArray();
            files.Clear();
            return list;
        }

        /// <summary>
        /// Gets a relative path to the directory or file.
        /// </summary>
        /// <param name="fullpath">Full path to the directory.</param>
        /// <param name="relativepath">Relative path.</param>
        /// <returns>Relative path to the directory.</returns>
        public static string GetRelativePath(string fullpath, string relativepath)
        {
            return Uri.UnescapeDataString(new Uri(relativepath).MakeRelativeUri(new Uri(fullpath)).ToString());
        }

        /// <summary>
        /// Gets a relative path to the directory or file.
        /// </summary>
        /// <param name="fullpath">Full path to the directory.</param>
        /// <param name="relativepath">Relative path.</param>
        /// <returns>Relative path to the directory.</returns>
        public static string[] GetRelativePath(string[] fullpath, string relativepath)
        {
            List<string> result = new List<string>();
            Uri rp = new Uri(relativepath);
            foreach(string s in fullpath)
            {
                result.Add(Uri.UnescapeDataString(rp.MakeRelativeUri(new Uri(s)).ToString()));
            }
            return result.ToArray();
        }

        /// <summary>
        /// Saves the application.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        /// <param name="save">Save (string array).</param>
        public static void Save(string path, string[] save)
        {
            File.WriteAllLines(path, save);
        }

        /// <summary>
        /// Loads the application.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        /// <returns>Loaded string array.</returns>
        public static string[] Load(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
