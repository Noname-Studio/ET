/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_leftmoney: GComponent
    {
        public View_yellow_light_circle light;
        public GImage coin1;
        public Transition t0;
        public const string URL = "ui://dpc3yd4ts6xta4";

        public static View_effect_leftmoney CreateInstance()
        {
            return (View_effect_leftmoney) UIPackage.CreateObject("GamingUI", "effect_leftmoney");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light = (View_yellow_light_circle) GetChild("light");
            coin1 = (GImage) GetChild("coin1");
            t0 = GetTransition("t0");
        }
    }
}