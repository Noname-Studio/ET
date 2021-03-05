/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.ChatBubble
{
	public partial class View_ChatBubbleWrap : GComponent
	{
		public Controller Type;
		public GImage Background;
		public GTextField title;
		public GImage ImageBg;
		public GLoader icon;

		public const string URL = "ui://ywzdb926j73a5o";

		public static View_ChatBubbleWrap CreateInstance()
		{
			return (View_ChatBubbleWrap)UIPackage.CreateObject("ChatBubble","ChatBubbleWrap");
		}

		public View_ChatBubbleWrap()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Type = this.GetControllerAt(0);
			Background = (GImage)this.GetChildAt(0);
			title = (GTextField)this.GetChildAt(1);
			ImageBg = (GImage)this.GetChildAt(2);
			icon = (GLoader)this.GetChildAt(3);
		}
	}
}