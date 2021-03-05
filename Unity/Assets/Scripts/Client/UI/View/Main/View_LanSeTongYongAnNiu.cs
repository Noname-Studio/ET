/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_LanSeTongYongAnNiu : GButton
	{
		public GComponent hit;

		public const string URL = "ui://fmkyh2ywc1ts8nt";

		public static View_LanSeTongYongAnNiu CreateInstance()
		{
			return (View_LanSeTongYongAnNiu)UIPackage.CreateObject("Main","蓝色通用按钮");
		}

		public View_LanSeTongYongAnNiu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			hit = (GComponent)this.GetChildAt(2);
		}
	}
}