using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace PearXLib.Wiki
{
	public static class WikiUtils
	{
		public static WikiSummaryResponse.RootObject GetSummary(string apiPhp, string name)
		{
			using (WebClient c = new WebClient())
			{
				string nm = HttpUtility.UrlEncode(name);
				string s = c.DownloadString(apiPhp + "?format=json&action=query&prop=extracts&exintro=&explaintext=&redirects=&titles=" + nm);
				return JsonConvert.DeserializeObject<WikiSummaryResponse.RootObject>(s);
			}
		}
	}
}
