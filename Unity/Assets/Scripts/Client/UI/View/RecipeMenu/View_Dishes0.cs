/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.RecipeMenu
{
    public partial class View_Dishes0: GComponent
    {
        public View_dishes food;
        public GTextField title;
        public GList Star;

        public const string URL = "ui://rrligmrxq9pov";

        public static View_Dishes0 CreateInstance()
        {
            return (View_Dishes0) UIPackage.CreateObject("RecipeMenu", "Dishes0");
        }

        public View_Dishes0()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            food = (View_dishes) GetChildAt(1);
            title = (GTextField) GetChildAt(2);
            Star = (GList) GetChildAt(3);
        }
    }
}