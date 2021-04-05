/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.EditFurniture
{
    public partial class View_FurnitureSelect: GButton
    {
        public Controller Buy;
        public Controller Guide;
        public GRichTextField Money;
        public GGroup Popframe;
        public Transition t0;

        public const string URL = "ui://yee5iu2phrvd80";

        public static View_FurnitureSelect CreateInstance()
        {
            return (View_FurnitureSelect) UIPackage.CreateObject("EditFurniture", "FurnitureSelect");
        }

        public View_FurnitureSelect()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Buy = GetControllerAt(1);
            Guide = GetControllerAt(2);
            Money = (GRichTextField) GetChildAt(8);
            Popframe = (GGroup) GetChildAt(10);
            t0 = GetTransitionAt(0);
        }
    }
}