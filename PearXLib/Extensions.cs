using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Newtonsoft.Json;

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

		/// <summary>
		/// Is the string contains a character?
		/// </summary>
		/// <returns>If string contains a character, returns true.</returns>
		/// <param name="s">Input string.</param>
		/// <param name="c">Character.</param>
		public static bool Contains(this string s, char c)
		{
			return s.IndexOf(c) != -1;
		}


		/// <summary>
		/// Formats an object to the JSON format.
		/// </summary>
		/// <returns>The JSON-formatted object.</returns>
		/// <param name="obj">Input object.</param>
		public static string ToJson(this object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}
	}
}
