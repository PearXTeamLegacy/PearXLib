using System;
using System.IO;

namespace PearXLib
{
	/// <summary>
	/// Directories
	/// </summary>
	public static class D
	{
		/// <summary>
		/// My documents directory.  On Windows - C:\Users\{USER}\Documents\, on Linux - /home/{USER}/
		/// </summary>
		/// <value>The documents directory path.</value>
		public static string Documents => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

		/// <summary>
		/// Application Data directory. On Windows - C:\Users\{USER}\AppData\Roaming\, on Linux - /home/{USER}/.config/
		/// </summary>
		/// <value>The AppData path.</value>
		public static string AppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		/// <summary>
		/// Desktop directory. On Windows - C:\Users\{USER}\Desktop, on Linux - /home/{USER}/Desktop
		/// </summary>
		/// <value>The desktop directory path.</value>
		public static string Desktop => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		/// <summary>
		/// PearX Team's directory.
		/// </summary>
		/// <value>The PearX Team's directory path.</value>
		public static string PearX => Path.Combine(Documents, "PearX");
	}
}