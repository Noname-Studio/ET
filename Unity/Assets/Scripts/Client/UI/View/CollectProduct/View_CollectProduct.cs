/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CollectProduct
{
    public partial class View_CollectProduct: GComponent
    {
        public GButton bg;

        public GComponent Effect;

        //public GLoader icon;
        public GTextField title;

        public const string URL = "ui://m99fdlgyi1033";

        public static View_CollectProduct CreateInstance()
        {
            return (View_CollectProduct) UIPackage.CreateObject("CollectProduct", "CollectProduct");
        }

        public View_CollectProduct()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChildAt(0);
            Effect = (GComponent) GetChildAt(1);
            //icon = (GLoader)this.GetChildAt(3);
            title = (GTextField) GetChildAt(5);
        }
    }
}