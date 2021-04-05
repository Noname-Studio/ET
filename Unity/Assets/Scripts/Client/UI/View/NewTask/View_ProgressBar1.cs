/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
    public partial class View_ProgressBar1: GProgressBar
    {
        public Controller c1;
        public Controller c2;
        public GButton box;

        public const string URL = "ui://f1lcfy6mh8zvb";

        public static View_ProgressBar1 CreateInstance()
        {
            return (View_ProgressBar1) UIPackage.CreateObject("NewTask", "ProgressBar1");
        }

        public View_ProgressBar1()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            c2 = GetControllerAt(1);
            box = (GButton) GetChildAt(3);
        }
    }
}