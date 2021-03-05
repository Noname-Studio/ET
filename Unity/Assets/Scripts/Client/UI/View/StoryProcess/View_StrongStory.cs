/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_StrongStory : GComponent
	{
		public Transition t0;

		public const string URL = "ui://y0mpnw87tmayfs";

		public static View_StrongStory CreateInstance()
		{
			return (View_StrongStory)UIPackage.CreateObject("StoryProcess","StrongStory");
		}

		public View_StrongStory()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
		}
	}
}