using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PearXLib
{
	/// <summary>
	/// PearXLib extensions.
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// Gets a byte array from Bitmap.
		/// </summary>
		/// <returns>A Bitmap byte array.</returns>
		/// <param name="bmp">Bitmap.</param>
		/// <param name="format">Image Format.</param>
		public static byte[] ToByteArray(this Bitmap bmp, ImageFormat format)
		{
			using (MemoryStream str = new MemoryStream())
			{
				bmp.Save(str, format);
				return str.ToArray();
			}
		}

		public static bool Contains(this string s, char c)
		{
			return s.IndexOf(c) != -1;
		}

		/// <summary>
		/// Clears and disposes all the ControlCollection's components.
		/// </summary>
		/// <param name="c">Control Collection.</param>
		public static void ClearAndDispose(this Control.ControlCollection c)
		{
			foreach (Control ctrl in c)
			{
				ctrl.Dispose();
			}
			c.Clear();
		}
	}
}
