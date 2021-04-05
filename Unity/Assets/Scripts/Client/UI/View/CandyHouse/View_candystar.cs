/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_candystar: GComponent
    {
        public Controller c1;
        public Transition t0;

        public const string URL = "ui://3b4mf257bldv1h";

        public static View_candystar CreateInstance()
        {
            return (View_candystar) UIPackage.CreateObject("CandyHouse", "candystar");
        }

        public View_candystar()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            t0 = GetTransitionAt(0);
        }
    }
}