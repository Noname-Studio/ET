/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bank
{
    public partial class View_gift : GLabel
    {
        public Controller c1;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://yf9s6r30skkaje";

        public static View_gift CreateInstance()
        {
            return (View_gift)UIPackage.CreateObject("Bank", "gift");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}