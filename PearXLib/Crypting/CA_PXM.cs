using System;
using System.Text;

namespace PearXLib.Crypting
{
    /// <summary>
    /// PXM encrypting algorithm (1. Convert char to int. 2. Result * 'salt').
    /// </summary>
    public class CA_PXM
    {
        /// <summary>
        /// Encrypts string by algorithm "PXM".
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="salt">Salt</param>
        /// <returns>Encrypted string.</returns>
        public static string Enrypt(string input, int salt)
        {
            byte[] ba = Encoding.UTF8.GetBytes(input.ToCharArray());
            long[] la = new long[ba.Length];

            for (int j = 0; j < ba.Length; j++)
            {
                long i = Convert.ToInt64(ba[j]);
                i *= salt;
                la[j] = i;
            }
            return string.Join(" ", la);
        }

        /// <summary>
        /// Decrypts string by algorithm "PXM".
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="salt">Salt</param>
        /// <returns>Decrypted string.</returns>
        public static string Decrypt(string input, int salt)
        {
            string[] s = input.Split(' ');

            long[] la = new long[s.Length];
            byte[] ba = new byte[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                la[i] = long.Parse(s[i]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                ba[i] = Convert.ToByte(la[i] / salt);
            }
            
            return new string(Encoding.UTF8.GetChars(ba));
        }
    }
}
