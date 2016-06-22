using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib.Crypting
{
    /// <summary>
    /// PXInterference Algorithm. 
    /// 1. Add "n" random false chars.
    /// 2. Add true char.
    /// 3. Repeat.
    /// Keys - interference count for every true char.
    /// </summary>
    public class CA_PXI
    {
        public static string Encrypt(string s, string interference, int maxInterference, Random rand, out int[] keys)
        {
            StringBuilder sbOut = new StringBuilder();
            keys = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                int interferenceCount = rand.Next(maxInterference + 1);
                keys[i] = interferenceCount;
                for (int j = 0; j < interferenceCount; j++)
                {
                    sbOut.Append(interference[rand.Next(interference.Length)]);
                }
                sbOut.Append(s[i]);
            }
            return sbOut.ToString();
        }

        public static string Decrypt(string s, int[] keys)
        {
            StringBuilder sbOut = new StringBuilder();
            int j = 0;
            for (int i = 0; i < keys.Length; i++)
            {
                j += keys[i];
                sbOut.Append(s[j]);
                j += 1;
            }
            return sbOut.ToString();
        }
    }
}
