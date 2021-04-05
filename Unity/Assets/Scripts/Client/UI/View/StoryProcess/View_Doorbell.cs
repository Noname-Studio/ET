/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.StoryProcess
{
    public partial class View_Doorbell: GComponent
    {
        public Transition Loop;
        public Transition Enter;

        public const string URL = "ui://y0mpnw87qh8hns";

        public static View_Doorbell CreateInstance()
        {
            return (View_Doorbell) UIPackage.CreateObject("StoryProcess", "Doorbell");
        }

        public View_Doorbell()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Loop = GetTransitionAt(0);
            Enter = GetTransitionAt(1);
        }
    }
}