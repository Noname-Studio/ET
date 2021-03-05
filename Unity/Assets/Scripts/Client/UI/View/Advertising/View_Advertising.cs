/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Advertising
{
	public partial class View_Advertising : GComponent
	{
		public Controller c1;
		public Controller Language;
		public GButton bg;
		public GComponent YellowLight;
		public GLabel GiftItem;
		public GButton Get;
		public GComponent Flicker;
		public GGroup after;
		public View_Play_button Play;
		public GLoader Icon;
		public GTextField Number;
		public GGroup before;
		public GComponent Light_1;
		public GComponent Light_2;
		public GComponent Light_3;
		public GComponent Light_4;
		public GComponent Light_5;
		public GButton Close;
		public GButton gotest;
		public GButton next;
		public GButton Close0;
		public GTextField port;

		public const string URL = "ui://lpoqxdrph5c8e";

		public static View_Advertising CreateInstance()
		{
			return (View_Advertising)UIPackage.CreateObject("Advertising","Advertising");
		}

		public View_Advertising()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			Language = this.GetControllerAt(1);
			bg = (GButton)this.GetChildAt(0);
			YellowLight = (GComponent)this.GetChildAt(3);
			GiftItem = (GLabel)this.GetChildAt(6);
			Get = (GButton)this.GetChildAt(7);
			Flicker = (GComponent)this.GetChildAt(8);
			after = (GGroup)this.GetChildAt(9);
			Play = (View_Play_button)this.GetChildAt(11);
			Icon = (GLoader)this.GetChildAt(13);
			Number = (GTextField)this.GetChildAt(14);
			before = (GGroup)this.GetChildAt(15);
			Light_1 = (GComponent)this.GetChildAt(17);
			Light_2 = (GComponent)this.GetChildAt(18);
			Light_3 = (GComponent)this.GetChildAt(19);
			Light_4 = (GComponent)this.GetChildAt(20);
			Light_5 = (GComponent)this.GetChildAt(21);
			Close = (GButton)this.GetChildAt(22);
			gotest = (GButton)this.GetChildAt(24);
			next = (GButton)this.GetChildAt(25);
			Close0 = (GButton)this.GetChildAt(28);
			port = (GTextField)this.GetChildAt(30);
		}
	}
}