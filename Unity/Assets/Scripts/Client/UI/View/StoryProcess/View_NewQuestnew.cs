/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_NewQuestnew: GLabel
    {
        public Controller c1;
        public Transition t0;
        public Transition t1;

        public const string URL = "ui://y0mpnw87lusuny";

        public static View_NewQuestnew CreateInstance()
        {
            return (View_NewQuestnew) UIPackage.CreateObject("StoryProcess", "NewQuestnew");
        }

        public View_NewQuestnew()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            t0 = GetTransitionAt(0);
            t1 = GetTransitionAt(1);
        }
    }
}