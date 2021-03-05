/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_shengjijiantou : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsiriugpp";

        public static View_shengjijiantou CreateInstance()
        {
            return (View_shengjijiantou)UIPackage.CreateObject("Common", "shengjijiantou");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}