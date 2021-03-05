/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
	public partial class View_TaskTtem : GComponent
	{
		public Controller c1;
		public GProgressBar Progress;
		public GRichTextField Title;
		public GLoader RewardIcon;
		public GTextField RewardNum;
		public GButton Receive;
		public GButton GoLevel;
		public GTextField UnlockDesc;

		public const string URL = "ui://f1lcfy6menftl";

		public static View_TaskTtem CreateInstance()
		{
			return (View_TaskTtem)UIPackage.CreateObject("NewTask","TaskTtem");
		}

		public View_TaskTtem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			Progress = (GProgressBar)this.GetChildAt(1);
			Title = (GRichTextField)this.GetChildAt(2);
			RewardIcon = (GLoader)this.GetChildAt(3);
			RewardNum = (GTextField)this.GetChildAt(4);
			Receive = (GButton)this.GetChildAt(6);
			GoLevel = (GButton)this.GetChildAt(7);
			UnlockDesc = (GTextField)this.GetChildAt(9);
		}
	}
}