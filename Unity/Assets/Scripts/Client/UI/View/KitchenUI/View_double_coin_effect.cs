/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_double_coin_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://y66af8ydso97vz7";

        public static View_double_coin_effect CreateInstance()
        {
            return (View_double_coin_effect)UIPackage.CreateObject("KitchenUI", "double_coin_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}