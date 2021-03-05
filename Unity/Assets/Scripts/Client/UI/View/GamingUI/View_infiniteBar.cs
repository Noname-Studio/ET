/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_infiniteBar : GProgressBar
    {
        public GLoader c_icon;
        public GTextField total;
        public GGroup scoreview;
        public GLoader target;
        public View_WuJinQiPao bubbleCom;
        public GTextField guidecake;
        public const string URL = "ui://dpc3yd4tfbcjvyt";

        public static View_infiniteBar CreateInstance()
        {
            return (View_infiniteBar)UIPackage.CreateObject("GamingUI", "infiniteBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c_icon = (GLoader)GetChild("c_icon");
            total = (GTextField)GetChild("total");
            scoreview = (GGroup)GetChild("scoreview");
            target = (GLoader)GetChild("target");
            bubbleCom = (View_WuJinQiPao)GetChild("bubbleCom");
            guidecake = (GTextField)GetChild("guidecake");
        }
    }
}