/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_NameGroupLeft : GLabel
	{
		public GImage Name1Bg;

		public const string URL = "ui://y0mpnw87s6ho5i";

		public static View_NameGroupLeft CreateInstance()
		{
			return (View_NameGroupLeft)UIPackage.CreateObject("StoryProcess","NameGroupLeft");
		}

		public View_NameGroupLeft()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Name1Bg = (GImage)this.GetChildAt(0);
		}
	}
}