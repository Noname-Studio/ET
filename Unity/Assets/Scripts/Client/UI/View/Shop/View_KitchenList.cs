/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
    public partial class View_KitchenList: GComponent
    {
        public GList List;
        public const string URL = "ui://y7wvbjtcvlqqnm";

        public static View_KitchenList CreateInstance()
        {
            return (View_KitchenList) UIPackage.CreateObject("Shop", "KitchenList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList) GetChild("List");
        }
    }
}