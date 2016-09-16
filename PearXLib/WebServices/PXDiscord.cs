using System;
using Newtonsoft.Json;

namespace PearXLib.WebServices
{
	public static class PXDiscord
	{
		public static string GetUserToken(string email, string pass)
		{
			string resp = WebUtils.SendRequest("https://discordapp.com/api/auth/login", "POST", "{\"email\":\"" + email + "\",\"password\":\"" + pass + "\"}", "application/json");
			var v = JsonConvert.DeserializeObject<Response>(resp);
			if (v.token != null)
				return v.token;
			throw new DiscordException(v.email, v.password);
		}

		/// <summary>
		/// Discord login request response.
		/// </summary>
		public class Response
		{
			/// <summary>
			/// If OK, token.
			/// </summary>
			/// <value>The token.</value>
			public string token { get; set; }
			/// <summary>
			/// Email error.
			/// </summary>
			public string[] email { get; set; }
			/// <summary>
			/// Password error.
			/// </summary>
			public string[] password { get; set; }
		}

		public class DiscordException : Exception
		{
			string _Message = "";
			public DiscordException(string[] email, string[] pass)
			{
				if (email != null)
					_Message = email[0];
				if (pass != null)
					_Message = pass[0];
			}

			public override string Message
			{
				get
				{
					return _Message;
				}
			}
		}
	}
}
