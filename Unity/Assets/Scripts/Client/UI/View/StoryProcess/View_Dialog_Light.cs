/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_Dialog_Light : GComponent
	{
		public Transition t0;

		public const string URL = "ui://y0mpnw87nfvpmq";

		public static View_Dialog_Light CreateInstance()
		{
			return (View_Dialog_Light)UIPackage.CreateObject("StoryProcess","Dialog_Light");
		}

		public View_Dialog_Light()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
		}
	}
}