/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.EditFurniture
{
	public partial class View_EditFurnitureProgress : GComponent
	{
		public GImage Progress;

		public const string URL = "ui://yee5iu2pko1t81";

		public static View_EditFurnitureProgress CreateInstance()
		{
			return (View_EditFurnitureProgress)UIPackage.CreateObject("EditFurniture","EditFurnitureProgress");
		}

		public View_EditFurnitureProgress()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Progress = (GImage)this.GetChildAt(1);
		}
	}
}