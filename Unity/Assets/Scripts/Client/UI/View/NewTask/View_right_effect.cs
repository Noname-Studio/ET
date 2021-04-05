/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
    public partial class View_right_effect: GComponent
    {
        public GLoader icon;
        public GTextField Num;
        public Transition t0;

        public const string URL = "ui://f1lcfy6mms1kt";

        public static View_right_effect CreateInstance()
        {
            return (View_right_effect) UIPackage.CreateObject("NewTask", "right_effect");
        }

        public View_right_effect()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon = (GLoader) GetChildAt(0);
            Num = (GTextField) GetChildAt(1);
            t0 = GetTransitionAt(0);
        }
    }
}