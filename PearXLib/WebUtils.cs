using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace PearXLib
{
	/// <summary>
	/// PearXLib Web Utilities
	/// </summary>
	public static class WebUtils
	{
		/// <summary>
		/// Sends a POST request to the site.
		/// </summary>
		/// <param name="url">Site URL.</param>
		/// <param name="data">Request's content. Use &amp; to split more than one parameters. ex: login=Developer&amp;password=123456789</param>
		/// <param name="contentType">Your content type.</param>
		/// <returns>Web response.</returns>
		public static string SendPOSTRequest(string url, string data, string contentType = "application/x-www-form-urlencoded")
		{
			WebRequest wr = WebRequest.Create(url);
			wr.Method = "POST";
			wr.ContentType = contentType;
			wr.Proxy = new WebProxy();

			byte[] bytes = Encoding.ASCII.GetBytes(data);
			wr.ContentLength = bytes.Length;
			using (Stream reqStream = wr.GetRequestStream())
			{
				reqStream.Write(bytes, 0, bytes.Length);
			}
			using (WebResponse resp = wr.GetResponse())
			{
				using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
				{
					return sr.ReadToEnd().Trim();
				}
			}
		}

		/// <summary>
		/// Sends a GET request.
		/// </summary>
		/// <returns>The response string.</returns>
		/// <param name="url">URL.</param>
		public static string SendGetRequest(string url)
		{
			using (WebClient c = new WebClient())
				return c.DownloadString(url);
		}

		/// <summary>
		/// Checks for a Internet connectivity.
		/// </summary>
		/// <param name="domain">The domain, that you want to ping. If not presented, uses google.com</param>
		/// <returns>True, if Internet connection is available, else returns false.</returns>
		public static bool CheckForInternetConnection(string domain = "google.com")
		{
			try
			{
				return new Ping().Send(domain).Status == IPStatus.Success;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Gets the redirect URL from URL.
		/// </summary>
		/// <returns>The redirect URL.</returns>
		/// <param name="url">URL.</param>
		public static string GetRedirectUrl(string url)
		{
			var req = (HttpWebRequest)WebRequest.Create(url);
			req.AllowAutoRedirect = false;
			req.Method = "HEAD";
			using (var resp = req.GetResponse())
			{
				return resp.Headers["Location"];
			}
		}
	}
}
