using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Management;

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
         */

        /* 
         * =========================
         * ======PearX Library======
         * =====Open Source Lib=====
         * ===github.com/mrAppleXZ==
         * =========================
         */






        /// <summary>
        /// PearXLib version.
        /// </summary>
        public static readonly string ver = "41";

        /// <summary>
        /// Directory sepator.
        /// </summary>
        public static char s = Path.DirectorySeparatorChar;

        /// <summary>
        /// For TextBox.
        /// </summary>
        /// <param name="e">Args</param>
        /// <returns>True or false.</returns>
        public static bool isNumberKey(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates shortcut.
        /// </summary>
        /// <param name="path">Path to exe.</param>
        /// <param name="filePath">Path to new shortcut.</param>
        public static void createShortcut(string path, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[InternetShortcut]");
            sb.AppendLine("URL=file://" + path);
            sb.AppendLine("IconFile=" + path);
            sb.AppendLine("IconIndex=0");
            File.WriteAllText(filePath + ".url", sb.ToString());
        }

        /// <summary>
        /// Replaces first occurrence of string.
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
        /// Gets a string[] from string, uses new line(\n).
        /// </summary>
        /// <param name="s"></param>
        public static string[] GetArrayFromString(string s)
        {
            return s.Split('\n');
        }

        /// <summary>
        /// Gets a string from string[], uses new line(\n).
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
            int w = (parent.Location.X + (((parent.Size.Width - child.Size.Width) / 2)));
            int h = (parent.Location.Y + (((parent.Size.Height - child.Size.Height) / 2)));
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
        /// Gets a path to a Java folder.
        /// </summary>
        /// <returns>A path to a Java folder.</returns>
        public static string GetJavaPath()
        {
            RegistryView rv;
            rv = RegistryView.Registry64;
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rv).OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment"))
            {
                using (var homeKey = baseKey.OpenSubKey(baseKey.GetValue("CurrentVersion").ToString()))
                    return homeKey.GetValue("JavaHome").ToString();
            }
        }

        /// <summary>
        /// Gets an PC info
        /// </summary>
        /// <param name="what">Caption</param>
        /// <returns>Result</returns>
        public static string GetFromPC(string what)
        {
            ManagementObjectSearcher ser = new ManagementObjectSearcher("SELECT " + what + " FROM Win32_OperatingSystem");
            foreach(ManagementObject mo in ser.Get())
            {
                return mo[what].ToString();
            }
            return null;
        }

        /// <summary>
        /// Gets a control's center.
        /// </summary>
        /// <param name="parent">Control's parent form.</param>
        /// <param name="p">Control's location.</param>
        /// <param name="s">Control's size.</param>
        /// <returns></returns>
        public static Point GetControlCenter(Form parent, Point p, Size s)
        {
            return new Point((parent.Width - s.Width) / 2, p.Y);
        }
    }
}