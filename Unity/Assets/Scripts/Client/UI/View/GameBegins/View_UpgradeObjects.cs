/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_UpgradeObjects: GComponent
    {
        public GLoader plate;
        public GLoader loader;
        public const string URL = "ui://ytyvezjfo13wq0";

        public static View_UpgradeObjects CreateInstance()
        {
            return (View_UpgradeObjects) UIPackage.CreateObject("GameBegins", "UpgradeObjects");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            plate = (GLoader) GetChild("plate");
            loader = (GLoader) GetChild("loader");
        }
    }
}