/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_skill_addcoin : GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4ttfbl90";

        public static View_effect_skill_addcoin CreateInstance()
        {
            return (View_effect_skill_addcoin)UIPackage.CreateObject("GamingUI", "effect_skill_addcoin");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}