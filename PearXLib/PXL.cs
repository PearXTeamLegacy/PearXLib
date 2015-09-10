using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PearXLib
{
    public class PXL
    {
        /* 
         * =========================
         * ======PearX Library======
         * =====Open Source Lib=====
         * =========pearx.ru========
         * =========================
         */






        /// <summary>
        /// Checks file's hash. Returns hash.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns></returns>
        public static string hashCheck(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }
        /// <summary>
        /// Converts string to integer. This is alias for Convert.ToInt32(param).
        /// </summary>
        /// <param name="s">String</param>
        /// <returns></returns>
        public static int cTI(string s)
        {
            return Convert.ToInt32(s);
        }

        /// <summary>
        /// Folder "My Documents".
        /// </summary>
        public static string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        /// <summary>
        /// Folder "Application Data".
        /// </summary>
        public static string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Directory sepator.
        /// </summary>
        public static char s = Path.DirectorySeparatorChar;
    }
}
