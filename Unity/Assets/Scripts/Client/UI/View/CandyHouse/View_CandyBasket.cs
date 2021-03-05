/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
	public partial class View_CandyBasket : GComponent
	{
		public Controller Candy;
		public GTextField TotalCount;
		public Transition t0;

		public const string URL = "ui://3b4mf257es74q";

		public static View_CandyBasket CreateInstance()
		{
			return (View_CandyBasket)UIPackage.CreateObject("CandyHouse","CandyBasket");
		}

		public View_CandyBasket()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Candy = this.GetControllerAt(0);
			TotalCount = (GTextField)this.GetChildAt(8);
			t0 = this.GetTransitionAt(0);
		}
	}
}