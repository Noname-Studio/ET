/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bank
{
    public partial class View_QianDaoKaPian : GButton
    {
        public Controller c1;
        public GTextField Day;
        public GComponent light;
        public GLoader Icon;
        public GComponent gou;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://yf9s6r30mpckif";

        public static View_QianDaoKaPian CreateInstance()
        {
            return (View_QianDaoKaPian)UIPackage.CreateObject("Bank", "签到卡片");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Day = (GTextField)GetChild("Day");
            light = (GComponent)GetChild("light");
            Icon = (GLoader)GetChild("Icon");
            gou = (GComponent)GetChild("gou");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}