/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_failure : GLabel
    {
        public Controller ui_style;
        public GButton exit;
        public Transition t1;
        public const string URL = "ui://y66af8ydtycj61";

        public static View_failure CreateInstance()
        {
            return (View_failure)UIPackage.CreateObject("KitchenUI", "failure");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ui_style = GetController("ui_style");
            exit = (GButton)GetChild("exit");
            t1 = GetTransition("t1");
        }
    }
}