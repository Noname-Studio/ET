/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
    public partial class View_tips: GComponent
    {
        public Controller c1;
        public GRichTextField title;
        public Transition t0;

        public const string URL = "ui://btrw885im8faeg";

        public static View_tips CreateInstance()
        {
            return (View_tips) UIPackage.CreateObject("QuizGame", "tips");
        }

        public View_tips()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            title = (GRichTextField) GetChildAt(2);
            t0 = GetTransitionAt(0);
        }
    }
}