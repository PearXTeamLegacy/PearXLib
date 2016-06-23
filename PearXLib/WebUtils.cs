using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// PearXLib Web Utilities
    /// </summary>
    public class WebUtils
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
            using (StreamReader sr = new StreamReader(wr.GetResponse().GetResponseStream()))
            {
                return sr.ReadToEnd().Trim();
            }
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
        /// Shorts an URL. Returns JSON! De-serialize it with <![CDATA[JsonConvert.DeserializeObject<GoogleShortener>(string)]]>
        /// </summary>
        /// <param name="url">Full URL</param>
        /// <param name="apiKey">Google API Key</param>
        /// <returns>Shorten URL in JSON format</returns>
        public static string ShortURL(string url, string apiKey)
        {
            return SendPOSTRequest("https://www.googleapis.com/urlshortener/v1/url?key=" + apiKey, "{\"longUrl\": \"" + url + "\"}", "application/json");
        }
    }

    /// <summary>
    /// A class for deserialized goo.gl response
    /// </summary>
    public class GoogleShortener
    {
        /// <summary>
        /// ?
        /// </summary>
        public string kind { get; set; }
        /// <summary>
        /// Short URL
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Long URL
        /// </summary>
        public string longUrl { get; set; }
    }
}
