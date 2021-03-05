/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_pop_reward_mult : GComponent
    {
        public Controller c2;
        public GButton bg;
        public View_unlock_item item30;
        public View_unlock_item item31;
        public View_unlock_item item32;
        public GGroup group3;
        public View_unlock_item item20;
        public View_unlock_item item21;
        public GGroup group2;
        public View_unlock_item item10;
        public GGroup group1;
        public GTextField title;
        public GButton ok_btn;
        public const string URL = "ui://ucagdrsibet7tx";

        public static View_pop_reward_mult CreateInstance()
        {
            return (View_pop_reward_mult)UIPackage.CreateObject("Common", "pop_reward_mult");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c2 = GetController("c2");
            bg = (GButton)GetChild("bg");
            item30 = (View_unlock_item)GetChild("item30");
            item31 = (View_unlock_item)GetChild("item31");
            item32 = (View_unlock_item)GetChild("item32");
            group3 = (GGroup)GetChild("group3");
            item20 = (View_unlock_item)GetChild("item20");
            item21 = (View_unlock_item)GetChild("item21");
            group2 = (GGroup)GetChild("group2");
            item10 = (View_unlock_item)GetChild("item10");
            group1 = (GGroup)GetChild("group1");
            title = (GTextField)GetChild("title");
            ok_btn = (GButton)GetChild("ok_btn");
        }
    }
}