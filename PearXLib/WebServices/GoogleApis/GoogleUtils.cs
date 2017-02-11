using System;
using Newtonsoft.Json;

namespace PearXLib.WebServices.GoogleApis
{
	/// <summary>
	/// PearXLib's Google API Utils.
	/// </summary>
	public class GoogleUtils
	{
		/// <summary>
		/// Shorts an URL.
		/// </summary>
		/// <param name="url">Full URL</param>
		/// <param name="apiKey">Google API Key</param>
		/// <returns>Shorten URL in JSON format</returns>
		public static GoogleShortener ShortURL(string url, string apiKey)
		{
			string s = WebUtils.SendRequest("https://www.googleapis.com/urlshortener/v1/url?key=" + apiKey, "POST", "{\"longUrl\": \"" + url + "\"}", "application/json");
			return JsonConvert.DeserializeObject<GoogleShortener>(s);
		}

		/// <summary>
		/// Search image in the Google.
		/// </summary>
		/// <returns>Response in JSON format.</returns>
		/// <param name="query">Search query.</param>
		/// <param name="apiKey">Google API key.</param>
		/// <param name="searchID">Google Custom Search ID.</param>
		/// <param name="start">Start search from $start entry.</param>
		public static GoogleImageSearch.RootObject SearchImages(string query, string apiKey, string searchID, int start = 1)
		{
			string q = Uri.EscapeUriString(query.Replace("&", " "));
			string str = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&q={q}&searchType=image&alt=json&start={start.ToString()}&cx={searchID}";
			string s = WebUtils.SendGetRequest(str);
			return JsonConvert.DeserializeObject<GoogleImageSearch.RootObject>(s);
		}
	}
}
