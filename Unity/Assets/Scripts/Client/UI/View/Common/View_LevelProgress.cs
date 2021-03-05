/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_LevelProgress : GLabel
    {
        public View_KitchenProgressBar Progress;
        public GImage arrow;
        public GTextField txt1;
        public GTextField txt2;
        public GGroup ProgressGroup;
        public const string URL = "ui://ucagdrsihf6t9q";

        public static View_LevelProgress CreateInstance()
        {
            return (View_LevelProgress)UIPackage.CreateObject("Common", "LevelProgress");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Progress = (View_KitchenProgressBar)GetChild("Progress");
            arrow = (GImage)GetChild("arrow");
            txt1 = (GTextField)GetChild("txt1");
            txt2 = (GTextField)GetChild("txt2");
            ProgressGroup = (GGroup)GetChild("ProgressGroup");
        }
    }
}