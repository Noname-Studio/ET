/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiYaoQingLieBiao : GComponent
    {
        public Controller c1;
        public GButton bg;
        public GList Menu;
        public GButton Close;
        public GButton Confirm;
        public GButton MoreFriend;
        public GList FriendList;
        public GTextField Desc;
        public GList ApplicationList;
        public GComponent NewMemberHit;
        public GTextField NoApplication;
        public GGroup UI;
        public const string URL = "ui://nvat1mjs100kdl3";

        public static View_GongHuiYaoQingLieBiao CreateInstance()
        {
            return (View_GongHuiYaoQingLieBiao)UIPackage.CreateObject("TheGuild", "公会邀请列表");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton)GetChild("bg");
            Menu = (GList)GetChild("Menu");
            Close = (GButton)GetChild("Close");
            Confirm = (GButton)GetChild("Confirm");
            MoreFriend = (GButton)GetChild("MoreFriend");
            FriendList = (GList)GetChild("FriendList");
            Desc = (GTextField)GetChild("Desc");
            ApplicationList = (GList)GetChild("ApplicationList");
            NewMemberHit = (GComponent)GetChild("NewMemberHit");
            NoApplication = (GTextField)GetChild("NoApplication");
            UI = (GGroup)GetChild("UI");
        }
    }
}