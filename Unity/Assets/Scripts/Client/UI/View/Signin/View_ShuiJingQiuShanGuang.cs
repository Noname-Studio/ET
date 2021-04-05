/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Signin
{
    public partial class View_ShuiJingQiuShanGuang: GComponent
    {
        public Transition t0;

        public const string URL = "ui://9cwletjdwz6tq";

        public static View_ShuiJingQiuShanGuang CreateInstance()
        {
            return (View_ShuiJingQiuShanGuang) UIPackage.CreateObject("Signin", "水晶球闪光");
        }

        public View_ShuiJingQiuShanGuang()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransitionAt(0);
        }
    }
}