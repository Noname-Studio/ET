/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_JiaRuGongHuiZuJian : GButton
    {
        public GLoader Bg;
        public GTextField UnionName;
        public GTextField UnionDesc;
        public GButton Join;
        public GLoader frame;
        public GLoader inside;
        public const string URL = "ui://nvat1mjslaefjk";

        public static View_JiaRuGongHuiZuJian CreateInstance()
        {
            return (View_JiaRuGongHuiZuJian)UIPackage.CreateObject("TheGuild", "加入公会组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Bg = (GLoader)GetChild("Bg");
            UnionName = (GTextField)GetChild("UnionName");
            UnionDesc = (GTextField)GetChild("UnionDesc");
            Join = (GButton)GetChild("Join");
            frame = (GLoader)GetChild("frame");
            inside = (GLoader)GetChild("inside");
        }
    }
}