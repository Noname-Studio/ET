/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_GameTitle : GComponent
    {
        public GLoader GemIcon;
        public GImage EnergyFrame;
        public GLoader HealthIcon;
        public GTextField Health;
        public GTextField Diamond;
        public GButton AddHealth;
        public GButton AddDiamond;
        public GTextField EnergyTime;
        public GTextField Coin;
        public GLoader CoinIcon;
        public GButton AddCoin;
        public GGroup LeftTop;
        public GTextField Tableware;
        public GLoader TablewareIcon;
        public GGroup RightTop;
        public Transition Out;
        public const string URL = "ui://ucagdrsio6pdk2";

        public static View_GameTitle CreateInstance()
        {
            return (View_GameTitle)UIPackage.CreateObject("Common", "GameTitle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            GemIcon = (GLoader)GetChild("GemIcon");
            EnergyFrame = (GImage)GetChild("EnergyFrame");
            HealthIcon = (GLoader)GetChild("HealthIcon");
            Health = (GTextField)GetChild("Health");
            Diamond = (GTextField)GetChild("Diamond");
            AddHealth = (GButton)GetChild("AddHealth");
            AddDiamond = (GButton)GetChild("AddDiamond");
            EnergyTime = (GTextField)GetChild("EnergyTime");
            Coin = (GTextField)GetChild("Coin");
            CoinIcon = (GLoader)GetChild("CoinIcon");
            AddCoin = (GButton)GetChild("AddCoin");
            LeftTop = (GGroup)GetChild("LeftTop");
            Tableware = (GTextField)GetChild("Tableware");
            TablewareIcon = (GLoader)GetChild("TablewareIcon");
            RightTop = (GGroup)GetChild("RightTop");
            Out = GetTransition("Out");
        }
    }
}