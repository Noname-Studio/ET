/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_HelpFriendPlay : GComponent
    {
        public Controller board_style;
        public GButton bg;
        public GGroup board;
        public GButton Close;
        public GButton Play;
        public View_game_target target;
        public GTextField Restaurant;
        public GImage guidedifficult;
        public GTextField Title1;
        public GTextField Title;
        public View_propitems0 prop;
        public View_recipebtn Recipe;
        public const string URL = "ui://ytyvezjftg7o8rl";

        public static View_HelpFriendPlay CreateInstance()
        {
            return (View_HelpFriendPlay)UIPackage.CreateObject("GameBegins", "HelpFriendPlay");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            board_style = GetController("board_style");
            bg = (GButton)GetChild("bg");
            board = (GGroup)GetChild("board");
            Close = (GButton)GetChild("Close");
            Play = (GButton)GetChild("Play");
            target = (View_game_target)GetChild("target");
            Restaurant = (GTextField)GetChild("Restaurant");
            guidedifficult = (GImage)GetChild("guidedifficult");
            Title1 = (GTextField)GetChild("Title1");
            Title = (GTextField)GetChild("Title");
            prop = (View_propitems0)GetChild("prop");
            Recipe = (View_recipebtn)GetChild("Recipe");
        }
    }
}