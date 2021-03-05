/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Log_in
{
	public partial class View_logo_liuguangJian : GComponent
	{
		public Transition t0;

		public const string URL = "ui://jevtvvketauep";

		public static View_logo_liuguangJian CreateInstance()
		{
			return (View_logo_liuguangJian)UIPackage.CreateObject("Log_in","logo_liuguang简");
		}

		public View_logo_liuguangJian()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
		}
	}
}