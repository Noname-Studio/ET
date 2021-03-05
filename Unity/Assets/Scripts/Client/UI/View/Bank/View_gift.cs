/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
	public partial class View_gift : GComponent
	{
		public Controller c1;
		public GTextField Num;
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://yf9s6r30skkaje";

		public static View_gift CreateInstance()
		{
			return (View_gift)UIPackage.CreateObject("Bank","gift");
		}

		public View_gift()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			Num = (GTextField)this.GetChildAt(4);
			t0 = this.GetTransitionAt(0);
			t1 = this.GetTransitionAt(1);
		}
	}
}