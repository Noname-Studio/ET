/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Review
{
	public partial class View_ScrollBar1 : GScrollBar
	{
		public GGraph bar;
		public GButton grip;

		public const string URL = "ui://ijwojn7zen8l1";

		public static View_ScrollBar1 CreateInstance()
		{
			return (View_ScrollBar1)UIPackage.CreateObject("Review","ScrollBar1");
		}

		public View_ScrollBar1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bar = (GGraph)this.GetChildAt(1);
			grip = (GButton)this.GetChildAt(2);
		}
	}
}