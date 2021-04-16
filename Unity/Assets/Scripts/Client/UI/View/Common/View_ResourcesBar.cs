/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_ResourcesBar : GComponent
    {
        public GLoader GemIcon;
        public GImage EnergyFrame;
        public GLoader HealthIcon;
        public GTextField Energy;
        public GRichTextField Gem;
        public GButton AddHealth;
        public GButton AddDiamond;
        public GTextField EnergyTime;
        public GTextField Coin;
        public GLoader CoinIcon;
        public GButton AddCoin;
        public GGroup LeftTop;
        public Transition Out;
        public const string URL = "ui://ucagdrsio6pdk2";

        public static View_ResourcesBar CreateInstance()
        {
            return (View_ResourcesBar)UIPackage.CreateObject("Common", "ResourcesBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            GemIcon = (GLoader)GetChild("GemIcon");
            EnergyFrame = (GImage)GetChild("EnergyFrame");
            HealthIcon = (GLoader)GetChild("HealthIcon");
            Energy = (GTextField)GetChild("Energy");
            Gem = (GRichTextField)GetChild("Gem");
            AddHealth = (GButton)GetChild("AddHealth");
            AddDiamond = (GButton)GetChild("AddDiamond");
            EnergyTime = (GTextField)GetChild("EnergyTime");
            Coin = (GTextField)GetChild("Coin");
            CoinIcon = (GLoader)GetChild("CoinIcon");
            AddCoin = (GButton)GetChild("AddCoin");
            LeftTop = (GGroup)GetChild("LeftTop");
            Out = GetTransition("Out");
        }
    }
}