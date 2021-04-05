/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_cw_cookie_choose: GComponent
    {
        public GLoader icon_bg0;
        public GLoader icon_bg1;
        public GLoader icon_bg2;
        public GImage icon_light;
        public GImage icon0;
        public GImage icon1;
        public GImage icon2;
        public const string URL = "ui://dpc3yd4tkao74f";

        public static View_cw_cookie_choose CreateInstance()
        {
            return (View_cw_cookie_choose) UIPackage.CreateObject("GamingUI", "cw_cookie_choose");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon_bg0 = (GLoader) GetChild("icon_bg0");
            icon_bg1 = (GLoader) GetChild("icon_bg1");
            icon_bg2 = (GLoader) GetChild("icon_bg2");
            icon_light = (GImage) GetChild("icon_light");
            icon0 = (GImage) GetChild("icon0");
            icon1 = (GImage) GetChild("icon1");
            icon2 = (GImage) GetChild("icon2");
        }
    }
}