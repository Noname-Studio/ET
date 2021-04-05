/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_MakeCandy_effect: GComponent
    {
        public Transition t0;
        public Transition t1;
        public Transition t3;

        public const string URL = "ui://3b4mf2579ubho";

        public static View_MakeCandy_effect CreateInstance()
        {
            return (View_MakeCandy_effect) UIPackage.CreateObject("CandyHouse", "MakeCandy_effect");
        }

        public View_MakeCandy_effect()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransitionAt(0);
            t1 = GetTransitionAt(1);
            t3 = GetTransitionAt(2);
        }
    }
}