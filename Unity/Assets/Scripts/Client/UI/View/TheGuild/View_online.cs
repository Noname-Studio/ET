/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_online : GComponent
    {
        public Controller c1;
        public GTextField Time;
        public const string URL = "ui://nvat1mjsgissw28";

        public static View_online CreateInstance()
        {
            return (View_online)UIPackage.CreateObject("TheGuild", "online");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Time = (GTextField)GetChild("Time");
        }
    }
}