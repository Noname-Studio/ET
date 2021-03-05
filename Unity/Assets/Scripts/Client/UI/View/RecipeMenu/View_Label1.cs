/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.RecipeMenu
{
	public partial class View_Label1 : GLabel
	{
		public GLoader plate;

		public const string URL = "ui://rrligmrxq9pot";

		public static View_Label1 CreateInstance()
		{
			return (View_Label1)UIPackage.CreateObject("RecipeMenu","Label1");
		}

		public View_Label1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			plate = (GLoader)this.GetChildAt(2);
		}
	}
}