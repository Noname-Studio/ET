/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.RecipeMenu
{
	public partial class View_dishes : GComponent
	{
		public View_Label1 labelframe;

		public const string URL = "ui://rrligmrxq9pos";

		public static View_dishes CreateInstance()
		{
			return (View_dishes)UIPackage.CreateObject("RecipeMenu","dishes");
		}

		public View_dishes()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			labelframe = (View_Label1)this.GetChildAt(2);
		}
	}
}