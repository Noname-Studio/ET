/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_step1 : GComponent
    {
        public GImage equal;
        public GImage m1;
        public GImage arrow;
        public GImage food;
        public GImage cw;
        public const string URL = "ui://dpc3yd4ttmfvt";

        public static View_step1 CreateInstance()
        {
            return (View_step1)UIPackage.CreateObject("GamingUI", "step1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            equal = (GImage)GetChild("equal");
            m1 = (GImage)GetChild("m1");
            arrow = (GImage)GetChild("arrow");
            food = (GImage)GetChild("food");
            cw = (GImage)GetChild("cw");
        }
    }
}