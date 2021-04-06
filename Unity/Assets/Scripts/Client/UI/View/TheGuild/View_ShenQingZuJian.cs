/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_ShenQingZuJian : GLabel
    {
        public GButton Approve;
        public GButton Ignore;
        public const string URL = "ui://nvat1mjsmivdw1g";

        public static View_ShenQingZuJian CreateInstance()
        {
            return (View_ShenQingZuJian)UIPackage.CreateObject("TheGuild", "申请组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Approve = (GButton)GetChild("Approve");
            Ignore = (GButton)GetChild("Ignore");
        }
    }
}