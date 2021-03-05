/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_more_gold : GComponent
    {
        public GTextField number;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://dpc3yd4tgoguas";

        public static View_effect_more_gold CreateInstance()
        {
            return (View_effect_more_gold)UIPackage.CreateObject("GamingUI", "effect_more_gold");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            number = (GTextField)GetChild("number");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}