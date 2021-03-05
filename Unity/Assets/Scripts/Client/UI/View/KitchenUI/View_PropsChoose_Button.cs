/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_PropsChoose_Button : GButton
    {
        public Controller c1;
        public View_JiXuDaoJu view;
        public GTextField itemcontent;
        public GGroup FREE;
        public const string URL = "ui://y66af8ydun1rk8";

        public static View_PropsChoose_Button CreateInstance()
        {
            return (View_PropsChoose_Button)UIPackage.CreateObject("KitchenUI", "PropsChoose_Button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            view = (View_JiXuDaoJu)GetChild("view");
            itemcontent = (GTextField)GetChild("itemcontent");
            FREE = (GGroup)GetChild("FREE");
        }
    }
}