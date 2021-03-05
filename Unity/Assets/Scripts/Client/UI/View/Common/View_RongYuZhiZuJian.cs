/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_RongYuZhiZuJian : GComponent
    {
        public GProgressBar bar;
        public View_RongYuZhi_effect myicon;
        public View_giftblue_effect gift;
        public GTextField add;
        public GGroup addgroup;
        public Transition t0;
        public const string URL = "ui://ucagdrsiyo6bw0p";

        public static View_RongYuZhiZuJian CreateInstance()
        {
            return (View_RongYuZhiZuJian)UIPackage.CreateObject("Common", "荣誉值组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GProgressBar)GetChild("bar");
            myicon = (View_RongYuZhi_effect)GetChild("myicon");
            gift = (View_giftblue_effect)GetChild("gift");
            add = (GTextField)GetChild("add");
            addgroup = (GGroup)GetChild("addgroup");
            t0 = GetTransition("t0");
        }
    }
}