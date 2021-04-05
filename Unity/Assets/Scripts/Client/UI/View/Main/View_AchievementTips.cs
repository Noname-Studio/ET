/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_AchievementTips: GLabel
    {
        public Transition t0;
        public const string URL = "ui://fmkyh2ywtj0c8op";

        public static View_AchievementTips CreateInstance()
        {
            return (View_AchievementTips) UIPackage.CreateObject("Main", "AchievementTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}