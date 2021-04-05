/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamingUI
{
    public partial class View_TipBar: GComponent
    {
        public GLoader foodIcon;
        public GImage new_icon;
        public GList List;
        public const string URL = "ui://dpc3yd4ttmfvs";

        public static View_TipBar CreateInstance()
        {
            return (View_TipBar) UIPackage.CreateObject("GamingUI", "TipBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            foodIcon = (GLoader) GetChild("foodIcon");
            new_icon = (GImage) GetChild("new_icon");
            List = (GList) GetChild("List");
        }
    }
}