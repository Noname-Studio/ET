/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Bank
{
    public partial class View_QianDaoKaPian: GButton
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
            return (View_QianDaoKaPian) UIPackage.CreateObject("Bank", "签到卡片");
        }

        public View_QianDaoKaPian()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Day = (GTextField) GetChildAt(6);
            light = (GComponent) GetChildAt(7);
            Icon = (GLoader) GetChildAt(8);
            gou = (GComponent) GetChildAt(10);
            t0 = GetTransitionAt(0);
            t1 = GetTransitionAt(1);
        }
    }
}