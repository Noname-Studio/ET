/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_unlock_item : GComponent
    {
        public Controller c1;
        public View_yellow_light_circle icon_light;
        public GLoader icon;
        public GTextField counttxt;
        public GGroup prop01;
        public GLoader unlock;
        public GTextField title;
        public GTextField name;
        public Transition t0;
        public const string URL = "ui://ucagdrsih2ikvu9";

        public static View_unlock_item CreateInstance()
        {
            return (View_unlock_item)UIPackage.CreateObject("Common", "unlock_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            icon_light = (View_yellow_light_circle)GetChild("icon_light");
            icon = (GLoader)GetChild("icon");
            counttxt = (GTextField)GetChild("counttxt");
            prop01 = (GGroup)GetChild("prop01");
            unlock = (GLoader)GetChild("unlock");
            title = (GTextField)GetChild("title");
            name = (GTextField)GetChild("name");
            t0 = GetTransition("t0");
        }
    }
}