using System;
using System.Collections.Generic;
using System.Globalization;

namespace PearXLib.I18n
{
	/// <summary>
	/// An internationalization system from PearXLib
	/// </summary>
	public class I18n
	{
		I18nLoader Loader { get; set; }
		/// <summary>
		/// The default language name.
		/// </summary>
		public string DefaultLangName { get; set; }

		I18nPage Current { get; set; }
		I18nPage Default { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PearXLib.I18n.I18n"/> class.
		/// </summary>
		/// <param name="loader">An I18n Loader.</param>
		/// <param name="def">Default language name.</param>
		public I18n(I18nLoader loader, string def)
		{
			DefaultLangName = def;
			Loader = loader;
		}

		I18nPage LoadPage(string lang)
		{
			return new I18nPage { Values = Loader.Load(lang), Name = lang };
		}

		/// <summary>
		/// Gets localized string from an unlocalized key.
		/// </summary>
		/// <param name="key">An unlocalized name.</param>
		public string this[string key]
		{
			get
			{
				if (Current.Values.ContainsKey(key))
				{
					return Current.Values[key];
				}
				if (Default != null)
				{
					if (Default.Values.ContainsKey(key))
					{
						return Default.Values[key];
					}
				}
				return key;
			}
		}

		/// <summary>
		/// Loads the specified language.
		/// </summary>
		/// <param name="name">Language name.</param>
		public void Load(string name)
		{
			if(name != DefaultLangName)
				Default = new I18nPage { Values = Loader.Load(DefaultLangName), Name = DefaultLangName };
			Current = new I18nPage { Values = Loader.Load(name), Name = name };
		}

		/// <summary>
		/// Reloads the selected language.
		/// </summary>
		public void Reload()
		{
			if(Current.Name != DefaultLangName)
				Default = new I18nPage { Values = Loader.Load(DefaultLangName), Name = DefaultLangName };
			Current = new I18nPage { Values = Loader.Load(Current.Name), Name = Current.Name };
		}

		/// <summary>
		/// Gets a list of all the available languages.
		/// </summary>
		/// <returns>A language list.</returns>
		public List<I18nLang> ListLanguages()
		{
			return Loader.ListLanguages();
		}

		/// <summary>
		/// Gets a system language.
		/// </summary>
		public static string GetSystem()
		{
			var cult = CultureInfo.CurrentUICulture;
			return cult.Name.Replace("-", "_");
		}

		/// <summary>
		/// Gets a I18n pair from a line.
		/// </summary>
		/// <returns>An I18n pair.</returns>
		/// <param name="line">Localization file line.</param>
		public static KeyValuePair<string, string> ProcessString(string line)
		{
			if (!string.IsNullOrWhiteSpace(line))
			{
				string unform = line.Replace("\t", "").Replace(" ", "");
				if (!unform.StartsWith("#", StringComparison.Ordinal))
				{
					int sep = line.IndexOf("=", StringComparison.Ordinal);
					if (sep != -1)
					{
						string k = line.Substring(0, sep);
						string v = line.Substring(sep + 1).Replace("\\n", "\n");
						return new KeyValuePair<string, string>(k, v);
					}
				}
			}
			return new KeyValuePair<string, string>(null, null);
		}
	}
}
