/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_nameframe: GComponent
    {
        public GTextField name;
        public const string URL = "ui://dpc3yd4t106ztvz2";

        public static View_nameframe CreateInstance()
        {
            return (View_nameframe) UIPackage.CreateObject("GamingUI", "nameframe");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            name = (GTextField) GetChild("name");
        }
    }
}