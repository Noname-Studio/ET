/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
	public partial class View_MachineHand : GComponent
	{
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://3b4mf257qxtbd";

		public static View_MachineHand CreateInstance()
		{
			return (View_MachineHand)UIPackage.CreateObject("CandyHouse","MachineHand");
		}

		public View_MachineHand()
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