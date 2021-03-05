/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Star : GComponent
    {
        public Controller Active;
        public const string URL = "ui://ucagdrsir0cjt7";

        public static View_Star CreateInstance()
        {
            return (View_Star)UIPackage.CreateObject("Common", "Star");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Active = GetController("Active");
        }
    }
}