/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.SlotMachine
{
	public partial class View_Paw : GComponent
	{
		public Transition t0;

		public const string URL = "ui://yta40mdqfrj4ma";

		public static View_Paw CreateInstance()
		{
			return (View_Paw)UIPackage.CreateObject("SlotMachine","Paw");
		}

		public View_Paw()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = this.GetTransitionAt(0);
		}
	}
}