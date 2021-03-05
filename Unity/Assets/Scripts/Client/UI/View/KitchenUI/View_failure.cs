/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_failure : GComponent
    {
        public Controller ui_style;
        public GButton bg;
        public GImage caidai;
        public GTextField title;
        public GButton replay;
        public GButton Close;
        public GLoader coin_icon;
        public GTextField coinsnum;
        public GTextField addflytxt;
        public View_double_coin_effect rewardEffect;
        public GButton watchvideo;
        public View_Ads video_icon;
        public GGroup watch;
        public GButton change;
        public Transition t1;
        public const string URL = "ui://y66af8ydtycj61";

        public static View_failure CreateInstance()
        {
            return (View_failure)UIPackage.CreateObject("KitchenUI", "failure");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ui_style = GetController("ui_style");
            bg = (GButton)GetChild("bg");
            caidai = (GImage)GetChild("caidai");
            title = (GTextField)GetChild("title");
            replay = (GButton)GetChild("replay");
            Close = (GButton)GetChild("Close");
            coin_icon = (GLoader)GetChild("coin_icon");
            coinsnum = (GTextField)GetChild("coinsnum");
            addflytxt = (GTextField)GetChild("addflytxt");
            rewardEffect = (View_double_coin_effect)GetChild("rewardEffect");
            watchvideo = (GButton)GetChild("watchvideo");
            video_icon = (View_Ads)GetChild("video_icon");
            watch = (GGroup)GetChild("watch");
            change = (GButton)GetChild("change");
            t1 = GetTransition("t1");
        }
    }
}