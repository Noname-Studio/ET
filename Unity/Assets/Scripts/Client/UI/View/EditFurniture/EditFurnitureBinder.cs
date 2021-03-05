/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace UI.Story.EditFurniture
{
	public class EditFurnitureBinder
	{
		[UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void BindAll()
		{
			UIObjectFactory.SetPackageItemExtension(View_FurnitureSelect.URL, typeof(View_FurnitureSelect));
			UIObjectFactory.SetPackageItemExtension(View_EditFurniture.URL, typeof(View_EditFurniture));
			UIObjectFactory.SetPackageItemExtension(View_EditFurnitureProgress.URL, typeof(View_EditFurnitureProgress));
		}
	}
}