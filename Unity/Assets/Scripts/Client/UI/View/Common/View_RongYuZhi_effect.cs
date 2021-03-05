/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_RongYuZhi_effect : GComponent
    {
        public View_yellow_light_circle light;
        public View_flicker_act star;
        public GTextField lev;
        public Transition leveup;
        public const string URL = "ui://ucagdrsimzi1w0r";

        public static View_RongYuZhi_effect CreateInstance()
        {
            return (View_RongYuZhi_effect)UIPackage.CreateObject("Common", "荣誉值_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light = (View_yellow_light_circle)GetChild("light");
            star = (View_flicker_act)GetChild("star");
            lev = (GTextField)GetChild("lev");
            leveup = GetTransition("leveup");
        }
    }
}