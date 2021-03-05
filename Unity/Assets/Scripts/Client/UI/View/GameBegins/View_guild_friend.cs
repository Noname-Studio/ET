/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_guild_friend : GComponent
    {
        public Controller mode;
        public GGraph holder;
        public View_invitefriend com;
        public const string URL = "ui://ytyvezjfsfoz8qg";

        public static View_guild_friend CreateInstance()
        {
            return (View_guild_friend)UIPackage.CreateObject("GameBegins", "guild_friend");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            mode = GetController("mode");
            holder = (GGraph)GetChild("holder");
            com = (View_invitefriend)GetChild("com");
        }
    }
}