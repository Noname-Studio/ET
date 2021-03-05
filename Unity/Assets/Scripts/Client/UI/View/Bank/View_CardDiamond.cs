/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
	public partial class View_CardDiamond : GButton
	{
		public GRichTextField Num;
		public GRichTextField Additive;
		public GGroup Offer;
		public GTextField InfineTime;
		public GGroup InfineGroup;
		public GTextField Price;
		public GLabel recommend;
		public GButton Buy;
		public Transition ads_effect;

		public const string URL = "ui://yf9s6r30qmjom0";

		public static View_CardDiamond CreateInstance()
		{
			return (View_CardDiamond)UIPackage.CreateObject("Bank","CardDiamond");
		}

		public View_CardDiamond()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Num = (GRichTextField)this.GetChildAt(6);
			Additive = (GRichTextField)this.GetChildAt(9);
			Offer = (GGroup)this.GetChildAt(10);
			InfineTime = (GTextField)this.GetChildAt(12);
			InfineGroup = (GGroup)this.GetChildAt(14);
			Price = (GTextField)this.GetChildAt(15);
			recommend = (GLabel)this.GetChildAt(16);
			Buy = (GButton)this.GetChildAt(17);
			ads_effect = this.GetTransitionAt(0);
		}
	}
}