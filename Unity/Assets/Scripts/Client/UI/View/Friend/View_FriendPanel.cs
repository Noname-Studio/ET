/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Friend
{
	public partial class View_FriendPanel : GComponent
	{
		public Controller c1;
		public GButton bg;
		public GButton Close;
		public View_InvitePlayer InvitePlayer;
		public View_InviteReward InviteReward;

		public const string URL = "ui://y072jhf1m1eebc";

		public static View_FriendPanel CreateInstance()
		{
			return (View_FriendPanel)UIPackage.CreateObject("Friend","FriendPanel");
		}

		public View_FriendPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			Close = (GButton)this.GetChildAt(9);
			InvitePlayer = (View_InvitePlayer)this.GetChildAt(10);
			InviteReward = (View_InviteReward)this.GetChildAt(11);
		}
	}
}