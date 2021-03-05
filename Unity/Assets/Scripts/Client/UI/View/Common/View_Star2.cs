/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Star2 : GComponent
    {
        public Controller Active;
        public const string URL = "ui://ucagdrsiq2tinl";

        public static View_Star2 CreateInstance()
        {
            return (View_Star2)UIPackage.CreateObject("Common", "Star2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Active = GetController("Active");
        }
    }
}