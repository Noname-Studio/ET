/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_ChuiZiDongHua: GComponent
    {
        public Transition t0;

        public const string URL = "ui://3b4mf257tnnr16";

        public static View_ChuiZiDongHua CreateInstance()
        {
            return (View_ChuiZiDongHua) UIPackage.CreateObject("CandyHouse", "锤子动画");
        }

        public View_ChuiZiDongHua()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransitionAt(0);
        }
    }
}