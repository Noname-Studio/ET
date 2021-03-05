/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
	public partial class View_CardGift : GButton
	{
		public GLabel recommend;
		public GButton Buy;
		public GTextField Price;

		public const string URL = "ui://yf9s6r30qmjom9";

		public static View_CardGift CreateInstance()
		{
			return (View_CardGift)UIPackage.CreateObject("Bank","CardGift");
		}

		public View_CardGift()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			recommend = (GLabel)this.GetChildAt(13);
			Buy = (GButton)this.GetChildAt(14);
			Price = (GTextField)this.GetChildAt(15);
		}
	}
}