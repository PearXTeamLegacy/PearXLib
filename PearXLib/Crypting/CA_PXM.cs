using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib.Crypting
{
    public class CA_PXM
    {
        /// <summary>
        /// Encrypts string by algorithm "PXM" (1. Convert char to int. 2. Result * 'salt').
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="salt">Salt</param>
        /// <returns>Encrypted string.</returns>
        public static string Enrypt(string input, int salt)
        {
            char[] ca = input.ToCharArray();
            int[] ia = new int[ca.Length];
            for (int i = 0; i < ca.Length; i++)
            {
                ia[i] = PXL.GetIntFromChar(ca[i]);
            }
            for (int i = 0; i < ia.Length; i++)
            {
                ia[i] *= salt;
            }
                return string.Join(" ", ia);
        }

        /// <summary>
        /// Decrypts string by algorithm "PXM" (1. Convert int to char. 2. Result / 'salt').
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="salt">Salt</param>
        /// <returns>Decrypted string.</returns>
        public static string Decrypt(string input, int salt)
        {
            string[] s = input.Split(' ');
            int[] ia = new int[s.Length];
            char[] ca = new char[ia.Length];
            for (int i = 0; i < s.Length; i++)
            {
                ia[i] = int.Parse(s[i]);
            }
            for (int i = 0; i < s.Length; i++)
            {
                ia[i] /= salt;
            }
            for (int i = 0; i < ia.Length; i++)
            {
                 ca[i] = PXL.GetCharFromInt(ia[i]);
            }
            return new string(ca);
        }
    }
}
