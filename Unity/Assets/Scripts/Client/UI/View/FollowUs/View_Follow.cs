/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.FollowUs
{
	public partial class View_Follow : GComponent
	{
		public GButton bg;
		public GButton Go;
		public GButton Skip;
		public GTextField Desc;

		public const string URL = "ui://h0jalhnpfkga3";

		public static View_Follow CreateInstance()
		{
			return (View_Follow)UIPackage.CreateObject("FollowUs","Follow");
		}

		public View_Follow()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Go = (GButton)this.GetChildAt(3);
			Skip = (GButton)this.GetChildAt(4);
			Desc = (GTextField)this.GetChildAt(5);
		}
	}
}