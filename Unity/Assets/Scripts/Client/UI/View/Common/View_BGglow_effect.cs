/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_BGglow_effect : GComponent
    {
        public Transition t1;
        public const string URL = "ui://ucagdrsikh00tg";

        public static View_BGglow_effect CreateInstance()
        {
            return (View_BGglow_effect)UIPackage.CreateObject("Common", "BGglow_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t1 = GetTransition("t1");
        }
    }
}