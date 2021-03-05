/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Achievement
{
    public partial class View_ChengJiu1 : GComponent
    {
        public Controller c1;
        public Controller c2;
        public GTextField Name;
        public GTextField Desc;
        public GProgressBar ProgressBar;
        public GButton Finish;
        public GTextField ProgressTitle;
        public GGraph FlyPoint;
        public GLoader Icon;
        public GList Star;
        public const string URL = "ui://y1hfvz76cnzofl";

        public static View_ChengJiu1 CreateInstance()
        {
            return (View_ChengJiu1)UIPackage.CreateObject("Achievement", "成就1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            c2 = GetController("c2");
            Name = (GTextField)GetChild("Name");
            Desc = (GTextField)GetChild("Desc");
            ProgressBar = (GProgressBar)GetChild("ProgressBar");
            Finish = (GButton)GetChild("Finish");
            ProgressTitle = (GTextField)GetChild("ProgressTitle");
            FlyPoint = (GGraph)GetChild("FlyPoint");
            Icon = (GLoader)GetChild("Icon");
            Star = (GList)GetChild("Star");
        }
    }
}