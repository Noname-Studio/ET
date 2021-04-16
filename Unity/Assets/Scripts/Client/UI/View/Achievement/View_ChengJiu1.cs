/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Achievement
{
    public partial class View_ChengJiu1 : GLabel
    {
        public Controller IconPage;
        public Controller State;
        public GTextField Desc;
        public GProgressBar ProgressBar;
        public GButton Finish;
        public GList Star;
        public const string URL = "ui://y1hfvz76cnzofl";

        public static View_ChengJiu1 CreateInstance()
        {
            return (View_ChengJiu1)UIPackage.CreateObject("Achievement", "成就1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            IconPage = GetController("IconPage");
            State = GetController("State");
            Desc = (GTextField)GetChild("Desc");
            ProgressBar = (GProgressBar)GetChild("ProgressBar");
            Finish = (GButton)GetChild("Finish");
            Star = (GList)GetChild("Star");
        }
    }
}