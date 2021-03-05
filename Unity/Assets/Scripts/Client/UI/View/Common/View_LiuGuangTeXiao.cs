/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_LiuGuangTeXiao : GLabel
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsiglxdi7";

        public static View_LiuGuangTeXiao CreateInstance()
        {
            return (View_LiuGuangTeXiao)UIPackage.CreateObject("Common", "流光特效");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}