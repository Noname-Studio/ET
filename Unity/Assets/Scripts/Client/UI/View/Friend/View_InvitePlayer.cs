/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Friend
{
    public partial class View_InvitePlayer: GComponent
    {
        public Controller c1;
        public GList List;

        public const string URL = "ui://y072jhf1cpakda";

        public static View_InvitePlayer CreateInstance()
        {
            return (View_InvitePlayer) UIPackage.CreateObject("Friend", "InvitePlayer");
        }

        public View_InvitePlayer()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            List = (GList) GetChildAt(1);
        }
    }
}