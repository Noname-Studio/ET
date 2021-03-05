/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_YouWin_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://y66af8ydkh00j5";

        public static View_YouWin_effect CreateInstance()
        {
            return (View_YouWin_effect)UIPackage.CreateObject("KitchenUI", "YouWin_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}