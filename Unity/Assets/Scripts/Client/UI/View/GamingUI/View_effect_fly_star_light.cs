/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_fly_star_light : GComponent
    {
        public GImage light1;
        public Transition t0;
        public const string URL = "ui://dpc3yd4tcd6g9t";

        public static View_effect_fly_star_light CreateInstance()
        {
            return (View_effect_fly_star_light)UIPackage.CreateObject("GamingUI", "effect_fly_star_light");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light1 = (GImage)GetChild("light1");
            t0 = GetTransition("t0");
        }
    }
}