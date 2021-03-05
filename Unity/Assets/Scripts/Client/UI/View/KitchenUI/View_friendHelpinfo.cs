/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_friendHelpinfo : GComponent
    {
        public GButton bg;
        public GTextField title;
        public GButton GoQuiz;
        public GButton Close;
        public const string URL = "ui://y66af8ydbaduvz9";

        public static View_friendHelpinfo CreateInstance()
        {
            return (View_friendHelpinfo)UIPackage.CreateObject("KitchenUI", "friendHelpinfo");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            title = (GTextField)GetChild("title");
            GoQuiz = (GButton)GetChild("GoQuiz");
            Close = (GButton)GetChild("Close");
        }
    }
}