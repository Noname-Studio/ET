/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
    public partial class View_Taskschedule: GComponent
    {
        public View_ProgressBar2 Progress;
        public GButton Gift;

        public const string URL = "ui://ytnp4vk8ifeglw";

        public static View_Taskschedule CreateInstance()
        {
            return (View_Taskschedule) UIPackage.CreateObject("Quest", "Taskschedule");
        }

        public View_Taskschedule()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Progress = (View_ProgressBar2) GetChildAt(1);
            Gift = (GButton) GetChildAt(3);
        }
    }
}