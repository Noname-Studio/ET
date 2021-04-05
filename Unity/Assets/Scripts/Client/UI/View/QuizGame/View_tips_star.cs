/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
    public partial class View_tips_star: GComponent
    {
        public GTextField title;
        public Transition t0;

        public const string URL = "ui://btrw885ifq7chl";

        public static View_tips_star CreateInstance()
        {
            return (View_tips_star) UIPackage.CreateObject("QuizGame", "tips_star");
        }

        public View_tips_star()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = (GTextField) GetChildAt(1);
            t0 = GetTransitionAt(0);
        }
    }
}