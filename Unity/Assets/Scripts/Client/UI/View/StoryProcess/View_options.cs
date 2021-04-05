/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_options: GLabel
    {
        public GButton Send;

        public const string URL = "ui://y0mpnw87so97pj";

        public static View_options CreateInstance()
        {
            return (View_options) UIPackage.CreateObject("StoryProcess", "options");
        }

        public View_options()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Send = (GButton) GetChildAt(2);
        }
    }
}