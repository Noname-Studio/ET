/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.NewTask
{
	public partial class View_NewTask : GComponent
	{
		public GButton bg;
		public GButton Help;
		public GButton Close;
		public GList List;
		public GGroup UI;

		public const string URL = "ui://f1lcfy6mh8zv6";

		public static View_NewTask CreateInstance()
		{
			return (View_NewTask)UIPackage.CreateObject("NewTask","NewTask");
		}

		public View_NewTask()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Help = (GButton)this.GetChildAt(5);
			Close = (GButton)this.GetChildAt(6);
			List = (GList)this.GetChildAt(7);
			UI = (GGroup)this.GetChildAt(9);
		}
	}
}