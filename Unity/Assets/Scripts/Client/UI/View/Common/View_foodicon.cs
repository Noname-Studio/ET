/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_foodicon : GComponent
    {
        public Controller c1;
        public const string URL = "ui://ucagdrsil8xbvw5";

        public static View_foodicon CreateInstance()
        {
            return (View_foodicon)UIPackage.CreateObject("Common", "foodicon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
        }
    }
}