/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Settings
{
    public partial class View_copy_ok_tip: GComponent
    {
        public Transition t0;
        public const string URL = "ui://yzgsvb7wcu4no8";

        public static View_copy_ok_tip CreateInstance()
        {
            return (View_copy_ok_tip) UIPackage.CreateObject("Settings", "copy_ok_tip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}