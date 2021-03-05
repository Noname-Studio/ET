/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenStop
{
    public partial class View_ChoiceProps : GButton
    {
        public Controller lockcontrol;
        public GButton choice;
        public GComponent recommend;
        public const string URL = "ui://ydojo8b9syr9gh";

        public static View_ChoiceProps CreateInstance()
        {
            return (View_ChoiceProps)UIPackage.CreateObject("KitchenStop", "ChoiceProps");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            lockcontrol = GetController("lockcontrol");
            choice = (GButton)GetChild("choice");
            recommend = (GComponent)GetChild("recommend");
        }
    }
}