/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_props_buy_unlock : GComponent
    {
        public Controller c1;
        public GButton bg;
        public View_yellow_light_circle icon_light;
        public GLoader icon;
        public GTextField title;
        public GTextField content;
        public View_green_button buy;
        public GRichTextField price;
        public GTextField num;
        public View_yellow_button get;
        public GButton Close;
        public const string URL = "ui://ucagdrsirimjt4";

        public static View_props_buy_unlock CreateInstance()
        {
            return (View_props_buy_unlock)UIPackage.CreateObject("Common", "props_buy_unlock");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton)GetChild("bg");
            icon_light = (View_yellow_light_circle)GetChild("icon_light");
            icon = (GLoader)GetChild("icon");
            title = (GTextField)GetChild("title");
            content = (GTextField)GetChild("content");
            buy = (View_green_button)GetChild("buy");
            price = (GRichTextField)GetChild("price");
            num = (GTextField)GetChild("num");
            get = (View_yellow_button)GetChild("get");
            Close = (GButton)GetChild("Close");
        }
    }
}