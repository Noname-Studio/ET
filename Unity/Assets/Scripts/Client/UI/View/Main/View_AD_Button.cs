/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_AD_Button : GButton
	{
		public GTextField Text;
		public Transition t0;

		public const string URL = "ui://fmkyh2ywkf5q8p9";

		public static View_AD_Button CreateInstance()
		{
			return (View_AD_Button)UIPackage.CreateObject("Main","AD_Button");
		}

		public View_AD_Button()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Text = (GTextField)this.GetChildAt(11);
			t0 = this.GetTransitionAt(0);
		}
	}
}