/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_NoQuest : GComponent
	{
		public GButton bg;
		public GButton FollowUs;
		public GTextField Desc;

		public const string URL = "ui://ytnp4vk8igsnnr";

		public static View_NoQuest CreateInstance()
		{
			return (View_NoQuest)UIPackage.CreateObject("Quest","NoQuest");
		}

		public View_NoQuest()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			FollowUs = (GButton)this.GetChildAt(3);
			Desc = (GTextField)this.GetChildAt(4);
		}
	}
}