using System.Collections.Generic;
using Kitchen;

namespace Kitchen.Action
{
    public class PutIngredientAndGetFood: IGameAction
    {
        private PlayerController Controller { get; }
        private ICookware Cookware { get; }

        public PutIngredientAndGetFood(PlayerController controller, ICookware cookware)
        {
            Controller = controller;
            Cookware = cookware;
        }

        public void Execute()
        {
            List<string> list = new List<string>();
            Controller.HandProvider.Get(ref list);
            list = Cookware.PutIn(list);
            //发现不需要放入任何东西了.我们直接开始厨具工作就好了
            if (list == null)
            {
                Cookware.DoWork();
                TakeFoodFromCW();
            }
            else
            {
                //发现手上的东西需要放到厨具上.我们放进去
                Controller.HandProvider.Take(list);
                TakeFoodFromCW();
                //检查是否可以工作.然后开始工作
                Cookware.DoWork();
            }
        }

        private void TakeFoodFromCW()
        {
            if (!string.IsNullOrEmpty(Cookware.FoodId))
            {
                bool holdSuccess = Controller.HandProvider.Hold(Cookware.FoodId);
                if (holdSuccess)
                {
                    //成功抓取.拿走食物.如果手上没有空间则不允许玩家拿走食物
                    Cookware.TakeFood();
                }
            }
        }

        bool IGameAction.Update()
        {
            return true;
        }
    }
}