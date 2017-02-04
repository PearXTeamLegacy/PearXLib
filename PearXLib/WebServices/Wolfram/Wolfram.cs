using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace PearXLib.WebServices.Wolfram
{
	/// <summary>
	/// PearXLib's Wolfram utilities.
	/// </summary>
	public static class Wolfram
	{
		/// <summary>
		/// Use Wolfram!
		/// </summary>
		/// <returns>Wolfram output.</returns>
		/// <param name="input">Input string.</param>
		/// <param name="appid">Wolfram AppID.</param>
		public static WolframPod[] Process(string input, string appid)
		{
			List<WolframPod> lst = new List<WolframPod>();

			string inp = HttpUtility.UrlEncode(input);
			string s = WebUtils.SendGetRequest($"http://api.wolframalpha.com/v2/query?input={inp}&appid={appid}");

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(s);
			foreach (XmlNode n in doc.SelectNodes("queryresult/pod")) // foreach pods...
			{
				WolframPod pod = new WolframPod();
				pod.Title = n.Attributes["title"].Value;

				var ndsImg = n.SelectNodes("subpod/img");
				pod.Images = new WolframImage[ndsImg.Count];
				for (int i = 0; i < ndsImg.Count; i++) //foreach subpods...
				{
					var attrs = ndsImg[i].Attributes;
					pod.Images[i] = new WolframImage
					{
						Alt = attrs["alt"].Value,
						Image = WebUtils.DownloadImage(attrs["src"].Value)
					};
				}
				lst.Add(pod);
			}
			return lst.ToArray();
		}
	}
}
