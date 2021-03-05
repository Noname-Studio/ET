/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
	public partial class View_FaXingMaoZiWu : GButton
	{
		public Controller c1;
		public GLoader icon1;
		public GTextField gem;

		public const string URL = "ui://e18f31potbryn";

		public static View_FaXingMaoZiWu CreateInstance()
		{
			return (View_FaXingMaoZiWu)UIPackage.CreateObject("Fashion","发型帽子屋");
		}

		public View_FaXingMaoZiWu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(1);
			icon1 = (GLoader)this.GetChildAt(3);
			gem = (GTextField)this.GetChildAt(4);
		}
	}
}