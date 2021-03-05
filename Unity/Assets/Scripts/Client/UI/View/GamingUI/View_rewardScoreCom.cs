/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_rewardScoreCom : GComponent
    {
        public GRichTextField poptxt;
        public GImage light1;
        public Transition t0;
        public const string URL = "ui://dpc3yd4tgji2vyf";

        public static View_rewardScoreCom CreateInstance()
        {
            return (View_rewardScoreCom)UIPackage.CreateObject("GamingUI", "rewardScoreCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            poptxt = (GRichTextField)GetChild("poptxt");
            light1 = (GImage)GetChild("light1");
            t0 = GetTransition("t0");
        }
    }
}