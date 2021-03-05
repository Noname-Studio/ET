/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Log_in
{
	public partial class View_Login : GComponent
	{
		public Controller HasLogin;
		public Controller IsFirstLogin;
		public GButton ButtonUp;
		public View_logo_effect logo;
		public GButton FacebookButton;
		public View_x30_effect RewardGem;
		public GGroup FacebookGroup;
		public GRichTextField Relief;
		public GButton Accept;
		public Transition t0;

		public const string URL = "ui://jevtvvkez5hf2";

		public static View_Login CreateInstance()
		{
			return (View_Login)UIPackage.CreateObject("Log_in","Login");
		}

		public View_Login()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			HasLogin = this.GetControllerAt(0);
			IsFirstLogin = this.GetControllerAt(1);
			ButtonUp = (GButton)this.GetChildAt(2);
			logo = (View_logo_effect)this.GetChildAt(3);
			FacebookButton = (GButton)this.GetChildAt(4);
			RewardGem = (View_x30_effect)this.GetChildAt(5);
			FacebookGroup = (GGroup)this.GetChildAt(6);
			Relief = (GRichTextField)this.GetChildAt(9);
			Accept = (GButton)this.GetChildAt(10);
			t0 = this.GetTransitionAt(0);
		}
	}
}