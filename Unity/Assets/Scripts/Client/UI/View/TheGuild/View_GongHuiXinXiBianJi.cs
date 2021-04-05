/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiXinXiBianJi : GComponent
    {
        public GLoader Creator;
        public GButton Close;
        public GGroup chuangjian;
        public const string URL = "ui://nvat1mjsrmezdn2";

        public static View_GongHuiXinXiBianJi CreateInstance()
        {
            return (View_GongHuiXinXiBianJi)UIPackage.CreateObject("TheGuild", "公会信息编辑");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Creator = (GLoader)GetChild("Creator");
            Close = (GButton)GetChild("Close");
            chuangjian = (GGroup)GetChild("chuangjian");
        }
    }
}