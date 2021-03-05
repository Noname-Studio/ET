
using System.Collections.Generic;

namespace Kitchen
{
    public class PutIngredientToCookware : IGameAction
    {
        private PlayerController mController;
        private NormalCookware mTarget;
        public PutIngredientToCookware(PlayerController controller,NormalCookware target)
        {
            mController = controller;
            mTarget = target;
        }
    
        public void Execute()
        {
            List<string> list = new List<string>();
            mController.HandProvider.Get(ref list);
            list = mTarget.PutIn(list);
            //发现不需要放入任何东西了.我们直接开始厨具工作就好了
            if (list == null)
            {
                mTarget.DoWork();
            }
            else
            {
                //发现手上的东西需要放到厨具上.我们放进去
                mController.HandProvider.Take(list);
                //检查是否可以工作.然后开始工作
                mTarget.DoWork();
            }
        }

        bool IGameAction.Update()
        {
            return true;
        }
    }

}
