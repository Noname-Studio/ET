/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Settings
{
    public partial class View_setting: GComponent
    {
        public GButton bg;
        public GButton Close;
        public View_TouXiangZuJian HeadPanel;
        public GButton WebSite;
        public GButton Voice;
        public GButton Service;
        public GButton Music;
        public GButton Pet;
        public GButton FAQ;
        public View_synchrodata_button syncBtn;
        public GButton CopyAccount;
        public View_copy_ok_tip copy_ok_tip;
        public const string URL = "ui://yzgsvb7we00cj5";

        public static View_setting CreateInstance()
        {
            return (View_setting) UIPackage.CreateObject("Settings", "setting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChild("bg");
            Close = (GButton) GetChild("Close");
            HeadPanel = (View_TouXiangZuJian) GetChild("HeadPanel");
            WebSite = (GButton) GetChild("WebSite");
            Voice = (GButton) GetChild("Voice");
            Service = (GButton) GetChild("Service");
            Music = (GButton) GetChild("Music");
            Pet = (GButton) GetChild("Pet");
            FAQ = (GButton) GetChild("FAQ");
            syncBtn = (View_synchrodata_button) GetChild("syncBtn");
            CopyAccount = (GButton) GetChild("CopyAccount");
            copy_ok_tip = (View_copy_ok_tip) GetChild("copy_ok_tip");
        }
    }
}