/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_BianJiGongHuiXinXi : GComponent
    {
        public GButton bg;
        public GLoader Creator;
        public GButton Close;
        public const string URL = "ui://nvat1mjssudiw2e";

        public static View_BianJiGongHuiXinXi CreateInstance()
        {
            return (View_BianJiGongHuiXinXi)UIPackage.CreateObject("TheGuild", "编辑公会信息");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            Creator = (GLoader)GetChild("Creator");
            Close = (GButton)GetChild("Close");
        }
    }
}