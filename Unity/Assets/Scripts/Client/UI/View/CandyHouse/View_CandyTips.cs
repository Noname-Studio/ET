/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_CandyTips: GComponent
    {
        public GButton bg;
        public GTextField Desc;
        public GTextField Number;
        public GButton Close;
        public GButton Confirm;

        public const string URL = "ui://3b4mf257p0yfi";

        public static View_CandyTips CreateInstance()
        {
            return (View_CandyTips) UIPackage.CreateObject("CandyHouse", "CandyTips");
        }

        public View_CandyTips()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChildAt(0);
            Desc = (GTextField) GetChildAt(7);
            Number = (GTextField) GetChildAt(8);
            Close = (GButton) GetChildAt(9);
            Confirm = (GButton) GetChildAt(10);
        }
    }
}