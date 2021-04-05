/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_ZengYiZuJian: GComponent
    {
        public GLoader icon0;
        public GTextField num;
        public const string URL = "ui://ytyvezjfpik88qe";

        public static View_ZengYiZuJian CreateInstance()
        {
            return (View_ZengYiZuJian) UIPackage.CreateObject("GameBegins", "增益组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon0 = (GLoader) GetChild("icon0");
            num = (GTextField) GetChild("num");
        }
    }
}