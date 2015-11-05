using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib.Crypting
{
    /// <summary>
    /// PXMx encrypting algorithm (1.Convert char to int. 2. Result * 'salt' 3. Repeat 'multipliplier' times).
    /// </summary>
    public class CA_PXMx
    {
        /// <summary>
        /// Encrypts string by algorithm "PXMx".
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="salt">Salt.</param>
        /// <param name="multiplier">Multiplier.</param>
        /// <returns>Encrypted string.</returns>
        public static string Enrypt(string input, short salt, byte multiplier)
        {
            string output = input;
            for (int ii = 0; ii < multiplier; ii++)
            {
                char[] ca = output.ToCharArray();
                int[] ia = new int[ca.Length];
                for (int i = 0; i < ca.Length; i++)
                {
                    ia[i] = PXL.GetIntFromChar(ca[i]);
                }
                for (int i = 0; i < ia.Length; i++)
                {
                    ia[i] *= salt;
                }
                output = string.Join(" ", ia);
            }
            return output;
        }
        /// <summary>
        /// Decrypts string by algorithm "PXMx".
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="salt">Salt.</param>
        /// <param name="multiplier">Multiplier.</param>
        /// <returns>Decrypted string.</returns>
        public static string Decrypt(string input, short salt, byte multiplier)
        {
            string output = input;
            for (int ii = 0; ii < multiplier; ii++)
            {
                string[] s = output.Split(' ');
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
                output = new string(ca);
            }
            return output;
        }
    }
}
