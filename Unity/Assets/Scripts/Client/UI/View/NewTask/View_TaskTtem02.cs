/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
    public partial class View_TaskTtem02: GButton
    {
        public Controller c1;
        public GTextField Question;
        public View_Button1 Answer1;
        public GLoader Effect0;
        public GGroup A1;
        public View_Button1 Answer2;
        public GLoader Effect1;
        public GGroup A2;
        public GButton Next;
        public GTextField Desc;

        public const string URL = "ui://f1lcfy6menftn";

        public static View_TaskTtem02 CreateInstance()
        {
            return (View_TaskTtem02) UIPackage.CreateObject("NewTask", "TaskTtem02");
        }

        public View_TaskTtem02()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Question = (GTextField) GetChildAt(0);
            Answer1 = (View_Button1) GetChildAt(1);
            Effect0 = (GLoader) GetChildAt(2);
            A1 = (GGroup) GetChildAt(3);
            Answer2 = (View_Button1) GetChildAt(4);
            Effect1 = (GLoader) GetChildAt(5);
            A2 = (GGroup) GetChildAt(6);
            Next = (GButton) GetChildAt(7);
            Desc = (GTextField) GetChildAt(8);
        }
    }
}