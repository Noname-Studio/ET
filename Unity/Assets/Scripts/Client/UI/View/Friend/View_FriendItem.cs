/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Friend
{
	public partial class View_FriendItem : GLabel
	{
		public GLoader Type;
		public GLoader Head;
		public GTextField Level;

		public const string URL = "ui://y072jhf1m1eebe";

		public static View_FriendItem CreateInstance()
		{
			return (View_FriendItem)UIPackage.CreateObject("Friend","FriendItem");
		}

		public View_FriendItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Type = (GLoader)this.GetChildAt(2);
			Head = (GLoader)this.GetChildAt(3);
			Level = (GTextField)this.GetChildAt(6);
		}
	}
}