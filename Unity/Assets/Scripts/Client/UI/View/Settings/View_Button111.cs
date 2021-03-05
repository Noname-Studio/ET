/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Settings
{
	public partial class View_Button111 : GButton
	{
		public GTextField FBStatus;

		public const string URL = "ui://yzgsvb7wb0v5no";

		public static View_Button111 CreateInstance()
		{
			return (View_Button111)UIPackage.CreateObject("Settings","Button111");
		}

		public View_Button111()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			FBStatus = (GTextField)this.GetChildAt(6);
		}
	}
}