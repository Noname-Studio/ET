/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GuidePanel : GComponent
    {
        public Controller c2;
        public GButton bkg;
        public GImage Mask;
        public View_Thearrow_effect arrow;
        public View_tipboard tipboard;
        public GGroup normal;
        public View_SKIP skipBtn;
        public const string URL = "ui://ucagdrsi8sfnob";

        public static View_GuidePanel CreateInstance()
        {
            return (View_GuidePanel)UIPackage.CreateObject("Common", "GuidePanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c2 = GetController("c2");
            bkg = (GButton)GetChild("bkg");
            Mask = (GImage)GetChild("Mask");
            arrow = (View_Thearrow_effect)GetChild("arrow");
            tipboard = (View_tipboard)GetChild("tipboard");
            normal = (GGroup)GetChild("normal");
            skipBtn = (View_SKIP)GetChild("skipBtn");
        }
    }
}