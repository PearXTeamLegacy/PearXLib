using System;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace PearXLib.Wiki
{
	/// <summary>
	/// PearXLib's wiki utils.
	/// </summary>
	public static class WikiUtils
	{
		/// <summary>
		/// Gets the wiki page summary.
		/// </summary>
		/// <returns>The wiki page summary.</returns>
		/// <param name="apiPhp">Wiki's API php.</param>
		/// <param name="name">Page name.</param>
		public static WikiSummaryResponse.RootObject GetSummary(string apiPhp, string name)
		{
			using (WebClient c = new WebClient())
			{
				string nm = Uri.EscapeUriString(name);
				string s = c.DownloadString(apiPhp + "?format=json&action=query&prop=extracts&exintro=&explaintext=&redirects=&titles=" + nm);
				return JsonConvert.DeserializeObject<WikiSummaryResponse.RootObject>(s);
			}
		}
	}
}
