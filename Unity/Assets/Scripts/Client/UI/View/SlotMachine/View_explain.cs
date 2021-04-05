/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.SlotMachine
{
    public partial class View_explain: GComponent
    {
        public GButton bg;
        public GButton Close;

        public const string URL = "ui://yta40mdqini3m5";

        public static View_explain CreateInstance()
        {
            return (View_explain) UIPackage.CreateObject("SlotMachine", "explain");
        }

        public View_explain()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChildAt(0);
            Close = (GButton) GetChildAt(2);
        }
    }
}