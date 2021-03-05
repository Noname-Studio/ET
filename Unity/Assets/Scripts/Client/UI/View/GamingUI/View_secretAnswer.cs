/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_secretAnswer : GComponent
    {
        public GLoader cus;
        public GLoader dish;
        public GLoader food;
        public const string URL = "ui://dpc3yd4tpx5q5g";

        public static View_secretAnswer CreateInstance()
        {
            return (View_secretAnswer)UIPackage.CreateObject("GamingUI", "secretAnswer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            cus = (GLoader)GetChild("cus");
            dish = (GLoader)GetChild("dish");
            food = (GLoader)GetChild("food");
        }
    }
}