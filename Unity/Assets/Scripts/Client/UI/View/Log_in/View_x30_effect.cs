/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Log_in
{
	public partial class View_x30_effect : GComponent
	{
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://jevtvvkehl5712";

		public static View_x30_effect CreateInstance()
		{
			return (View_x30_effect)UIPackage.CreateObject("Log_in","x30_effect");
		}

		public View_x30_effect()
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