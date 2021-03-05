/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_juesepaiming : GComponent
    {
        public Controller c1;
        public GTextField Rank;
        public GTextField Name;
        public GLoader cupcake;
        public GTextField Reward;
        public GLoader gift;
        public const string URL = "ui://nvat1mjsf9b9ib";

        public static View_juesepaiming CreateInstance()
        {
            return (View_juesepaiming)UIPackage.CreateObject("TheGuild", "juesepaiming");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Rank = (GTextField)GetChild("Rank");
            Name = (GTextField)GetChild("Name");
            cupcake = (GLoader)GetChild("cupcake");
            Reward = (GTextField)GetChild("Reward");
            gift = (GLoader)GetChild("gift");
        }
    }
}