using System;
using System.Collections.Generic;
using System.IO;

namespace PearXLib
{
	/// <summary>
	/// The localization utilities.<para/>
	/// ---<para/>
	/// Lang file example:<para/>
	/// btnPlay=Play the game.<para/>
	/// btnExit=Exit the game.<para/>
	/// ---<para/>
	/// btnPlay and btnExit - localization names.<para/>
	/// "Play the game." and "Exit the game" - string values.
	/// </summary>
	public class Localization
	{
	     Dictionary<string, string> names;
		 Dictionary<string, string> defaultNames;
		 bool useDefaultNames = true;

		/// <summary>
		/// Initializes a new localization component.
		/// </summary>
		/// <param name="dir">Path to the lang directory (with slash).</param>
		/// <param name="langname">Language name.</param>
		/// <param name="defaultlang">Default language name.</param>
		public Localization(string dir, string langname, string defaultlang = "en_US")
		{
			
			if (defaultlang != langname)
			{
				Prepare(out names, langname, dir);
				Prepare(out defaultNames, defaultlang, dir);
			}
			else
			{
				useDefaultNames = false;
				Prepare(out names, langname, dir);
			}
		}

		/// <summary>
		/// Gets a string from the lang file.
		/// </summary>
		/// <param name="key">Unlocalized name.</param>
		/// <param name="usedef">Use default lang file?</param>
		/// <returns>String.</returns>
		public string GetString(string key, bool usedef = false)
		{
			if (!usedef)
			{
				if (names.ContainsKey(key))
					return names[key];
				else
				{
					if (useDefaultNames)
						return GetString(key, true);
					else
						return key;
				}
			}
			else
			{
				if (defaultNames.ContainsKey(key))
					return defaultNames[key];
				else
					return key;
			}
		}

		 void Prepare(out Dictionary<string, string> nms, string langname, string dir)
		{
			string[] langFile = File.ReadAllLines(dir + langname + ".lang");
			nms = new Dictionary<string, string>();
			foreach (string s in langFile)
			{
				if (string.IsNullOrWhiteSpace(s)) continue;
				if (s.Substring(0, 1) == "#") continue;

				int p = s.IndexOf("=", StringComparison.Ordinal);
				string sFilt = s.Remove(0, p + 1);
				sFilt = sFilt.Replace("\\n", "\n");
				nms.Add(s.Substring(0, p), sFilt);
			}
		}
	}
}
