/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_green_button : GButton
    {
        public Controller c1;
        public const string URL = "ui://ucagdrsiiy08w";

        public static View_green_button CreateInstance()
        {
            return (View_green_button)UIPackage.CreateObject("Common", "green_button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
        }
    }
}