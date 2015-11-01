﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PearXLib
{
    public class PXL
    {
        /* 
         * =========================
         * ======PearX Library======
         * =====Open Source Lib=====
         * =========pearx.ru========
         * =========================
         */







        /// <summary>
        /// Directory sepator.
        /// </summary>
        public static char s = Path.DirectorySeparatorChar;

        /// <summary>
        /// Creates dir if not exists.
        /// </summary>
        /// <param name="path">Directory path.</param>
        public static void createDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// For TextBox.
        /// </summary>
        /// <param name="e">Args</param>
        /// <returns>True or false.</returns>
        public static bool isNumberKey(KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates shortcut.
        /// </summary>
        /// <param name="path">Path to exe.</param>
        /// <param name="filePath">Path to new shortcut.</param>
        public static void createShortcut(string path, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[InternetShortcut]");
            sb.AppendLine("URL=file://" + path);
            sb.AppendLine("IconFile=" + path);
            sb.AppendLine("IconIndex=0");
            File.WriteAllText(filePath + ".url", sb.ToString());
        }

        /// <summary>
        /// Saves the app.
        /// </summary>
        /// <param name="appname">App name.</param>
        /// <param name="savename">Save name.</param>
        /// <param name="save">Save (string array).</param>
        public static void Save(string appname, string savename, string[] save)
        {
            File.WriteAllLines(d.pxDir + s + appname + s + savename + ".save", save);
        }

        /// <summary>
        /// Loads the app.
        /// </summary>
        /// <param name="appname">App name.</param>
        /// <param name="savename">Save name.</param>
        /// <returns>Loaded string array.</returns>
        public static string[] Load(string appname, string savename)
        {
            return File.ReadAllLines(d.pxDir + s + appname + s + savename + ".save");
        }

        /// <summary>
        /// Generates random character.
        /// </summary>
        /// <returns>Random character.</returns>
        public static char GenChar()
        {
            Thread.Sleep(1);
            Random r = new Random((int)DateTime.Now.Ticks);
            int i = r.Next(1, 27);
            return GetCharFromInt(i);
        }

        /// <summary>
        /// Generates random number.
        /// </summary>
        /// <returns>Random number</returns>
        public static int GenNumber()
        {
            Thread.Sleep(1);
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(0, 10);
        }

        /// <summary>
        /// Generate random number.
        /// </summary>
        /// <param name="min">Minimal random number (inclusive).</param>
        /// <param name="max">Maximal random number (inclusive).</param>
        /// <returns></returns>
        public static int GenNumber(int min, int max)
        {
            Thread.Sleep(1);
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(min, max + 1);
        }

        /// <summary>
        /// Replaces first occurrence of string.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <param name="replaceFrom">Replace from...</param>
        /// <param name="replaceTo">Replace to...</param>
        /// <returns></returns>
        public static string ReplaceFirst(string str, string replaceFrom, string replaceTo)
        {
            int p = str.IndexOf(replaceFrom);
            return str.Substring(0, p) + replaceTo + str.Substring(p + replaceFrom.Length);
        }

        /// <summary>
        /// Gets an integer from a char.
        /// </summary>
        /// <param name="input">Input byte.</param>
        /// <returns>Integer.</returns>
        public static int GetIntFromChar(char input)
        {
            switch(input)
            {
                case 'a':
                    return 1;
                case 'b':
                    return 2;
                case 'c':
                    return 3;
                case 'd':
                    return 4;
                case 'e':
                    return 5;
                case 'f':
                    return 6;
                case 'g':
                    return 7;
                case 'h':
                    return 8;
                case 'i':
                    return 9;
                case 'j':
                    return 10;
                case 'k':
                    return 11;
                case 'l':
                    return 12;
                case 'm':
                    return 13;
                case 'n':
                    return 14;
                case 'o':
                    return 15;
                case 'p':
                    return 16;
                case 'q':
                    return 17;
                case 'r':
                    return 18;
                case 's':
                    return 19;
                case 't':
                    return 20;
                case 'u':
                    return 21;
                case 'v':
                    return 22;
                case 'w':
                    return 23;
                case 'x':
                    return 24;
                case 'y':
                    return 25;
                case 'z':
                    return 26;
                default:
                    return 0;
            }
        }

        public static char GetCharFromInt(int input)
        {
            switch (input)
            {
                case 1:
                    return 'a';
                case 2:
                    return 'b';
                case 3:
                    return 'c';
                case 4:
                    return 'd';
                case 5:
                    return 'e';
                case 6:
                    return 'f';
                case 7:
                    return 'g';
                case 8:
                    return 'h';
                case 9:
                    return 'i';
                case 10:
                    return 'j';
                case 11:
                    return 'k';
                case 12:
                    return 'l';
                case 13:
                    return 'm';
                case 14:
                    return 'n';
                case 15:
                    return 'o';
                case 16:
                    return 'p';
                case 17:
                    return 'q';
                case 18:
                    return 'r';
                case 19:
                    return 's';
                case 20:
                    return 't';
                case 21:
                    return 'u';
                case 22:
                    return 'v';
                case 23:
                    return 'w';
                case 24:
                    return 'x';
                case 25:
                    return 'y';
                case 26:
                    return 'z';
                default:
                    return '!';
            }
        }
    }
}
