/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_form: GComponent
    {
        public Controller c1;
        public GTextField Title;
        public GTextField Time;
        public GTextField Product;
        public GTextField Limit;

        public const string URL = "ui://3b4mf257uhxx1d";

        public static View_form CreateInstance()
        {
            return (View_form) UIPackage.CreateObject("CandyHouse", "form");
        }

        public View_form()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            Title = (GTextField) GetChildAt(0);
            Time = (GTextField) GetChildAt(9);
            Product = (GTextField) GetChildAt(11);
            Limit = (GTextField) GetChildAt(12);
        }
    }
}