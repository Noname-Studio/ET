/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.SlotMachine
{
	public partial class View_rewardpopup : GComponent
	{
		public GButton bg;

		public const string URL = "ui://yta40mdqini3m4";

		public static View_rewardpopup CreateInstance()
		{
			return (View_rewardpopup)UIPackage.CreateObject("SlotMachine","rewardpopup");
		}

		public View_rewardpopup()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
		}
	}
}