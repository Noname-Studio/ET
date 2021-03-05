/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_NewUpdate : GComponent
	{
		public GButton bg;
		public GLabel Content;
		public GButton UpdateButton;
		public GButton CancelButton;

		public const string URL = "ui://97pg0d8ft3u76";

		public static View_NewUpdate CreateInstance()
		{
			return (View_NewUpdate)UIPackage.CreateObject("WithoutHot","NewUpdate");
		}

		public View_NewUpdate()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Content = (GLabel)this.GetChildAt(2);
			UpdateButton = (GButton)this.GetChildAt(3);
			CancelButton = (GButton)this.GetChildAt(4);
		}
	}
}