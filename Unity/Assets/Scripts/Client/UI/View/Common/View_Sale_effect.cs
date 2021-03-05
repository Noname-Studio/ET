/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Sale_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsifjljpz";

        public static View_Sale_effect CreateInstance()
        {
            return (View_Sale_effect)UIPackage.CreateObject("Common", "Sale_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}