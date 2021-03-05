/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_propPreViewItem : GComponent
    {
        public GComponent light;
        public GLoader icon;
        public const string URL = "ui://y66af8yds6xtim";

        public static View_propPreViewItem CreateInstance()
        {
            return (View_propPreViewItem)UIPackage.CreateObject("KitchenUI", "propPreViewItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light = (GComponent)GetChild("light");
            icon = (GLoader)GetChild("icon");
        }
    }
}