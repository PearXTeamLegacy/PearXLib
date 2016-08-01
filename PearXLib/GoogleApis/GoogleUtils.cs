using System;
namespace PearXLib.GoogleApis
{
	public class GoogleUtils
	{
		/// <summary>
		/// Shorts an URL. Returns JSON! De-serialize it with <![CDATA[JsonConvert.DeserializeObject<GoogleShortener>(string)]]>
		/// </summary>
		/// <param name="url">Full URL</param>
		/// <param name="apiKey">Google API Key</param>
		/// <returns>Shorten URL in JSON format</returns>
		public static string ShortURL(string url, string apiKey)
		{
			return WebUtils.SendPOSTRequest("https://www.googleapis.com/urlshortener/v1/url?key=" + apiKey, "{\"longUrl\": \"" + url + "\"}", "application/json");
		}

		/// <summary>
		/// Uses Google Search for image searching. Returns JSON! De-serialize it with <![CDATA[JsonConvert.DeserializeObject<GoogleImageSearch.RootObject>(stirng)]]>
		/// </summary>
		/// <returns>Response in JSON format.</returns>
		/// <param name="query">Search query.</param>
		/// <param name="apiKey">Google API key.</param>
		/// <param name="searchID">Google Custom Search ID.</param>
		public static string SearchImages(string query, string apiKey, string searchID)
		{
			return WebUtils.SendGetRequest($"https://www.googleapis.com/customsearch/v1?key={apiKey}&q={query}&searchType=image&alt=json&cx={searchID}");
		}
	}
}
