namespace PearXLib
{
	public class MsgJson
	{
		public string Message { get; set; }
		public string Json { get; set; }

		public static MsgJson Parse(string resp)
		{
			MsgJson mj = new MsgJson();
			int i = resp.IndexOf(':');
			if (i == -1)
				mj.Message = resp;
			else
			{
				mj.Message = resp.Substring(0, i);
				mj.Json = resp.Substring(i + 1);
			}
			return mj;
		}
	}
}
