/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_step2: GComponent
    {
        public GImage m1;
        public GImage m2;
        public GImage equal;
        public GImage arrow;
        public GImage food;
        public GImage cw;
        public const string URL = "ui://dpc3yd4ttmfvu";

        public static View_step2 CreateInstance()
        {
            return (View_step2) UIPackage.CreateObject("GamingUI", "step2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m1 = (GImage) GetChild("m1");
            m2 = (GImage) GetChild("m2");
            equal = (GImage) GetChild("equal");
            arrow = (GImage) GetChild("arrow");
            food = (GImage) GetChild("food");
            cw = (GImage) GetChild("cw");
        }
    }
}