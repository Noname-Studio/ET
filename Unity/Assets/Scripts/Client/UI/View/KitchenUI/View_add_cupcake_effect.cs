/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_add_cupcake_effect : GComponent
    {
        public GLoader cupcake_icon;
        public GLoader cupcake1_icon;
        public GLoader cupcake2_icon;
        public GTextField num;
        public Transition t0;
        public const string URL = "ui://y66af8ydj0j1vzr";

        public static View_add_cupcake_effect CreateInstance()
        {
            return (View_add_cupcake_effect)UIPackage.CreateObject("KitchenUI", "add_cupcake_effect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            cupcake_icon = (GLoader)GetChild("cupcake_icon");
            cupcake1_icon = (GLoader)GetChild("cupcake1_icon");
            cupcake2_icon = (GLoader)GetChild("cupcake2_icon");
            num = (GTextField)GetChild("num");
            t0 = GetTransition("t0");
        }
    }
}