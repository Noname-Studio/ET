/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_NewPack2_Button : GButton
    {
        public Transition t0;
        public const string URL = "ui://fmkyh2yw7znc8ou";

        public static View_NewPack2_Button CreateInstance()
        {
            return (View_NewPack2_Button)UIPackage.CreateObject("Main", "NewPack2_Button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}