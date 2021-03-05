/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_TiaoZhanicon : GButton
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsiotqrvzm";

        public static View_TiaoZhanicon CreateInstance()
        {
            return (View_TiaoZhanicon)UIPackage.CreateObject("Common", "挑战icon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}