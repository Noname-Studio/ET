/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_StorageFood : GComponent
    {
        public Controller c1;
        public GLoader Food1;
        public GLoader Food2;
        public const string URL = "ui://dpc3yd4tjljftw0v";

        public static View_StorageFood CreateInstance()
        {
            return (View_StorageFood)UIPackage.CreateObject("GamingUI", "StorageFood");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Food1 = (GLoader)GetChild("Food1");
            Food2 = (GLoader)GetChild("Food2");
        }
    }
}