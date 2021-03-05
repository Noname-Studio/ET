/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_CollectionButton : GButton
	{
		public Controller c1;
		public GLoader iconshadow;
		public GImage Magnifier;

		public const string URL = "ui://ytnp4vk8vhqdn5";

		public static View_CollectionButton CreateInstance()
		{
			return (View_CollectionButton)UIPackage.CreateObject("Quest","CollectionButton");
		}

		public View_CollectionButton()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			iconshadow = (GLoader)this.GetChildAt(1);
			Magnifier = (GImage)this.GetChildAt(5);
		}
	}
}