/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_effect_addReward: GComponent
    {
        public GLoader coin;
        public GTextField count;
        public GTextField txt;
        public Transition t0;
        public const string URL = "ui://dpc3yd4tt40xvyo";

        public static View_effect_addReward CreateInstance()
        {
            return (View_effect_addReward) UIPackage.CreateObject("GamingUI", "effect_addReward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            coin = (GLoader) GetChild("coin");
            count = (GTextField) GetChild("count");
            txt = (GTextField) GetChild("txt");
            t0 = GetTransition("t0");
        }
    }
}