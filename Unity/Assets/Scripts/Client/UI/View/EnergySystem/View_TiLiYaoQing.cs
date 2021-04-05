/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace EnergySystem
{
    public partial class View_TiLiYaoQing: GComponent
    {
        public Controller c1;
        public GButton bg;
        public GGroup NoFriend;
        public GButton Close;
        public GList List;
        public GButton SendGift;
        public GButton AskFriend;
        public GButton LoginFB;
        public GButton InviteFriend;
        public const string URL = "ui://yvifr4bblbuubw";

        public static View_TiLiYaoQing CreateInstance()
        {
            return (View_TiLiYaoQing) UIPackage.CreateObject("EnergySystem", "体力邀请");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton) GetChild("bg");
            NoFriend = (GGroup) GetChild("NoFriend");
            Close = (GButton) GetChild("Close");
            List = (GList) GetChild("List");
            SendGift = (GButton) GetChild("SendGift");
            AskFriend = (GButton) GetChild("AskFriend");
            LoginFB = (GButton) GetChild("LoginFB");
            InviteFriend = (GButton) GetChild("InviteFriend");
        }
    }
}