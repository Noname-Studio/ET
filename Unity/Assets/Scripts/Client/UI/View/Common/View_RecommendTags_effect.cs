/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_RecommendTags_effect : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsiyahmph";

        public static View_RecommendTags_effect CreateInstance()
        {
            return (View_RecommendTags_effect)UIPackage.CreateObject("Common", "RecommendTags_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}