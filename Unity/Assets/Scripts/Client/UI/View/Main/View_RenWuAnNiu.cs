/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_RenWuAnNiu: GButton
    {
        public GComponent tips;
        public const string URL = "ui://fmkyh2ywvqob10";

        public static View_RenWuAnNiu CreateInstance()
        {
            return (View_RenWuAnNiu) UIPackage.CreateObject("Main", "任务按钮");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tips = (GComponent) GetChild("tips");
        }
    }
}