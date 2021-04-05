/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_toch_act: GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4temwx4i";

        public static View_toch_act CreateInstance()
        {
            return (View_toch_act) UIPackage.CreateObject("GamingUI", "toch_act");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}