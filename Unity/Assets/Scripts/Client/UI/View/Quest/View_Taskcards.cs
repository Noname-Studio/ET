/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_Taskcards : GComponent
	{
		public View_Doit Accept;
		public GTextField Title;
		public GLoader Icon;
		public GComponent Finish;
		public GProgressBar Progress;
		public Transition Enter;
		public Transition Fade;
		public Transition Move;
		public Transition StateChange;
		public Transition ResetState;

		public const string URL = "ui://ytnp4vk8ifeglt";

		public static View_Taskcards CreateInstance()
		{
			return (View_Taskcards)UIPackage.CreateObject("Quest","Taskcards");
		}

		public View_Taskcards()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Accept = (View_Doit)this.GetChildAt(4);
			Title = (GTextField)this.GetChildAt(5);
			Icon = (GLoader)this.GetChildAt(6);
			Finish = (GComponent)this.GetChildAt(7);
			Progress = (GProgressBar)this.GetChildAt(8);
			Enter = this.GetTransitionAt(0);
			Fade = this.GetTransitionAt(1);
			Move = this.GetTransitionAt(2);
			StateChange = this.GetTransitionAt(3);
			ResetState = this.GetTransitionAt(4);
		}
	}
}