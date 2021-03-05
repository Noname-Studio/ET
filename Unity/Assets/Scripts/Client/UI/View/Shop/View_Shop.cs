/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
    public partial class View_Shop : GComponent
    {
        public Controller ShowPanelType;
        public GButton bg;
        public GList PanelType;
        public GList KitchenList;
        public GList DishesList;
        public GButton Close;
        public GButton MoreCoin;
        public const string URL = "ui://y7wvbjtcohmpna";

        public static View_Shop CreateInstance()
        {
            return (View_Shop)UIPackage.CreateObject("Shop", "Shop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ShowPanelType = GetController("ShowPanelType");
            bg = (GButton)GetChild("bg");
            PanelType = (GList)GetChild("PanelType");
            KitchenList = (GList)GetChild("KitchenList");
            DishesList = (GList)GetChild("DishesList");
            Close = (GButton)GetChild("Close");
            MoreCoin = (GButton)GetChild("MoreCoin");
        }
    }
}