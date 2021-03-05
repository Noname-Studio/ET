/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_XiTongXiaoXi : GComponent
    {
        public GTextField Desc;
        public const string URL = "ui://nvat1mjsrki3dlk";

        public static View_XiTongXiaoXi CreateInstance()
        {
            return (View_XiTongXiaoXi)UIPackage.CreateObject("TheGuild", "系统消息");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Desc = (GTextField)GetChild("Desc");
        }
    }
}