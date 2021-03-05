/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Main
{
	public partial class View_NewPack : GComponent
	{
		public GButton bg;
		public GTextField titlename;
		public GTextField gemnum;
		public GTextField intimer;
		public GButton buy;
		public GButton Close;
		public GTextField RecommondText;
		public GGroup UI;
		public Transition t0;

		public const string URL = "ui://fmkyh2ywobqw8nb";

		public static View_NewPack CreateInstance()
		{
			return (View_NewPack)UIPackage.CreateObject("Main","NewPack");
		}

		public View_NewPack()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			titlename = (GTextField)this.GetChildAt(11);
			gemnum = (GTextField)this.GetChildAt(13);
			intimer = (GTextField)this.GetChildAt(14);
			buy = (GButton)this.GetChildAt(15);
			Close = (GButton)this.GetChildAt(16);
			RecommondText = (GTextField)this.GetChildAt(18);
			UI = (GGroup)this.GetChildAt(19);
			t0 = this.GetTransitionAt(0);
		}
	}
}