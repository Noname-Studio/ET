/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_tipboard : GComponent
    {
        public Controller c1;
        public GRichTextField content;
        public GGroup tipboard;
        public const string URL = "ui://ucagdrsig0wdvup";

        public static View_tipboard CreateInstance()
        {
            return (View_tipboard)UIPackage.CreateObject("Common", "tipboard");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            content = (GRichTextField)GetChild("content");
            tipboard = (GGroup)GetChild("tipboard");
        }
    }
}