/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_NormalItemIcon : GLabel
    {
        public Controller c1;
        public GTextField name2;
        public GTextField name1;
        public const string URL = "ui://ucagdrsiivbstu";

        public static View_NormalItemIcon CreateInstance()
        {
            return (View_NormalItemIcon)UIPackage.CreateObject("Common", "NormalItemIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            name2 = (GTextField)GetChild("name2");
            name1 = (GTextField)GetChild("name1");
        }
    }
}