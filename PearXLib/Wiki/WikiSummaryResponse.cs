using System.Collections.Generic;
#pragma warning disable 1591

namespace PearXLib.Wiki
{
	public class WikiSummaryResponse
	{
		public class Page
		{
			public int pageid { get; set; }
			public int ns { get; set; }
			public string title { get; set; }
			public string extract { get; set; }
		}

		public class Query
		{
			public Dictionary<string, Page> pages { get; set; }
		}

		public class RootObject
		{
			public string batchcomplete { get; set; }
			public Query query { get; set; }
		}
	}
}
