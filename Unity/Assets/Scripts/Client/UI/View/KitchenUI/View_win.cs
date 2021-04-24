/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_win : GComponent
    {
        public Controller c1;
        public Controller style;
        public Controller HasAd;
        public GButton bg;
        public GButton Confirm;
        public GButton Watchvideo;
        public View_Ads video_icon;
        public View_add_cupcake_effect addCake;
        public GTextField guildScore;
        public GButton Guild;
        public GLabel NormalReward;
        public const string URL = "ui://y66af8yddb14is";

        public static View_win CreateInstance()
        {
            return (View_win)UIPackage.CreateObject("KitchenUI", "win");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            style = GetController("style");
            HasAd = GetController("HasAd");
            bg = (GButton)GetChild("bg");
            Confirm = (GButton)GetChild("Confirm");
            Watchvideo = (GButton)GetChild("Watchvideo");
            video_icon = (View_Ads)GetChild("video_icon");
            addCake = (View_add_cupcake_effect)GetChild("addCake");
            guildScore = (GTextField)GetChild("guildScore");
            Guild = (GButton)GetChild("Guild");
            NormalReward = (GLabel)GetChild("NormalReward");
        }
    }
}