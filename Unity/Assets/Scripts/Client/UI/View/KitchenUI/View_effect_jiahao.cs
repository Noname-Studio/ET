/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_effect_jiahao : GComponent
    {
        public Transition t0;
        public const string URL = "ui://y66af8ydv4pnvzj";

        public static View_effect_jiahao CreateInstance()
        {
            return (View_effect_jiahao)UIPackage.CreateObject("KitchenUI", "effect_jiahao");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}