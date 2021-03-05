/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Review
{
	public partial class View_ChooseOptions : GComponent
	{
		public GButton bg;
		public GLoader Head1;
		public GList List;
		public View_WenTiQiPao Bubble;
		public GButton ShowReview;

		public const string URL = "ui://ijwojn7zen8l2";

		public static View_ChooseOptions CreateInstance()
		{
			return (View_ChooseOptions)UIPackage.CreateObject("Review","ChooseOptions");
		}

		public View_ChooseOptions()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Head1 = (GLoader)this.GetChildAt(1);
			List = (GList)this.GetChildAt(3);
			Bubble = (View_WenTiQiPao)this.GetChildAt(4);
			ShowReview = (GButton)this.GetChildAt(5);
		}
	}
}