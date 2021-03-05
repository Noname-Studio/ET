/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_tipsnew : GComponent
	{
		public Controller tips;
		public GButton bg;
		public GGroup BG;
		public GRichTextField Desc;
		public GButton Confirm;
		public GTextField Title;
		public GGroup biaoti;
		public GButton Close;

		public const string URL = "ui://97pg0d8fihve30";

		public static View_tipsnew CreateInstance()
		{
			return (View_tipsnew)UIPackage.CreateObject("WithoutHot","tipsnew");
		}

		public View_tipsnew()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			tips = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			BG = (GGroup)this.GetChildAt(3);
			Desc = (GRichTextField)this.GetChildAt(4);
			Confirm = (GButton)this.GetChildAt(5);
			Title = (GTextField)this.GetChildAt(7);
			biaoti = (GGroup)this.GetChildAt(8);
			Close = (GButton)this.GetChildAt(9);
		}
	}
}