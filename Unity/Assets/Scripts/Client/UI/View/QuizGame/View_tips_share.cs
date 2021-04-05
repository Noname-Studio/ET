/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
    public partial class View_tips_share: GComponent
    {
        public GTextField title;
        public Transition t0;

        public const string URL = "ui://btrw885ih851ho";

        public static View_tips_share CreateInstance()
        {
            return (View_tips_share) UIPackage.CreateObject("QuizGame", "tips_share");
        }

        public View_tips_share()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = (GTextField) GetChildAt(2);
            t0 = GetTransitionAt(0);
        }
    }
}