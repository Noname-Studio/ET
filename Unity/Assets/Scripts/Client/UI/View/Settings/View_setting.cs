/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Settings
{
	public partial class View_setting : GComponent
	{
		public GButton bg;
		public GButton Close;
		public View_TouXiangZuJian HeadPanel;
		public GButton WebSite;
		public GButton Voice;
		public GButton Service;
		public GButton Music;
		public GButton Pet;
		public GButton reset;
		public View_Button111 LinkFB;
		public GButton openweb;
		public View_synchrodata_button syncBtn;
		public GButton CopyAccount;
		public View_copy_ok_tip copy_ok_tip;

		public const string URL = "ui://yzgsvb7we00cj5";

		public static View_setting CreateInstance()
		{
			return (View_setting)UIPackage.CreateObject("Settings","setting");
		}

		public View_setting()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Close = (GButton)this.GetChildAt(3);
			HeadPanel = (View_TouXiangZuJian)this.GetChildAt(4);
			WebSite = (GButton)this.GetChildAt(5);
			Voice = (GButton)this.GetChildAt(6);
			Service = (GButton)this.GetChildAt(7);
			Music = (GButton)this.GetChildAt(8);
			Pet = (GButton)this.GetChildAt(9);
			reset = (GButton)this.GetChildAt(10);
			LinkFB = (View_Button111)this.GetChildAt(11);
			openweb = (GButton)this.GetChildAt(12);
			syncBtn = (View_synchrodata_button)this.GetChildAt(13);
			CopyAccount = (GButton)this.GetChildAt(14);
			copy_ok_tip = (View_copy_ok_tip)this.GetChildAt(16);
		}
	}
}