/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Map
{
	public partial class View_XuanZhongDeCanTing : GLabel
	{
		public GLabel Image;

		public const string URL = "ui://z2vd6wpaookxg";

		public static View_XuanZhongDeCanTing CreateInstance()
		{
			return (View_XuanZhongDeCanTing)UIPackage.CreateObject("Map","选中的餐厅");
		}

		public View_XuanZhongDeCanTing()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Image = (GLabel)this.GetChildAt(1);
		}
	}
}