/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_ok: GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4tgd9naa";

        public static View_effect_ok CreateInstance()
        {
            return (View_effect_ok) UIPackage.CreateObject("GamingUI", "effect_ok");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}