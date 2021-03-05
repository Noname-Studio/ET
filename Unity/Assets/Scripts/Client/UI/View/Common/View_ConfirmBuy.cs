/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_ConfirmBuy : GComponent
    {
        public GButton bg;
        public View_green_button buy;
        public GTextField title;
        public GRichTextField instructions;
        public GRichTextField price;
        public GRichTextField content;
        public GButton Close;
        public const string URL = "ui://ucagdrsir0cjp1";

        public static View_ConfirmBuy CreateInstance()
        {
            return (View_ConfirmBuy)UIPackage.CreateObject("Common", "ConfirmBuy");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            buy = (View_green_button)GetChild("buy");
            title = (GTextField)GetChild("title");
            instructions = (GRichTextField)GetChild("instructions");
            price = (GRichTextField)GetChild("price");
            content = (GRichTextField)GetChild("content");
            Close = (GButton)GetChild("Close");
        }
    }
}