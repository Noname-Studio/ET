/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_Tips : GComponent
	{
		public Controller ButtonState;
		public GButton bg;
		public GRichTextField Content;
		public GList ButtonList;
		public Transition t0;

		public const string URL = "ui://97pg0d8ft3u7j";

		public static View_Tips CreateInstance()
		{
			return (View_Tips)UIPackage.CreateObject("WithoutHot","Tips");
		}

		public View_Tips()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			ButtonState = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			Content = (GRichTextField)this.GetChildAt(3);
			ButtonList = (GList)this.GetChildAt(5);
			t0 = this.GetTransitionAt(0);
		}
	}
}