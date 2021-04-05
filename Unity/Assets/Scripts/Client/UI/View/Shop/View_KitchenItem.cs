/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
    public partial class View_KitchenItem: GButton
    {
        public Controller State;
        public GLoader Plate;
        public GList Star;
        public GComponent Recommend;
        public const string URL = "ui://y7wvbjtcq2tini";

        public static View_KitchenItem CreateInstance()
        {
            return (View_KitchenItem) UIPackage.CreateObject("Shop", "KitchenItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            State = GetController("State");
            Plate = (GLoader) GetChild("Plate");
            Star = (GList) GetChild("Star");
            Recommend = (GComponent) GetChild("Recommend");
        }
    }
}