/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Review
{
    public partial class View_Choose_yellowButton: GButton
    {
        public GTextField Desc;

        public const string URL = "ui://ijwojn7znniq19";

        public static View_Choose_yellowButton CreateInstance()
        {
            return (View_Choose_yellowButton) UIPackage.CreateObject("Review", "Choose_yellowButton");
        }

        public View_Choose_yellowButton()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Desc = (GTextField) GetChildAt(1);
        }
    }
}