/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_GongHuiHuoDongZuJian : GComponent
    {
        public Controller c1;
        public GList List;
        public GButton help;
        public GTextField NextTime;
        public GTextField content;
        public GProgressBar Progress;
        public GTextField RewardDesc;
        public View_tuanduijiesuanjiangli_effect rewardBubble;
        public GButton GetReward;
        public GButton buyfull;
        public GList Stage;
        public GButton Start;
        public GTextField nextTime;
        public GTextField FinishTime;
        public const string URL = "ui://nvat1mjsr398dm8";

        public static View_GongHuiHuoDongZuJian CreateInstance()
        {
            return (View_GongHuiHuoDongZuJian)UIPackage.CreateObject("TheGuild", "公会活动组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            List = (GList)GetChild("List");
            help = (GButton)GetChild("help");
            NextTime = (GTextField)GetChild("NextTime");
            content = (GTextField)GetChild("content");
            Progress = (GProgressBar)GetChild("Progress");
            RewardDesc = (GTextField)GetChild("RewardDesc");
            rewardBubble = (View_tuanduijiesuanjiangli_effect)GetChild("rewardBubble");
            GetReward = (GButton)GetChild("GetReward");
            buyfull = (GButton)GetChild("buyfull");
            Stage = (GList)GetChild("Stage");
            Start = (GButton)GetChild("Start");
            nextTime = (GTextField)GetChild("nextTime");
            FinishTime = (GTextField)GetChild("FinishTime");
        }
    }
}