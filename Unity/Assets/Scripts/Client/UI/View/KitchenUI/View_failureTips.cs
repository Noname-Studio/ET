/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_failureTips : GComponent
    {
        public GLoader icon;
        public GTextField content;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://y66af8ydn0yflj";

        public static View_failureTips CreateInstance()
        {
            return (View_failureTips)UIPackage.CreateObject("KitchenUI", "failureTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon = (GLoader)GetChild("icon");
            content = (GTextField)GetChild("content");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}