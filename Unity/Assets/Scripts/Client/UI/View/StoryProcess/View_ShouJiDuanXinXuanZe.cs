/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
	public partial class View_ShouJiDuanXinXuanZe : GComponent
	{
		public GGraph TapBox;
		public GLabel Mask;
		public GTextField Name;
		public GList ChatList;
		public GButton TapDesc;
		public GLoader SenderHead;
		public GList options;

		public const string URL = "ui://y0mpnw87so97ph";

		public static View_ShouJiDuanXinXuanZe CreateInstance()
		{
			return (View_ShouJiDuanXinXuanZe)UIPackage.CreateObject("StoryProcess","手机短信选择");
		}

		public View_ShouJiDuanXinXuanZe()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			TapBox = (GGraph)this.GetChildAt(0);
			Mask = (GLabel)this.GetChildAt(8);
			Name = (GTextField)this.GetChildAt(9);
			ChatList = (GList)this.GetChildAt(10);
			TapDesc = (GButton)this.GetChildAt(11);
			SenderHead = (GLoader)this.GetChildAt(13);
			options = (GList)this.GetChildAt(14);
		}
	}
}