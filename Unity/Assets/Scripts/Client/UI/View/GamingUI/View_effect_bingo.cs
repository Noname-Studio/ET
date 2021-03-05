/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_bingo : GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4tks4x41";

        public static View_effect_bingo CreateInstance()
        {
            return (View_effect_bingo)UIPackage.CreateObject("GamingUI", "effect_bingo");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}