/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.WithoutHot
{
	public partial class View_InTheLink : GComponent
	{
		public GGraph Holder;

		public const string URL = "ui://97pg0d8futdc33";

		public static View_InTheLink CreateInstance()
		{
			return (View_InTheLink)UIPackage.CreateObject("WithoutHot","InTheLink");
		}

		public View_InTheLink()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Holder = (GGraph)this.GetChildAt(1);
		}
	}
}