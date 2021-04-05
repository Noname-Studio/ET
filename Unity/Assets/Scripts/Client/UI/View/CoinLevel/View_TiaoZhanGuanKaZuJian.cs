/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CoinLevel
{
    public partial class View_TiaoZhanGuanKaZuJian: GComponent
    {
        public Controller c1;
        public GButton Challenge;
        public GButton Button;
        public GButton Finish;
        public GTextField Time;

        public const string URL = "ui://yza5bcq0igjbvzt";

        public static View_TiaoZhanGuanKaZuJian CreateInstance()
        {
            return (View_TiaoZhanGuanKaZuJian) UIPackage.CreateObject("CoinLevel", "挑战关卡组件");
        }

        public View_TiaoZhanGuanKaZuJian()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Challenge = (GButton) GetChildAt(1);
            Button = (GButton) GetChildAt(2);
            Finish = (GButton) GetChildAt(5);
            Time = (GTextField) GetChildAt(7);
        }
    }
}