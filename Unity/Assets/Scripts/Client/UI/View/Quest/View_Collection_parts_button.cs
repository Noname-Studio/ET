/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_Collection_parts_button : GButton
	{
		public Controller IsLock;

		public const string URL = "ui://ytnp4vk8b0bmno";

		public static View_Collection_parts_button CreateInstance()
		{
			return (View_Collection_parts_button)UIPackage.CreateObject("Quest","Collection_parts_button");
		}

		public View_Collection_parts_button()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			IsLock = this.GetControllerAt(1);
		}
	}
}