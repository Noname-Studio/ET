/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_Success_effect: GComponent
    {
        public Transition t0;
        public const string URL = "ui://dpc3yd4tpq9ovxv";

        public static View_Success_effect CreateInstance()
        {
            return (View_Success_effect) UIPackage.CreateObject("GamingUI", "Success_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}