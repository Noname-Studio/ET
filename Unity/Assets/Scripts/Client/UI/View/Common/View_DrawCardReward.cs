/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_DrawCardReward : GComponent
    {
        public GLoader icon;
        public GButton play;
        public const string URL = "ui://ucagdrsio835w3z";

        public static View_DrawCardReward CreateInstance()
        {
            return (View_DrawCardReward)UIPackage.CreateObject("Common", "DrawCardReward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            icon = (GLoader)GetChild("icon");
            play = (GButton)GetChild("play");
        }
    }
}