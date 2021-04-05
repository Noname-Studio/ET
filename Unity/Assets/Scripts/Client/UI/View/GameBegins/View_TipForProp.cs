/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameBegins
{
    public partial class View_TipForProp: GComponent
    {
        public GTextField content;
        public const string URL = "ui://ytyvezjfxgo5mx";

        public static View_TipForProp CreateInstance()
        {
            return (View_TipForProp) UIPackage.CreateObject("GameBegins", "TipForProp");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            content = (GTextField) GetChild("content");
        }
    }
}