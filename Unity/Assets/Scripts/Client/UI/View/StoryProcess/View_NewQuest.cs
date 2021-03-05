/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_NewQuest : GLabel
	{
		public GLabel Core;
		public Transition T0;

		public const string URL = "ui://y0mpnw87q9s95d";

		public static View_NewQuest CreateInstance()
		{
			return (View_NewQuest)UIPackage.CreateObject("StoryProcess","NewQuest");
		}

		public View_NewQuest()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Core = (GLabel)this.GetChildAt(0);
			T0 = this.GetTransitionAt(0);
		}
	}
}