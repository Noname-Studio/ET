/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_game_target : GComponent
    {
        public Controller target_style;
        public GImage item0_bg;
        public GTextField Time;
        public GTextField Coin;
        public GLoader timeIcon;
        public GLoader coinIcon;
        public GLoader targetIcon;
        public GGroup item0;
        public GImage item1_bg;
        public GComponent target0;
        public GComponent target1;
        public GComponent target2;
        public GComponent target3;
        public GGroup item1;
        public const string URL = "ui://ytyvezjf9j9g8rh";

        public static View_game_target CreateInstance()
        {
            return (View_game_target)UIPackage.CreateObject("GameBegins", "game_target");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            target_style = GetController("target_style");
            item0_bg = (GImage)GetChild("item0_bg");
            Time = (GTextField)GetChild("Time");
            Coin = (GTextField)GetChild("Coin");
            timeIcon = (GLoader)GetChild("timeIcon");
            coinIcon = (GLoader)GetChild("coinIcon");
            targetIcon = (GLoader)GetChild("targetIcon");
            item0 = (GGroup)GetChild("item0");
            item1_bg = (GImage)GetChild("item1_bg");
            target0 = (GComponent)GetChild("target0");
            target1 = (GComponent)GetChild("target1");
            target2 = (GComponent)GetChild("target2");
            target3 = (GComponent)GetChild("target3");
            item1 = (GGroup)GetChild("item1");
        }
    }
}