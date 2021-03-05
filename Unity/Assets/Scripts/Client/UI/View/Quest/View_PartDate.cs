/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_PartDate : GComponent
	{
		public GList Progress;
		public GTextField Day;
		public GTextField RestName;

		public const string URL = "ui://ytnp4vk8kswco6";

		public static View_PartDate CreateInstance()
		{
			return (View_PartDate)UIPackage.CreateObject("Quest","PartDate");
		}

		public View_PartDate()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Progress = (GList)this.GetChildAt(2);
			Day = (GTextField)this.GetChildAt(3);
			RestName = (GTextField)this.GetChildAt(4);
		}
	}
}