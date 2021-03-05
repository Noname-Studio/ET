/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_super_cw : GLabel
    {
        public View_quanquan_effect light1;
        public View_quanquan_effect light2;
        public View_yellow_light_circle light3;
        public const string URL = "ui://ucagdrsicjihoo";

        public static View_super_cw CreateInstance()
        {
            return (View_super_cw)UIPackage.CreateObject("Common", "super_cw");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light1 = (View_quanquan_effect)GetChild("light1");
            light2 = (View_quanquan_effect)GetChild("light2");
            light3 = (View_yellow_light_circle)GetChild("light3");
        }
    }
}