/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_Download_Tips : GLabel
	{
		public Controller c1;
		public GButton bg;
		public GGroup BG;
		public GButton Download;
		public GButton WaitMinute;

		public const string URL = "ui://97pg0d8fx3ci35";

		public static View_Download_Tips CreateInstance()
		{
			return (View_Download_Tips)UIPackage.CreateObject("WithoutHot","Download_Tips");
		}

		public View_Download_Tips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			BG = (GGroup)this.GetChildAt(4);
			Download = (GButton)this.GetChildAt(5);
			WaitMinute = (GButton)this.GetChildAt(6);
		}
	}
}