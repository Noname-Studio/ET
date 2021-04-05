/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
    public partial class View_TaskProgressBar: GComponent
    {
        public GImage bar;

        public const string URL = "ui://ytnp4vk8j9x1mg";

        public static View_TaskProgressBar CreateInstance()
        {
            return (View_TaskProgressBar) UIPackage.CreateObject("Quest", "TaskProgressBar");
        }

        public View_TaskProgressBar()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage) GetChildAt(0);
        }
    }
}