/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bank
{
    public partial class View_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://yf9s6r30qmjomb";

        public static View_effect CreateInstance()
        {
            return (View_effect)UIPackage.CreateObject("Bank", "effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}