/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_tuanduijiesuanjiangli_effect : GComponent
    {
        public Controller c1;
        public GList TeamReward;
        public GTextField content;
        public Transition t2;
        public const string URL = "ui://nvat1mjsjmfydn3";

        public static View_tuanduijiesuanjiangli_effect CreateInstance()
        {
            return (View_tuanduijiesuanjiangli_effect)UIPackage.CreateObject("TheGuild", "tuanduijiesuanjiangli_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            TeamReward = (GList)GetChild("TeamReward");
            content = (GTextField)GetChild("content");
            t2 = GetTransition("t2");
        }
    }
}