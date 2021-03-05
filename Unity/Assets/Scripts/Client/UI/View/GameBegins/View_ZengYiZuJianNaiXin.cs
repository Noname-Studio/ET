/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_ZengYiZuJianNaiXin : GComponent
    {
        public GLoader icon0;
        public GTextField num;
        public const string URL = "ui://ytyvezjfv7p48rj";

        public static View_ZengYiZuJianNaiXin CreateInstance()
        {
            return (View_ZengYiZuJianNaiXin)UIPackage.CreateObject("GameBegins", "增益组件耐心");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon0 = (GLoader)GetChild("icon0");
            num = (GTextField)GetChild("num");
        }
    }
}