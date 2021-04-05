/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_Scared_Bubble: GComponent
    {
        public GTextField title;
        public Transition t0;
        public Transition t1;

        public const string URL = "ui://y0mpnw87duofoi";

        public static View_Scared_Bubble CreateInstance()
        {
            return (View_Scared_Bubble) UIPackage.CreateObject("StoryProcess", "Scared_Bubble");
        }

        public View_Scared_Bubble()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title = (GTextField) GetChildAt(2);
            t0 = GetTransitionAt(0);
            t1 = GetTransitionAt(1);
        }
    }
}