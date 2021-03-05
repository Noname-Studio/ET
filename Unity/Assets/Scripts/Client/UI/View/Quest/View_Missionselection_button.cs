/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_Missionselection_button : GButton
	{
		public GImage Tips;

		public const string URL = "ui://ytnp4vk8ifeglv";

		public static View_Missionselection_button CreateInstance()
		{
			return (View_Missionselection_button)UIPackage.CreateObject("Quest","Missionselection_button");
		}

		public View_Missionselection_button()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Tips = (GImage)this.GetChildAt(3);
		}
	}
}