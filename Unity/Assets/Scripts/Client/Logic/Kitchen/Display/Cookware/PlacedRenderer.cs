using Client.UI.ViewModel;
using FairyGUI;
using UnityEngine;

namespace Kitchen
{
    public class PlacedRenderer
    {
        private PlacedIngredients Ingredients { get; }
        private Vector3 Pos { get; }
        private UI_StorageFood Ui { get; set; }

        public PlacedRenderer(PlacedIngredients ingredients, Vector3 pos)
        {
            Ingredients = ingredients;
            Pos = pos;
            CreateUI();
            Ingredients.OnChanged += IngredientsOnChanged;
        }

        private void IngredientsOnChanged()
        {
            var list = Ingredients.List;
            if (list.Count == 0)
            {
                Ui.Visible = false;
                return;
            }

            Ui.Visible = true;
            Ui.View.c1.selectedPage = list.Count.ToString();
            for (int i = 0; i < list.Count; i++)
            {
                var node = list[i];
                var loader = Ui.View.GetChild("Food" + (i + 1)).asLoader;
                FoodProperty ingredient = null;
                ingredient = KitchenDataHelper.LoadFood(node);
                if (ingredient != null)
                {
                    loader.url = ingredient.CurrentLevel.Texture;
                }
            }
        }

        private void CreateUI()
        {
            Ui = UIKit.Inst.Create<UI_StorageFood>();
            Ui.Visible = false;
            Vector3 screenPos = KitchenRoot.Inst.MainCamera.WorldToScreenPoint(Pos);
            screenPos.y = Screen.height - screenPos.y;
            var pt = GRoot.inst.GlobalToLocal(screenPos);
            Ui.View.position = pt;
        }

        public void Dispose()
        {
            Ingredients.OnChanged -= IngredientsOnChanged;
        }
    }
}