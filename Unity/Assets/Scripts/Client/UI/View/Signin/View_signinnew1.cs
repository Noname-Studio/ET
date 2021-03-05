/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Signin
{
	public partial class View_signinnew1 : GComponent
	{
		public GButton bg;
		public View_SigninComponent Day1;
		public View_SigninComponent Day2;
		public View_SigninComponent Day3;
		public View_SigninComponent Day4;
		public View_SigninComponent Day5;
		public View_SigninComponent Day6;
		public View_SigninComponent Day7;
		public GTextField Title;
		public GButton Close;
		public GButton Receive;

		public const string URL = "ui://9cwletjdfigra";

		public static View_signinnew1 CreateInstance()
		{
			return (View_signinnew1)UIPackage.CreateObject("Signin","signinnew1");
		}

		public View_signinnew1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Day1 = (View_SigninComponent)this.GetChildAt(8);
			Day2 = (View_SigninComponent)this.GetChildAt(9);
			Day3 = (View_SigninComponent)this.GetChildAt(10);
			Day4 = (View_SigninComponent)this.GetChildAt(11);
			Day5 = (View_SigninComponent)this.GetChildAt(12);
			Day6 = (View_SigninComponent)this.GetChildAt(13);
			Day7 = (View_SigninComponent)this.GetChildAt(14);
			Title = (GTextField)this.GetChildAt(19);
			Close = (GButton)this.GetChildAt(20);
			Receive = (GButton)this.GetChildAt(21);
		}
	}
}