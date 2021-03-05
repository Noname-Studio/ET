/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_tipsprop : GComponent
    {
        public GButton bg;
        public GList PropList;
        public GButton Confirm;
        public GTextField Title;
        public Transition t0;
        public Transition t1;
        public Transition t2;
        public const string URL = "ui://ucagdrsie2sqvwh";

        public static View_tipsprop CreateInstance()
        {
            return (View_tipsprop)UIPackage.CreateObject("Common", "tipsprop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            PropList = (GList)GetChild("PropList");
            Confirm = (GButton)GetChild("Confirm");
            Title = (GTextField)GetChild("Title");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
            t2 = GetTransition("t2");
        }
    }
}