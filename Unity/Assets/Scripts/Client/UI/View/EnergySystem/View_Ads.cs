/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace EnergySystem
{
    public partial class View_Ads : GComponent
    {
        public Transition t0;
        public const string URL = "ui://yvifr4bbfgktjg";

        public static View_Ads CreateInstance()
        {
            return (View_Ads)UIPackage.CreateObject("EnergySystem", "Ads");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}