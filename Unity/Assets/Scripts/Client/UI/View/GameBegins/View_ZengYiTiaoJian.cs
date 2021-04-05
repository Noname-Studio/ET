/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_ZengYiTiaoJian: GComponent
    {
        public Controller c1;
        public GTextField txt;
        public View_ZengYiZuJian up_coin;
        public GTextField total;
        public const string URL = "ui://ytyvezjf119o8q5";

        public static View_ZengYiTiaoJian CreateInstance()
        {
            return (View_ZengYiTiaoJian) UIPackage.CreateObject("GameBegins", "增益条件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            txt = (GTextField) GetChild("txt");
            up_coin = (View_ZengYiZuJian) GetChild("up_coin");
            total = (GTextField) GetChild("total");
        }
    }
}