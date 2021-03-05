/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_WoDeGongHuiZuJian : GComponent
    {
        public Controller c1;
        public GLoader frame;
        public GLoader inside;
        public GTextField Name;
        public GTextField NumOfPeople;
        public GButton invite;
        public GButton Edit;
        public GButton Menu;
        public View_Member Member;
        public const string URL = "ui://nvat1mjstdx3dlm";

        public static View_WoDeGongHuiZuJian CreateInstance()
        {
            return (View_WoDeGongHuiZuJian)UIPackage.CreateObject("TheGuild", "我的公会组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            frame = (GLoader)GetChild("frame");
            inside = (GLoader)GetChild("inside");
            Name = (GTextField)GetChild("Name");
            NumOfPeople = (GTextField)GetChild("NumOfPeople");
            invite = (GButton)GetChild("invite");
            Edit = (GButton)GetChild("Edit");
            Menu = (GButton)GetChild("Menu");
            Member = (View_Member)GetChild("Member");
        }
    }
}