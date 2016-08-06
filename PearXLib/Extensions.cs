using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PearXLib
{
	public static class Extensions
	{
		public static byte[] ToByteArray(this Bitmap bmp, ImageFormat format)
		{
			using (MemoryStream str = new MemoryStream())
			{
				bmp.Save(str, format);
				return str.ToArray();
			}
		}
	}
}
