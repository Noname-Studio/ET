/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_game_quit : GComponent
    {
        public Controller c1;
        public GButton bg;
        public GTextField content1;
        public GButton yes_again;
        public GButton no_again;
        public GTextField content0;
        public GButton yes_quit;
        public GButton no_quit;
        public GGroup hearticon;
        public GButton no_stud;
        public GButton yes_stud;
        public View_failureTips failTip;
        public const string URL = "ui://y66af8ydltpyge";

        public static View_game_quit CreateInstance()
        {
            return (View_game_quit)UIPackage.CreateObject("KitchenUI", "game_quit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton)GetChild("bg");
            content1 = (GTextField)GetChild("content1");
            yes_again = (GButton)GetChild("yes_again");
            no_again = (GButton)GetChild("no_again");
            content0 = (GTextField)GetChild("content0");
            yes_quit = (GButton)GetChild("yes_quit");
            no_quit = (GButton)GetChild("no_quit");
            hearticon = (GGroup)GetChild("hearticon");
            no_stud = (GButton)GetChild("no_stud");
            yes_stud = (GButton)GetChild("yes_stud");
            failTip = (View_failureTips)GetChild("failTip");
        }
    }
}