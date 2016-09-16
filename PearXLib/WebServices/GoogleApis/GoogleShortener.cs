namespace PearXLib.WebServices.GoogleApis
{
	/// <summary>
	/// A class for deserialized goo.gl response
	/// </summary>
	public class GoogleShortener
	{
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
