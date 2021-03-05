/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_failurePrompted_tip : GComponent
    {
        public GLoader icon;
        public GTextField content;
        public Transition act_in;
        public Transition act_out;
        public Transition beifen;
        public const string URL = "ui://y66af8ydop5vfa";

        public static View_failurePrompted_tip CreateInstance()
        {
            return (View_failurePrompted_tip)UIPackage.CreateObject("KitchenUI", "failurePrompted_tip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon = (GLoader)GetChild("icon");
            content = (GTextField)GetChild("content");
            act_in = GetTransition("act_in");
            act_out = GetTransition("act_out");
            beifen = GetTransition("beifen");
        }
    }
}