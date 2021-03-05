/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_Button1 : GButton
	{
		public View_Component1 com;
		public GButton morebtn;
		public GComponent hit;
		public Transition t0;
		public Transition t2;

		public const string URL = "ui://fmkyh2ywjgrh8nx";

		public static View_Button1 CreateInstance()
		{
			return (View_Button1)UIPackage.CreateObject("Main","Button1");
		}

		public View_Button1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			com = (View_Component1)this.GetChildAt(0);
			morebtn = (GButton)this.GetChildAt(1);
			hit = (GComponent)this.GetChildAt(3);
			t0 = this.GetTransitionAt(0);
			t2 = this.GetTransitionAt(1);
		}
	}
}