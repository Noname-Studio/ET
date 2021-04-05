/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
    public partial class View_Button1: GButton
    {
        public Controller c1;

        public const string URL = "ui://f1lcfy6meldux";

        public static View_Button1 CreateInstance()
        {
            return (View_Button1) UIPackage.CreateObject("NewTask", "Button1");
        }

        public View_Button1()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(1);
        }
    }
}