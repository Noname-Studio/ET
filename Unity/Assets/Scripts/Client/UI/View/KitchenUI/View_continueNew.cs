/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace KitchenUI
{
    public partial class View_continueNew : GComponent
    {
        public Controller c1;
        public GButton bg;
        public GButton Close;
        public GButton btnOk;
        public GTextField total;
        public GTextField target;
        public GLoader targetIcon;
        public GGroup target0;
        public View_PropsChoose_Button item0;
        public View_PropsChoose_Button item1;
        public GTextField content;
        public GTextField Title0;
        public GTextField Title;
        public GLoader titleIcon;
        public GComponent activePanel;
        public View_failureTips failTip;
        public const string URL = "ui://y66af8ydun1rk2";

        public static View_continueNew CreateInstance()
        {
            return (View_continueNew)UIPackage.CreateObject("KitchenUI", "continueNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetController("c1");
            bg = (GButton)GetChild("bg");
            Close = (GButton)GetChild("Close");
            btnOk = (GButton)GetChild("btnOk");
            total = (GTextField)GetChild("total");
            target = (GTextField)GetChild("target");
            targetIcon = (GLoader)GetChild("targetIcon");
            target0 = (GGroup)GetChild("target0");
            item0 = (View_PropsChoose_Button)GetChild("item0");
            item1 = (View_PropsChoose_Button)GetChild("item1");
            content = (GTextField)GetChild("content");
            Title0 = (GTextField)GetChild("Title0");
            Title = (GTextField)GetChild("Title");
            titleIcon = (GLoader)GetChild("titleIcon");
            activePanel = (GComponent)GetChild("activePanel");
            failTip = (View_failureTips)GetChild("failTip");
        }
    }
}