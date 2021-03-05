/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_RestaurantJump_button : GButton
	{
		public GLabel Mask;

		public const string URL = "ui://fmkyh2ywslfx8nk";

		public static View_RestaurantJump_button CreateInstance()
		{
			return (View_RestaurantJump_button)UIPackage.CreateObject("Main","RestaurantJump_button");
		}

		public View_RestaurantJump_button()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Mask = (GLabel)this.GetChildAt(0);
		}
	}
}