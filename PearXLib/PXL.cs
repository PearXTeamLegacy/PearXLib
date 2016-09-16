using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PearXLib
{
  /// <summary>
  /// PearXLib main class.
  /// </summary>
  public static class PXL
  {
    /// <summary>
    /// Gets the PearXLib version.
    /// </summary>
    /// <value>The PearXLib version.</value>
    public static string Version => "2.3.1";

    /// <summary>
    /// Creates a shortcut.
    /// </summary>
    /// <param name="path">Path to the executable file.</param>
    /// <param name="filePath">Path to the new shortcut.</param>
    public static void CreateShortcut(string path, string filePath)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("[InternetShortcut]");
      sb.AppendLine("URL=file://" + path);
      sb.AppendLine("IconFile=" + path);
      sb.AppendLine("IconIndex=0");
      File.WriteAllText(filePath + ".url", sb.ToString());
    }

    /// <summary>
    /// Gets a string array from the string, uses new line(\n).
    /// </summary>
    /// <param name="str"></param>
    public static string[] GetArrayFromString(string str)
    {
      return str.Split('\n');
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
    /// <returns>Hashed string.</returns>
    public static string GetMD5(string str)
    {
      byte[] ascii = Encoding.ASCII.GetBytes(str);
      byte[] hashed = MD5.Create().ComputeHash(ascii);
      return BitConverter.ToString(hashed).Replace("-", "").ToLower();
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

    /// <summary>
    /// For TextBox.
    /// </summary>
    /// <param name="e">Arguments</param>
    /// <returns>True or false.</returns>
    public static bool IsNumberKey(KeyPressEventArgs e)
    {
      if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char) Keys.Back)
      {
        return true;
      }
      return false;
    }
  }

  /// <summary>
  /// An empty delegate. Special for you =).
  /// </summary>
  public delegate void EmptyDelegate();
}