/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_date : GComponent
	{
		public Controller c1;
		public GImage Progress;
		public Transition t0;

		public const string URL = "ui://ytnp4vk8kswco2";

		public static View_date CreateInstance()
		{
			return (View_date)UIPackage.CreateObject("Quest","date");
		}

		public View_date()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			Progress = (GImage)this.GetChildAt(1);
			t0 = this.GetTransitionAt(0);
		}
	}
}