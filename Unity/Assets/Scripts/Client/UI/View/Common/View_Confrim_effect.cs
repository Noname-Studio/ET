/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Confrim_effect : GComponent
    {
        public GImage Icon;
        public Transition Enter;
        public const string URL = "ui://ucagdrsitdbotd";

        public static View_Confrim_effect CreateInstance()
        {
            return (View_Confrim_effect)UIPackage.CreateObject("Common", "Confrim_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Icon = (GImage)GetChild("Icon");
            Enter = GetTransition("Enter");
        }
    }
}