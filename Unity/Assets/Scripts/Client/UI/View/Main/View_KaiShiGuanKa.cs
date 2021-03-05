/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_KaiShiGuanKa : GButton
	{
		public Controller Hard;
		public Transition t0;

		public const string URL = "ui://fmkyh2ywvqobs";

		public static View_KaiShiGuanKa CreateInstance()
		{
			return (View_KaiShiGuanKa)UIPackage.CreateObject("Main","开始关卡");
		}

		public View_KaiShiGuanKa()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Hard = this.GetControllerAt(1);
			t0 = this.GetTransitionAt(0);
		}
	}
}