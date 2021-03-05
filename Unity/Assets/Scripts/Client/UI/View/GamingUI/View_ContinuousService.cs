/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_ContinuousService : GComponent
    {
        public Controller c1;
        public GLoader ComboTimes;
        public GLoader Interval;
        public const string URL = "ui://dpc3yd4tauz2ee";

        public static View_ContinuousService CreateInstance()
        {
            return (View_ContinuousService)UIPackage.CreateObject("GamingUI", "ContinuousService");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            ComboTimes = (GLoader)GetChild("ComboTimes");
            Interval = (GLoader)GetChild("Interval");
        }
    }
}