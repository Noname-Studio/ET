/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_SoftSwitching: GComponent
    {
        public GImage frame;
        public GTextField Text;
        public Transition Black;
        public Transition White;

        public const string URL = "ui://y0mpnw87l0hih1";

        public static View_SoftSwitching CreateInstance()
        {
            return (View_SoftSwitching) UIPackage.CreateObject("StoryProcess", "SoftSwitching");
        }

        public View_SoftSwitching()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            frame = (GImage) GetChildAt(1);
            Text = (GTextField) GetChildAt(2);
            Black = GetTransitionAt(0);
            White = GetTransitionAt(1);
        }
    }
}