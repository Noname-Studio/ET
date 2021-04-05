/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_addpatientitem: GComponent
    {
        public Controller c1;
        public Controller ui_style;
        public GLoader icon;
        public GImage sel;
        public GProgressBar restoreBar;
        public GImage numbg;
        public GImage add_icon;
        public GTextField num;
        public GComponent recommend;
        public const string URL = "ui://dpc3yd4tg0a174";

        public static View_addpatientitem CreateInstance()
        {
            return (View_addpatientitem) UIPackage.CreateObject("GamingUI", "addpatientitem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            ui_style = GetController("ui_style");
            icon = (GLoader) GetChild("icon");
            sel = (GImage) GetChild("sel");
            restoreBar = (GProgressBar) GetChild("restoreBar");
            numbg = (GImage) GetChild("numbg");
            add_icon = (GImage) GetChild("add_icon");
            num = (GTextField) GetChild("num");
            recommend = (GComponent) GetChild("recommend");
        }
    }
}