/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_step0: GComponent
    {
        public GImage arrow;
        public GImage food;
        public GImage cw;
        public const string URL = "ui://dpc3yd4ttmfvw";

        public static View_step0 CreateInstance()
        {
            return (View_step0) UIPackage.CreateObject("GamingUI", "step0");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            arrow = (GImage) GetChild("arrow");
            food = (GImage) GetChild("food");
            cw = (GImage) GetChild("cw");
        }
    }
}