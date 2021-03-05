/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_flicker_act : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsihf6t9v";

        public static View_flicker_act CreateInstance()
        {
            return (View_flicker_act)UIPackage.CreateObject("Common", "flicker_act");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}