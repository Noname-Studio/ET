/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_LianXuGuoGuanZuJian : GComponent
    {
        public Controller c1;
        public View_continuebar fill;
        public GTextField title;
        public GTextField timetxt;
        public GButton getit;
        public const string URL = "ui://ucagdrsigqtovww";

        public static View_LianXuGuoGuanZuJian CreateInstance()
        {
            return (View_LianXuGuoGuanZuJian)UIPackage.CreateObject("Common", "连续过关组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            fill = (View_continuebar)GetChild("fill");
            title = (GTextField)GetChild("title");
            timetxt = (GTextField)GetChild("timetxt");
            getit = (GButton)GetChild("getit");
        }
    }
}