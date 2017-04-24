using System;
using System.IO;
using System.Net;
using System.Text;
using PearXLib.Maths;

namespace PearXLib
{
	/// <summary>
	/// An upgraded webclient.
	/// </summary>
	public class XWebClient : IDisposable
	{
		/// <summary>
		/// Occurs when download progress changed.
		/// </summary>
		public event EventHandler<BytesRecievedEventArgs> ProgressChanged;

		/// <summary>
		/// Releases all resource used by the <see cref="T:PearXLib.XWebClient"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:PearXLib.XWebClient"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="T:PearXLib.XWebClient"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="T:PearXLib.XWebClient"/> so the garbage
		/// collector can reclaim the memory that the <see cref="T:PearXLib.XWebClient"/> was occupying.</remarks>
		public void Dispose()
		{
			ProgressChanged = null;
			//GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Downloads the file.
		/// </summary>
		/// <param name="url">File URL.</param>
		/// <param name="local">Local path.</param>
		/// <param name="bufferSize">Buffer size.</param>
		/// <param name="asyncEvents">If set to <c>true</c>, events should be async.</param>
		/// <param name="post">POST data.</param>
		/// <param name="enc">POST encoding.</param>
		public void DownloadFile(string url, string local, string post = null, Encoding enc = null, int bufferSize = 8192)
		{
			using (var fs = new FileStream(local, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
			{
				if (enc == null)
					enc = Encoding.UTF8;
				WebRequest req = WebRequest.Create(url);
			    if (post != null)
			    {
			        req.Method = "POST";
			        using (var str = req.GetRequestStream())
			        {
			            byte[] bts = enc.GetBytes(post);
			            str.Write(bts, 0, bts.Length);
			            str.Flush();
			        }
			    }
			    using (WebResponse resp = req.GetResponse())
				{
					using (Stream str = resp.GetResponseStream())
					{
						long size = Convert.ToInt64(resp.Headers[HttpResponseHeader.ContentLength]);
						byte[] buffer = new byte[bufferSize];
						int i;
						long rec = 0;
						do
						{
							i = str.Read(buffer, 0, buffer.Length);
							rec += i;
							fs.Write(buffer, 0, i);
							ProgressChanged?.Invoke(this, new BytesRecievedEventArgs(size, rec));
						} while (i > 0);
						str.Flush();
					}
				}
				fs.Flush();
			}
		}
	}

	/// <summary>
	/// Event arguments for downloading.
	/// </summary>
	public class BytesRecievedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PearXLib.BytesRecievedEventArgs"/> class.
		/// </summary>
		/// <param name="total">Total bytes to download.</param>
		/// <param name="recieved">Recieved bytes.</param>
		public BytesRecievedEventArgs(long total, long recieved)
		{
			Total = total;
			Recieved = recieved;
		}
		/// <summary>
		/// Total bytes to download.
		/// </summary>
		public long Total { get; set; }

		/// <summary>
		/// Recieved bytes.
		/// </summary>
		public long Recieved { get; set; }

		/// <summary>
		/// Recieved bytes in percents
		/// </summary>
		/// <value>The in percents.</value>
		public double InPercents => MathUtils.GetInPercents(Total, Recieved);
	}
}
