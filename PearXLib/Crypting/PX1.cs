using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib.Crypting
{
    public class PX1
    {
        public static string Enrypt(string input)
        {
            char[] ca = input.ToCharArray();
            int[] ia = new int[ca.Length];
            for (int i = 0; i < ca.Length; i++ )
            {
                ia[i] = PXL.GetIntFromChar(ca[i]);
            }
            return string.Join(" ", ia);
        }

        public static string Decrypt(string input)
        {
            string[] s = input.Split(' ');
            int[] ia = new int[s.Length];
            char[] ca = new char[ia.Length];
            for (int i = 0; i < s.Length; i++)
            {
                ia[i] = int.Parse(s[i]);
            }
            for (int i = 0; i < ia.Length; i++)
            {
                ca[i] = PXL.GetCharFromInt(ia[i]);
            }
            return new string(ca);
        }
    }
}
