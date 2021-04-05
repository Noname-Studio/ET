/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
    public partial class View_Component1: GComponent
    {
        public GList list;
        public const string URL = "ui://fmkyh2ywc1ts8nu";

        public static View_Component1 CreateInstance()
        {
            return (View_Component1) UIPackage.CreateObject("Main", "Component1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList) GetChild("list");
        }
    }
}