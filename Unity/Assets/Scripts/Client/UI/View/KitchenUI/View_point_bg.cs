/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_point_bg : GComponent
    {
        public Transition t1;
        public Transition t0;
        public const string URL = "ui://y66af8ydc0zyj9";

        public static View_point_bg CreateInstance()
        {
            return (View_point_bg)UIPackage.CreateObject("KitchenUI", "point_bg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t1 = GetTransition("t1");
            t0 = GetTransition("t0");
        }
    }
}