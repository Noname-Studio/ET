/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_ShiZhuangZuJian: GComponent
    {
        public Controller c1;
        public GList List1;

        public const string URL = "ui://e18f31pokgfn1h";

        public static View_ShiZhuangZuJian CreateInstance()
        {
            return (View_ShiZhuangZuJian) UIPackage.CreateObject("Fashion", "时装组件");
        }

        public View_ShiZhuangZuJian()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            List1 = (GList) GetChildAt(1);
        }
    }
}