/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_ZheZhao : GComponent
    {
        public GComponent title_bg_light;
        public const string URL = "ui://y66af8ydkh00j4";

        public static View_ZheZhao CreateInstance()
        {
            return (View_ZheZhao)UIPackage.CreateObject("KitchenUI", "遮罩");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title_bg_light = (GComponent)GetChild("title_bg_light");
        }
    }
}