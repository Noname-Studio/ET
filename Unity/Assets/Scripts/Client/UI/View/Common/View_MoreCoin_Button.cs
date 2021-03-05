/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_MoreCoin_Button : GButton
    {
        public Transition t0;
        public const string URL = "ui://ucagdrsiuaj8po";

        public static View_MoreCoin_Button CreateInstance()
        {
            return (View_MoreCoin_Button)UIPackage.CreateObject("Common", "MoreCoin_Button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            t0 = GetTransition("t0");
        }
    }
}