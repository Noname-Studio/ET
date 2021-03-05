/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Signin
{
	public partial class View_ShiJianBiaoQian : GLabel
	{
		public Controller c1;

		public const string URL = "ui://9cwletjdwz6tn";

		public static View_ShiJianBiaoQian CreateInstance()
		{
			return (View_ShiJianBiaoQian)UIPackage.CreateObject("Signin","时间标签");
		}

		public View_ShiJianBiaoQian()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
		}
	}
}