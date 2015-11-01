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
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
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
            switch (input)
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
                case 'A':
                    return 27;
                case 'B':
                    return 28;
                case 'C':
                    return 29;
                case 'D':
                    return 30;
                case 'E':
                    return 31;
                case 'F':
                    return 32;
                case 'G':
                    return 33;
                case 'H':
                    return 34;
                case 'I':
                    return 35;
                case 'J':
                    return 36;
                case 'K':
                    return 37;
                case 'L':
                    return 38;
                case 'M':
                    return 39;
                case 'N':
                    return 40;
                case 'O':
                    return 41;
                case 'P':
                    return 42;
                case 'Q':
                    return 43;
                case 'R':
                    return 44;
                case 'S':
                    return 45;
                case 'T':
                    return 46;
                case 'U':
                    return 47;
                case 'V':
                    return 48;
                case 'W':
                    return 49;
                case 'X':
                    return 50;
                case 'Y':
                    return 51;
                case 'Z':
                    return 52;
                case ':':
                    return 53;
                case ';':
                    return 54;
                case '\'':
                    return 55;
                case '"':
                    return 56;
                case '[':
                    return 57;
                case ']':
                    return 58;
                case '{':
                    return 59;
                case '}':
                    return 60;
                case '-':
                    return 61;
                case '_':
                    return 62;
                case '+':
                    return 63;
                case '=':
                    return 64;
                case ')':
                    return 65;
                case '(':
                    return 66;
                case '*':
                    return 67;
                case '&':
                    return 68;
                case '?':
                    return 69;
                case '^':
                    return 70;
                case '%':
                    return 71;
                case '$':
                    return 72;
                case '#':
                    return 73;
                case '№':
                    return 74;
                case '@':
                    return 75;
                case '`':
                    return 76;
                case '~':
                    return 77;
                case '|':
                    return 78;
                case '/':
                    return 79;
                case '!':
                    return 80;
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
                case 27:
                    return 'A';
                case 28:
                    return 'B';
                case 29:
                    return 'C';
                case 30:
                    return 'D';
                case 31:
                    return 'E';
                case 32:
                    return 'F';
                case 33:
                    return 'G';
                case 34:
                    return 'H';
                case 35:
                    return 'I';
                case 36:
                    return 'J';
                case 37:
                    return 'K';
                case 38:
                    return 'L';
                case 39:
                    return 'M';
                case 40:
                    return 'N';
                case 41:
                    return 'O';
                case 42:
                    return 'P';
                case 43:
                    return 'Q';
                case 44:
                    return 'R';
                case 45:
                    return 'S';
                case 46:
                    return 'T';
                case 47:
                    return 'U';
                case 48:
                    return 'V';
                case 49:
                    return 'W';
                case 50:
                    return 'X';
                case 51:
                    return 'Y';
                case 52:
                    return 'Z';
                case 53:
                    return ':';
                case 54:
                    return ';';
                case 55:
                    return '\'';
                case 56:
                    return '"';
                case 57:
                    return '[';
                case 58:
                    return ']';
                case 59:
                    return '{';
                case 60:
                    return '}';
                case 61:
                    return '-';
                case 62:
                    return '_';
                case 63:
                    return '+';
                case 64:
                    return '=';
                case 65:
                    return ')';
                case 66:
                    return '(';
                case 67:
                    return '*';
                case 68:
                    return '&';
                case 69:
                    return '?';
                case 70:
                    return '^';
                case 71:
                    return '%';
                case 72:
                    return '$';
                case 73:
                    return '#';
                case 74:
                    return '№';
                case 75:
                    return '@';
                case 76:
                    return '`';
                case 77:
                    return '~';
                case 78:
                    return '|';
                case 79:
                    return '/';
                case 80:
                    return '!';
                default:
                    return '!';
            }
        }
    }
}
