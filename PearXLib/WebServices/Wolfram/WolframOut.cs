using System;
using System.Drawing;

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
