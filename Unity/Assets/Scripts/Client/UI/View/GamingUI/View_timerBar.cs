/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_timerBar : GProgressBar
    {
        public GLoader icon;
        public GImage timer_waring;
        public GTextField txt;
        public Transition t0;
        public const string URL = "ui://dpc3yd4tvejr1p";

        public static View_timerBar CreateInstance()
        {
            return (View_timerBar)UIPackage.CreateObject("GamingUI", "timerBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon = (GLoader)GetChild("icon");
            timer_waring = (GImage)GetChild("timer_waring");
            txt = (GTextField)GetChild("txt");
            t0 = GetTransition("t0");
        }
    }
}