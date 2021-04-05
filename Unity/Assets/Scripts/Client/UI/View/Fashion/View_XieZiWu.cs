/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_XieZiWu: GButton
    {
        public Controller c1;
        public GLoader icon1;
        public GTextField gem;

        public const string URL = "ui://e18f31potbryr";

        public static View_XieZiWu CreateInstance()
        {
            return (View_XieZiWu) UIPackage.CreateObject("Fashion", "鞋子屋");
        }

        public View_XieZiWu()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            icon1 = (GLoader) GetChildAt(5);
            gem = (GTextField) GetChildAt(6);
        }
    }
}