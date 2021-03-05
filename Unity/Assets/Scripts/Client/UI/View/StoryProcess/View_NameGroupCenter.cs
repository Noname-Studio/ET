/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_NameGroupCenter : GLabel
	{
		public GImage Name2Bg;

		public const string URL = "ui://y0mpnw87s6ho5j";

		public static View_NameGroupCenter CreateInstance()
		{
			return (View_NameGroupCenter)UIPackage.CreateObject("StoryProcess","NameGroupCenter");
		}

		public View_NameGroupCenter()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Name2Bg = (GImage)this.GetChildAt(0);
		}
	}
}