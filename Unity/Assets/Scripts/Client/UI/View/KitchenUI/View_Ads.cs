/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_Ads : GComponent
    {
        public GLoader icon2;
        public GLoader icon1;
        public GLoader icon;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://y66af8yddb14j0";

        public static View_Ads CreateInstance()
        {
            return (View_Ads)UIPackage.CreateObject("KitchenUI", "Ads");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon2 = (GLoader)GetChild("icon2");
            icon1 = (GLoader)GetChild("icon1");
            icon = (GLoader)GetChild("icon");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}