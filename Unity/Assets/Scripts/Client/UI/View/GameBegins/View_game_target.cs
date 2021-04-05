/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_game_target: GComponent
    {
        public Controller target_style;
        public const string URL = "ui://ytyvezjf9j9g8rh";

        public static View_game_target CreateInstance()
        {
            return (View_game_target) UIPackage.CreateObject("GameBegins", "game_target");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            target_style = GetController("target_style");
        }
    }
}