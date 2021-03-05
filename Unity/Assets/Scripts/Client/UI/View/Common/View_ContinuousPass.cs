/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_ContinuousPass : GComponent
    {
        public GList list;
        public const string URL = "ui://ucagdrsigqtovwm";

        public static View_ContinuousPass CreateInstance()
        {
            return (View_ContinuousPass)UIPackage.CreateObject("Common", "ContinuousPass");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            list = (GList)GetChild("list");
        }
    }
}