using System.Collections.ObjectModel;
using GamingUI;
using RestaurantPreview.Config;

namespace Client.UI.ViewModel
{
    [UIWidget(Pool = true, Repeat = true)]
    public class UI_Order: UIBase<View_Order>
    {
        public UI_Order()
        {
        }

        public UI_Order(View_Order order): base(order)
        {
        }

        /// <summary>
        /// 刷新订单面板
        /// </summary>
        /// <param name="properties"></param>
        public void RefreshUI(ObservableCollection<string> properties)
        {
            if (properties == null)
            {
                Visible = false;
                return;
            }

            int count = properties.Count;
            if (count == 0)
            {
                Visible = false;
                return;
            }

            Visible = true;
            View.Number.selectedIndex = count - 1;
            InitFood(properties);
        }

        /// <summary>
        /// 初始化订单面板食物
        /// </summary>
        /// <param name="properties"></param>
        private void InitFood(ObservableCollection<string> properties)
        {
            for (int i = 0; i < properties.Count; i++)
            {
                var display = View.GetChild("Food" + (i + 1)) as View_FoodDisplay;
                if (display == null)
                {
                    Log.Error("找不到 Food" + (i + 1) + "这个Child");
                    continue;
                }
                var food = FoodProperty.Read(properties[i]);
                if (food == null)
                {
                    Log.Error("找不到这个食物ID" + properties[i]);
                    continue;
                }
                display.icon = food.CurrentLevel.Texture;
            }
        }
    }
}