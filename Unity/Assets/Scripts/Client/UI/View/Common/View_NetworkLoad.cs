/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_NetworkLoad : GComponent
    {
        public View_loading_effect Circle;
        public const string URL = "ui://ucagdrsioiyqj5";

        public static View_NetworkLoad CreateInstance()
        {
            return (View_NetworkLoad)UIPackage.CreateObject("Common", "NetworkLoad");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Circle = (View_loading_effect)GetChild("Circle");
        }
    }
}