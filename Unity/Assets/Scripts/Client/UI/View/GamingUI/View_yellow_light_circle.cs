/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_yellow_light_circle : GComponent
    {
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://dpc3yd4tpj3te5";

        public static View_yellow_light_circle CreateInstance()
        {
            return (View_yellow_light_circle)UIPackage.CreateObject("GamingUI", "yellow_light_circle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}