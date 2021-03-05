/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_yellowgiftcom : GComponent
    {
        public View_10ZuanShiLiHe box;
        public const string URL = "ui://ucagdrsiip1ovyr";

        public static View_yellowgiftcom CreateInstance()
        {
            return (View_yellowgiftcom)UIPackage.CreateObject("Common", "yellowgiftcom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            box = (View_10ZuanShiLiHe)GetChild("box");
        }
    }
}