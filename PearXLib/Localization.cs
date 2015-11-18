using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// A localization utilities.<para/>
    /// ---<para/>
    /// Lang file example:<para/>
    /// btnPlay=Play the game.<para/>
    /// btnExit=Exit the game.<para/>
    /// ---<para/>
    /// btnPlay and btnExit - localization names.<para/>
    /// "Play the game." and "Exit the game" - string values.
    /// </summary>
    public class Localization
    {
        private string[] locnms;
        private string[] vls;

        /// <summary>
        /// Initializes a new localization component.
        /// </summary>
        /// <param name="appname">Application name.</param>
        /// <param name="langname">Language name.</param>
        public Localization(string appname, string langname)
        {
            string[] str = File.ReadAllLines(d.pxDir + PXL.s + appname + PXL.s + "langs" + PXL.s + langname + ".lang");
            locnms = new String[str.Length];
            vls = new String[str.Length];
            int count = -1;
            foreach (string s in str)
            {
                count++;
                int p = s.IndexOf("=");
                locnms[count] = s.Substring(0, p);
                int i = s.Length;
                vls[count] = s.Substring(++p, i - p);
            }
        }

        /// <summary>
        /// Gets a string from a lang file.
        /// </summary>
        /// <param name="localname">Localization name.</param>
        /// <returns>String.</returns>
        public string GetString(string localname)
        {
            int count = -1;
            string finded = localname;
            foreach(string s in locnms)
            {
                count++;
                if (s.Equals(localname))
                {
                    finded = vls[count];
                }
            }
            return finded;
        }
    }
}
