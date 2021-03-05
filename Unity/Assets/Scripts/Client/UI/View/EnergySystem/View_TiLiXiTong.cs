/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace EnergySystem
{
    public partial class View_TiLiXiTong : GComponent
    {
        public Controller c1;
        public Controller Language;
        public GButton bg;
        public GButton Close;
        public GTextField Desc;
        public GTextField InfineTimeDesc;
        public GButton AskFriend;
        public GButton InviteFriend;
        public GButton WatchTV;
        public GButton Buy;
        public GTextField Time;
        public const string URL = "ui://yvifr4bblbuubt";

        public static View_TiLiXiTong CreateInstance()
        {
            return (View_TiLiXiTong)UIPackage.CreateObject("EnergySystem", "体力系统");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Language = GetController("Language");
            bg = (GButton)GetChild("bg");
            Close = (GButton)GetChild("Close");
            Desc = (GTextField)GetChild("Desc");
            InfineTimeDesc = (GTextField)GetChild("InfineTimeDesc");
            AskFriend = (GButton)GetChild("AskFriend");
            InviteFriend = (GButton)GetChild("InviteFriend");
            WatchTV = (GButton)GetChild("WatchTV");
            Buy = (GButton)GetChild("Buy");
            Time = (GTextField)GetChild("Time");
        }
    }
}