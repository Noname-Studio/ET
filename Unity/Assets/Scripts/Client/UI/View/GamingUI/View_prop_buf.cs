/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_prop_buf: GComponent
    {
        public GImage bg;
        public GImage fill;
        public GLoader icon;
        public const string URL = "ui://dpc3yd4tro727p";

        public static View_prop_buf CreateInstance()
        {
            return (View_prop_buf) UIPackage.CreateObject("GamingUI", "prop_buf");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage) GetChild("bg");
            fill = (GImage) GetChild("fill");
            icon = (GLoader) GetChild("icon");
        }
    }
}