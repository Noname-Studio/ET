using System.Collections.ObjectModel;
using GamingUI;

namespace Client.UI.ViewModel
{
    [UIWidget(Pool = true,Repeat = true)]
    public class UI_Order : UIBase<View_Order>
    {
        /// <summary>
        /// 刷新订单面板
        /// </summary>
        /// <param name="properties"></param>
        public void RefreshUI(ObservableCollection<FoodProperty> properties)
        {
            if (properties == null)
            {
                CloseMySelf();
                return;
            }
            int count = properties.Count;
            if (count == 0)
            {
                CloseMySelf();
                return;
            }
            View.Number.selectedIndex = count - 1;
            InitFood(properties);
        }

        /// <summary>
        /// 初始化订单面板食物
        /// </summary>
        /// <param name="properties"></param>
        private void InitFood(ObservableCollection<FoodProperty> properties)
        {
            for (int i = 0; i < properties.Count; i++)
            {
                var display = View.GetChild("Food" + (i + 1)) as View_FoodDisplay;
                if (display == null)
                {
                    Log.Error("找不到 Food" + (i + 1) + "这个Child");
                    continue;
                }
                display.icon = properties[i].Texture;
            }
        }
    }
}
