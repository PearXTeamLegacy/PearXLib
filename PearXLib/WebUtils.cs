using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PearXLib
{
	/// <summary>
	/// PearXLib Web Utilities
	/// </summary>
	public static class WebUtils
	{
		/// <summary>
		/// Sends a request to the site.
		/// </summary>
		/// <param name="url">Site URL.</param>
		/// <param name="method">Request method.</param>
		/// <param name="data">Request's content. Use &amp; to split more than one parameters. ex: login=Developer&amp;password=123456789</param>
		/// <param name="contentType">Your content type.</param>
		/// <param name="enc">The encoding for performing a request.</param>
		/// <returns>Web response.</returns>
		public static string SendRequest(string url, string method, string data, string contentType = "application/x-www-form-urlencoded", Encoding enc = null)
		{
			if (enc == null)
				enc = Encoding.UTF8;
			WebRequest wr = WebRequest.Create(url);
			wr.Method = method;
			if (!string.IsNullOrEmpty(contentType))
				wr.ContentType = contentType;
			wr.Proxy = new WebProxy();

			if (!string.IsNullOrEmpty(data))
			{
				byte[] bytes = enc.GetBytes(data);
				wr.ContentLength = bytes.Length;
				using (Stream reqStream = wr.GetRequestStream())
				{
					reqStream.Write(bytes, 0, bytes.Length);
				}
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
		/// <param name="url">A url for the connection check.</param>
		/// <param name="port">A port for the connection check.</param>
		/// <returns>True, if Internet connection is available, else returns false.</returns>
		public static bool CheckForInternetConnection(string url = "http://google.com", int port = 80)
		{
			using (var tcp = new TcpClient())
			{
				try
				{
					tcp.Connect(url, port);
					tcp.Close();
					return true;
				}
				catch(SocketException) { }
			}
			return false;
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

		/// <summary>
		/// Downloads an image from the Internet.
		/// </summary>
		/// <returns>Image.</returns>
		/// <param name="url">Image URL.</param>
		public static Image DownloadImage(string url)
		{
			using (WebResponse resp = WebRequest.Create(url).GetResponse())
			{
				using (var stream = resp.GetResponseStream())
				{
					return Image.FromStream(stream);
				}
			}
		}
	}
}
