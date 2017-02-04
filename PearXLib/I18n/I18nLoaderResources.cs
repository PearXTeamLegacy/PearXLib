using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PearXLib.I18n
{
	/// <summary>
	/// An I18n loader for loading from embedded resources.
	/// </summary>
	public class I18nLoaderResources : I18nLoader
	{
		/// <summary>
		/// The embedded resources domain. For example, "Game.Resources.Langs".
		/// </summary>
		public string ResourcesPath { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PearXLib.I18n.I18nLoaderResources"/> class.
		/// </summary>
		/// <param name="resPath">The embedded resources domain. For example, "Game.Resources.Langs".</param>
		public I18nLoaderResources(string resPath)
		{
			ResourcesPath = resPath;
		}

		/// <summary>
		/// Loads a language into the Dictionary.
		/// </summary>
		/// <returns>The key:localized dictionary.</returns>
		/// <param name="lang">Language name.</param>
		public Dictionary<string, string> Load(string lang)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			var nm = ResourcesPath + "." + lang + ".lang";
			var str = Encoding.UTF8.GetString(ResourceUtils.GetFromResources(nm));
			foreach (string l in PXL.GetArrayFromString(str))
			{
				var pair = I18n.ProcessString(l);
				if (pair.Key != null)
					dict.Add(pair.Key, pair.Value);
			}
			return dict;
		}

		/// <summary>
		/// Gets a list of all the available languages.
		/// </summary>
		/// <returns>A language list.</returns>
		public List<I18nLang> ListLanguages()
		{
			List<I18nLang> l = new List<I18nLang>();
			var resrs = ResourceUtils.GetResourcesInDomain(ResourcesPath);
			foreach (var res in resrs)
			{
				if (res.EndsWith(".lang", StringComparison.Ordinal))
				{
					if (resrs.Contains(res + "info"))
					{
						string ln = res.Substring(ResourcesPath.Length + 1);
						l.Add(new I18nLang { Name = ln.Substring(0, ln.Length - 5), LangName = Encoding.UTF8.GetString(ResourceUtils.GetFromResources(res + "info")) });
					}
				}
			}
			return l;
		}
	}
}
