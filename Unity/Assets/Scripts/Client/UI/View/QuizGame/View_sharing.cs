/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
    public partial class View_sharing: GComponent
    {
        public Controller c1;
        public GLoader icon;
        public GButton ok;
        public Transition t0;

        public const string URL = "ui://btrw885ihqihhu";

        public static View_sharing CreateInstance()
        {
            return (View_sharing) UIPackage.CreateObject("QuizGame", "sharing");
        }

        public View_sharing()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            icon = (GLoader) GetChildAt(10);
            ok = (GButton) GetChildAt(11);
            t0 = GetTransitionAt(0);
        }
    }
}