using System.Drawing;
#pragma warning disable 1591

namespace PearXLib.WebServices.Wolfram
{
	public class WolframPod
	{
		public WolframImage[] Images { get; set; }
		public string Title { get; set; }
	}

	public class WolframImage
	{
		public Image Image { get; set; }
		public string Alt { get; set; }
	}
}
