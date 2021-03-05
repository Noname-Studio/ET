/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiChengYuanHuZhu : GComponent
    {
        public Controller c1;
        public GList HelpList;
        public GComponent reputation;
        public GGroup UI;
        public const string URL = "ui://nvat1mjsr9blkt";

        public static View_GongHuiChengYuanHuZhu CreateInstance()
        {
            return (View_GongHuiChengYuanHuZhu)UIPackage.CreateObject("TheGuild", "公会成员互助");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            HelpList = (GList)GetChild("HelpList");
            reputation = (GComponent)GetChild("reputation");
            UI = (GGroup)GetChild("UI");
        }
    }
}