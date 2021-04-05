/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Settings
{
    public partial class View_TouXiangZuJian: GComponent
    {
        public Controller c1;
        public GTextField Name;
        public GButton EditName;
        public GButton EditHead;
        public const string URL = "ui://yzgsvb7wujv4mo";

        public static View_TouXiangZuJian CreateInstance()
        {
            return (View_TouXiangZuJian) UIPackage.CreateObject("Settings", "头像组件");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            Name = (GTextField) GetChild("Name");
            EditName = (GButton) GetChild("EditName");
            EditHead = (GButton) GetChild("EditHead");
        }
    }
}