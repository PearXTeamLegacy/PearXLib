﻿using PearXLib.Crypting;
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
        /// Can system create file, nammed "filename"?
        /// </summary>
        /// <param name="filename">File name.</param>
        /// <returns>If system can create file, returns true, else returns false.</returns>
        public static bool CanCreate(string filename)
        {
            if(filename.Contains("\\") || filename.Contains("/") || filename.Contains(">") || filename.Contains("<") || filename.Contains("\"") || filename.Contains("?") || filename.Contains(":") || filename.Contains("*") || filename.Contains("|"))
            {
                return false;
            }
            else
            {
                return true;
            }
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
        /// Getting all files in directory and subdirectories.
        /// </summary>
        /// <param name="dir">Directory name.</param>
        /// <returns>All files in directory and subdirectories.</returns>
        public static string[] GetFilesInDir(string dir)
        {
            string[] list;
            foreach (string f in Directory.GetFiles(dir))
                files.Add(f);
            foreach (string d in Directory.GetDirectories(dir))
            {
                _DirSearch(d);
            }
            list = files.ToArray();
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
        /// Saves the app with using encryption.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        /// <param name="save">Strings to save.</param>
        /// <param name="salt">Encryption salt.</param>
        public static void SaveEnc(string path, string[] save, short salt)
        {
            string saveEncrypted = CA_PXM.Enrypt(PXL.GetStringFromArray(save), salt);
            File.WriteAllText(path, saveEncrypted);
        }

        /// <summary>
        /// Loads the app with using encryption.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        /// <param name="salt">Encryption salt.</param>
        /// <returns>Loaded string array.</returns>
        public static string[] LoadEnc(string path, short salt)
        {
            string decrypted = CA_PXM.Decrypt(File.ReadAllText(path), salt);
            return PXL.GetArrayFromString(decrypted);
        }

        /// <summary>
        /// Saves the app.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        /// <param name="save">Save (string array).</param>
        public static void Save(string path, string[] save)
        {
            File.WriteAllLines(path, save);
        }

        /// <summary>
        /// Loads the app.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        /// <returns>Loaded string array.</returns>
        public static string[] Load(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
