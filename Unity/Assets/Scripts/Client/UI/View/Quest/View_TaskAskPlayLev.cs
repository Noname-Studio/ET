/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_TaskAskPlayLev : GComponent
	{
		public Controller c1;
		public GButton bg;
		public GButton Close;
		public GButton play;
		public GTextField title;
		public GButton get;

		public const string URL = "ui://ytnp4vk8nndgmo";

		public static View_TaskAskPlayLev CreateInstance()
		{
			return (View_TaskAskPlayLev)UIPackage.CreateObject("Quest","TaskAskPlayLev");
		}

		public View_TaskAskPlayLev()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			Close = (GButton)this.GetChildAt(8);
			play = (GButton)this.GetChildAt(10);
			title = (GTextField)this.GetChildAt(15);
			get = (GButton)this.GetChildAt(16);
		}
	}
}