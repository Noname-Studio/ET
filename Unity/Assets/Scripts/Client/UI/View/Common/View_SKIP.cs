/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_SKIP : GButton
    {
        public GTextField titel;
        public const string URL = "ui://ucagdrsilw2ntq";

        public static View_SKIP CreateInstance()
        {
            return (View_SKIP)UIPackage.CreateObject("Common", "SKIP");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            titel = (GTextField)GetChild("titel");
        }
    }
}