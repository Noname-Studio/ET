/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_ChuiZiDongHuaNew: GComponent
    {
        public Transition chuizi;
        public Transition yun;
        public Transition exit;

        public const string URL = "ui://3b4mf257qvkm17";

        public static View_ChuiZiDongHuaNew CreateInstance()
        {
            return (View_ChuiZiDongHuaNew) UIPackage.CreateObject("CandyHouse", "锤子动画New");
        }

        public View_ChuiZiDongHuaNew()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            chuizi = GetTransitionAt(0);
            yun = GetTransitionAt(1);
            exit = GetTransitionAt(2);
        }
    }
}