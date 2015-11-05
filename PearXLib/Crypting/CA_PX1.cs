using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib.Crypting
{
    /// <summary>
    /// PX1 encrypting algorithm (Convert every char to int and back).
    /// </summary>
    public class CA_PX1
    {
        /// <summary>
        /// Encrypts string by algorithm "PX1".
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Encrypted string.</returns>
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

        /// <summary>
        /// Decrypts string by algorithm "PX1".
        /// </summary>
        /// <param name="input">Encrypted string.</param>
        /// <returns>Decrypted string.</returns>
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
