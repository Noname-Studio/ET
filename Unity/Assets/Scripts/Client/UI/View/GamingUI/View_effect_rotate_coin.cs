/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_rotate_coin: GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4tv4jo9e";

        public static View_effect_rotate_coin CreateInstance()
        {
            return (View_effect_rotate_coin) UIPackage.CreateObject("GamingUI", "effect_rotate_coin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}