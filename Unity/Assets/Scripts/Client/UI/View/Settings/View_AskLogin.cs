/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Settings
{
	public partial class View_AskLogin : GComponent
	{
		public Controller c1;
		public GButton bg;
		public GButton login;
		public GButton Close;
		public GRichTextField Relief;

		public const string URL = "ui://yzgsvb7wsqrcns";

		public static View_AskLogin CreateInstance()
		{
			return (View_AskLogin)UIPackage.CreateObject("Settings","AskLogin");
		}

		public View_AskLogin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			login = (GButton)this.GetChildAt(2);
			Close = (GButton)this.GetChildAt(8);
			Relief = (GRichTextField)this.GetChildAt(9);
		}
	}
}