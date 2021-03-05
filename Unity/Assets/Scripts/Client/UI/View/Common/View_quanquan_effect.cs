/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_quanquan_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsicjihop";

        public static View_quanquan_effect CreateInstance()
        {
            return (View_quanquan_effect)UIPackage.CreateObject("Common", "quanquan_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}