/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_XiTongTiShiDaiJiangLi : GComponent
    {
        public Controller c1;
        public GTextField Desc;
        public const string URL = "ui://nvat1mjsrki3dlj";

        public static View_XiTongTiShiDaiJiangLi CreateInstance()
        {
            return (View_XiTongTiShiDaiJiangLi)UIPackage.CreateObject("TheGuild", "系统提示带奖励");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Desc = (GTextField)GetChild("Desc");
        }
    }
}