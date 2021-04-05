/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_title: GComponent
    {
        public GGroup candy5;
        public GGroup dengpao;
        public View_candystar Star1;
        public View_candystar Star2;
        public View_candystar Star3;
        public View_candystar Star4;
        public View_candystar Star5;
        public GGroup star;
        public GTextField title;

        public const string URL = "ui://3b4mf257btlo1m";

        public static View_title CreateInstance()
        {
            return (View_title) UIPackage.CreateObject("CandyHouse", "title");
        }

        public View_title()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            candy5 = (GGroup) GetChildAt(2);
            dengpao = (GGroup) GetChildAt(12);
            Star1 = (View_candystar) GetChildAt(14);
            Star2 = (View_candystar) GetChildAt(15);
            Star3 = (View_candystar) GetChildAt(16);
            Star4 = (View_candystar) GetChildAt(17);
            Star5 = (View_candystar) GetChildAt(18);
            star = (GGroup) GetChildAt(19);
            title = (GTextField) GetChildAt(20);
        }
    }
}