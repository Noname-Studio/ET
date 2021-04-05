/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_recipebtn: GButton
    {
        public Transition t0;
        public const string URL = "ui://ytyvezjfpgdvpd";

        public static View_recipebtn CreateInstance()
        {
            return (View_recipebtn) UIPackage.CreateObject("GameBegins", "recipebtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}