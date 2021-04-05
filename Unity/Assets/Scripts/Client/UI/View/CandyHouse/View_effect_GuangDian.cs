/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CandyHouse
{
    public partial class View_effect_GuangDian: GComponent
    {
        public Transition t0;

        public const string URL = "ui://3b4mf257mk18n";

        public static View_effect_GuangDian CreateInstance()
        {
            return (View_effect_GuangDian) UIPackage.CreateObject("CandyHouse", "effect_光点");
        }

        public View_effect_GuangDian()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransitionAt(0);
        }
    }
}