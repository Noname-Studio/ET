/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Settings
{
	public partial class View_synchrodata_button : GButton
	{
		public Controller c1;
		public Transition t0;

		public const string URL = "ui://yzgsvb7w91qrny";

		public static View_synchrodata_button CreateInstance()
		{
			return (View_synchrodata_button)UIPackage.CreateObject("Settings","synchrodata_button");
		}

		public View_synchrodata_button()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(1);
			t0 = this.GetTransitionAt(0);
		}
	}
}