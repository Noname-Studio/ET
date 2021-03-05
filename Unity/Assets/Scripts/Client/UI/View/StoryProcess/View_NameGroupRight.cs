/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_NameGroupRight : GLabel
	{
		public GImage Name4Bg;

		public const string URL = "ui://y0mpnw87s6ho5k";

		public static View_NameGroupRight CreateInstance()
		{
			return (View_NameGroupRight)UIPackage.CreateObject("StoryProcess","NameGroupRight");
		}

		public View_NameGroupRight()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Name4Bg = (GImage)this.GetChildAt(0);
		}
	}
}