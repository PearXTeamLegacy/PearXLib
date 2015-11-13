using PearXLib.Crypting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// PearXLib file utilities.
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// Saves the app with using encryption.
        /// </summary>
        /// <param name="appname">Application name.</param>
        /// <param name="savename">Save name.</param>
        /// <param name="save">Strings to save.</param>
        /// <param name="salt">Encryption salt.</param>
        /// <param name="useMultiple">Use multiple encryption?</param>
        public static void SaveEnc(string appname, string savename, string[] save, short salt, bool useMultiple)
        {
            string saveEncrypted = "";
            if (!useMultiple)
            {
                saveEncrypted = CA_PXM.Enrypt(PXL.GetStringFromArray(save), salt);
            }
            else
            {
                saveEncrypted = CA_PXMx.Enrypt(PXL.GetStringFromArray(save), salt, 2);
            }
            File.WriteAllText(d.pxDir + PXL.s + appname + PXL.s + savename + ".save", saveEncrypted);
        }

        /// <summary>
        /// Loads the app with using encryption.
        /// </summary>
        /// <param name="appname">Application name.</param>
        /// <param name="savename">Save name.</param>
        /// <param name="salt">Encryption salt.</param>
        /// <param name="useMultiple">Use multiple encryption?</param>
        /// <returns>Loaded string array.</returns>
        public static string[] LoadEnc(string appname, string savename, short salt, bool useMultiple)
        {
            string decrypted = "";
            if (!useMultiple)
            {
                decrypted = CA_PXM.Decrypt(File.ReadAllText(d.pxDir + PXL.s + appname + PXL.s + savename + ".save"), salt);
            }
            else
            {
                decrypted = CA_PXMx.Decrypt(File.ReadAllText(d.pxDir + PXL.s + appname + PXL.s + savename + ".save"), salt, 2);
            }
            return PXL.GetArrayFromString(decrypted);
        }

        /// <summary>
        /// Saves the app.
        /// </summary>
        /// <param name="appname">App name.</param>
        /// <param name="savename">Save name.</param>
        /// <param name="save">Save (string array).</param>
        public static void Save(string appname, string savename, string[] save)
        {
            File.WriteAllLines(d.pxDir + PXL.s + appname + PXL.s + savename + ".save", save);
        }

        /// <summary>
        /// Loads the app.
        /// </summary>
        /// <param name="appname">App name.</param>
        /// <param name="savename">Save name.</param>
        /// <returns>Loaded string array.</returns>
        public static string[] Load(string appname, string savename)
        {
            return File.ReadAllLines(d.pxDir + PXL.s + appname + PXL.s + savename + ".save");
        }

        /// <summary>
        /// Creates dir if it does not exists.
        /// </summary>
        /// <param name="path">Directory path.</param>
        public static void createDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
