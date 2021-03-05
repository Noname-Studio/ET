/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_Dialog_Amazing : GComponent
	{
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://y0mpnw87nfvpmo";

		public static View_Dialog_Amazing CreateInstance()
		{
			return (View_Dialog_Amazing)UIPackage.CreateObject("StoryProcess","Dialog_Amazing");
		}

		public View_Dialog_Amazing()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
			t1 = this.GetTransitionAt(1);
		}
	}
}