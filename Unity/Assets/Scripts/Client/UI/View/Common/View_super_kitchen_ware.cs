/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_super_kitchen_ware : GComponent
    {
        public View_super_cw supercontent;
        public GTextField name;
        public GTextField p1;
        public GTextField p2;
        public View_yellow_button BuySuperKitchen;
        public GTextField gettxt;
        public GGroup buygroup;
        public const string URL = "ui://ucagdrsicjihoq";

        public static View_super_kitchen_ware CreateInstance()
        {
            return (View_super_kitchen_ware)UIPackage.CreateObject("Common", "super_kitchen_ware");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            supercontent = (View_super_cw)GetChild("supercontent");
            name = (GTextField)GetChild("name");
            p1 = (GTextField)GetChild("p1");
            p2 = (GTextField)GetChild("p2");
            BuySuperKitchen = (View_yellow_button)GetChild("BuySuperKitchen");
            gettxt = (GTextField)GetChild("gettxt");
            buygroup = (GGroup)GetChild("buygroup");
        }
    }
}