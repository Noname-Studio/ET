/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_NormalReward : GComponent
    {
        public GButton bg;
        public View_yellow_light_circle YellowLight;
        public GLoader Title;
        public View_flicker_act Flicker;
        public GList List;
        public GGroup after;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://ucagdrsinz1fvys";

        public static View_NormalReward CreateInstance()
        {
            return (View_NormalReward)UIPackage.CreateObject("Common", "NormalReward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            YellowLight = (View_yellow_light_circle)GetChild("YellowLight");
            Title = (GLoader)GetChild("Title");
            Flicker = (View_flicker_act)GetChild("Flicker");
            List = (GList)GetChild("List");
            after = (GGroup)GetChild("after");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}