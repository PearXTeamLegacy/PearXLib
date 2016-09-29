using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
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
			using (var v = Assembly.GetEntryAssembly().GetManifestResourceStream(name))
			{
				byte[] arr = new byte[v.Length];
				v.Read(arr, 0, (int)v.Length);
				return arr;
			}
		}

		public static Image ImageFromBytes(byte[] bytes)
		{
			using (MemoryStream str = new MemoryStream(bytes))
			{
				return Image.FromStream(str);
			}
		}

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
		/// Gets an image from resources.
		/// </summary>
		/// <param name="name">Resource name.</param>
		public static Image ImageFromResources(string name)
		{
			return ImageFromBytes(GetFromResources(name));
		}
	}
}
