using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PearXLib
{
	/// <summary>
	/// PearXLib main class.
	/// </summary>
	public static class PXL
	{
		/// <summary>
		/// Creates a shortcut.
		/// </summary>
		/// <param name="path">Path to the executable file.</param>
		/// <param name="shDir">Shortcut directory without slash.</param>
		/// <param name="shName">Shortcut name.</param>
		/// <param name="genericName">Generic name. For example: if name is "Povar File Manager", generic name should be "File Manager".</param>
		/// <param name="linuxIconPath">Path to the icon for a Linux desktop entry.</param>
		public static void CreateShortcut(string path, string shDir, string shName, string genericName, string linuxIconPath)
		{
			var sb = new StringBuilder();
			if (PCUtils.IsWindows())
			{
				sb.AppendLine("[InternetShortcut]");
				sb.AppendLine("URL=file://" + path);
				sb.AppendLine("IconFile=" + path);
				sb.AppendLine("IconIndex=0");
				File.WriteAllText(shDir + "/" + shName + ".url", sb.ToString());
			}
			else
			{
				sb.AppendLine("[Desktop Entry]");
				sb.AppendLine("Name=" + shName);
				sb.AppendLine("GenericName=" + genericName);
				sb.AppendLine("Icon=" + linuxIconPath);
				sb.AppendLine("Type=Application");
				sb.AppendLine("StartupNotify=true");
				sb.AppendLine("Exec=\"" + path + "\"");
				File.WriteAllText(shDir + "/" + shName + ".desktop", sb.ToString());
			}
		}

		/// <summary>
		/// Gets a string array from the string, uses new line(\n).
		/// </summary>
		/// <param name="str"></param>
		public static string[] GetArrayFromString(string str)
		{
			return str.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
		}

		/// <summary>
		/// Gets a string from the string array, uses new line(\n).
		/// </summary>
		/// <param name="str"></param>
		public static string GetStringFromArray(string[] str)
		{
			return string.Join("\n", str);
		}

		/// <summary>
		/// Gets an actual date and time.
		/// </summary>
		/// <returns>Actual date and time.</returns>
		public static string GetDateTimeNow()
		{
			DateTime dt = DateTime.Now;
			return dt.ToString("yyyy.MM.dd_HH-mm-ss");
		}

		/// <summary>
		/// Gets a MD5 hash from the string.
		/// </summary>
		/// <param name="str">The string.</param>
		/// <returns>MD5 hash.</returns>
		public static string GetMD5(string str)
		{
			using (MD5 md5 = MD5.Create())
			{
				byte[] ascii = Encoding.ASCII.GetBytes(str);
				byte[] hashed = md5.ComputeHash(ascii);
				return BitConverter.ToString(hashed).Replace("-", "").ToLower();
			}
		}

		/// <summary>
		/// Gets a file's MD5
		/// </summary>
		/// <returns>MD5 hash.</returns>
		/// <param name="path">File path.</param>
		public static string GetFileMD5(string path)
		{
			using (MD5 md5 =MD5.Create())
			{
				using (FileStream str = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					byte[] hashed = md5.ComputeHash(str);
					return BitConverter.ToString(hashed).Replace("-", "").ToLower();
				}
			}
		}

		public static string GetSha256(string txt)
		{
			using (SHA256 sha = SHA256.Create())
			{
				byte[] utf8 = Encoding.UTF8.GetBytes(txt);
				byte[] hash = sha.ComputeHash(utf8);
				return BitConverter.ToString(hash).Replace("-", "");
			}
		}

		/// <summary>
		/// Gets the control point, based from align.
		/// </summary>
		/// <param name="align">The control's alignment.</param>
		/// <param name="containerSize">The control's container size.</param>
		/// <param name="size">The control's size.</param>
		/// <param name="border">The border.</param>
		/// <returns></returns>
		public static PointF AlignPoint(ContentAlignment align, SizeF containerSize, SizeF size, int border)
		{
			float x = 0;
			float y = 0;

			switch (align)
			{
				case ContentAlignment.BottomCenter:
					x = (containerSize.Width - size.Width) / 2;
					y = containerSize.Height - size.Height - border;
					break;
				case ContentAlignment.BottomLeft:
					x = border;
					y = containerSize.Height - size.Height - border;
					break;
				case ContentAlignment.BottomRight:
					x = containerSize.Width - size.Width - border;
					y = containerSize.Height - size.Height - border;
					break;
				case ContentAlignment.MiddleCenter:
					x = (containerSize.Width - size.Width) / 2;
					y = (containerSize.Height - size.Height) / 2;
					break;
				case ContentAlignment.MiddleLeft:
					x = border;
					y = (containerSize.Height - size.Height) / 2;
					break;
				case ContentAlignment.MiddleRight:
					x = containerSize.Width - size.Width - border;
					y = (containerSize.Height - size.Height) / 2;
					break;
				case ContentAlignment.TopCenter:
					x = (containerSize.Width - size.Width) / 2;
					y = border;
					break;
				case ContentAlignment.TopLeft:
					x = border;
					y = border;
					break;
				case ContentAlignment.TopRight:
					x = containerSize.Width - size.Width - border;
					y = border;
					break;
			}
			return new PointF(x, y);
		}
	}

	/// <summary>
	/// An empty delegate. Special for you =).
	/// </summary>
	public delegate void EmptyDelegate();

	/// <summary>
	/// List mode.
	/// </summary>
	public enum ListMode
	{
		/// <summary>
		/// Whitelist.
		/// </summary>
		Whitelist,
		/// <summary>
		/// Blacklist.
		/// </summary>
		Blacklist
	}
}