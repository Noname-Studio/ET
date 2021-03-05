/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
	public partial class View_CardProp : GButton
	{
		public GTextField Name;
		public GButton Buy;
		public GTextField Price;
		public GTextField Num;
		public GTextField DisableDesc;

		public const string URL = "ui://yf9s6r30qmjom5";

		public static View_CardProp CreateInstance()
		{
			return (View_CardProp)UIPackage.CreateObject("Bank","CardProp");
		}

		public View_CardProp()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Name = (GTextField)this.GetChildAt(7);
			Buy = (GButton)this.GetChildAt(8);
			Price = (GTextField)this.GetChildAt(9);
			Num = (GTextField)this.GetChildAt(16);
			DisableDesc = (GTextField)this.GetChildAt(17);
		}
	}
}