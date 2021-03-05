/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
	public partial class View_Pack : GComponent
	{
		public Controller c1;
		public GLoader packIcon;
		public GLoader prop1icon;
		public GTextField prop1text;
		public GGroup prop1;
		public GLoader prop0icon;
		public GTextField prop0text;
		public GGroup prop0;
		public GLoader prop2icon;
		public GTextField prop2text;
		public GGroup prop2;
		public GLoader prop4icon;
		public GTextField prop4text;
		public GGroup prop4;
		public GLoader prop3icon;
		public GTextField prop3text;
		public GGroup prop3;
		public GLoader prop5icon;
		public GTextField prop5text;
		public GGroup prop5;
		public GLoader prop6icon;
		public GTextField prop6text;
		public GGroup prop6;
		public GLoader prop7icon;
		public GTextField prop7text;
		public GGroup prop7;

		public const string URL = "ui://yf9s6r30p9humc";

		public static View_Pack CreateInstance()
		{
			return (View_Pack)UIPackage.CreateObject("Bank","Pack");
		}

		public View_Pack()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			packIcon = (GLoader)this.GetChildAt(0);
			prop1icon = (GLoader)this.GetChildAt(2);
			prop1text = (GTextField)this.GetChildAt(4);
			prop1 = (GGroup)this.GetChildAt(5);
			prop0icon = (GLoader)this.GetChildAt(6);
			prop0text = (GTextField)this.GetChildAt(8);
			prop0 = (GGroup)this.GetChildAt(9);
			prop2icon = (GLoader)this.GetChildAt(10);
			prop2text = (GTextField)this.GetChildAt(12);
			prop2 = (GGroup)this.GetChildAt(13);
			prop4icon = (GLoader)this.GetChildAt(14);
			prop4text = (GTextField)this.GetChildAt(16);
			prop4 = (GGroup)this.GetChildAt(17);
			prop3icon = (GLoader)this.GetChildAt(18);
			prop3text = (GTextField)this.GetChildAt(20);
			prop3 = (GGroup)this.GetChildAt(21);
			prop5icon = (GLoader)this.GetChildAt(22);
			prop5text = (GTextField)this.GetChildAt(24);
			prop5 = (GGroup)this.GetChildAt(25);
			prop6icon = (GLoader)this.GetChildAt(26);
			prop6text = (GTextField)this.GetChildAt(28);
			prop6 = (GGroup)this.GetChildAt(29);
			prop7icon = (GLoader)this.GetChildAt(30);
			prop7text = (GTextField)this.GetChildAt(32);
			prop7 = (GGroup)this.GetChildAt(33);
		}
	}
}