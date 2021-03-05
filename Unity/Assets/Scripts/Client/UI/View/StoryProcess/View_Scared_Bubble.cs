/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_Scared_Bubble : GComponent
	{
		public GTextField title;
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://y0mpnw87duofoi";

		public static View_Scared_Bubble CreateInstance()
		{
			return (View_Scared_Bubble)UIPackage.CreateObject("StoryProcess","Scared_Bubble");
		}

		public View_Scared_Bubble()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			title = (GTextField)this.GetChildAt(2);
			t0 = this.GetTransitionAt(0);
			t1 = this.GetTransitionAt(1);
		}
	}
}