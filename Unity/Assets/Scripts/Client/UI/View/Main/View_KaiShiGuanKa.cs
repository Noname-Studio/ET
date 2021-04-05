/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_KaiShiGuanKa: GButton
    {
        public Controller Hard;
        public Transition t0;
        public const string URL = "ui://fmkyh2ywvqobs";

        public static View_KaiShiGuanKa CreateInstance()
        {
            return (View_KaiShiGuanKa) UIPackage.CreateObject("Main", "开始关卡");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Hard = GetController("Hard");
            t0 = GetTransition("t0");
        }
    }
}