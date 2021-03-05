/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
	public partial class View_xingxing_effect : GComponent
	{
		public Transition t0;

		public const string URL = "ui://e18f31pohdmz1a";

		public static View_xingxing_effect CreateInstance()
		{
			return (View_xingxing_effect)UIPackage.CreateObject("Fashion","xingxing_effect");
		}

		public View_xingxing_effect()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
		}
	}
}