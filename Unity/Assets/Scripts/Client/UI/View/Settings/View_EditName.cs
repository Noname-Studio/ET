/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Settings
{
	public partial class View_EditName : GComponent
	{
		public Controller name;
		public GButton bg;
		public GButton Close;
		public GTextInput Input;
		public GButton Confrim;

		public const string URL = "ui://yzgsvb7wm59bm7";

		public static View_EditName CreateInstance()
		{
			return (View_EditName)UIPackage.CreateObject("Settings","EditName");
		}

		public View_EditName()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			name = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			Close = (GButton)this.GetChildAt(4);
			Input = (GTextInput)this.GetChildAt(6);
			Confrim = (GButton)this.GetChildAt(7);
		}
	}
}