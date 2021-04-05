/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_Grid: GButton
    {
        public GGraph Grid;
        public const string URL = "ui://97pg0d8fwybbw3x";

        public static View_Grid CreateInstance()
        {
            return (View_Grid) UIPackage.CreateObject("InternalResources", "Grid");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Grid = (GGraph) GetChild("Grid");
        }
    }
}