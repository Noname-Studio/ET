/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Settings
{
    public partial class View_synchrodata_button : GButton
    {
        public Controller c1;
        public Transition t0;
        public const string URL = "ui://yzgsvb7w91qrny";

        public static View_synchrodata_button CreateInstance()
        {
            return (View_synchrodata_button)UIPackage.CreateObject("Settings", "synchrodata_button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            t0 = GetTransition("t0");
        }
    }
}