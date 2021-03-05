/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_goldarrow : GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4tgoguar";

        public static View_effect_goldarrow CreateInstance()
        {
            return (View_effect_goldarrow)UIPackage.CreateObject("GamingUI", "effect_goldarrow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}