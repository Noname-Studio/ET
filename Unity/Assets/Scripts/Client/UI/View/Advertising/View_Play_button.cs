/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Advertising
{
	public partial class View_Play_button : GButton
	{
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://lpoqxdrph5c8h";

		public static View_Play_button CreateInstance()
		{
			return (View_Play_button)UIPackage.CreateObject("Advertising","Play_button");
		}

		public View_Play_button()
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