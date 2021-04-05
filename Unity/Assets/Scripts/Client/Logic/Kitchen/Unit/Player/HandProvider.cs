using System;
using System.Collections.Generic;

namespace Kitchen
{
    public class HandProvider
    {
        /// <summary>
        /// 手得集合.
        /// 将来我们可能会设计一些不同程度得助手.
        /// 这些助手有可能只能使用一只手进行操作食材.
        /// </summary>
        private Dictionary<string, PlayerTray> HandCollection = new Dictionary<string, PlayerTray>();

        /// <summary>
        /// 添加一只可操作托盘得手或者可操作厨具得手
        /// </summary>
        /// <param name="key">标记</param>
        /// <param name="trayObj">托盘路径</param>
        public void AddHand(string key, UnityObject trayObj)
        {
            HandCollection[key] = new PlayerTray(trayObj);
        }

        /// <summary>
        /// 清空玩家手上指定Key的食物
        /// </summary>
        public void Remove(string key)
        {
            foreach (var node in HandCollection)
            {
                var value = node.Value;
                if (value.Item == key)
                {
                    value.Take();
                }
            }
        }

        /// <summary>
        /// 清空玩家手上的所有食物
        /// </summary>
        public void Clear()
        {
            foreach (var node in HandCollection)
            {
                var value = node.Value;
                value.Take();
            }
        }

        /// <summary>
        /// 得到玩家手上拿的所有食物
        /// 这个方法经常会被调用.所以我们这里传参需要传入一个List处理.这样可以大量避免GC
        /// </summary>
        /// <returns></returns>
        public void Get(ref List<string> list)
        {
            if (list == null)
            {
                list = new List<string>();
            }

            list.Clear();
            foreach (var node in HandCollection)
            {
                if (node.Value.Item != null)
                {
                    list.Add(node.Value.Item);
                }
            }
        }

        /// <summary>
        /// 手上是否有空闲得位置
        /// </summary>
        /// <returns></returns>
        public bool HasFreeSpace()
        {
            foreach (var node in HandCollection)
            {
                if (node.Value.Item == null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 从手上拿走食物,传入List,如果同时匹配左右手则全部拿走
        /// </summary>
        /// <param name="list"></param>
        public void Take(List<string> list)
        {
            if (list == null)
            {
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                Take(list[i]);
            }
        }

        /// <summary>
        /// 从手上拿走食物
        /// </summary>
        /// <param name="list"></param>
        public void Take(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            //如果找到了食物.就把后面得食物往前面顶
            PlayerTray swap = null;
            foreach (var node in HandCollection)
            {
                var value = node.Value;
                if (swap == null)
                {
                    if (value.Item == key)
                    {
                        value.Take();
                        swap = value;
                    }
                }
                else
                {
                    string item = value.Take();
                    if (string.IsNullOrEmpty(item))
                    {
                        break;
                    }

                    swap.Hold(item);
                    swap = value;
                }
            }
        }

        /// <summary>
        /// 手上是否有对应得食材或食物
        /// </summary>
        /// <returns></returns>
        public bool HasHold(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            foreach (var node in HandCollection)
            {
                if (node.Value.Item == id)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 拿取食物
        /// </summary>
        /// <param name="id"></param>
        public bool Hold(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            foreach (var node in HandCollection)
            {
                var value = node.Value;
                if (value.Item == null)
                {
                    value.Hold(id);
                    return true;
                }
            }

            //TODO 播放操作失败得音效
            return false;
        }

        public void Dispose()
        {
            foreach (var node in HandCollection)
            {
                node.Value.Dispose();
            }
        }

        public void Update()
        {
            foreach (var node in HandCollection)
            {
                node.Value.Update();
            }
        }
    }
}