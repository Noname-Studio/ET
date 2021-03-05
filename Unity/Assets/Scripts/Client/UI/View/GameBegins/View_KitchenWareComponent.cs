/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_KitchenWareComponent : GComponent
    {
        public GLoader icon_plate;
        public GLoader icon;
        public const string URL = "ui://ytyvezjff7gkpr";

        public static View_KitchenWareComponent CreateInstance()
        {
            return (View_KitchenWareComponent)UIPackage.CreateObject("GameBegins", "KitchenWareComponent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon_plate = (GLoader)GetChild("icon_plate");
            icon = (GLoader)GetChild("icon");
        }
    }
}