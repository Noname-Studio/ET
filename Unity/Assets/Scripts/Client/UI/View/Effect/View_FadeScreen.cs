/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Effect
{
	public partial class View_FadeScreen : GComponent
	{
		public Transition t0;

		public const string URL = "ui://baomx0f25mka0";

		public static View_FadeScreen CreateInstance()
		{
			return (View_FadeScreen)UIPackage.CreateObject("Effect","FadeScreen");
		}

		public View_FadeScreen()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransition("t0");
		}
	}
}