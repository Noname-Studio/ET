/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
	public partial class View_CandyHouse : GComponent
	{
		public Controller ProduceState;
		public Controller Candy;
		public Controller IsMaxLevel;
		public GButton bg;
		public View_title Title;
		public GTextField MachineCount;
		public GList UpgradeList;
		public GLabel GetCandy;
		public GGroup tips2;
		public View_CandyBasket basket;
		public GButton UpgradeButton;
		public GButton Get;
		public GButton Fix;
		public View_MakeCandy_effect MakeCandyEffect;
		public View_ChuiZiDongHuaNew Damaged;
		public GButton Close;
		public GButton Help;
		public Transition t0;
		public Transition t1;

		public const string URL = "ui://3b4mf257hjnga";

		public static View_CandyHouse CreateInstance()
		{
			return (View_CandyHouse)UIPackage.CreateObject("CandyHouse","CandyHouse");
		}

		public View_CandyHouse()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			ProduceState = this.GetControllerAt(0);
			Candy = this.GetControllerAt(1);
			IsMaxLevel = this.GetControllerAt(2);
			bg = (GButton)this.GetChildAt(0);
			Title = (View_title)this.GetChildAt(18);
			MachineCount = (GTextField)this.GetChildAt(19);
			UpgradeList = (GList)this.GetChildAt(21);
			GetCandy = (GLabel)this.GetChildAt(24);
			tips2 = (GGroup)this.GetChildAt(25);
			basket = (View_CandyBasket)this.GetChildAt(26);
			UpgradeButton = (GButton)this.GetChildAt(27);
			Get = (GButton)this.GetChildAt(30);
			Fix = (GButton)this.GetChildAt(31);
			MakeCandyEffect = (View_MakeCandy_effect)this.GetChildAt(33);
			Damaged = (View_ChuiZiDongHuaNew)this.GetChildAt(37);
			Close = (GButton)this.GetChildAt(38);
			Help = (GButton)this.GetChildAt(39);
			t0 = this.GetTransitionAt(0);
			t1 = this.GetTransitionAt(1);
		}
	}
}