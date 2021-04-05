/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace EnergySystem
{
    public partial class View_ZuanShi_effect: GComponent
    {
        public Transition t0;
        public const string URL = "ui://yvifr4bbv5nhccb";

        public static View_ZuanShi_effect CreateInstance()
        {
            return (View_ZuanShi_effect) UIPackage.CreateObject("EnergySystem", "钻石_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}