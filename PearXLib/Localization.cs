using System;
using System.IO;

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

        private string[] deflocnms;
        private string[] defvls;

        /// <summary>
        /// Initializes a new localization component.
        /// </summary>
        /// <param name="dir">Path to the lang dir (with slash).</param>
        /// <param name="langname">Language name.</param>
        /// <param name="defaultlang">Default language name.</param>
        public Localization(string dir, string langname, string defaultlang = "en_US")
        {
            if (defaultlang != langname)
            {
                Prepare(ref vls, ref locnms, langname, dir);
                Prepare(ref defvls, ref deflocnms, defaultlang, dir);
            }
            else
                Prepare(ref vls, ref locnms, langname, dir);
        }

        /// <summary>
        /// Gets a string from a lang file.
        /// </summary>
        /// <param name="localname">Localization name.</param>
        /// <param name="usedef">DON'T USE IT</param>
        /// <returns>String.</returns>
        public string GetString(string localname, bool usedef = false)
        {
            if (!usedef)
            {
                int count = -1;
                foreach (string s in locnms)
                {
                    count++;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s == localname)
                        {
                            return vls[count].Replace(@"&\n", "\n");
                        }
                    }
                }
                return GetString(localname, true);
            }
            else
            {
                int count = -1;
                foreach (string s in deflocnms)
                {
                    count++;
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s == localname)
                        {
                            return defvls[count].Replace(@"&\n", "\n");
                        }
                    }
                }
                return localname;
            }
        }

        private void Prepare(ref string[] values, ref string[] localnames, string langname, string dir)
        {
            string[] str = File.ReadAllLines(dir + langname + ".lang");
            localnames = new string[str.Length];
            values = new string[str.Length];
            int count = 0;
            foreach (string s in str)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (s.Substring(0, 1) != "#")
                    {
                        int p = s.IndexOf("=");
                        localnames[count] = s.Substring(0, p);
                        int i = s.Length;
                        values[count] = s.Substring(++p, i - p);
                        count++;
                    }
                }
            }
        }
    }
}
