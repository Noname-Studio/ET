/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_TaoZhuangWu: GButton
    {
        public Controller c1;
        public GLoader icon1;
        public GTextField gem;
        public GGroup free;

        public const string URL = "ui://e18f31potbryp";

        public static View_TaoZhuangWu CreateInstance()
        {
            return (View_TaoZhuangWu) UIPackage.CreateObject("Fashion", "套装屋");
        }

        public View_TaoZhuangWu()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(1);
            icon1 = (GLoader) GetChildAt(4);
            gem = (GTextField) GetChildAt(5);
            free = (GGroup) GetChildAt(9);
        }
    }
}