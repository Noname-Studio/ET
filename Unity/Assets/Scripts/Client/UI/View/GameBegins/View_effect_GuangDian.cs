/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_effect_GuangDian : GComponent
    {
        public Transition t0;
        public const string URL = "ui://ytyvezjfgveo8qk";

        public static View_effect_GuangDian CreateInstance()
        {
            return (View_effect_GuangDian)UIPackage.CreateObject("GameBegins", "effect_光点");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}