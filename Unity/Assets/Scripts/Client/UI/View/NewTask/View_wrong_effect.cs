/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
	public partial class View_wrong_effect : GComponent
	{
		public GLoader icon;
		public GTextField Num;
		public Transition t0;

		public const string URL = "ui://f1lcfy6mms1ks";

		public static View_wrong_effect CreateInstance()
		{
			return (View_wrong_effect)UIPackage.CreateObject("NewTask","wrong_effect");
		}

		public View_wrong_effect()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			icon = (GLoader)this.GetChildAt(0);
			Num = (GTextField)this.GetChildAt(1);
			t0 = this.GetTransitionAt(0);
		}
	}
}