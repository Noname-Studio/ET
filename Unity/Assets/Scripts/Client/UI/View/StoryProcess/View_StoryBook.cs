/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_StoryBook : GComponent
	{
		public GButton bg;
		public GGraph Holder;
		public GTextField Desc;

		public const string URL = "ui://y0mpnw87lpzcupt";

		public static View_StoryBook CreateInstance()
		{
			return (View_StoryBook)UIPackage.CreateObject("StoryProcess","StoryBook");
		}

		public View_StoryBook()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Holder = (GGraph)this.GetChildAt(1);
			Desc = (GTextField)this.GetChildAt(2);
		}
	}
}