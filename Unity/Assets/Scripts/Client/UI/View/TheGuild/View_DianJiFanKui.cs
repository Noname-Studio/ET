/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_DianJiFanKui : GComponent
    {
        public Transition t0;
        public const string URL = "ui://nvat1mjsc1fndn4";

        public static View_DianJiFanKui CreateInstance()
        {
            return (View_DianJiFanKui)UIPackage.CreateObject("TheGuild", "点击反馈");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}