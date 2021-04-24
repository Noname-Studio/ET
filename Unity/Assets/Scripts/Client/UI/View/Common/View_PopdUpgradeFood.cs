/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_PopdUpgradeFood : GComponent
    {
        public Controller IsMax;
        public Controller c1;
        public View_yellow_light_circle icon_light;
        public GLoader Plane;
        public GLoader FoodIcon;
        public GTextField FoodName;
        public GTextField priceTitle;
        public GGroup titlegroup;
        public GRichTextField finishprice;
        public GRichTextField From;
        public GRichTextField To;
        public GLoader max_icon;
        public GGroup MaxLevel;
        public View_green_button UpgradeButton;
        public GRichTextField Price;
        public GGroup UpgradeGroup;
        public GList Star;
        public GButton Close;
        public GButton resetBtn;
        public const string URL = "ui://ucagdrsinru7j5";

        public static View_PopdUpgradeFood CreateInstance()
        {
            return (View_PopdUpgradeFood)UIPackage.CreateObject("Common", "PopdUpgradeFood");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            IsMax = GetController("IsMax");
            c1 = GetController("c1");
            icon_light = (View_yellow_light_circle)GetChild("icon_light");
            Plane = (GLoader)GetChild("Plane");
            FoodIcon = (GLoader)GetChild("FoodIcon");
            FoodName = (GTextField)GetChild("FoodName");
            priceTitle = (GTextField)GetChild("priceTitle");
            titlegroup = (GGroup)GetChild("titlegroup");
            finishprice = (GRichTextField)GetChild("finishprice");
            From = (GRichTextField)GetChild("From");
            To = (GRichTextField)GetChild("To");
            max_icon = (GLoader)GetChild("max_icon");
            MaxLevel = (GGroup)GetChild("MaxLevel");
            UpgradeButton = (View_green_button)GetChild("UpgradeButton");
            Price = (GRichTextField)GetChild("Price");
            UpgradeGroup = (GGroup)GetChild("UpgradeGroup");
            Star = (GList)GetChild("Star");
            Close = (GButton)GetChild("Close");
            resetBtn = (GButton)GetChild("resetBtn");
        }
    }
}