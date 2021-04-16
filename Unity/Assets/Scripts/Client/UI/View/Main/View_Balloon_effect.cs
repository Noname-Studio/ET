/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_Balloon_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://fmkyh2ywoge98on";

        public static View_Balloon_effect CreateInstance()
        {
            return (View_Balloon_effect)UIPackage.CreateObject("Main", "Balloon_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}