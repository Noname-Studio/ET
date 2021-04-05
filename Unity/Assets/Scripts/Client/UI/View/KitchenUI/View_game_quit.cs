/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_game_quit : GComponent
    {
        public Controller Type;
        public GButton bg;
        public GGroup hearticon;
        public View_failureTips failTip;
        public GButton Yes;
        public GButton No;
        public const string URL = "ui://y66af8ydltpyge";

        public static View_game_quit CreateInstance()
        {
            return (View_game_quit)UIPackage.CreateObject("KitchenUI", "game_quit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Type = GetController("Type");
            bg = (GButton)GetChild("bg");
            hearticon = (GGroup)GetChild("hearticon");
            failTip = (View_failureTips)GetChild("failTip");
            Yes = (GButton)GetChild("Yes");
            No = (GButton)GetChild("No");
        }
    }
}