/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_Bar : GComponent
	{
		public GImage bar;

		public const string URL = "ui://ytnp4vk8atg3l4";

		public static View_Bar CreateInstance()
		{
			return (View_Bar)UIPackage.CreateObject("Quest","Bar");
		}

		public View_Bar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bar = (GImage)this.GetChildAt(0);
		}
	}
}