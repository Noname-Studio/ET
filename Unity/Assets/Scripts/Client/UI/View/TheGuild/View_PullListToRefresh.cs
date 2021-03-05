/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_PullListToRefresh : GComponent
    {
        public Controller c1;
        public GTextField Desc;
        public Transition t0;
        public const string URL = "ui://nvat1mjsofkbw2a";

        public static View_PullListToRefresh CreateInstance()
        {
            return (View_PullListToRefresh)UIPackage.CreateObject("TheGuild", "PullListToRefresh");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Desc = (GTextField)GetChild("Desc");
            t0 = GetTransition("t0");
        }
    }
}