/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_target : GComponent
    {
        public Controller c1;
        public GButton bg;
        public GImage papper;
        public GTextField tapcontinue;
        public GImage item0_bg;
        public GTextField Time;
        public GTextField Coin;
        public GLoader timeIcon;
        public GLoader coinIcon;
        public GGroup item0;
        public GImage item1_bg;
        public GComponent target0;
        public GComponent target1;
        public GComponent target2;
        public GComponent target3;
        public GGroup item1;
        public GList propPreViewList;
        public GTextField txt2;
        public GTextField txt3;
        public const string URL = "ui://y66af8ydo9762k";

        public static View_target CreateInstance()
        {
            return (View_target)UIPackage.CreateObject("KitchenUI", "target");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton)GetChild("bg");
            papper = (GImage)GetChild("papper");
            tapcontinue = (GTextField)GetChild("tapcontinue");
            item0_bg = (GImage)GetChild("item0_bg");
            Time = (GTextField)GetChild("Time");
            Coin = (GTextField)GetChild("Coin");
            timeIcon = (GLoader)GetChild("timeIcon");
            coinIcon = (GLoader)GetChild("coinIcon");
            item0 = (GGroup)GetChild("item0");
            item1_bg = (GImage)GetChild("item1_bg");
            target0 = (GComponent)GetChild("target0");
            target1 = (GComponent)GetChild("target1");
            target2 = (GComponent)GetChild("target2");
            target3 = (GComponent)GetChild("target3");
            item1 = (GGroup)GetChild("item1");
            propPreViewList = (GList)GetChild("propPreViewList");
            txt2 = (GTextField)GetChild("txt2");
            txt3 = (GTextField)GetChild("txt3");
        }
    }
}