/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_dialogue_right : GComponent
	{
		public GImage Bg;
		public GTextField Text;

		public const string URL = "ui://y0mpnw87so97pl";

		public static View_dialogue_right CreateInstance()
		{
			return (View_dialogue_right)UIPackage.CreateObject("StoryProcess","dialogue_right");
		}

		public View_dialogue_right()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Bg = (GImage)this.GetChildAt(0);
			Text = (GTextField)this.GetChildAt(1);
		}
	}
}