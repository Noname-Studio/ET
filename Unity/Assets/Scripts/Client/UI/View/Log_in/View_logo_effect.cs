/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Log_in
{
	public partial class View_logo_effect : GComponent
	{
		public Controller c1;
		public GLoader faguang;
		public GLoader cake;
		public GLoader logo;
		public View_logo_liuguang light0;
		public View_logo_liuguangFan light1;
		public View_logo_liuguangJian light2;
		public Transition t0;

		public const string URL = "ui://jevtvvkerir5e";

		public static View_logo_effect CreateInstance()
		{
			return (View_logo_effect)UIPackage.CreateObject("Log_in","logo_effect");
		}

		public View_logo_effect()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			faguang = (GLoader)this.GetChildAt(0);
			cake = (GLoader)this.GetChildAt(1);
			logo = (GLoader)this.GetChildAt(2);
			light0 = (View_logo_liuguang)this.GetChildAt(6);
			light1 = (View_logo_liuguangFan)this.GetChildAt(7);
			light2 = (View_logo_liuguangJian)this.GetChildAt(8);
			t0 = this.GetTransitionAt(0);
		}
	}
}