/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_Dialog_Question: GComponent
    {
        public Transition t0;
        public Transition t1;

        public const string URL = "ui://y0mpnw87nfvpmp";

        public static View_Dialog_Question CreateInstance()
        {
            return (View_Dialog_Question) UIPackage.CreateObject("StoryProcess", "Dialog_Question");
        }

        public View_Dialog_Question()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransitionAt(0);
            t1 = GetTransitionAt(1);
        }
    }
}