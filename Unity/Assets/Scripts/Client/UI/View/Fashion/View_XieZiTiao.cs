/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
	public partial class View_XieZiTiao : GComponent
	{
		public GList List;

		public const string URL = "ui://e18f31poqcub1w";

		public static View_XieZiTiao CreateInstance()
		{
			return (View_XieZiTiao)UIPackage.CreateObject("Fashion","鞋子条");
		}

		public View_XieZiTiao()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			List = (GList)this.GetChildAt(1);
		}
	}
}