/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_ZhuanYangHuiZhangDanChu : GComponent
    {
        public GButton Transfer;
        public GButton KickOut;
        public const string URL = "ui://nvat1mjsmivdw1i";

        public static View_ZhuanYangHuiZhangDanChu CreateInstance()
        {
            return (View_ZhuanYangHuiZhangDanChu)UIPackage.CreateObject("TheGuild", "转样会长弹出");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Transfer = (GButton)GetChild("Transfer");
            KickOut = (GButton)GetChild("KickOut");
        }
    }
}