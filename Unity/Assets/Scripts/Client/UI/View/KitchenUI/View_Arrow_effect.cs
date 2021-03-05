/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_Arrow_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://y66af8ydmh2zvyd";

        public static View_Arrow_effect CreateInstance()
        {
            return (View_Arrow_effect)UIPackage.CreateObject("KitchenUI", "Arrow_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}