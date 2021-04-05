/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
    public partial class View_TaskCard: GButton
    {
        public Controller c1;
        public View_ProgressBar1 Progress;
        public GComponent Hit;

        public const string URL = "ui://f1lcfy6mh8zvd";

        public static View_TaskCard CreateInstance()
        {
            return (View_TaskCard) UIPackage.CreateObject("NewTask", "TaskCard");
        }

        public View_TaskCard()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Progress = (View_ProgressBar1) GetChildAt(5);
            Hit = (GComponent) GetChildAt(6);
        }
    }
}