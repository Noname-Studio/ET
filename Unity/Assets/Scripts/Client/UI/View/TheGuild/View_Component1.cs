/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TheGuild
{
    public partial class View_Component1 : GComponent
    {
        public Controller c1;
        public GImage bg;
        public const string URL = "ui://nvat1mjse6qwik";

        public static View_Component1 CreateInstance()
        {
            return (View_Component1)UIPackage.CreateObject("TheGuild", "Component1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GImage)GetChild("bg");
        }
    }
}