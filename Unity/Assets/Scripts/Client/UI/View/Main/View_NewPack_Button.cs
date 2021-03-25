/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_NewPack_Button : GButton
    {
        public GComponent light;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://fmkyh2ywobqw8nh";

        public static View_NewPack_Button CreateInstance()
        {
            return (View_NewPack_Button)UIPackage.CreateObject("Main", "NewPack_Button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light = (GComponent)GetChild("light");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}