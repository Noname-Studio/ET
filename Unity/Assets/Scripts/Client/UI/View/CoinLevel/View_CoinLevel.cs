/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CoinLevel
{
	public partial class View_CoinLevel : GComponent
	{
		public Controller c1;
		public Controller HaveChallenge;
		public GButton bg;
		public GLabel MaskRest;
		public GTextField RestName;
		public GButton NextBatch;
		public GGroup RestaurantInformation;
		public View_MoreCoin_Button MoreCoin;
		public GButton Shop;
		public GButton Close;
		public GList CoinLevelList;
		public View_TiaoZhanGuanKaZuJian Challenge;

		public const string URL = "ui://yza5bcq0ldf1ij";

		public static View_CoinLevel CreateInstance()
		{
			return (View_CoinLevel)UIPackage.CreateObject("CoinLevel","CoinLevel");
		}

		public View_CoinLevel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			HaveChallenge = this.GetControllerAt(1);
			bg = (GButton)this.GetChildAt(0);
			MaskRest = (GLabel)this.GetChildAt(20);
			RestName = (GTextField)this.GetChildAt(21);
			NextBatch = (GButton)this.GetChildAt(26);
			RestaurantInformation = (GGroup)this.GetChildAt(27);
			MoreCoin = (View_MoreCoin_Button)this.GetChildAt(28);
			Shop = (GButton)this.GetChildAt(29);
			Close = (GButton)this.GetChildAt(30);
			CoinLevelList = (GList)this.GetChildAt(35);
			Challenge = (View_TiaoZhanGuanKaZuJian)this.GetChildAt(36);
		}
	}
}