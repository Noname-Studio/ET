/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_UpgradeObjectsTips : GComponent
    {
        public GList list;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://ytyvezjfo13wq2";

        public static View_UpgradeObjectsTips CreateInstance()
        {
            return (View_UpgradeObjectsTips)UIPackage.CreateObject("GameBegins", "UpgradeObjectsTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChild("list");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}