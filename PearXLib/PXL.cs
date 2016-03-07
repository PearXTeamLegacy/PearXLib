using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace PearXLib
{
    /// <summary>
    /// PearXLib main class.
    /// </summary>
    public class PXL
    {
        /*
         *   ______             __   __  _     _ _                          
         *   | ___ \            \ \ / / | |   (_) |                         
         *   | |_/ /__  __ _ _ __\ V /  | |    _| |__  _ __ __ _ _ __ _   _ 
         *   |  __/ _ \/ _` | '__/   \  | |   | | '_ \| '__/ _` | '__| | | |
         *   | | |  __/ (_| | | / /^\ \ | |___| | |_) | | | (_| | |  | |_| |
         *   \_|  \___|\__,_|_| \/   \/ \_____/_|_.__/|_|  \__,_|_|   \__, |
         *                                                             __/ |
         *                                                            |___/ 
         */

        /* 
         * =========================
         * ======PearX Library======
         * =====Open Source Lib=====
         * ===github.com/mrAppleXZ==
         * =========================
         */






        /// <summary>
        /// PearXLib version.
        /// </summary>
        public static readonly string ver = "36";

        /// <summary>
        /// Directory sepator.
        /// </summary>
        public static char s = Path.DirectorySeparatorChar;

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
        /// <param name="input">Input char.</param>
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
                case ' ':
                    return 81;
                case ',':
                    return 82;
                case '.':
                    return 83;
                case '1':
                    return 84;
                case '2':
                    return 85;
                case '3':
                    return 86;
                case '4':
                    return 87;
                case '5':
                    return 88;
                case '6':
                    return 89;
                case '7':
                    return 90;
                case '8':
                    return 91;
                case '9':
                    return 92;
                case '0':
                    return 93;
                case '\n':
                    return 94;
                case '\\':
                    return 95;
                case 'а':
                    return 96;
                case 'б':
                    return 97;
                case 'в':
                    return 98;
                case 'г':
                    return 99;
                case 'д':
                    return 100;
                case 'е':
                    return 101;
                case 'ё':
                    return 102;
                case 'ж':
                    return 103;
                case 'з':
                    return 104;
                case 'и':
                    return 105;
                case 'й':
                    return 106;
                case 'к':
                    return 107;
                case 'л':
                    return 108;
                case 'м':
                    return 109;
                case 'н':
                    return 110;
                case 'о':
                    return 111;
                case 'п':
                    return 112;
                case 'р':
                    return 113;
                case 'с':
                    return 114;
                case 'т':
                    return 115;
                case 'у':
                    return 116;
                case 'ф':
                    return 117;
                case 'х':
                    return 118;
                case 'ц':
                    return 119;
                case 'ч':
                    return 120;
                case 'ш':
                    return 121;
                case 'щ':
                    return 122;
                case 'ъ':
                    return 123;
                case 'ы':
                    return 124;
                case 'ь':
                    return 125;
                case 'э':
                    return 126;
                case 'ю':
                    return 127;
                case 'я':
                    return 128;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Gets a char from an integer.
        /// </summary>
        /// <param name="input">Input int.</param>
        /// <returns>Char.</returns>
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
                case 81:
                    return ' ';
                case 82:
                    return ',';
                case 83:
                    return '.';
                case 84:
                    return '1';
                case 85:
                    return '2';
                case 86:
                    return '3';
                case 87:
                    return '4';
                case 88:
                    return '5';
                case 89:
                    return '6';
                case 90:
                    return '7';
                case 91:
                    return '8';
                case 92:
                    return '9';
                case 93:
                    return '0';
                case 94:
                    return '\n';
                case 95:
                    return '\\';
                case 96:
                    return 'а';
                case 97:
                    return 'б';
                case 98:
                    return 'в';
                case 99:
                    return 'г';
                case 100:
                    return 'д';
                case 101:
                    return 'е';
                case 102:
                    return 'ё';
                case 103:
                    return 'ж';
                case 104:
                    return 'з';
                case 105:
                    return 'и';
                case 106:
                    return 'й';
                case 107:
                    return 'к';
                case 108:
                    return 'л';
                case 109:
                    return 'м';
                case 110:
                    return 'н';
                case 111:
                    return 'о';
                case 112:
                    return 'п';
                case 113:
                    return 'р';
                case 114:
                    return 'с';
                case 115:
                    return 'т';
                case 116:
                    return 'у';
                case 117:
                    return 'ф';
                case 118:
                    return 'х';
                case 119:
                    return 'ц';
                case 120:
                    return 'ч';
                case 121:
                    return 'ш';
                case 122:
                    return 'щ';
                case 123:
                    return 'ъ';
                case 124:
                    return 'ы';
                case 125:
                    return 'ь';
                case 126:
                    return 'э';
                case 127:
                    return 'ю';
                case 128:
                    return 'я';
                default:
                    return '!';
            }
        }

        /// <summary>
        /// Gets a string[] from string, uses new line(\n).
        /// </summary>
        /// <param name="s"></param>
        public static string[] GetArrayFromString(string s)
        {
            return s.Split('\n');
        }

        /// <summary>
        /// Gets a string from string[], uses new line(\n).
        /// </summary>
        /// <param name="s"></param>
        public static string GetStringFromArray(string[] s)
        {
            return String.Join("\n", s);
        }

        /// <summary>
        /// Gets an actual date and time.
        /// </summary>
        /// <returns>Actual date and time.</returns>
        public static string GetDateTimeNow()
        {
            DateTime dt = DateTime.Now;
            return dt.ToString("dd.MM.yyyy_HH-mm-ss");
        }

        /// <summary>
        /// Gets a form start position.
        /// </summary>
        /// <param name="parent">Parent form.</param>
        /// <param name="child">Child form.</param>
        /// <returns>Form start position.</returns>
        public static Point GetFormStartPosition(Form parent, Form child)
        {
            int w = (parent.Location.X + (((parent.Size.Width - child.Size.Width) / 2)));
            int h = (parent.Location.Y + (((parent.Size.Height - child.Size.Height) / 2)));
            return new Point(w, h);
        }

        /// <summary>
        /// Is cursor located on the element?
        /// </summary>
        /// <param name="startPoint">Start point(ex. - Location).</param>
        /// <param name="endPoint">End point(ex. - Location + Size).</param>
        /// <returns></returns>
        public static bool IsCursorOnElement(Point startPoint, Point endPoint)
        {
            if (Control.MousePosition.X >= startPoint.X && Control.MousePosition.X <= endPoint.X &&
                Control.MousePosition.Y >= startPoint.Y && Control.MousePosition.Y <= endPoint.Y)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Gets a path to a Java folder.
        /// </summary>
        /// <returns>A path to a Java folder.</returns>
        public static string GetJavaPath()
        {
            RegistryView rv;
            rv = RegistryView.Registry64;
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, rv).OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment"))
            {
                using (var homeKey = baseKey.OpenSubKey(baseKey.GetValue("CurrentVersion").ToString()))
                    return homeKey.GetValue("JavaHome").ToString();
            }
        }

        /// <summary>
        /// Gets an PC info
        /// </summary>
        /// <param name="what">Caption</param>
        /// <returns>Result</returns>
        public static string GetFromPC(string what)
        {
            ManagementObjectSearcher ser = new ManagementObjectSearcher("SELECT " + what + " FROM Win32_OperatingSystem");
            foreach(ManagementObject mo in ser.Get())
            {
                return mo[what].ToString();
            }
            return null;
        }

        /// <summary>
        /// Gets a control's center.
        /// </summary>
        /// <param name="parent">Control's parent form.</param>
        /// <param name="p">Control's location.</param>
        /// <param name="s">Control's size.</param>
        /// <returns></returns>
        public static Point GetControlCenter(Form parent, Point p, Size s)
        {
            return new Point((parent.Width - s.Width) / 2, p.Y);
        }
    }
}