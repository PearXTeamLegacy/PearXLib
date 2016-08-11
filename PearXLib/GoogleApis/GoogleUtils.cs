using System.Web;
using Newtonsoft.Json;

namespace PearXLib.GoogleApis
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
			string s = WebUtils.SendPOSTRequest("https://www.googleapis.com/urlshortener/v1/url?key=" + apiKey, "{\"longUrl\": \"" + url + "\"}", "application/json");
			return JsonConvert.DeserializeObject<GoogleShortener>(s);
		}

		/// <summary>
		/// Search image in the Google.
		/// </summary>
		/// <returns>Response in JSON format.</returns>
		/// <param name="query">Search query.</param>
		/// <param name="apiKey">Google API key.</param>
		/// <param name="searchID">Google Custom Search ID.</param>
		public static GoogleImageSearch.RootObject SearchImages(string query, string apiKey, string searchID)
		{
			string q = HttpUtility.UrlEncode(query.Replace("&", " "));
			string s = WebUtils.SendGetRequest($"https://www.googleapis.com/customsearch/v1?key={apiKey}&q={q}&searchType=image&alt=json&cx={searchID}");
			return JsonConvert.DeserializeObject<GoogleImageSearch.RootObject>(s);
		}
	}
}
