using System.Collections.Generic;

namespace PearXLib.I18n
{
	/// <summary>
	/// An I18n language page.
	/// </summary>
	public class I18nPage
	{
		/// <summary>
		/// A key:localized pair.
		/// </summary>
		public Dictionary<string, string> Values { get; set; }
		/// <summary>
		/// The language name.
		/// </summary>
		public string Name { get; set; }
	}
}
