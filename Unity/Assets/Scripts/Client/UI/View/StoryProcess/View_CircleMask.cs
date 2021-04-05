/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_CircleMask: GComponent
    {
        public GGraph Circle;
        public Transition t0;

        public const string URL = "ui://y0mpnw87kzizo3";

        public static View_CircleMask CreateInstance()
        {
            return (View_CircleMask) UIPackage.CreateObject("StoryProcess", "CircleMask");
        }

        public View_CircleMask()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Circle = (GGraph) GetChildAt(1);
            t0 = GetTransitionAt(0);
        }
    }
}