/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
	public partial class View_BankNew : GComponent
	{
		public Controller c1;
		public GGroup BG;
		public GList Menu;
		public GTextField ItemDesc;
		public View_effect Effect;
		public View_Pack Detail;
		public GTextField ItemName2;
		public GLoader ItemIcon;
		public GImage NumShadow;
		public GTextField ItemName;
		public GImage OwnCountFrame;
		public GTextField OwnCount;
		public View_gift DiamondExt;
		public GButton Buy;
		public GButton buy_prop;
		public GTextField InfineTime;
		public GGroup InfineGroup;
		public GList DiamondList;
		public GList GiftList;
		public GList PropList;
		public GButton Close;

		public const string URL = "ui://yf9s6r30qmjolw";

		public static View_BankNew CreateInstance()
		{
			return (View_BankNew)UIPackage.CreateObject("Bank","BankNew");
		}

		public View_BankNew()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			BG = (GGroup)this.GetChildAt(9);
			Menu = (GList)this.GetChildAt(14);
			ItemDesc = (GTextField)this.GetChildAt(17);
			Effect = (View_effect)this.GetChildAt(18);
			Detail = (View_Pack)this.GetChildAt(19);
			ItemName2 = (GTextField)this.GetChildAt(20);
			ItemIcon = (GLoader)this.GetChildAt(21);
			NumShadow = (GImage)this.GetChildAt(22);
			ItemName = (GTextField)this.GetChildAt(23);
			OwnCountFrame = (GImage)this.GetChildAt(24);
			OwnCount = (GTextField)this.GetChildAt(25);
			DiamondExt = (View_gift)this.GetChildAt(26);
			Buy = (GButton)this.GetChildAt(27);
			buy_prop = (GButton)this.GetChildAt(28);
			InfineTime = (GTextField)this.GetChildAt(30);
			InfineGroup = (GGroup)this.GetChildAt(32);
			DiamondList = (GList)this.GetChildAt(34);
			GiftList = (GList)this.GetChildAt(35);
			PropList = (GList)this.GetChildAt(36);
			Close = (GButton)this.GetChildAt(37);
		}
	}
}