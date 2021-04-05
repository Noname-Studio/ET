/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_WuJinQiPao: GComponent
    {
        public GImage bg;
        public GTextField num;
        public Transition show;
        public Transition t1;
        public Transition hide;
        public const string URL = "ui://dpc3yd4ty2e8vz0";

        public static View_WuJinQiPao CreateInstance()
        {
            return (View_WuJinQiPao) UIPackage.CreateObject("GamingUI", "无尽气泡");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage) GetChild("bg");
            num = (GTextField) GetChild("num");
            show = GetTransition("show");
            t1 = GetTransition("t1");
            hide = GetTransition("hide");
        }
    }
}