namespace PearXLib
{
	/// <summary>
	/// Message + Json format, splitted by ":" character.
	/// </summary>
	public class MsgJson
	{
		/// <summary>
		/// Message.
		/// </summary>
		public string Message { get; set; }
		/// <summary>
		/// Json.
		/// </summary>
		public string Json { get; set; }

		/// <summary>
		/// Parses a string to the MsgJson.
		/// </summary>
		/// <returns>MsgJson.</returns>
		/// <param name="resp">Input string.</param>
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
