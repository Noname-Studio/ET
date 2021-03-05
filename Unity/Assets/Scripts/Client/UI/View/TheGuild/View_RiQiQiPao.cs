/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_RiQiQiPao : GComponent
    {
        public GTextField Desc;
        public const string URL = "ui://nvat1mjsowxyw1f";

        public static View_RiQiQiPao CreateInstance()
        {
            return (View_RiQiQiPao)UIPackage.CreateObject("TheGuild", "日期气泡");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Desc = (GTextField)GetChild("Desc");
        }
    }
}