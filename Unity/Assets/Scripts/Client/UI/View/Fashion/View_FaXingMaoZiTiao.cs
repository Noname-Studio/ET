/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_FaXingMaoZiTiao: GComponent
    {
        public GList List;

        public const string URL = "ui://e18f31pokqr1z";

        public static View_FaXingMaoZiTiao CreateInstance()
        {
            return (View_FaXingMaoZiTiao) UIPackage.CreateObject("Fashion", "发型帽子条");
        }

        public View_FaXingMaoZiTiao()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList) GetChildAt(1);
        }
    }
}