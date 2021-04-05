/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_Dialog_Confusion: GComponent
    {
        public Transition t0;

        public const string URL = "ui://y0mpnw87nfvpmr";

        public static View_Dialog_Confusion CreateInstance()
        {
            return (View_Dialog_Confusion) UIPackage.CreateObject("StoryProcess", "Dialog_Confusion");
        }

        public View_Dialog_Confusion()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransitionAt(0);
        }
    }
}