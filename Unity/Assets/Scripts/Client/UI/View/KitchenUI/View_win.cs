/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_win : GComponent
    {
        public Controller c1;
        public Controller style;
        public GButton bg;
        public GButton nextLevel;
        public View_point_bg point_bg;
        public GTextField pointtxt;
        public View_double_coin_effect rewardEffect;
        public GButton watchvideo;
        public View_Ads video_icon;
        public GTextField p2;
        public GTextField p1;
        public View_ZheZhao faguang;
        public View_YouWin_effect title_bg;
        public GImage title_cn;
        public GImage title_en;
        public GGroup top_title;
        public GLoader coin_icon;
        public GLoader hat_icon;
        public GTextField coinsnum;
        public GTextField hatnum;
        public GTextField addflytxt;
        public GLoader cash_icon;
        public GTextField cashsnum;
        public View_add_cupcake_effect addCake;
        public GTextField guildScore;
        public GButton back;
        public GButton replayforTester;
        public GComponent honor;
        public GTextField total_customer;
        public GTextField totaltips;
        public GTextField totalfresh;
        public GTextField total_coin;
        public GTextField get_coin;
        public GTextField dish_count;
        public GTextField like_count;
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
            bg = (GButton)GetChild("bg");
            nextLevel = (GButton)GetChild("nextLevel");
            point_bg = (View_point_bg)GetChild("point_bg");
            pointtxt = (GTextField)GetChild("pointtxt");
            rewardEffect = (View_double_coin_effect)GetChild("rewardEffect");
            watchvideo = (GButton)GetChild("watchvideo");
            video_icon = (View_Ads)GetChild("video_icon");
            p2 = (GTextField)GetChild("p2");
            p1 = (GTextField)GetChild("p1");
            faguang = (View_ZheZhao)GetChild("faguang");
            title_bg = (View_YouWin_effect)GetChild("title_bg");
            title_cn = (GImage)GetChild("title_cn");
            title_en = (GImage)GetChild("title_en");
            top_title = (GGroup)GetChild("top_title");
            coin_icon = (GLoader)GetChild("coin_icon");
            hat_icon = (GLoader)GetChild("hat_icon");
            coinsnum = (GTextField)GetChild("coinsnum");
            hatnum = (GTextField)GetChild("hatnum");
            addflytxt = (GTextField)GetChild("addflytxt");
            cash_icon = (GLoader)GetChild("cash_icon");
            cashsnum = (GTextField)GetChild("cashsnum");
            addCake = (View_add_cupcake_effect)GetChild("addCake");
            guildScore = (GTextField)GetChild("guildScore");
            back = (GButton)GetChild("back");
            replayforTester = (GButton)GetChild("replayforTester");
            honor = (GComponent)GetChild("honor");
            total_customer = (GTextField)GetChild("total_customer");
            totaltips = (GTextField)GetChild("totaltips");
            totalfresh = (GTextField)GetChild("totalfresh");
            total_coin = (GTextField)GetChild("total_coin");
            get_coin = (GTextField)GetChild("get_coin");
            dish_count = (GTextField)GetChild("dish_count");
            like_count = (GTextField)GetChild("like_count");
        }
    }
}