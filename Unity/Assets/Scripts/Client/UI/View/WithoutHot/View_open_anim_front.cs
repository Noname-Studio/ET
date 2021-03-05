/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_open_anim_front : GComponent
	{
		public GGraph BgHolder;
		public GGraph LeftButtfly;
		public GGraph RightButtfly;
		public GGraph ButtflyParticle;
		public View_LoadingProgress Loading;
		public GTextField Title;
		public Transition t2;
		public Transition t3;
		public Transition t4;

		public const string URL = "ui://97pg0d8fp5kx0";

		public static View_open_anim_front CreateInstance()
		{
			return (View_open_anim_front)UIPackage.CreateObject("WithoutHot","open_anim_front");
		}

		public View_open_anim_front()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			BgHolder = (GGraph)this.GetChildAt(0);
			LeftButtfly = (GGraph)this.GetChildAt(13);
			RightButtfly = (GGraph)this.GetChildAt(14);
			ButtflyParticle = (GGraph)this.GetChildAt(15);
			Loading = (View_LoadingProgress)this.GetChildAt(16);
			Title = (GTextField)this.GetChildAt(17);
			t2 = this.GetTransitionAt(0);
			t3 = this.GetTransitionAt(1);
			t4 = this.GetTransitionAt(2);
		}
	}
}