using System;

namespace PearXLib
{
    /// <summary>
    /// Directories
    /// </summary>
    public class d
    {

        /// <summary>
        /// Folder "My Documents".
        /// </summary>
        public static string documents
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
        }

        /// <summary>
        /// Folder "Application Data".
        /// </summary>
        public static string appData
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); }
        }

        /// <summary>
        /// Desktop folder.
        /// </summary>
        public static string desktop
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }
        }

        /// <summary>
        /// PearX Team's Directory.
        /// </summary>
        public static string pxDir
        {
            get { return documents + PXL.s + "PearX"; }
        }
    }
}
