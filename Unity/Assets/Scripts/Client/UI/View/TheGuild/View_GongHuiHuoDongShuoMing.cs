/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiHuoDongShuoMing : GComponent
    {
        public GButton Close;
        public GList HelpList;
        public const string URL = "ui://nvat1mjslbjnkx";

        public static View_GongHuiHuoDongShuoMing CreateInstance()
        {
            return (View_GongHuiHuoDongShuoMing)UIPackage.CreateObject("TheGuild", "公会活动说明");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Close = (GButton)GetChild("Close");
            HelpList = (GList)GetChild("HelpList");
        }
    }
}