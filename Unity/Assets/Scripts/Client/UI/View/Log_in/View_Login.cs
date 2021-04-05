/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Log_in
{
    public partial class View_Login: GComponent
    {
        public Controller HasLogin;
        public Controller IsFirstLogin;
        public GButton ButtonUp;
        public View_logo_effect logo;
        public GButton FacebookButton;
        public View_x30_effect RewardGem;
        public GGroup FacebookGroup;
        public GRichTextField Relief;
        public GButton Accept;
        public Transition t0;
        public const string URL = "ui://jevtvvkez5hf2";

        public static View_Login CreateInstance()
        {
            return (View_Login) UIPackage.CreateObject("Log_in", "Login");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            HasLogin = GetController("HasLogin");
            IsFirstLogin = GetController("IsFirstLogin");
            ButtonUp = (GButton) GetChild("ButtonUp");
            logo = (View_logo_effect) GetChild("logo");
            FacebookButton = (GButton) GetChild("FacebookButton");
            RewardGem = (View_x30_effect) GetChild("RewardGem");
            FacebookGroup = (GGroup) GetChild("FacebookGroup");
            Relief = (GRichTextField) GetChild("Relief");
            Accept = (GButton) GetChild("Accept");
            t0 = GetTransition("t0");
        }
    }
}