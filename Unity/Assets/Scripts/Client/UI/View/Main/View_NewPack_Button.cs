/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_NewPack_Button : GButton
	{
		public GComponent light;
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://fmkyh2ywobqw8nh";

		public static View_NewPack_Button CreateInstance()
		{
			return (View_NewPack_Button)UIPackage.CreateObject("Main","NewPack_Button");
		}

		public View_NewPack_Button()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			light = (GComponent)this.GetChildAt(1);
			t0 = this.GetTransitionAt(0);
			t1 = this.GetTransitionAt(1);
		}
	}
}