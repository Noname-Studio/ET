namespace Kitchen
{
    public class TakeFood : IGameAction
    {
        private PlayerController mController;
        private NormalCookware mNormalCookware;
        private IngredientDisplay mIngredient;
        public TakeFood(PlayerController controller,NormalCookware normalCookware)
        {
            mController = controller;
            mNormalCookware = normalCookware;
        }
        public TakeFood(PlayerController controller,IngredientDisplay ingredient)
        {
            mController = controller;
            mIngredient = ingredient;
        }
        public void Execute()
        {
            if (mNormalCookware != null)
            {
                bool holdSuccess = mController.HandProvider.Hold(mNormalCookware.FoodId);
                if (holdSuccess)
                {
                    //成功抓取.拿走食物.如果手上没有空间则不允许玩家拿走食物
                    mNormalCookware.TakeFood();
                }
            }
            else if(mIngredient != null)
            {
                //直接拿食材,因为食材是不会消耗的所以随便拿.
                mController.HandProvider.Hold(mIngredient.FoodId);
            }
        }

        public bool Update()
        {
            return true;
        }
    }
}
