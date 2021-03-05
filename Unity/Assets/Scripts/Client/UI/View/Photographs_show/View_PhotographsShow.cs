/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Photographs_show
{
	public partial class View_PhotographsShow : GComponent
	{
		public GButton bg;
		public GLabel PhotoFake;
		public GLabel Photo3;
		public GLabel Photo2;
		public GLabel Photo1;
		public GButton Turnoff;
		public Transition t0;
		public Transition Play1;
		public Transition Play2;
		public Transition Switch;
		public Transition t4;

		public const string URL = "ui://ye4cqbd210anj0";

		public static View_PhotographsShow CreateInstance()
		{
			return (View_PhotographsShow)UIPackage.CreateObject("Photographs_show","PhotographsShow");
		}

		public View_PhotographsShow()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			PhotoFake = (GLabel)this.GetChildAt(1);
			Photo3 = (GLabel)this.GetChildAt(2);
			Photo2 = (GLabel)this.GetChildAt(3);
			Photo1 = (GLabel)this.GetChildAt(4);
			Turnoff = (GButton)this.GetChildAt(5);
			t0 = this.GetTransitionAt(0);
			Play1 = this.GetTransitionAt(1);
			Play2 = this.GetTransitionAt(2);
			Switch = this.GetTransitionAt(3);
			t4 = this.GetTransitionAt(4);
		}
	}
}