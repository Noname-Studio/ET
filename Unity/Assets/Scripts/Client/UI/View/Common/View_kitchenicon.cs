/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_kitchenicon : GComponent
    {
        public Controller c1;
        public View_LabelLanSe label;
        public const string URL = "ui://ucagdrsiq9poo9";

        public static View_kitchenicon CreateInstance()
        {
            return (View_kitchenicon)UIPackage.CreateObject("Common", "kitchenicon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            label = (View_LabelLanSe)GetChild("label");
        }
    }
}