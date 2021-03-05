/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.EditFurniture
{
	public partial class View_EditFurniture : GComponent
	{
		public Controller Select;
		public GList List;
		public GButton Cancel;
		public GButton Finish;

		public const string URL = "ui://yee5iu2pj73a5n";

		public static View_EditFurniture CreateInstance()
		{
			return (View_EditFurniture)UIPackage.CreateObject("EditFurniture","EditFurniture");
		}

		public View_EditFurniture()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Select = this.GetControllerAt(0);
			List = (GList)this.GetChildAt(0);
			Cancel = (GButton)this.GetChildAt(1);
			Finish = (GButton)this.GetChildAt(2);
		}
	}
}