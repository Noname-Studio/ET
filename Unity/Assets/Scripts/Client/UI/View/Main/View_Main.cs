/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_Main : GComponent
	{
		public Controller State;
		public GList LeftList;
		public View_RenWuAnNiu Menu;
		public View_Button1 More;
		public View_Button_icon Club;
		public GGroup LeftBttom;
		public GList packlist;
		public GButton Settings;
		public GGroup Right;
		public View_RestaurantJump_button Jump;
		public View_KaiShiGuanKa Play;
		public View_Button_icon Shop;
		public View_Button_icon Equipment;
		public GGroup RightBottom;
		public Transition In;
		public Transition Out;

		public const string URL = "ui://fmkyh2ywvqob1";

		public static View_Main CreateInstance()
		{
			return (View_Main)UIPackage.CreateObject("Main","Main");
		}

		public View_Main()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			State = this.GetControllerAt(0);
			LeftList = (GList)this.GetChildAt(0);
			Menu = (View_RenWuAnNiu)this.GetChildAt(1);
			More = (View_Button1)this.GetChildAt(2);
			Club = (View_Button_icon)this.GetChildAt(3);
			LeftBttom = (GGroup)this.GetChildAt(4);
			packlist = (GList)this.GetChildAt(5);
			Settings = (GButton)this.GetChildAt(6);
			Right = (GGroup)this.GetChildAt(7);
			Jump = (View_RestaurantJump_button)this.GetChildAt(8);
			Play = (View_KaiShiGuanKa)this.GetChildAt(9);
			Shop = (View_Button_icon)this.GetChildAt(10);
			Equipment = (View_Button_icon)this.GetChildAt(11);
			RightBottom = (GGroup)this.GetChildAt(12);
			In = this.GetTransitionAt(0);
			Out = this.GetTransitionAt(1);
		}
	}
}