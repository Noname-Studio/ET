/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
	public partial class View_play : GButton
	{
		public Controller c1;
		public Transition t0;

		public const string URL = "ui://btrw885ip98whd";

		public static View_play CreateInstance()
		{
			return (View_play)UIPackage.CreateObject("QuizGame","play");
		}

		public View_play()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(1);
			t0 = this.GetTransitionAt(0);
		}
	}
}