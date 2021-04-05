using System.Collections.Generic;

namespace GamingUI
{
    public partial class View_TipBar
    {
        public View_TipBar Left(List<string> left)
        {
            if (left.Count == 0)
            {
                Log.Error("菜品数量为0");
                return this;
            }

            var leftObj = (View_MultipleFood) List.AddItemFromPool();
            int count = left.Count - 1;
            for (int i = 0; i < left.Count; i++)
            {
                if (string.IsNullOrEmpty(left[i]))
                {
                    Log.Error("传入空的Icon路径");
                    count--;
                    continue;
                }

                leftObj.GetChild("n" + i).asLoader.url = left[i];
            }

            leftObj.c1.selectedIndex = count;
            return this;
        }

        public View_TipBar Left(string left)
        {
            if (string.IsNullOrEmpty(left))
            {
                Log.Error("菜品Icon为空");
                return this;
            }

            var obj = (View_MultipleFood) List.AddItemFromPool();
            obj.c1.selectedIndex = 0;
            obj.GetChild("n" + 0).asLoader.url = left;
            return this;
        }

        public View_TipBar Right(string right)
        {
            if (string.IsNullOrEmpty(right))
            {
                Log.Error("菜品Icon为空");
                return this;
            }

            var rightObj = (View_MultipleFood) List.AddItemFromPool();
            rightObj.c1.selectedIndex = 0;
            rightObj.GetChild("n" + 0).asLoader.url = right;
            return this;
        }

        /// <summary>
        /// left和right传入icon路径. 
        /// </summary>
        /// <returns></returns>
        public View_TipBar Plus(List<string> left, string right)
        {
            Left(left);
            Plus();
            Right(right);
            return this;
        }

        public View_TipBar Equal(string right)
        {
            Equal();
            Right(right);
            return this;
        }

        public View_TipBar To(string left, string right)
        {
            Left(left);
            To();
            Right(right);
            return this;
        }

        public View_TipBar Plus()
        {
            List.AddItemFromPool("ui://GamingUI/Plus");
            return this;
        }

        public View_TipBar Equal()
        {
            List.AddItemFromPool("ui://GamingUI/Equal");
            return this;
        }

        public View_TipBar Slash()
        {
            List.AddItemFromPool("ui://GamingUI/Slash");
            return this;
        }

        public View_TipBar To()
        {
            List.AddItemFromPool("ui://GamingUI/To");
            return this;
        }

        public void RemoveAll()
        {
            List.RemoveChildrenToPool();
        }
    }
}