/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
	public partial class View_loadingstar : GComponent
	{
		public Transition t0;

		public const string URL = "ui://btrw885ip59ohk";

		public static View_loadingstar CreateInstance()
		{
			return (View_loadingstar)UIPackage.CreateObject("QuizGame","loadingstar");
		}

		public View_loadingstar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
		}
	}
}