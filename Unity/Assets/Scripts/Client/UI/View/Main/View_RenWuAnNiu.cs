/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_RenWuAnNiu : GButton
	{
		public GComponent tips;

		public const string URL = "ui://fmkyh2ywvqob10";

		public static View_RenWuAnNiu CreateInstance()
		{
			return (View_RenWuAnNiu)UIPackage.CreateObject("Main","任务按钮");
		}

		public View_RenWuAnNiu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			tips = (GComponent)this.GetChildAt(1);
		}
	}
}