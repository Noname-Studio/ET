/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
    public partial class View_Label1: GLabel
    {
        public Controller c1;
        public GGraph content;
        public View_loadingstar loading;
        public GButton retry;
        public GGroup reload;
        public GTextField tip;
        public Transition t0;

        public const string URL = "ui://btrw885im8faec";

        public static View_Label1 CreateInstance()
        {
            return (View_Label1) UIPackage.CreateObject("QuizGame", "Label1");
        }

        public View_Label1()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            content = (GGraph) GetChildAt(8);
            loading = (View_loadingstar) GetChildAt(11);
            retry = (GButton) GetChildAt(15);
            reload = (GGroup) GetChildAt(16);
            tip = (GTextField) GetChildAt(17);
            t0 = GetTransitionAt(0);
        }
    }
}