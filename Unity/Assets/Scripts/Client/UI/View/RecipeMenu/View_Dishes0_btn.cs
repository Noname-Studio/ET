/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.RecipeMenu
{
    public partial class View_Dishes0_btn: GButton
    {
        public View_Dishes0 dishes;
        public GImage newicon;
        public GButton practice;

        public const string URL = "ui://rrligmrxq9poq";

        public static View_Dishes0_btn CreateInstance()
        {
            return (View_Dishes0_btn) UIPackage.CreateObject("RecipeMenu", "Dishes0_btn");
        }

        public View_Dishes0_btn()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            dishes = (View_Dishes0) GetChildAt(2);
            newicon = (GImage) GetChildAt(3);
            practice = (GButton) GetChildAt(4);
        }
    }
}