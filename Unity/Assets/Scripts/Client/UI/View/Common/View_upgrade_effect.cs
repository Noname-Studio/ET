/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_upgrade_effect : GComponent
    {
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://ucagdrsigkg6tb";

        public static View_upgrade_effect CreateInstance()
        {
            return (View_upgrade_effect)UIPackage.CreateObject("Common", "upgrade_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}