using System.Collections.Generic;

namespace PearXLib.I18n
{
	/// <summary>
	/// A base for I18n loaders.
	/// </summary>
	public interface I18nLoader
	{
		/// <summary>
		/// Loads a language into the Dictionary.
		/// </summary>
		/// <returns>The key:localized dictionary.</returns>
		/// <param name="lang">Language name.</param>
		Dictionary<string, string> Load(string lang);

		/// <summary>
		/// Gets a list of all the available languages.
		/// </summary>
		/// <returns>A language list.</returns>
		List<I18nLang> ListLanguages();

		bool Contains(string name);
	}
}
