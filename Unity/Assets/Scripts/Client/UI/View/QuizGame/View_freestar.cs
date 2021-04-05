/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
    public partial class View_freestar: GComponent
    {
        public GComponent light;
        public GImage Image1;
        public GTextField Text;
        public GImage Image;
        public GGroup effectGroup;
        public Transition t0;

        public const string URL = "ui://btrw885inpzihi";

        public static View_freestar CreateInstance()
        {
            return (View_freestar) UIPackage.CreateObject("QuizGame", "freestar");
        }

        public View_freestar()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light = (GComponent) GetChildAt(2);
            Image1 = (GImage) GetChildAt(3);
            Text = (GTextField) GetChildAt(4);
            Image = (GImage) GetChildAt(8);
            effectGroup = (GGroup) GetChildAt(10);
            t0 = GetTransitionAt(0);
        }
    }
}