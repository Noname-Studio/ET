/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_gonghuichengyuan : GComponent
    {
        public Controller c1;
        public GTextField Name;
        public GTextField Reward;
        public GTextField Rank;
        public View_giftblue_effect gift;
        public const string URL = "ui://ucagdrsimwtuw0w";

        public static View_gonghuichengyuan CreateInstance()
        {
            return (View_gonghuichengyuan)UIPackage.CreateObject("Common", "gonghuichengyuan");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Name = (GTextField)GetChild("Name");
            Reward = (GTextField)GetChild("Reward");
            Rank = (GTextField)GetChild("Rank");
            gift = (View_giftblue_effect)GetChild("gift");
        }
    }
}