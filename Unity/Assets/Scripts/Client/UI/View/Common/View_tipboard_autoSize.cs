/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_tipboard_autoSize : GComponent
    {
        public Controller c1;
        public GTextField content;
        public GGroup tipboard;
        public const string URL = "ui://ucagdrsixpf1vv1";

        public static View_tipboard_autoSize CreateInstance()
        {
            return (View_tipboard_autoSize)UIPackage.CreateObject("Common", "tipboard_autoSize");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            content = (GTextField)GetChild("content");
            tipboard = (GGroup)GetChild("tipboard");
        }
    }
}