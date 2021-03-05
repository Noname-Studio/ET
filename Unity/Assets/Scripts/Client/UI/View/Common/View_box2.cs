/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_box2 : GButton
    {
        public View_yellow_light_circle Light;
        public GButton Button;
        public GTextField Desc;
        public Transition loop;
        public Transition click;
        public Transition opened;
        public Transition fade;
        public const string URL = "ui://ucagdrsipvuyto";

        public static View_box2 CreateInstance()
        {
            return (View_box2)UIPackage.CreateObject("Common", "box2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Light = (View_yellow_light_circle)GetChild("Light");
            Button = (GButton)GetChild("Button");
            Desc = (GTextField)GetChild("Desc");
            loop = GetTransition("loop");
            click = GetTransition("click");
            opened = GetTransition("opened");
            fade = GetTransition("fade");
        }
    }
}