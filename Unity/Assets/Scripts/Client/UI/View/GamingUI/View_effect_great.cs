/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_great: GComponent
    {
        public GImage light1;
        public Transition t0;
        public const string URL = "ui://dpc3yd4thfjta2";

        public static View_effect_great CreateInstance()
        {
            return (View_effect_great) UIPackage.CreateObject("GamingUI", "effect_great");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light1 = (GImage) GetChild("light1");
            t0 = GetTransition("t0");
        }
    }
}