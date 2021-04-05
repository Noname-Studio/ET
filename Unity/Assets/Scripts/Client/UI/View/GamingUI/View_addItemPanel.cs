/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_addItemPanel: GComponent
    {
        public GLoader icon;
        public GTextField txt;
        public const string URL = "ui://dpc3yd4tffhh57";

        public static View_addItemPanel CreateInstance()
        {
            return (View_addItemPanel) UIPackage.CreateObject("GamingUI", "addItemPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon = (GLoader) GetChild("icon");
            txt = (GTextField) GetChild("txt");
        }
    }
}