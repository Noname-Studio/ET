/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
    public partial class View_DishesItem: GButton
    {
        public Controller State;
        public Controller newicon_c;
        public GLoader Plate;
        public GImage newicon;
        public GComponent greentip;
        public GComponent recommend;
        public GComponent tip2;
        public GList Star;
        public const string URL = "ui://y7wvbjtcvv87aq";

        public static View_DishesItem CreateInstance()
        {
            return (View_DishesItem) UIPackage.CreateObject("Shop", "DishesItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            State = GetController("State");
            newicon_c = GetController("newicon_c");
            Plate = (GLoader) GetChild("Plate");
            newicon = (GImage) GetChild("newicon");
            greentip = (GComponent) GetChild("greentip");
            recommend = (GComponent) GetChild("recommend");
            tip2 = (GComponent) GetChild("tip2");
            Star = (GList) GetChild("Star");
        }
    }
}