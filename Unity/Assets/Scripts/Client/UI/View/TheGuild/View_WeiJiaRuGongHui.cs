/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_WeiJiaRuGongHui : GComponent
    {
        public Controller c1;
        public GLoader GuildList;
        public GLoader Creator;
        public GList Menu;
        public GButton Close;
        public GGroup BG;
        public const string URL = "ui://nvat1mjsh7udj8";

        public static View_WeiJiaRuGongHui CreateInstance()
        {
            return (View_WeiJiaRuGongHui)UIPackage.CreateObject("TheGuild", "未加入公会");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            GuildList = (GLoader)GetChild("GuildList");
            Creator = (GLoader)GetChild("Creator");
            Menu = (GList)GetChild("Menu");
            Close = (GButton)GetChild("Close");
            BG = (GGroup)GetChild("BG");
        }
    }
}