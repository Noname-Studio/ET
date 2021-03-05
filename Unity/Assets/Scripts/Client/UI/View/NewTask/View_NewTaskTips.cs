/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
	public partial class View_NewTaskTips : GComponent
	{
		public Controller c1;
		public GButton bg;
		public View_TaskCard Card;
		public GList List;
		public View_TaskTtem02 Quest;
		public GButton Close;

		public const string URL = "ui://f1lcfy6menfth";

		public static View_NewTaskTips CreateInstance()
		{
			return (View_NewTaskTips)UIPackage.CreateObject("NewTask","NewTaskTips");
		}

		public View_NewTaskTips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			Card = (View_TaskCard)this.GetChildAt(3);
			List = (GList)this.GetChildAt(4);
			Quest = (View_TaskTtem02)this.GetChildAt(5);
			Close = (GButton)this.GetChildAt(6);
		}
	}
}