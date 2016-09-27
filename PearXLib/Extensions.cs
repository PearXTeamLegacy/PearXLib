using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
	}
}
