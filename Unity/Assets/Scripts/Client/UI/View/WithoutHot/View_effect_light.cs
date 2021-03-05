/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_effect_light : GComponent
	{
		public Transition t0;

		public const string URL = "ui://97pg0d8fi8gs14";

		public static View_effect_light CreateInstance()
		{
			return (View_effect_light)UIPackage.CreateObject("WithoutHot","effect_light");
		}

		public View_effect_light()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
		}
	}
}