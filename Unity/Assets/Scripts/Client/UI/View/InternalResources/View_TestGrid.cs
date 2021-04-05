/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_TestGrid: GComponent
    {
        public GButton Create1;
        public GButton Create2;
        public GButton Create3;
        public GButton Create4;
        public GButton Create5;
        public GButton Create6;
        public const string URL = "ui://97pg0d8fwybbvwk";

        public static View_TestGrid CreateInstance()
        {
            return (View_TestGrid) UIPackage.CreateObject("InternalResources", "TestGrid");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Create1 = (GButton) GetChild("Create1");
            Create2 = (GButton) GetChild("Create2");
            Create3 = (GButton) GetChild("Create3");
            Create4 = (GButton) GetChild("Create4");
            Create5 = (GButton) GetChild("Create5");
            Create6 = (GButton) GetChild("Create6");
        }
    }
}