/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_JiXuDaoJu : GComponent
    {
        public Controller c1;
        public Controller c2;
        public GComponent light;
        public GLoader icon;
        public GTextField num;
        public GLoader gemIcon;
        public GTextField gemnum;
        public const string URL = "ui://y66af8ydun1rk7";

        public static View_JiXuDaoJu CreateInstance()
        {
            return (View_JiXuDaoJu)UIPackage.CreateObject("KitchenUI", "继续道具");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            c2 = GetController("c2");
            light = (GComponent)GetChild("light");
            icon = (GLoader)GetChild("icon");
            num = (GTextField)GetChild("num");
            gemIcon = (GLoader)GetChild("gemIcon");
            gemnum = (GTextField)GetChild("gemnum");
        }
    }
}