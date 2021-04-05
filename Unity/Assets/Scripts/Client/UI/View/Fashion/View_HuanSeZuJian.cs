/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_HuanSeZuJian: GComponent
    {
        public GList List;
        public GButton Down;
        public GButton Up;

        public const string URL = "ui://e18f31pokgfn1r";

        public static View_HuanSeZuJian CreateInstance()
        {
            return (View_HuanSeZuJian) UIPackage.CreateObject("Fashion", "换色组件");
        }

        public View_HuanSeZuJian()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList) GetChildAt(1);
            Down = (GButton) GetChildAt(2);
            Up = (GButton) GetChildAt(3);
        }
    }
}