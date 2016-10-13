using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace PearXLib
{
	public static class ResourceUtils
	{
		/// <summary>
		/// Gets a byte array from resources.
		/// </summary>
		/// <param name="name">Resource name. For example: "MyApp.Images.Cat.png"</param>
		public static byte[] GetFromResources(string name)
		{
			foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
			{
				if (asm.GetManifestResourceNames().Contains(name))
				{
					using (var v = asm.GetManifestResourceStream(name))
					{
						byte[] arr = new byte[v.Length];
						v.Read(arr, 0, (int)v.Length);
						return arr;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Gets an image from the bytes.
		/// </summary>
		/// <returns>An image.</returns>
		/// <param name="bytes">Byte array.</param>
		public static Image ImageFromBytes(byte[] bytes)
		{
			using (MemoryStream str = new MemoryStream(bytes))
			{
				return Image.FromStream(str);
			}
		}

		/// <summary>
		/// Converts a byte array to a font.
		/// </summary>
		/// <returns>Font.</returns>
		/// <param name="bts">Byte array.</param>
		public static FontFamily FontFromBytes(byte[] bts)
		{
			var hndl = GCHandle.Alloc(bts, GCHandleType.Pinned);
			try
			{
				var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(bts, 0);
				using (PrivateFontCollection col = new PrivateFontCollection())
				{
					col.AddMemoryFont(ptr, bts.Length);
					return col.Families[0x00];
				}
			}
			finally { hndl.Free(); }
		}

		/// <summary>
		/// Converts a byte array to an icon.
		/// </summary>
		/// <returns>An icon.</returns>
		/// <param name="bts">Byte array.</param>
		public static Icon IconFromBytes(byte[] bts)
		{
			using (MemoryStream str = new MemoryStream(bts))
			{
				return new Icon(str);
			}
		}

		/// <summary>
		/// Gets an image from resources.
		/// </summary>
		/// <param name="name">Resource name.</param>
		public static Image ImageFromResources(string name)
		{
			return ImageFromBytes(GetFromResources(name));
		}

		/// <summary>
		/// Gets an icon from the resources.
		/// </summary>
		/// <returns>An icon.</returns>
		/// <param name="name">Resource name.</param>
		public static Icon IconFromResources(string name)
		{
			return IconFromBytes(GetFromResources(name));
		}
	}
}
