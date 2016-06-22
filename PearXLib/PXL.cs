using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;

namespace PearXLib
{
    /// <summary>
    /// PearXLib main class.
    /// </summary>
    public class PXL
    {
        /*
         *   ______             __   __  _     _ _                          
         *   | ___ \            \ \ / / | |   (_) |                         
         *   | |_/ /__  __ _ _ __\ V /  | |    _| |__  _ __ __ _ _ __ _   _ 
         *   |  __/ _ \/ _` | '__/   \  | |   | | '_ \| '__/ _` | '__| | | |
         *   | | |  __/ (_| | | / /^\ \ | |___| | |_) | | | (_| | |  | |_| |
         *   \_|  \___|\__,_|_| \/   \/ \_____/_|_.__/|_|  \__,_|_|   \__, |
         *                                                             __/ |
         *                                                            |___/ 
         *
         * https://github.com/mrAppleXZ/PearXLib/
         */

        /// <summary>
        /// PearXLib version.
        /// </summary>
        private const string Version = "22.06.2016";

        /// <summary>
        /// Directory separator.
        /// </summary>
        public static char s = Path.DirectorySeparatorChar;

        /// <summary>
        /// For TextBox.
        /// </summary>
        /// <param name="e">Arguments</param>
        /// <returns>True or false.</returns>
        public static bool IsNumberKey(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char) Keys.Back)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates a shortcut.
        /// </summary>
        /// <param name="path">Path to the executable file.</param>
        /// <param name="filePath">Path to the new shortcut.</param>
        public static void CreateShortcut(string path, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[InternetShortcut]");
            sb.AppendLine("URL=file://" + path);
            sb.AppendLine("IconFile=" + path);
            sb.AppendLine("IconIndex=0");
            File.WriteAllText(filePath + ".url", sb.ToString());
        }

        /// <summary>
        /// Replaces the first occurrence of the string.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <param name="replaceFrom">Replace from...</param>
        /// <param name="replaceTo">Replace to...</param>
        public static void ReplaceFirst(ref string str, string replaceFrom, string replaceTo)
        {
            int p = str.IndexOf(replaceFrom, StringComparison.Ordinal);
            str = str.Substring(0, p) + replaceTo + str.Substring(p + replaceFrom.Length);
        }

        /// <summary>
        /// Gets a string array from the string, uses new line(\n).
        /// </summary>
        /// <param name="s"></param>
        public static string[] GetArrayFromString(string s)
        {
            return s.Split('\n');
        }

        /// <summary>
        /// Gets a string from the string array, uses new line(\n).
        /// </summary>
        /// <param name="s"></param>
        public static string GetStringFromArray(string[] s)
        {
            return string.Join("\n", s);
        }

        /// <summary>
        /// Gets an actual date and time.
        /// </summary>
        /// <returns>Actual date and time.</returns>
        public static string GetDateTimeNow()
        {
            DateTime dt = DateTime.Now;
            return dt.ToString("dd.MM.yyyy_HH-mm-ss");
        }

        /// <summary>
        /// Gets a form start position.
        /// </summary>
        /// <param name="parent">Parent form.</param>
        /// <param name="child">Child form.</param>
        /// <returns>Form start position.</returns>
        public static Point GetFormStartPosition(Form parent, Form child)
        {
            int w = parent.Location.X + (parent.Size.Width - child.Size.Width)/2;
            int h = parent.Location.Y + (parent.Size.Height - child.Size.Height)/2;
            return new Point(w, h);
        }

        /// <summary>
        /// Is cursor located on the element?
        /// </summary>
        /// <param name="startPoint">Start point(ex. - Location).</param>
        /// <param name="endPoint">End point(ex. - Location + Size).</param>
        /// <returns></returns>
        public static bool IsCursorOnElement(Point startPoint, Point endPoint)
        {
            if (Control.MousePosition.X >= startPoint.X && Control.MousePosition.X <= endPoint.X &&
                Control.MousePosition.Y >= startPoint.Y && Control.MousePosition.Y <= endPoint.Y)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Gets a center point for a UserControl.
        /// </summary>
        /// <param name="p">Parent Form</param>
        /// <param name="uc">Control</param>
        /// <returns></returns>
        public static Point GetControlCenterPoint(Form p, Control uc)
        {
            return new Point((p.Width - uc.Size.Width)/2, uc.Location.Y);
        }

        /// <summary>
        /// Gets the MD5 hash from string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>Hashed string.</returns>
        public static string GetMD5(string str)
        {
            byte[] ascii = Encoding.ASCII.GetBytes(str);
            byte[] hashed = MD5.Create().ComputeHash(ascii);
            return BitConverter.ToString(hashed).Replace("-", "").ToLower();
        }
    }

    /// <summary>
    /// An empty delegate. Special for you =).
    /// </summary>
    public delegate void EmptyDelegate();
}