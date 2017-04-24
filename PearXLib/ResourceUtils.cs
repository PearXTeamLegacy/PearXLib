using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PearXLib
{
	/// <summary>
	/// PearXLib Resource Utils
	/// </summary>
	public static class ResourceUtils
	{
		/// <summary>
		/// Gets a byte array from resources.
		/// </summary>
		/// <param name="name">Resource name. For example: "MyApp.Images.Cat.png".</param>
		public static byte[] GetFromResources(string name)
		{
			using (var v = StreamFromResources(name))
			{
				byte[] arr = new byte[v.Length];
				v.Read(arr, 0, (int)v.Length);
				return arr;
			}
		}

		/// <summary>
		/// Gets a Stream from resources.
		/// </summary>
		/// <returns>The Stream.</returns>
		/// <param name="name">Resource name. For example: "MyApp.Images.Cat.png".</param>
		public static Stream StreamFromResources(string name)
		{
			foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
			{
				if (asm.GetManifestResourceNames().Contains(name))
				{
					return asm.GetManifestResourceStream(name);
				}
			}
			return null;
		}

		/// <summary>
		/// Gets all the resources in domain.
		/// </summary>
		/// <returns>Resource names.</returns>
		/// <param name="domain">Resource domain.</param>
		public static string[] GetResourcesInDomain(string domain)
		{
			List<string> l = new List<string>();
			foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
			{
				var res = asm.GetManifestResourceNames();
				foreach (string s in res)
				{
					if (s.StartsWith(domain, StringComparison.Ordinal))
						l.Add(s);
				}
			}
			return l.ToArray();
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

	    /// <summary>
	    /// Gets a string from the resources.
	    /// </summary>
	    /// <param name="name">Resource name.</param>
	    /// <returns>A string</returns>
	    public static string StringFromResources(string name)
	    {
	        return Encoding.UTF8.GetString(GetFromResources(name));
	    }
	}
}
