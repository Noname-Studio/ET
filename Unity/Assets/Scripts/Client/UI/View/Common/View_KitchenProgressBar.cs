/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_KitchenProgressBar : GProgressBar
    {
        public GImage greenblock;
        public const string URL = "ui://ucagdrsihf6t9r";

        public static View_KitchenProgressBar CreateInstance()
        {
            return (View_KitchenProgressBar)UIPackage.CreateObject("Common", "KitchenProgressBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            greenblock = (GImage)GetChild("greenblock");
        }
    }
}