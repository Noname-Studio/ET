/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_NormalItemIconSmall : GLabel
    {
        public GTextField name2;
        public const string URL = "ui://ucagdrsiijo9w30";

        public static View_NormalItemIconSmall CreateInstance()
        {
            return (View_NormalItemIconSmall)UIPackage.CreateObject("Common", "NormalItemIconSmall");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            name2 = (GTextField)GetChild("name2");
        }
    }
}